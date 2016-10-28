using ND.DistributedCache.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace A2DFramework.SessionService
{
    public class MongoDBCachePartitionResolver : IPartitionResolver
    {
        public void Initialize()
        {
        }
        /// <summary>
        /// 找到所在机子的连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ResolvePartition(object key)
        {
            string cacheId = (string)key;
            string prefix;
            string realId;

            if (!DistributedCacheHelper.ParseCacheID(cacheId, out prefix, out realId))
                return string.Empty;

            return MongoDBCacheConfiguration.CacheIdentityDBMap[prefix];
        }
    }
}
