using A2DFramework.SessionService;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ND.DistributedCache.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：MongoDBCacheKeyMap.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/27 13:35:11         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/27 13:35:11          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.CacheKeyMap
{
    /// <summary>
    /// MongoDB集合
    /// </summary>
    public class MongoDBCacheKeyMap : CacheKeyMapBase
    {
        public override CacheKeyMapDescriptor GetCacheKeyMap(string key)
        {
            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
                var query = Query.And(Query.EQ("CacheKey", key));
                CacheKeyMapDescriptor cacheKeyMap = collection.FindOne(query);
                if(cacheKeyMap==null)
                {
                    return cacheKeyMap;
                }
              
                return cacheKeyMap;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

        public override void AddCacheKeyMap(CacheKeyMapDescriptor request)
        {
           
            MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
            if (collection != null)
            {
                try
                {
                    var query = Query.And(Query.EQ("CacheKey", request.CacheKey));
                    collection.Remove(query);
                }
                catch (Exception ex)
                { }
                WriteConcernResult res = collection.Save(request);
                if (request.Cachelimit != Cachelimit.Forever)
                {
                    TimeSpan timespan = request.ExpireDate.Subtract(DateTime.Now);

                    if (!collection.IndexExists(new IndexKeysBuilder().Ascending("ExpireDate")))
                    {
                        collection.EnsureIndex(new IndexKeysBuilder().Ascending("ExpireDate"), IndexOptions.SetTimeToLive(timespan));
                    }
                }
               
            }
          
        }

        public override bool DeleteCacheKeyMap(CacheKeyMapDescriptor request)
        {
            MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
            if (collection != null)
            {
                try
                {
                    var query = Query.And(Query.EQ("CacheKey", request.CacheKey));
                    WriteConcernResult res = collection.Remove(query);
                    if(res.Ok)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
               

            }
            return false;
        }

        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire)
        {
            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        collection.FindAll().ToList().ForEach(x =>
                        {
                            DeleteCacheKeyMap(x);
                        });
                        break;
                    case CacheExpire.Expired:
                        var query = Query.And(Query.LTE("ExpireDate", DateTime.Now));
                        collection.Find(query).ToList().ForEach(x =>
                        {
                            DeleteCacheKeyMap(x);
                        });
                        break;
                    case CacheExpire.NoExpired:
                        {
                            var query2 = Query.And(Query.GT("ExpireDate", DateTime.Now));
                            collection.Find(query2).ToList().ForEach(x =>
                            {
                                DeleteCacheKeyMap(x);
                            });
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

        #region DeleteCacheKeyMap
        public override bool DeleteCacheKeyMap(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();

                startDate = Convert.ToDateTime(startDate.ToString("yyyy-MM-dd") + " 0:00:00");
                endDate = Convert.ToDateTime(endDate.ToString("yyyy-MM-dd") + " 23:59:59");
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                         Query.GTE("CreateTime", startDate),
                                         Query.LTE("CreateTime", endDate)
                                    );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });

                            }
                            else
                            {
                                var query = Query.And(
                                        Query.GTE("ExpireDate", startDate),
                                        Query.LTE("ExpireDate", endDate)
                                   );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            }
                        }
                        break;
                    case CacheExpire.Expired:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                        Query.GTE("CreateTime", startDate),
                                        Query.LTE("CreateTime", endDate),
                                        Query.LTE("ExpireDate", DateTime.Now)
                                   );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            }
                            else
                            {
                                var query = Query.And(
                                       Query.GTE("ExpireDate", startDate),
                                       Query.LTE("CreateTime", endDate),
                                       Query.LTE("ExpireDate", DateTime.Now)
                                  );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            }
                        }
                        break;
                    case CacheExpire.NoExpired:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                       Query.GTE("CreateTime", startDate),
                                       Query.LTE("CreateTime", endDate),
                                       Query.GT("ExpireDate", DateTime.Now)
                                  );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });

                            }
                            else
                            {
                                var query = Query.And(
                                      Query.GTE("ExpireDate", startDate),
                                      Query.LTE("CreateTime", endDate),
                                      Query.GT("ExpireDate", DateTime.Now)
                                 );
                                collection.Find(query).ToList().ForEach(x => { DeleteCacheKeyMap(x); });
                            }

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
        #endregion

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();
           
            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        lstMap=collection.FindAll().ToList();
                        break;
                    case CacheExpire.Expired:
                        {
                            var query = Query.And(
                                           Query.LTE("ExpireDate", DateTime.Now)
                                      );
                            lstMap = collection.Find(query).ToList();
                        }
                        break;
                    case CacheExpire.NoExpired:
                        {
                            var query = Query.And(
                                           Query.GT("ExpireDate", DateTime.Now)
                                      );
                            lstMap = collection.Find(query).ToList();
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

        #region GetCacheKeyMapList
        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();

            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
                switch (cacheExpire)
                {
                    case CacheExpire.All:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                         Query.GTE("CreateTime", startDate),
                                         Query.LTE("CreateTime", endDate)
                                    );
                                lstMap = collection.Find(query).ToList();
                            }
                            else if (dateType == DateType.ExpireTime)
                            {
                                var query = Query.And(
                                        Query.GTE("ExpireDate", startDate),
                                        Query.LTE("ExpireDate", endDate)
                                   );
                                lstMap = collection.Find(query).ToList();
                            }
                            else lstMap = collection.FindAll().ToList();
                        }
                        break;
                    case CacheExpire.Expired:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                      Query.GTE("CreateTime", startDate),
                                      Query.LTE("CreateTime", endDate),
                                      Query.LTE("ExpireDate", DateTime.Now)
                                 );
                                lstMap = collection.Find(query).ToList();
                            }
                            else if (dateType == DateType.ExpireTime)
                            {
                                var query = Query.And(
                                      Query.GTE("ExpireDate", startDate),
                                      Query.LTE("ExpireDate", endDate),
                                      Query.LTE("ExpireDate", DateTime.Now)
                                 );
                                lstMap = collection.Find(query).ToList();

                            }
                            else
                            {
                                var query = Query.And(
                                      Query.LTE("ExpireDate", DateTime.Now)
                                 );
                                lstMap = collection.Find(query).ToList();
                            }
                        }
                        break;
                    case CacheExpire.NoExpired:
                        {
                            if (dateType == DateType.CreateTime)
                            {
                                var query = Query.And(
                                     Query.GTE("CreateTime", startDate),
                                     Query.LTE("CreateTime", endDate),
                                     Query.GT("ExpireDate", DateTime.Now)
                                );
                                lstMap = collection.Find(query).ToList();
                            }
                            else if (dateType == DateType.ExpireTime)
                            {
                                var query = Query.And(
                                    Query.GTE("ExpireDate", startDate),
                                    Query.LTE("ExpireDate", endDate),
                                    Query.GT("ExpireDate", DateTime.Now)
                               );
                                lstMap = collection.Find(query).ToList();

                            }
                            else
                            {
                                var query = Query.And(
                                   Query.GT("ExpireDate", DateTime.Now)
                              );
                                lstMap = collection.Find(query).ToList();
                            }
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
        #endregion

        public override List<CacheKeyMapDescriptor> GetCacheKeyMapList(Cachelimit cacheLimit, DateTime? startDate, DateTime? endDate)
        {
            List<CacheKeyMapDescriptor> lstMap = new List<CacheKeyMapDescriptor>();
            try
            {
                MongoCollection<CacheKeyMapDescriptor> collection = DistributedCacheHelper.GetMongoDBCacheKeyMapCollection();
                if (cacheLimit == Cachelimit.ByExpireDate)
                {
                    var query = Query.And(
                                         Query.EQ("Cachelimit", cacheLimit),
                                         Query.EQ("ExpireDate", startDate),
                                         Query.EQ("ExpireDate", endDate)
                                    );
                    lstMap = collection.Find(query).ToList();
                }
                else
                {
                    var query = Query.And(
                                       Query.EQ("Cachelimit", cacheLimit)
                                  );
                    lstMap = collection.Find(query).ToList();
                }
                return lstMap;
            }
            catch (Exception ex)
            {
                return lstMap;
            }
        }
    }
}
