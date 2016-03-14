using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.Data.Redis
{
    /// <summary>
    /// Redis事务管理机制
    /// </summary>
    public class RedisTransactionManager
    {
        /// <summary>
        /// 事务块处理
        /// </summary>
        /// <param name="redisClient">当前redis库</param>
        /// <param name="action">事务中的动作</param>
        public static void Transaction(IRedisClient redisClient, Action action)
        {
            using (IRedisTransaction IRT = redisClient.CreateTransaction())
            {
                try
                {
                    action();
                    IRT.Commit();
                }
                catch (Exception)
                {
                    IRT.Rollback();
                }
            }
        }
        /// <summary>
        /// 事务块处理
        /// </summary>
        /// <param name="redisClient">当前redis库</param>
        /// <param name="redisAction">Redis事务中的动作</param>
        /// <param name="sqlAction">Sql事务中的动作</param>
        public static void Transaction(IRedisClient redisClient, Action redisAction, Action sqlAction = null)
        {
            using (IRedisTransaction IRT = redisClient.CreateTransaction())
            {
                try
                {
                    redisAction();
                    if (sqlAction != null)
                    {
                        using (var trans = new TransactionScope())
                        {
                            sqlAction();
                            trans.Complete();
                        }
                    }
                    IRT.Commit();
                }
                catch (Exception)
                {
                    IRT.Rollback();
                }
            }
        }

    }
}
