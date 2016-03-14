using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data.Redis
{
    /// <summary>
    /// Redis实体基类，所有redis实体类都应该集成它
    /// </summary>
    public abstract class RedisEntity
    {
        public RedisEntity()
        {
            RootID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Redis实体主键，方法查询，删除，更新等操作
        /// </summary>
        public virtual string RootID { get; set; }
    }
}
