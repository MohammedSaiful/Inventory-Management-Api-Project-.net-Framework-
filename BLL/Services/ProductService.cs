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
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();

                cfg.CreateMap<Product, ProductTransactionDTO>().ReverseMap();
                cfg.CreateMap<Transaction, TransactionDTO>().ReverseMap();

                cfg.CreateMap<Product, ProductNotifiactionDTO>().ReverseMap();
                cfg.CreateMap<Notification, NotificationDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<ProductDTO> GetAll()
        {
            var data = DataAccessFactory.ProductData().GetAll();
            return GetMapper().Map<List<ProductDTO>>(data);
        }

        public static ProductDTO GetById(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            return GetMapper().Map<ProductDTO>(data);
        }

        public static bool Create(ProductDTO product)
        {
            product.TotalPrice = product.Quantity * product.UnitPrice;
            product.EntryDate = DateTime.Now;
            product.ExpiryDate = DateTime.Now.AddMonths(6);

            var  data = GetMapper().Map<Product>(product);
            return DataAccessFactory.ProductData().Create(data);
        }

        public static bool Update(ProductDTO product)
        {
            product.TotalPrice = product.Quantity * product.UnitPrice;

            var data =GetMapper().Map<Product>(product);
            return DataAccessFactory.ProductData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }


        public static List<ProductDTO> GetCategory(string category)
        {
            var data = DataAccessFactory.ProductFeature().GetCategory(category);
            return GetMapper().Map<List<ProductDTO>>(data);
        }

        public static List<ProductDTO> GetLowStock(int id)
        {
            var data = DataAccessFactory.ProductFeature().GetLowStock(id);
            return GetMapper().Map<List<ProductDTO>>(data);
        }

        public static List<ProductDTO> GetExpired()
        {
            var data = DataAccessFactory.ProductFeature().GetExpiredProducts();
            return GetMapper().Map<List<ProductDTO>>(data);
        }



        public static ProductTransactionDTO GetWithTransaction(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            return GetMapper().Map<ProductTransactionDTO>(data);
        }

        public static ProductNotifiactionDTO GetWithNotification(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            return GetMapper().Map<ProductNotifiactionDTO>(data);
        }
    }
}
