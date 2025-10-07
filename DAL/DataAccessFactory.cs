using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Supplier, int, bool> SupplierData() 
        { 
            return new SupplierRepo(); 
        }

        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }
        public static IProductFeature ProductFeature()
        {
            return new ProductRepo();
        }

        public static IRepo<Transaction, int, bool> TransactionData()
        {
            return new TransactionRepo();
        }

        public static IRepo<Notification, int, bool> NotificationData()
        {
            return new NotificationRepo();
        }
        public static INotificationFeature NotificationFeature()
        {
            return new NotificationRepo();
        }
    }
}
