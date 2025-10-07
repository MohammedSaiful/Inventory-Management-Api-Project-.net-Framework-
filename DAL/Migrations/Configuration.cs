namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.AllContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.AllContext context)
        {
            var rndm = new Random();
            string[] types = { "admin", "staff" };

            for (int i = 1; i < 11; i++)
            {
                string RandomType = types[rndm.Next(2)];

                context.Users.AddOrUpdate(new Models.User 
                { 
                    Uname = "User-"+i,
                    Name = Guid.NewGuid().ToString().Substring(0,15),
                    Password = Guid.NewGuid().ToString().Substring(0,10),
                    Type = RandomType,
                });
            }
            context.SaveChanges();

            for (int i = 1; i < 11; i++)
            { 
                context.Suppliers.AddOrUpdate(new Models.Supplier
                {
                    
                    Name="Company-"+i,
                    Email = "company"+i+"@gmail.com"

                });
            }
            context.SaveChanges();

            string[] categories = { "Electronics", "Clothing", "Books", "Toys", "Furniture", "Sports", "Beauty", "Groceries"};
            for (int i = 0; i < 8; i++)
            {
                float pr = (float)rndm.Next(1, 101);
                int qnty = rndm.Next(10, 101);
                context.Products.AddOrUpdate(new Models.Product
                {
                    
                    Name="Product-"+i,
                    Category=categories[i],
                    Quantity= qnty,
                    UnitPrice= pr,
                    TotalPrice = qnty * pr,
                    EntryDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMonths(6),
                    SupplierId=rndm.Next(1,9),

                });
            }
            context.SaveChanges();

            string[] Ttype = { "IN", "OUT" };
            for (int i = 1; i < 6; i++)
            {
                context.Transactions.AddOrUpdate(new Models.Transaction
                {
                    
                    ProductId = rndm.Next(1, 8),
                    UserName = "User-" + rndm.Next(1,10),
                    Tran_Qty=rndm.Next(1,10),
                    Tran_Date=DateTime.Now,
                    Tran_Type= Ttype[rndm.Next(2)]

                });
            }
            context.SaveChanges();
        }
    }
}
