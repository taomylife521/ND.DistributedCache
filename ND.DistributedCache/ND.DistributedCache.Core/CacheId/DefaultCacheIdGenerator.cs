using ND.DistributedCache.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：DefaultCacheIdGenerator.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 11:49:33         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 11:49:33          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
    internal class DefaultCacheIdGenerator : ICacheIdGenerator
    {
        private Random rnd = new Random();
        private object oLock = new object();
        /// <summary>
        /// 生成cacheId, key对应机器标识 value为guid
        /// </summary>
        /// <returns></returns>
        public string GenerateCacheId()
        {
            int index = 0;
            lock (this.oLock)
            {
                index = rnd.Next(CacheConfigurationBase.CacheServerIdentities.Length);
            }
            string cacheId = string.Format("{0}.{1}", CacheConfigurationBase.CacheServerIdentities[index], Guid.NewGuid().ToString("N"));
            return cacheId;
          
        }
    }
}
