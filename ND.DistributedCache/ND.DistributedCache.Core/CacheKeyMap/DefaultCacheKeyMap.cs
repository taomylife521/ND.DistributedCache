using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：DefaultCacheKeyMap.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/19 14:46:23         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/19 14:46:23          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.CacheKeyMap
{
    /// <summary>
    /// 内存集合
    /// </summary>
    public class DefaultCacheKeyMap:CacheKeyMapBase
    {
        private ConcurrentBag<CacheKeyMapDescriptor> mapList = new ConcurrentBag<CacheKeyMapDescriptor>();

        /// <summary>
        /// 获取cacheKeyMap映射
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override CacheKeyMapDescriptor GetCacheKeyMap(string key)
        {
            return mapList.FirstOrDefault(x => x.CacheKey == key);
        }

        /// <summary>
        /// 添加cachekeyap映射
        /// </summary>
        /// <param name="request"></param>
        public override void AddCacheKeyMap(CacheKeyMapDescriptor request)
        {
           var item= mapList.ToList().Where(x => x.CacheKey == request.CacheKey).ToList();
          item.ForEach(x=>{
              DeleteCacheKeyMap(x);
          });
              
           
            mapList.Add(request);
        }

        /// <summary>
        /// 删除cacheKeyMap映射
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override bool DeleteCacheKeyMap(CacheKeyMapDescriptor request)
        {
           return mapList.TryTake(out request);
        }


        /// <summary>
        /// 根据过期条件删除映射对象
        /// </summary>
        /// <param name="cacheExpire"></param>
        /// <returns></returns>
        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire)
        {
            try
            {
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        mapList.ToList().ForEach(x => {
                            DeleteCacheKeyMap(x);
                        });
                        break;
                    case CacheExpire.Expired:
                        mapList.ToList().Where(x => x.ExpireDate <= DateTime.Now).ToList().ForEach(x => {
                            DeleteCacheKeyMap(x);
                        });
                        break;
                    case CacheExpire.NoExpired:
                        mapList.ToList().Where(x => x.ExpireDate > DateTime.Now).ToList().ForEach(x => {
                            DeleteCacheKeyMap(x);
                        });
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据过期条件和时间来删除映射对象
        /// </summary>
        /// <param name="cacheExpire"></param>
        /// <param name="dateType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            try
            {
                startDate = Convert.ToDateTime(startDate.ToString("yyyy-MM-dd") + " 0:00:00");
                endDate = Convert.ToDateTime(endDate.ToString("yyyy-MM-dd") + " 23:59:59");
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        {
                            if (dateType == DateType.CreateTime) mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            else mapList.ToList().Where(x => x.ExpireDate >= startDate && x.CreateTime <= endDate).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                        }
                        break;
                    case CacheExpire.Expired:
                        {
                            if (dateType == DateType.CreateTime) mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate && x.ExpireDate <= DateTime.Now).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            else mapList.ToList().Where(x => x.ExpireDate >= startDate && x.CreateTime <= endDate && x.ExpireDate <= DateTime.Now).ToList().ForEach(x => { DeleteCacheKeyMap(x); });  
                        }
                        break;
                    case CacheExpire.NoExpired:
                        {
                            if (dateType == DateType.CreateTime) mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate && x.ExpireDate > DateTime.Now).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            else mapList.ToList().Where(x => x.ExpireDate >= startDate && x.CreateTime <= endDate && x.ExpireDate > DateTime.Now).ToList().ForEach(x => { DeleteCacheKeyMap(x); });  
                        
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 获取映射集合
        /// </summary>
        /// <param name="cacheExpire"></param>
        /// <returns></returns>
        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();
            try
            {
               
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        lstMap= mapList.ToList();
                        break;
                    case CacheExpire.Expired:
                        lstMap= mapList.ToList().Where(x => x.ExpireDate <= DateTime.Now).ToList();
                        break;
                    case CacheExpire.NoExpired:
                        lstMap = mapList.ToList().Where(x => x.ExpireDate > DateTime.Now).ToList();
                        break;
                    default:
                        break;
                }
                return lstMap;
            }
            catch (Exception ex)
            {
                return lstMap;
            }
        }


        /// <summary>
        /// 根据时间获取映射集合
        /// </summary>
        /// <param name="cacheExpire"></param>
        /// <param name="dateType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();
            try
            {

                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        {
                            if (dateType == DateType.CreateTime) lstMap = mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate).ToList();
                            else if (dateType == DateType.ExpireTime) lstMap = mapList.ToList().Where(x => x.ExpireDate >= startDate && x.ExpireDate <= endDate).ToList();
                            else lstMap = mapList.ToList();
                        }
                        break;
                    case CacheExpire.Expired:
                        {
                            if (dateType == DateType.CreateTime) lstMap = mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate && x.ExpireDate <= DateTime.Now).ToList();
                            else if (dateType == DateType.ExpireTime) lstMap = mapList.ToList().Where(x => x.ExpireDate >= startDate && x.ExpireDate <= endDate &&  x.ExpireDate <= DateTime.Now).ToList();
                            else lstMap = mapList.ToList().Where(x=>x.ExpireDate <= DateTime.Now).ToList();
                        }
                        break;
                    case CacheExpire.NoExpired:
                        {
                            if (dateType == DateType.CreateTime) lstMap = mapList.ToList().Where(x => x.CreateTime >= startDate && x.CreateTime <= endDate && x.ExpireDate > DateTime.Now).ToList();
                            else if (dateType == DateType.ExpireTime) lstMap = mapList.ToList().Where(x => x.ExpireDate >= startDate && x.ExpireDate <= endDate && x.ExpireDate > DateTime.Now).ToList();
                            else lstMap = mapList.ToList().Where(x => x.ExpireDate > DateTime.Now).ToList();
                        }
                        break;
                    default:
                        break;
                }
                return lstMap;
            }
            catch (Exception ex)
            {
                return lstMap;
            }
        }

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(Cachelimit cacheLimit, DateTime? startDate, DateTime? endDate)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();
            try
            {
                if (cacheLimit == Cachelimit.ByExpireDate)
                {
                    lstMap = mapList.ToList().Where(x => x.Cachelimit == cacheLimit && x.ExpireDate == startDate && x.ExpireDate == endDate).ToList();
                }
                else
                {
                    lstMap = mapList.ToList().Where(x => x.Cachelimit == cacheLimit).ToList();
                }
                return lstMap;
            }
            catch(Exception ex)
            {
                return lstMap;
            }
        }
    }
}
