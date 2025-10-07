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
    public class TransactionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        public static List<TransactionDTO> GetAll()
        {
            var data = DataAccessFactory.TransactionData().GetAll();
            return GetMapper().Map<List<TransactionDTO>>(data);
        }

        public static TransactionDTO GetById(int id)
        {
            var data = DataAccessFactory.TransactionData().Get(id);
            return GetMapper().Map<TransactionDTO>(data);
        }

        public static bool Create(TransactionDTO transaction)
        {
            var data = GetMapper().Map<Transaction>(transaction);
            return DataAccessFactory.TransactionData().Create(data);
        }

        public static bool Update(TransactionDTO transaction)
        {
            var data = GetMapper().Map<Transaction>(transaction);
            return DataAccessFactory.TransactionData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TransactionData().Delete(id);
        }
    }
}
