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

        public static TokenDTO Authenticate(string username, string password)
        {
            var result= DataAccessFactory.AuthenData().GetAuthen(username, password);
            if(result)
            {
                var token = new Token();
                token.UserId = username;
                token.CreatedAt = DateTime.Now;
                token.TokenKey = Guid.NewGuid().ToString();

                var ret = DataAccessFactory.TokenData().Create(token);

                if(ret != null)
                {
                    return GetMapper().Map<TokenDTO>(ret);
                }
            }
            return null;
        }

        // during logout updating the token delete time the update the token, update is okey the true
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
        public static bool ValidateToken(string tokenKey)
        {
            var ExistToken = DataAccessFactory.TokenData().Get(tokenKey);
            if(ExistToken != null && ExistToken.DeletedAt == null)
            {
                return true;
            }
            // if logged in more than 20 mins, token will expire and auto logout
            if(DateTime.Now > ExistToken.CreatedAt.AddMinutes(20))
            {
                Logout(tokenKey);
            }
            return false;
        }

    }
}
