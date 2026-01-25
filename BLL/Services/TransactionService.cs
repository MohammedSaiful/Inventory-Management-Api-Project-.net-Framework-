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
            var product = DataAccessFactory.ProductData().Get(transaction.ProductId);
            if (product == null) return false;

            var productDTO = GetMapper().Map<ProductDTO>(product);

            // Apply stock change
            if (transaction.Tran_Type == "IN")
                productDTO.Quantity += transaction.Tran_Qty;
            else
                productDTO.Quantity -= transaction.Tran_Qty;

            // Prevent negative stock
            if (productDTO.Quantity < 0)
                return NotificationService.LowNotification(productDTO);

            // Save updated stock
            ProductService.Update(productDTO);

            // Save transaction record
            transaction.Tran_Date = DateTime.Now;
            var tran = GetMapper().Map<Transaction>(transaction);


            var res = DataAccessFactory.TransactionData().Create(tran);

            if (res)
            {
                //  Trigger Low Stock Check (Threshold = 5)
                NotificationService.LowNotification(GetMapper().Map<ProductDTO>(product));
            }
            return res;
        }

        public static bool Update(TransactionDTO transaction)
        {
            var oldTran = DataAccessFactory.TransactionData().Get(transaction.Id);
            if (oldTran == null) return false;

            var product = DataAccessFactory.ProductData().Get(transaction.ProductId);
            if (product == null) return false;

            var productDTO = GetMapper().Map<ProductDTO>(product);

            // Reverse old transaction
            if (oldTran.Tran_Type == "IN")
                productDTO.Quantity -= oldTran.Tran_Qty;
            else
                productDTO.Quantity += oldTran.Tran_Qty;

            //  Apply new transaction
            if (transaction.Tran_Type == "IN")
                productDTO.Quantity += transaction.Tran_Qty;
            else
                productDTO.Quantity -= transaction.Tran_Qty;

            // Prevent negative stock
            if (productDTO.Quantity < 0)
                return false;

            // Save updated product stock
            ProductService.Update(productDTO);

            // Update transaction record
            var tran = GetMapper().Map<Transaction>(transaction);
            return DataAccessFactory.TransactionData().Update(tran);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TransactionData().Delete(id);
        }


        public static List<TransactionDTO> GetByUser(string username)
        {
            var data = DataAccessFactory.TransactionFeature().GetUser(username);
            return GetMapper().Map<List<TransactionDTO>>(data);
        }

        public static List<TransactionDTO> GetByProduct(int productId)
        {
            var data = DataAccessFactory.TransactionFeature().GetProduct(productId);
            return GetMapper().Map<List<TransactionDTO>>(data);
        }

        public static List<TransactionDTO> GetByType(string type)
        {
            var data = DataAccessFactory.TransactionFeature().GetType(type);
            return GetMapper().Map<List<TransactionDTO>>(data);
        }

        public static int GetCurrentStock(int productId)
        {
            return DataAccessFactory.TransactionFeature().GetTotalStock(productId);
        }
    }
}
