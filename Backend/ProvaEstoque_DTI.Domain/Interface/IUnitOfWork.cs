using ProvaEstoque_DTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaEstoque_DTI.Domain.Interface
{
    public  interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : EntityBase;

        Task Commit();

        void Dispose();
    }
}
