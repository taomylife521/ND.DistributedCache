using ND.DistributedCache.Core.CacheKeyMap;
using ND.DistributedCache.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheBase.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 16:33:21         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 16:33:21          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   public abstract class CacheBase:ICache
    {
       #region Event
        public static  event EventHandler<string> onOperating;

   

        /// <summary>
        /// 操作时
        /// </summary>
        /// <param name="e"></param>
        public void OnOperating(string e)
        {
            if (onOperating != null)
            {
                onOperating(this, e);
            }
        }

      
        #endregion

       #region Set
        public virtual bool SetValue(string key, object value)
        {
            return SetValue(key, value, Cachelimit.CurrentDay, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59"));
        }


        public virtual bool SetValue<T>(string key, T value) where T : class
       {
           return SetValue(key, value, Cachelimit.CurrentDay, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59"));
       }

       public abstract bool SetValue<T>(string key, T value,  Cachelimit cacheLimit,DateTime? expireDate) where T : class;

       bool ICache.SetValue(string key, object value, DateTime expireDate)
       {
           return SetValue(key, value, Cachelimit.ByExpireDate, expireDate);
       }


          bool ICache.SetValue<T>(string key, T value, DateTime expireDate) 
        {
            return SetValue(key, value, Cachelimit.ByExpireDate, expireDate);
        }

     

     
       

       #endregion

       #region Get
       public abstract object GetValue(string key);

       public virtual bool ContainsKey(string key)
       {
           return CacheKeyMapManger.Instance.GetCacheKeyMap(key) == null ? false : true;  
       }

       public virtual bool TryGetValue(string key, out object value)
       {
           return TryGetValue(key, out value);
       }

       public abstract bool TryGetValue<T>(string key, out T value);
       public virtual List<CacheKeyMapDescriptor> GetList(CacheExpire cacheExpire)
       {
           List<CacheEntityBase> lstEntity = new List<CacheEntityBase>();
           List<CacheKeyMapDescriptor> lstMapList = CacheKeyMapManger.Instance.GetCacheKeyMapList(cacheExpire);
           return lstMapList;
           //return GetEntityBaseByCacheKeyMapDescriptor(lstMapList);
       }

       public virtual List<CacheKeyMapDescriptor> GetList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
       {
           List<CacheEntityBase> lstEntity = new List<CacheEntityBase>();
           List<CacheKeyMapDescriptor> lstMapList = new List<CacheKeyMapDescriptor>();
           lstMapList = CacheKeyMapManger.Instance.GetCacheKeyMapList(cacheExpire, dateType, startDate, endDate);
           return lstMapList;
           //return GetEntityBaseByCacheKeyMapDescriptor(lstMapList);
       }
       #endregion

       #region Delete
       public abstract bool DeleteValue(string key, bool isClearOtherExpire = false);
      
       
       public virtual bool BulkDeleteValue(CacheExpire cacheExpire)
       {
           bool flag = true;
           List<CacheKeyMapDescriptor> lstMapList = CacheKeyMapManger.Instance.GetCacheKeyMapList(cacheExpire);
           lstMapList.ForEach(x =>
           {
               if (!DeleteValue(x.CacheKey,true))
               {
                   flag = false;
               }
           });
           return flag;
       }
       public virtual bool BulkDeleteValue(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
       {
           bool flag = true;
           List<CacheKeyMapDescriptor> lstMapList = CacheKeyMapManger.Instance.GetCacheKeyMapList(cacheExpire, dateType, startDate, endDate);
           lstMapList.ForEach(x =>
           {
               if (!DeleteValue(x.CacheKey,true))
               {
                   flag = false;
               }
           });
           return flag;
       }
       #endregion

       #region Private Method
       private List<CacheEntityBase> GetEntityBaseByCacheKeyMapDescriptor(List<CacheKeyMapDescriptor> lstMapList)
       {
           List<CacheEntityBase> lstEntity = new List<CacheEntityBase>();
           lstMapList.ForEach(x =>
           {
               //CacheEntityBase entity = new CacheEntityBase();
               object entity;
               //TryGetValue(x.CacheKey, out entity);
               entity=GetValue(x.CacheKey);
               if (entity != null)
               {
                   lstEntity.Add(new CacheEntityBase() { 
                        ApplicationName="",
                        CacheId=x.CacheId,
                        CacheKey=x.CacheKey,
                        CacheSta=x.CacheSta,
                       // CacheValue=JsonConvert.SerializeObject(entity),
                        Created=x.CreateTime,
                        ExpireDate=x.ExpireDate
                   });
               }
           });
           return lstEntity;
       }
        #endregion



    }
}
