using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VedasPortal.Entities.Models.Base;

namespace VedasPortal.Repository.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        int Add(T item);
        void AddRange(IEnumerable<T> items);
        int Count();
        T Get(int Id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        void Remove(int Id);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
    }
}