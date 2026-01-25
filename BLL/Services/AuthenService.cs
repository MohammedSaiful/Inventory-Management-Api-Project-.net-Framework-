using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthenService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>();
            });
            return new Mapper(config);
        }

        //public static TokenDTO Authenticate(string username, string password)
        //{
        //    var result= DataAccessFactory.AuthenData().GetAuthen(username, password);
        //    if(result)
        //    {
        //        var user =DataAccessFactory.UserData().Get(username);

        //        var token = new Token();
        //        token.UserId = username;
        //        token.UserType =user.Type;
        //        token.CreatedAt = DateTime.Now; 
        //        token.TokenKey = Guid.NewGuid().ToString();

        //        var ret = DataAccessFactory.TokenData().Create(token);

        //        if(ret != null)
        //        {
        //            return GetMapper().Map<TokenDTO>(ret);
        //        }
        //    }
        //    return null;
        //}


        public static object Authenticate(string username, string password)
        {
            var result = DataAccessFactory.AuthenData().GetAuthen(username, password);
            if (result)
            {
                var user = DataAccessFactory.UserData().Get(username);
                var jwt = JwtService.GenerateToken(user.Uname, user.Type);
                var rf = Guid.NewGuid().ToString();

                var token = new Token
                {
                    UserId = username,
                    UserType = user.Type,
                    TokenKey = jwt,
                    RefreshToken = rf,
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddDays(7)
                };
                var ret = DataAccessFactory.TokenData().Create(token);

                if (ret != null)
                {
                    return new { AccessToken = jwt, RefreshToken = rf };
                }
            }
            return null;
        }


        public static object RefreshToken(string rfToken)
        {
            var allTokens = DataAccessFactory.TokenData().GetAll();
            // Search for the refresh token in the database
            var session = allTokens.FirstOrDefault(t => t.RefreshToken == rfToken && t.DeletedAt == null);

            // Check if session exists and if the Refresh Token itself is still valid (ExpiredAt from migration)
            if (session != null && session.ExpiredAt > DateTime.Now)
            {
                // Generate a brand new JWT
                var newJwt = JwtService.GenerateToken(session.UserId, session.UserType);

                // Update the record with the new Access Token (TokenKey)
                session.TokenKey = newJwt;
                session.CreatedAt = DateTime.Now;
                var updated = DataAccessFactory.TokenData().Update( session);

                if (updated != null)
                {
                    return new { AccessToken = newJwt };
                }
            }
            return null;
        }

        public static bool ValidateToken(string tokenKey)
        {
            var principal = JwtService.GetPrincipal(tokenKey);
            if (principal == null) return false;


            //  Extract the UserId from the JWT claims
            var userId = principal.Identity.Name;

            // Check the DB to see if THIS USER has an active (non-deleted) session
            // We search by UserId instead of the long TokenKey string
            var allTokens = DataAccessFactory.TokenData().GetAll();
            var session = allTokens.FirstOrDefault(t => t.UserId == userId && t.DeletedAt == null);

            //  Return true if the session exists in DB
            return (session != null);
        }


        // during logout updating the token delete time then update the token, update is okey then true
        public static bool Logout(string tokenKey)  
        {
            var ExistToken = DataAccessFactory.TokenData().Get(tokenKey);
            ExistToken.DeletedAt = DateTime.Now;
            
            if(DataAccessFactory.TokenData().Update(ExistToken) != null)
            {
                return true;
            }
            return false;
        }

        // token is valid or not
        //public static bool ValidateToken(string tokenKey)
        //{
        //    var ExistToken = DataAccessFactory.TokenData().Get(tokenKey);
        //    if(ExistToken != null && ExistToken.DeletedAt == null)
        //    {
        //        return true;
        //    }
        //    // if logged in more than 20 mins, token will expire and auto logout
        //    if(DateTime.Now > ExistToken.CreatedAt.AddMinutes(20))
        //    {
        //        Logout(tokenKey);
        //    }
        //    return false;
        //}

    }
}
