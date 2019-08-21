using Microsoft.EntityFrameworkCore;
using ProvaEstoque_DTI.Domain.Entity;
using ProvaEstoque_DTI.Domain.Interface;
using ProvaEstoque_DTI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaEstoque_DTI.Repository.Repository
{

    public class RepositoryBase<T> : IRepositoryBase<T>
        where T: EntityBase
    {
        private readonly IDatabaseContext _dbContext;

        public RepositoryBase(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetByIdAsync(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task Delete(T entidade)
        {
            _dbContext.Set<T>().Remove(entidade);
        }



        public IQueryable<T> GetAll()
        {

            return _dbContext.Set<T>().AsNoTracking();

        }



        public virtual async Task<T> GetByIdAsync(int id)
        {

            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Identifier == id);
        }

        public async Task Update(T entity)
        {

            _dbContext.Set<T>().Update(entity);
        }

    }
}

