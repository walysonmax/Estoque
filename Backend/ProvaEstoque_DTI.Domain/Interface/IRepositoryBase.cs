using ProvaEstoque_DTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaEstoque_DTI.Domain.Interface
{

    public interface IRepositoryBase<T>
   where T : EntityBase
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task Update(T entity);

        Task Delete(int id);

        Task Delete(T entidade);


    }

}
