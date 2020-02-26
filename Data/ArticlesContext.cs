using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreWorkShop.Data
{
    public class ArticlesContext : DbContext
    {
        public ArticlesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./articles.db");
        }

    }
}
