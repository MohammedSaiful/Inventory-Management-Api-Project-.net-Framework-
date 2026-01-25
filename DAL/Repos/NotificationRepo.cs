using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, IRepo<Notification, int, bool>, INotificationFeature
    {
        public bool Create(Notification obj)
        {
            db.Notifications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public List<Notification> GetAll()
        {
            return db.Notifications.ToList();
        }

        public bool Update(Notification obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool LowStockNotification(Product product, int threshold)
        {
            if (product.Quantity < threshold)
            {
                // Check if a notification already exists for today to avoid spamming
                var alreadyNotified = db.Notifications.Any(n => n.ProductId == product.Id &&
                                      DbFunctions.TruncateTime(n.N_Date) == DbFunctions.TruncateTime(DateTime.Now));

                if (!alreadyNotified)
                {
                    var notify = new Notification
                    {
                        Massage = $"{product.Name} is running low! Current stock: {product.Quantity}",
                        ProductId = product.Id,
                        N_Date = DateTime.Now
                    };
                    db.Notifications.Add(notify);
                    return db.SaveChanges() > 0;
                }
            }
            return false;
        }
        public bool ExpireNotification(Product product)
        {
            if (product.ExpiryDate < DateTime.Now)
            {
                var note = new Notification
                {
                    Massage = product.Name + " expired on " + product.ExpiryDate.ToShortDateString(),
                    N_Date= DateTime.Now,
                    ProductId = product.Id
                };
                db.Notifications.Add(note);
                return db.SaveChanges()>0;
            }
            return false;
        }

    }
}
