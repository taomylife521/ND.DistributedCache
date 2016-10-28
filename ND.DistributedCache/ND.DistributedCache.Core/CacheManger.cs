using ND.DistributedCache.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheManger.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 11:35:00         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 11:35:00          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   public class CacheManger:CacheBase
    {
       
       
        private static CacheManger _instance = null;
     
        private static ICache _cache { get; set; }
        public static CacheManger Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }
       

        static CacheManger()
        {
            _cache = new MongoDBCache(); 
            Instance = new CacheManger();
        }

        public void RefreshCacheConfig()
        {
            _cache = new MongoDBCache();
           
        }
        //public override bool SetValue<T>(string key, T value, DateTime expireDate)
        //{
        //    return _cache.SetValue(key, value, expireDate);
        //}

        public override object GetValue(string key)
        {
            return _cache.GetValue(key);
        }

        public override bool TryGetValue<T>(string key, out T value)
        {
            return _cache.TryGetValue(key,out value);
        }

        public override bool DeleteValue(string key, bool isClearOtherExpire = false)
        {
            return _cache.DeleteValue(key, isClearOtherExpire);
        }
        public override bool SetValue<T>(string key, T value,  Cachelimit cacheLimit,DateTime? expireDate=null)
        {
            return _cache.SetValue<T>(key, value, cacheLimit, expireDate);
        }
    }
}
