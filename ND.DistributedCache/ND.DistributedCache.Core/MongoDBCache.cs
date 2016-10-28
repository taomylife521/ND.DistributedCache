using A2DFramework.SessionService;
using MongoDB.Driver;
using ND.DistributedCache.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Driver.Builders;
using ND.DistributedCache.Core.Configuration;
using ND.DistributedCache.Core.CacheKeyMap;

//**********************************************************************
//
// 文件名称(File Name)：MongoDBCache.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 11:33:30         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 11:33:30          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
    public class MongoDBCache : CacheBase
    {
        private string pApplicationName;
        private ICacheConfiguration  _configuration;
        public MongoDBCache():this(new MongoDBCacheConfiguration())
        {

        }
        public MongoDBCache(ICacheConfiguration configuration)
        {
            pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            _configuration = configuration;
        }
        
        /// <summary>
        /// 获取value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object GetValue(string key)
        {
            try
            {
                CacheKeyMapDescriptor cacheKeyMap = EnsureKeyExist(key);
                OnOperating("开始获取value:starting:key:" + key + ",cacheId:" + cacheKeyMap.CacheId);
                if (cacheKeyMap == null)
                {
                    return null;
                }
                MongoDBCacheEntity entity = GetMongoDBEntity(cacheKeyMap);
                if (entity != null)
                {
                    OnOperating("获取value成功:end-->:key:" + key + ",cacheId:" + cacheKeyMap.CacheId + ",value:" + entity.CacheValue);
                    return entity.CacheValue;
                }
                OnOperating("获取value失败:未找到key:" + key + "对应的值");
                return null;
            }
            catch(Exception ex)
            {
                OnOperating("获取value异常:" + JsonConvert.SerializeObject(ex) + "");
                return null;
            }
        }

     
        /// <summary>
        /// 删除value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool DeleteValue(string key, bool isClearOtherExpire)
        {
            try
            {
                CacheKeyMapDescriptor cacheKeyMap = EnsureKeyExist(key,true);
                if (cacheKeyMap == null)
                {
                    return false;
                }
                OnOperating("开始删除值:starting:key:" + key + ",cacheId:" + cacheKeyMap.CacheId);
                MongoCollection<MongoDBCacheEntity> collection = DistributedCacheHelper.GetMongoDBCollection(cacheKeyMap.CacheId, cacheKeyMap.Cachelimit);
                var query2 = Query.And(
                                    Query.EQ("_id", cacheKeyMap.CacheId)
                                    );
                WriteConcernResult res = collection.Remove(query2);//移除文档
                //清空过期的集合数据
               
                if (res.Ok)
                {
                   
                    bool r= CacheKeyMapManger.Instance.DeleteCacheKeyMap(key);
                    if (isClearOtherExpire) DistributedCacheHelper.ClearExpireData(cacheKeyMap);
                    if(r)
                    {
                        OnOperating("删除值完成:end:key:" + key + ",cacheId:" + cacheKeyMap.CacheId + ",result:" + res.Ok + "," + res.ErrorMessage);
                        return true;
                    }
                    OnOperating("删除值失败:end:key:" + key + ",cacheId:" + cacheKeyMap.CacheId + ",result:" + res.Ok + "," + res.ErrorMessage);
                    return false;
                }
                OnOperating("删除值完成:end:key:" + key + ",cacheId:" + cacheKeyMap.CacheId + ",result:" + res.Ok + "," + res.ErrorMessage);
                return false;
            }
            catch(Exception ex)
            {
                OnOperating("删除值异常:key:" + key + ",exception:" + JsonConvert.SerializeObject(ex));
                return false;
            }
        }

       


        ///// <summary>
        /////设置value
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="key"></param>
        ///// <param name="value"></param>
        ///// <param name="expireDate"></param>
        //private override bool SetValue<T>(string key, T value, DateTime expireDate) 
        //{
        //    try
        //    {
        //        string cacheId = CacheIdGeneratorManger.Instance.GenerateCacheId();
        //        OnOperating("开始写入值:starting:key:" + key + ",cacheId:" + cacheId + ",value:" + JsonConvert.SerializeObject(value) + ",expireDate:" + expireDate);
        //        MongoDBCacheEntity cache = new MongoDBCacheEntity();
        //        cache.ApplicationName = this.pApplicationName;
        //        cache.CacheId = cacheId;
        //        cache.Created = DateTime.Now;
        //        cache.CacheKey = key;
        //        cache.ExpireDate = expireDate;
        //        cache.CacheSta = CacheStatus.Effective;
        //        cache.CacheValue = JsonConvert.SerializeObject(value);
               
        //        MongoCollection<MongoDBCacheEntity> collection = DistributedCacheHelper.GetMongoDBCollection(cacheId);
        //        if (collection != null)
        //        {
        //            try
        //            {
        //                var query = Query.And(Query.EQ("CacheKey", key));
        //                collection.Remove(query);
        //            }
        //            catch(Exception ex)
        //            { }
        //            WriteConcernResult res = collection.Save(cache);
        //            OnOperating("写入完成end:key:" + key + ",cacheId:" + cacheId + ",result:" + res.Ok + "," + res.ErrorMessage);
        //            if (res.Ok)//成功后
        //            {

        //                CacheKeyMapManger.Instance.AddCacheKeyMap(key, cacheId, expireDate);
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch(Exception ex)
        //    {
        //        OnOperating("写入Excption:key:" + key +  ",exception:" + JsonConvert.SerializeObject(ex));
        //        return false;
        //    }
        //}


        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheLimit"></param>
        /// <returns></returns>
        public override bool SetValue<T>(string key, T value,  Cachelimit cacheLimit,DateTime? expireDate)
        {
            try
            {
                string cacheId = CacheIdGeneratorManger.Instance.GenerateCacheId();
                OnOperating("开始写入值:starting:key:" + key + ",cacheId:" + cacheId + ",value:" + JsonConvert.SerializeObject(value) + ",cacheLimit:" + cacheLimit.ToString());
                MongoDBCacheEntity cache = new MongoDBCacheEntity();
                cache.ApplicationName = this.pApplicationName;
                cache.CacheId = cacheId;
                cache.Created = DateTime.Now;
                cache.CacheKey = key;
                cache.ExpireDate = cacheLimit == Cachelimit.Forever ? Convert.ToDateTime("2099-12-30") : (cacheLimit == Cachelimit.CurrentDay ? Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59") : Convert.ToDateTime(expireDate));
                cache.CacheSta = CacheStatus.Effective;
               

                cache.CacheValue = JsonConvert.SerializeObject(value);
                if(cacheLimit ==Cachelimit.ByExpireDate)
                {

                }
                MongoCollection<MongoDBCacheEntity> collection = DistributedCacheHelper.GetMongoDBCollection(cacheId,cacheLimit);
                if (collection != null)
                {
                    try
                    {
                        var query = Query.And(Query.EQ("CacheKey", key));
                        collection.Remove(query);
                    }
                    catch (Exception ex)
                    { }
                    WriteConcernResult res = collection.Save(cache); 
                    TimeSpan timespan = cache.ExpireDate.Subtract(DateTime.Now);
                    if (cacheLimit != Cachelimit.Forever)
                    {
                        if (!collection.IndexExists(new IndexKeysBuilder().Ascending("ExpireDate")))
                        {
                            collection.EnsureIndex(new IndexKeysBuilder().Ascending("ExpireDate"), IndexOptions.SetTimeToLive(timespan));
                        }
                    }
                  
                    
                    OnOperating("写入完成end:key:" + key + ",cacheId:" + cacheId + ",result:" + res.Ok + "," + res.ErrorMessage);
                    if (res.Ok)//成功后
                    {

                        CacheKeyMapManger.Instance.AddCacheKeyMap(key, cacheId,expireDate, cacheLimit);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                OnOperating("写入Excption:key:" + key + ",exception:" + JsonConvert.SerializeObject(ex));
                return false;
            }
        }

        /// <summary>
        /// 获取value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TryGetValue<T>(string key, out T value) 
        {
            try
            {
                T temp = default(T);
                CacheKeyMapDescriptor cacheKeyMap = EnsureKeyExist(key);
                OnOperating("开始尝试获取值:starting:key:" + key + ",cacheId:" + cacheKeyMap);
                if (cacheKeyMap == null)
                {
                    value = default(T);
                    return false;
                }
                MongoDBCacheEntity entity = GetMongoDBEntity(cacheKeyMap);
                OnOperating("尝试获取值结束：end:key:" + key + ",cacheId:" + cacheKeyMap.CacheId+ ",result:" + JsonConvert.SerializeObject(entity));
                value = default(T);
                value =JsonConvert.DeserializeObject<T>(entity.CacheValue);
                return true;
            }
            catch (Exception ex)
            {
                OnOperating("尝试获取值异常：exception:key:" + key + ",excption:" + JsonConvert.SerializeObject(ex));
                value = default(T);
                return false;
            }
        }

        #region Private
       /// <summary>
       /// 确保key值存在
       /// </summary>
       /// <param name="key">key</param>
       /// <param name="isBackExpireData">如果当前key过期是否返回对应的对象</param>
       /// <returns></returns>
        private CacheKeyMapDescriptor EnsureKeyExist(string key,bool isBackExpireData=false)
        {
            try
            {
                CacheKeyMapDescriptor cacheKeyMap = CacheKeyMapManger.Instance.GetCacheKeyMap(key);
                if (cacheKeyMap == null)
                {
                    return null;
                    // throw new KeyNotFoundException("Cache Key:" + key + " is not exist");
                }
              if(cacheKeyMap.ExpireDate <=DateTime.Now)
              {
                  if(isBackExpireData)
                  {
                      return cacheKeyMap;
                  }
                  else
                  {
                      return null;
                  }
              }
                return cacheKeyMap;
                //if (!CacheKeyProvider.Instance.CacheKeyCollection.ContainsKey("_" + key))
                //{
                //    throw new KeyNotFoundException("Cache Key:" + key + " is not exist");
                //}
                //return CacheKeyProvider.Instance.CacheKeyCollection["_" + key];
            }
            catch(Exception ex)
            {
                OnOperating("EnsureKeyExist异常,excption:" + JsonConvert.SerializeObject(ex));
                return null;
            }
        }

        private MongoDBCacheEntity GetMongoDBEntity(CacheKeyMapDescriptor cacheKeyMap)
        {
            try
            {
                MongoCollection<MongoDBCacheEntity> collection = DistributedCacheHelper.GetMongoDBCollection(cacheKeyMap.CacheId,cacheKeyMap.Cachelimit);
                var query2 = Query.And(
                                   Query.EQ("_id", cacheKeyMap.CacheId)
                    //Query.GT("Expires", DateTime.Now),
                    // Query.EQ("CacheSta", "1")
                    //Query.EQ("ApplicationName", pApplicationName)
                                   );
                return collection.FindOne(query2);
            }
            catch(Exception ex)
            {
                OnOperating("GetMongoDBEntity异常,excption:" + JsonConvert.SerializeObject(ex));
                return null;
            }
        }
        #endregion

       
    }
}
