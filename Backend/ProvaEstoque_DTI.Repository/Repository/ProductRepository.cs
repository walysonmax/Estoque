using ProvaEstoque_DTI.Domain.Entity;
using ProvaEstoque_DTI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Repository.Repository
{
    public class ProductRepository: RepositoryBase<Product>
    {
        public ProductRepository(IDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
