using System;
using System.Collections.Generic;
using System.Configuration;
using LiteDB;

namespace Slask.Database
{
    public class DbContext
    {
        private static string DbConnectionString
        {
            get
            {
                var db = ConfigurationManager.AppSettings["LiteDbConnectionString"];
                var path = Environment.GetEnvironmentVariable("TEMP");
                
                return $"{path}\\{db}";
            }
        }

        public LiteCollection<DbUser> Users
        {
            get
            {
                using (var db = new LiteDatabase(DbConnectionString))
                {
                    return db.GetCollection<DbUser>("users");
                }
            }
        }

        public LiteCollection<DbProduct> Products
        {
            get
            {
                using (var db = new LiteDatabase(DbConnectionString))
                {
                    return db.GetCollection<DbProduct>("products");
                }
            }
        }
        
        public DbContext()
        {
            using (var db = new LiteDatabase(DbConnectionString))
            {
                var userCollection = db.GetCollection<DbUser>("users");
                userCollection.Delete(Query.All());
                userCollection.InsertBulk(new List<DbUser>()
                {
                    new DbUser() {Id = Guid.NewGuid(), FirstName = "Bosse", LastName = "Bosson"},
                    new DbUser() {Id = Guid.NewGuid(), FirstName = "Lasse", LastName = "Larsson"},
                    new DbUser() {Id = Guid.NewGuid(), FirstName = "Hasse", LastName = "Hansson" }
                });

                var productsCollection = db.GetCollection<DbProduct>("products");
                productsCollection.Delete(Query.All());
                productsCollection.InsertBulk(new List<DbProduct>()
                {
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore VIC 20"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore 64"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore SX 64"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore 128"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore 65"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Commodore 64C"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 1000"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 500"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 2000"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga CDTV"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 500+"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 3000"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 1200"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga CD32"},
                    new DbProduct() {Id = Guid.NewGuid(), Name = "Amiga 4000"},
                });
            }
        }
    }
}
