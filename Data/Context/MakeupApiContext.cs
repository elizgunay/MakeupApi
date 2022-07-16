using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MakeupApiContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
     


        public MakeupApiContext() : base(@"Server=localhost;Database=MakeupApiDB;Trusted_Connection=True;")
        {
        }

      
    }
}
