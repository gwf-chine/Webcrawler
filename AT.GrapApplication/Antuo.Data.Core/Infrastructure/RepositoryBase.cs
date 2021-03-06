﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Linq.Expressions;
using Antuo.Data;
using Antuo.Model;
using System.Data.Entity;

namespace Antuo.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private ATHouseContext dataContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get; private set;
        }

        protected ATHouseContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State =System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }
      
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
        public bool Exits(Expression<Func<T, bool>> where)
        {
            return dbset.Any(where);
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Any(predicate);
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0,
                                               int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null
                                ? dataContext.Set<T>().Where<T>(filter).AsQueryable()
                                : dataContext.Set<T>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
    }
}
