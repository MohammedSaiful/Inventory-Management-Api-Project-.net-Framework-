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
    public class UserService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => { 
              cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        public static List<UserDTO> GetAll()
        {
            var data = DataAccessFactory.UserData().GetAll();
            return GetMapper().Map<List<UserDTO>>(data);
        }

        public static UserDTO GetById(string uname)
        {
            var data = DataAccessFactory.UserData().Get(uname);
            return GetMapper().Map<UserDTO>(data);
        }

        public static UserDTO Create(UserDTO u)
        {
            var us = GetMapper().Map<User>(u);
            var user = DataAccessFactory.UserData().Create(us);
            return GetMapper().Map<UserDTO>(user);
        }


    }
}
