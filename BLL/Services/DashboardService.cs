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
    public class DashboardService
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

        public static DashboardDTO GetSummary()
        {
            var products = DataAccessFactory.ProductData().GetAll();
            var transToday = DataAccessFactory.TransactionData().GetAll()
                             .Where(t => t.Tran_Date.Date == DateTime.Now.Date).Count();

            return new DashboardDTO
            {
                TotalProducts = products.Count,
                TotalInventoryValue = products.Sum(p => p.Quantity * p.UnitPrice),
                LowStockCount = products.Where(p => p.Quantity < 10).Count(),
                TotalTransactionsToday = transToday
            };
        }

        //public static List<TransactionDTO> GetTop5Selling()
        //{
        //    var data = DataAccessFactory.TransactionFeature().GetTopSelling();

        //    // Grouping logic in BLL to keep the Repo return type as List<Transaction>
        //    var top5 = (from t in data
        //                group t by t.ProductId into g
        //                orderby g.Sum(x => x.Tran_Qty) descending
        //                select g.FirstOrDefault())
        //               .Take(5)
        //               .ToList();

        //    return GetMapper().Map<List<TransactionDTO>>(top5);
        //}
    }
}
