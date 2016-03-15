using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data.Redis.Repository
{
    /// <summary>
    /// Redis仓储实现
    /// </summary>
    public class RedisRepository<TEntity> :
        IDisposable,
        IRepository<TEntity>
        where TEntity : RedisEntity
    {
        IRedisClient redisDB;
        IRedisTypedClient<TEntity> redisTypedClient;
        IRedisList<TEntity> table;

        

        public RedisRepository()
        {
            redisDB = RedisManager.GetClient();
            redisTypedClient = redisDB.As<TEntity>();
            table = redisTypedClient.Lists[typeof(TEntity).Name];
        }

        #region IRepository<TEntity>成员
        public void SetDbContext(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }
        public void SetDataContext(object db)
        {
            try
            {
                //手动Redis数据库对象,在redis事务时启用
                redisDB = (IRedisClient)db;
                redisTypedClient = redisDB.As<TEntity>();
                table = redisTypedClient.Lists[typeof(TEntity).Name];
            }
            catch (Exception)
            {

                throw new ArgumentException("redis.SetDataContext要求db为IRedisClient类型");
            }

        }
        public void Insert(TEntity item)
        {
            if (item != null)
            {
                redisTypedClient.AddItemToList(table, item);
                redisDB.Save();
            }

        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                var entity = Find(item.RootID);
                redisTypedClient.RemoveItemFromList(table, entity);
                redisDB.Save();
            }
        }

        public void Update(TEntity item)
        {
            if (item != null)
            {
                var old = Find(item.RootID);
                if (old != null)
                {
                    redisTypedClient.RemoveItemFromList(table, old);
                    redisTypedClient.AddItemToList(table, item);
                    redisDB.Save();
                }
            }
        }

        public IQueryable<TEntity> GetModel()
        {
            return table.GetAll().AsQueryable();
        }

        public TEntity Find(params object[] id)
        {
            return table.Where(i => i.RootID == (string)id[0]).FirstOrDefault();
        }
        #endregion

        #region IDisposable成员
        public void Dispose()
        {
            this.ExplicitDispose();
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Provides the facility that disposes the object in an explicit manner,
        /// preventing the Finalizer from being called after the object has been
        /// disposed explicitly.
        /// </summary>
        protected void ExplicitDispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)//清除非托管资源
            {
                table = null;
                redisTypedClient = null;
                redisDB.Dispose();
            }
        }
        #endregion

        #region Finalization Constructs
        /// <summary>
        /// Finalizes the object.
        /// </summary>
        ~RedisRepository()
        {
            this.Dispose(false);
        }
        #endregion
    }
}

