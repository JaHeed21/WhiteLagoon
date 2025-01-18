using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext { 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
     new Villa
     {
         Id = 1,
         Name = "Premium Deluxe",
         Description = "The Deluxe is very premium, it has premium service.",
         ImageUrl = "https://placehold.co/600x400",
         Occupancy = 4,
         Sqft = 800,
         Price = 1900,
     },
      new Villa
      {
          Id = 2,
          Name = "Premium Pool Villa",
          Description = "The Pool vila is very premium, it has premium service.",
          ImageUrl = "https://placehold.co/600x400",
          Occupancy = 3,
          Sqft = 650,
          Price = 1400,
      },
       new Villa
       {
           Id = 3,
           Name = "Premium Deluxe Suite",
           Description = "The Suite is  very premium, it has premium service.",
           ImageUrl = "https://placehold.co/600x400",
           Occupancy = 4,
           Sqft = 1600,
           Price = 3000,
       }
     );

        }



    }

    
}
