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
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
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
            var temp = DataAccessFactory.ProductData().Get(transaction.ProductId);
            var data1 = GetMapper().Map<ProductDTO>(temp);

            if (transaction.Tran_Type == "IN")
            {
                data1.Quantity = data1.Quantity +transaction.Tran_Qty;
               // temp.Quantity=temp.Quantity + transaction.Tran_Qty;
               // var data1 = GetMapper().Map<ProductDTO>(temp);
                ProductService.Update(data1);
               // temp.TotalPrice=temp.UnitPrice * temp.Quantity;
            }
            else
            {
                data1.Quantity = data1.Quantity - transaction.Tran_Qty;
                ProductService.Update(data1);
                //temp.Quantity = temp.Quantity - transaction.Tran_Qty;
                // temp.TotalPrice = temp.UnitPrice * temp.Quantity;
            }


            if (data1.Quantity > 0)
            {
                transaction.Tran_Date = DateTime.Now;
                var data = GetMapper().Map<Transaction>(transaction);
                return DataAccessFactory.TransactionData().Create(data);
            }
            else
            {
                return NotificationService.LowNotification(data1);
            }
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
