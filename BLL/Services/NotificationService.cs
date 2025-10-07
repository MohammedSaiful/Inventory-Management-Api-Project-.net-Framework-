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
    public class NotificationService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification, NotificationDTO>();
            });
            return new Mapper(config);
        }

        public static List<NotificationDTO> GetAll()
        {
            var data = DataAccessFactory.NotificationData().GetAll();
            return GetMapper().Map<List<NotificationDTO>>(data);
        }

        public static NotificationDTO GetById(int id)
        {
            var data = DataAccessFactory.NotificationData().Get(id);
            return GetMapper().Map<NotificationDTO>(data);
        }

        public static bool Create(NotificationDTO notification)
        {
            var data = GetMapper().Map<Notification>(notification);
            return DataAccessFactory.NotificationData().Create(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.NotificationData().Delete(id);
        }


        public static bool LowNotification(ProductDTO product, int threshold)
        {
            var data = GetMapper().Map<Product>(product);
            return DataAccessFactory.NotificationFeature().LowStockNotification(data, threshold);
        }

        public static bool ExpireNotification(ProductDTO product)
        {
            var data = GetMapper().Map<Product>(product);
            return DataAccessFactory.NotificationFeature().ExpireNotification(data);
        }

    }
}
