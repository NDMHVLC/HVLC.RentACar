using Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T,bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);



    }
}
