using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheKeyMapManger.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/19 15:23:36         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/19 15:23:36          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.CacheKeyMap
{
   public class CacheKeyMapManger:CacheKeyMapBase
    {

        private static CacheKeyMapManger _instance = null;
        private ICacheKeyMap _cacheKeyMap;
        public ICacheKeyMap CacheKeyMap { get { return _cacheKeyMap; } }
        public static CacheKeyMapManger Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }
        private CacheKeyMapManger()
        {
            
            _cacheKeyMap = new MongoDBCacheKeyMap();
        }

        static CacheKeyMapManger()
        {
            _instance = new CacheKeyMapManger();
        }

        public override CacheKeyMapDescriptor GetCacheKeyMap(string key)
        {
           return _cacheKeyMap.GetCacheKeyMap(key);
        }

        public override List<CacheKeyMapDescriptor> GetCacheKeyMap(List<string> keys)
        {
            return _cacheKeyMap.GetCacheKeyMap(keys);
        }

        public override void AddCacheKeyMap(CacheKeyMapDescriptor request)
        {
            _cacheKeyMap.AddCacheKeyMap(request);
        }

        public override void AddCacheKeyMap(List<CacheKeyMapDescriptor> requestList)
        {
            _cacheKeyMap.AddCacheKeyMap(requestList);
        }

        public override void AddCacheKeyMap(string cacheKey, string cacheId)
        {
            _cacheKeyMap.AddCacheKeyMap(cacheKey, cacheId);
        }

        public override void AddCacheKeyMap(string cacheKey, string cacheId, DateTime expireDate)
        {
            _cacheKeyMap.AddCacheKeyMap(cacheKey, cacheId, expireDate);
        }

        public override bool DeleteCacheKeyMap(CacheKeyMapDescriptor request)
        {
            return _cacheKeyMap.DeleteCacheKeyMap(request);
        }

        public override bool DeleteCacheKeyMap(string key)
        {
            return _cacheKeyMap.DeleteCacheKeyMap(key);
        }

        public override bool DeleteCacheKeyMap(List<string> key)
        {
            return _cacheKeyMap.DeleteCacheKeyMap(key);
        }

        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire)
        {
            return _cacheKeyMap.DeleteCacheKeyMap(cacheExpire);
        }

        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            return _cacheKeyMap.DeleteCacheKeyMap(cacheExpire, dateType, startDate, endDate);
        }

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire)
        {
            return _cacheKeyMap.GetCacheKeyMapList(cacheExpire);
        }

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            return _cacheKeyMap.GetCacheKeyMapList(cacheExpire, dateType, startDate, endDate);
        }

        public override void AddCacheKeyMap(string cacheKey, string cacheId, DateTime? expireDate, Cachelimit cacheLimit)
        {
             _cacheKeyMap.AddCacheKeyMap(cacheKey,cacheId,expireDate,cacheLimit);
        }

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(Cachelimit cacheLimit, DateTime? startDate, DateTime? endDate)
        {
            return _cacheKeyMap.GetCacheKeyMapList(cacheLimit, startDate, endDate);
        }
    }
}
