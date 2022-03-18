using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using VedasPortal.Data;
using VedasPortal.Entities.Models.Base;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly VedasDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(VedasDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }
        public T Get(int Id)
        {

            var res = dbSet.Find(Id);
            return res;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {

            //var query = context.Set<T>().Include(context.GetIncludePaths(typeof(T)));
            if (predicate != null)
                return context.Set<T>().Where(predicate);
            return context.Set<T>();

        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    dbSet.Remove(item);
                }
            }
            context.SaveChanges();
        }

        public int Add(T item)
        {
            if (item.Id == 0)
            {
                dbSet.Add(item);
            }
            else
            {
                dbSet.Update(item);
            }
            context.SaveChanges();
            return item.Id;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (item.Id == 0)
                {
                    dbSet.Add(item);
                }
                else
                {
                    dbSet.Update(item);
                }
            }

            context.SaveChanges();
        }


        public void Remove(int Id)
        {
            var item = dbSet.Find(Id);
            if (item != null)
            {
                dbSet.Remove(item);
                context.SaveChanges();
            }
        }

        public int Count()
        {
            return dbSet.Count();
        }
    }


}
