using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheKeyMapBase.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/19 14:43:47         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/19 14:43:47          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.CacheKeyMap
{
    public abstract class CacheKeyMapBase:ICacheKeyMap
    {
        public abstract CacheKeyMapDescriptor GetCacheKeyMap(string key);


        public virtual List<CacheKeyMapDescriptor> GetCacheKeyMap(List<string> keys)
        {
            List<CacheKeyMapDescriptor> lst = new List<CacheKeyMapDescriptor>();
            keys.ForEach(x =>
            {
                CacheKeyMapDescriptor keymap = GetCacheKeyMap(x);
                if (keymap != null)
                {
                    lst.Add(keymap);
                }
            });
            return lst;
        }


        public abstract void AddCacheKeyMap(CacheKeyMapDescriptor request);


        public virtual void AddCacheKeyMap(List<CacheKeyMapDescriptor> requestList)
        {
            requestList.ForEach(x =>
            {
                AddCacheKeyMap(x);
            });
        }


        public virtual void AddCacheKeyMap(string cacheKey, string cacheId)
        {
            AddCacheKeyMap(cacheKey, cacheId, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")+" 23:59:59"),Cachelimit.CurrentDay);
        }

        public virtual void AddCacheKeyMap(string cacheKey, string cacheId, DateTime expireDate)
        {
            AddCacheKeyMap(new CacheKeyMapDescriptor()
            {
                CacheKey = cacheKey,
                CacheId = cacheId,
                CacheSta = CacheStatus.Effective, 
                ExpireDate = expireDate
            });
        }
      


        public abstract bool DeleteCacheKeyMap(CacheKeyMapDescriptor request);


        public virtual bool DeleteCacheKeyMap(string key)
        {
            return DeleteCacheKeyMap(GetCacheKeyMap(key));
        }


        public virtual bool DeleteCacheKeyMap(List<string> key)
        {
            bool flag = true;
            key.ForEach(x =>
            {
                if (!DeleteCacheKeyMap(x))
                {
                    flag = false;
                }
            });
            return flag;
        }


        public abstract bool DeleteCacheKeyMap(CacheExpire cacheExpire);


        public abstract bool DeleteCacheKeyMap(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate);







        public abstract List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire);


        public abstract List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate);



        public virtual void AddCacheKeyMap(string cacheKey, string cacheId, DateTime? expireDate, Cachelimit cacheLimit)
        {
            DateTime dt = DateTime.Now;
            switch (cacheLimit)
            {
                case Cachelimit.ByExpireDate:
                    dt = Convert.ToDateTime(expireDate);
                    break;
                case Cachelimit.CurrentDay:
                    dt = Convert.ToDateTime(dt.ToString("yyyy-MM-dd") + " 23:59:59");
                    break;
                case Cachelimit.Forever:
                    dt = Convert.ToDateTime("2099-12-30");
                    break;
                default:
                    break;
            }
            AddCacheKeyMap(new CacheKeyMapDescriptor()
            {
                CacheId = cacheId,
                CacheKey = cacheKey,
                Cachelimit = cacheLimit,
                CacheSta = CacheStatus.Effective,
                ExpireDate = dt
            });
        }



       



        public abstract List<CacheKeyMapDescriptor> GetCacheKeyMapList(Cachelimit cacheLimit, DateTime? startDate, DateTime? endDate);
        
    }
}
