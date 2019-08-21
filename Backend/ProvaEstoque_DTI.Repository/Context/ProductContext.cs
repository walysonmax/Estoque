using Microsoft.EntityFrameworkCore;
using ProvaEstoque_DTI.Repository.MappingConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Repository.Context
{
    public class ProductContext: DbContext, IDatabaseContext
    {
        private readonly string _dbPath;

        public ProductContext()
        {

        }

        public ProductContext(string dbPath) : base()
        {
            _dbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());



            base.OnModelCreating(modelBuilder);
        }
    }
}
