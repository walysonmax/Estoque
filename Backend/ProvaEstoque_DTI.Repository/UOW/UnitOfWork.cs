using ProvaEstoque_DTI.Domain.Entity;
using ProvaEstoque_DTI.Domain.Interface;
using ProvaEstoque_DTI.Repository.Context;
using ProvaEstoque_DTI.Repository.Factory;
using ProvaEstoque_DTI.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaEstoque_DTI.Repository.UOW
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private IDatabaseContext context;


        public UnitOfWork(IContextFactory contextFactory)
        {
            context = contextFactory.DbContext;
        }

        private ProductRepository _productRepository;
        private ProductRepository ProductRepository
        {
            get
            {
                return this._productRepository ?? new ProductRepository(context);
            }
            set => _productRepository = value;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }





        public IRepositoryBase<T> Repository<T>() where T : EntityBase
        {
            switch (typeof(T).Name)
            {
                case nameof(Product):
                    return (IRepositoryBase<T>)ProductRepository;               
                default:
                    break;
            }
            return null;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }






    }
}
