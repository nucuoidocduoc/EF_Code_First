using Contracts;
using Entities.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _applicationContext;

        public RepositoryBase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(T entity) => _applicationContext.Set<T>().Add(entity);

        public void Create(T entity)
        {
        }

        public void Remove(T entity) => _applicationContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => _applicationContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _applicationContext.Set<T>().Where(expression);

        public void Update(T entity) => _applicationContext.Set<T>().Update(entity);
    }
}