using Microsoft.EntityFrameworkCore;
using ProvaEstoque_DTI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Repository.Factory
{
    public class ContextFactory : IContextFactory
    {


        private readonly string _dbPath;

        public ContextFactory(string dbPath)
        {
            this._dbPath = dbPath;
        }

        public IDatabaseContext DbContext => GetDataContext();

        private ProductContext GetDataContext()
        {
            ProductContext context = new ProductContext(_dbPath);
            context.Database.Migrate();
            return context;
        }

     
    }
}
