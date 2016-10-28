using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.Web;
using System.Web.SessionState;
using System.IO;
using ND.DistributedCache.Core.Entity;
using ND.DistributedCache.Core.Configuration;
using ND.DistributedCache.Core;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using ND.DistributedCache.Core.CacheKeyMap;

namespace A2DFramework.SessionService
{
    internal class DistributedCacheHelper
    {
        public static bool ParseCacheID(string rawCacheId, out string prefix, out string realCacheId)
        {
            prefix = string.Empty;
            realCacheId = string.Empty;

            if (rawCacheId == null)
                return false;
            if (rawCacheId.Trim().Length == 0)
                return false;
            string[] parsedValues = rawCacheId.Split('.');
            if (parsedValues == null)
                return false;
            if (parsedValues.Length != 2)
                return false;

            prefix = parsedValues[0];
            realCacheId = parsedValues[1];

            return true;
        }
        public static MongoCollection<CacheKeyMapDescriptor> GetMongoDBCacheKeyMapCollection()
        {
            MongoClient client = new MongoClient(MongoDBCacheConfiguration.CacheKeyMapMongoDBConnStr);
            MongoServer srv = client.GetServer();
            MongoDatabase db = srv.GetDatabase(MongoDBCacheConfiguration.CacheKeyMapDBName);
            if (!db.CollectionExists(MongoDBCacheConfiguration.CacheKeyMapTableName))
                db.CreateCollection(MongoDBCacheConfiguration.CacheKeyMapTableName);

            MongoCollection<CacheKeyMapDescriptor> collection = db.GetCollection<CacheKeyMapDescriptor>(MongoDBCacheConfiguration.CacheKeyMapTableName);

            return collection;
        }
        public static MongoCollection<MongoDBCacheEntity> GetMongoDBCollection(string cacheId)
        {
          
                IPartitionResolver resolver = new MongoDBCachePartitionResolver();
                string mongoDbConnectionString = resolver.ResolvePartition(cacheId);
                MongoClient client = new MongoClient(mongoDbConnectionString);
                MongoServer srv = client.GetServer();
                MongoDatabase db = srv.GetDatabase(MongoDBCacheConfiguration.DBName);
                if (!db.CollectionExists(MongoDBCacheConfiguration.TableName))
                    db.CreateCollection(MongoDBCacheConfiguration.TableName);

                MongoCollection<MongoDBCacheEntity> collection = db.GetCollection<MongoDBCacheEntity>(MongoDBCacheConfiguration.TableName);

                return collection; 
        }

        public static MongoCollection<MongoDBCacheEntity> GetMongoDBCollection(string cacheId,Cachelimit cacheLimit)
        {

            IPartitionResolver resolver = new MongoDBCachePartitionResolver();
            string mongoDbConnectionString = resolver.ResolvePartition(cacheId);
            MongoClient client = new MongoClient(mongoDbConnectionString);
            MongoServer srv = client.GetServer();
            MongoDatabase db = srv.GetDatabase(MongoDBCacheConfiguration.DBName);
            string tableName = cacheLimit == Cachelimit.Forever ? MongoDBCacheConfiguration.TableName + "Forever" :  MongoDBCacheConfiguration.TableName + "ByExpireDate";
            if (!db.CollectionExists(tableName))
                db.CreateCollection(tableName);

            MongoCollection<MongoDBCacheEntity> collection = db.GetCollection<MongoDBCacheEntity>(tableName);

            return collection;

        }

        public static void ClearExpireData(CacheKeyMapDescriptor cacheKeyMap)
        {

            Task.Factory.StartNew(() =>
                {
                    lock (cacheKeyMap)
                    {
                        MongoCollection<MongoDBCacheEntity> collection2 = DistributedCacheHelper.GetMongoDBCollection(cacheKeyMap.CacheId, cacheKeyMap.Cachelimit);
                        
                        var query = Query.And(
                                            Query.EQ("_id", cacheKeyMap.CacheId)
                                            );
                        WriteConcernResult res2 = collection2.Remove(query);
                        string tableName = MongoDBCacheConfiguration.TableName + DateTime.Now.AddDays(-1).ToString("yyMMdd");
                        string expireDateTableName = MongoDBCacheConfiguration.TableName+"ByExpireDate";
                        if (collection2.Database.CollectionExists(tableName)) collection2.Database.DropCollection(tableName);//清空前一天的数据集合
                        if (collection2.Database.CollectionExists(expireDateTableName))
                        {
                            query = Query.And(
                                           Query.LTE("ExpireDate", DateTime.Now)
                                           );
                            collection2.Database.GetCollection<MongoDBCacheEntity>(expireDateTableName).Remove(query);
                        }
                          CacheKeyMapManger.Instance.DeleteCacheKeyMap(CacheExpire.Expired);
                        tableName = null;

                    }
                });

        }

        public static string Serialize(SessionStateItemCollection items)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);

            if (items != null)
                items.Serialize(writer);

            writer.Close();

            return Convert.ToBase64String(ms.ToArray());
        }


        public static SessionStateStoreData Deserialize(HttpContext context, string serializedItems, int timeout)
        {
            MemoryStream ms = null;
            if(serializedItems!=null&&serializedItems.Trim().Length>0)
                ms = new MemoryStream(Convert.FromBase64String(serializedItems));

            SessionStateItemCollection sessionItems =
              new SessionStateItemCollection();

            if (ms!=null&&ms.Length > 0)
            {
                BinaryReader reader = new BinaryReader(ms);
                sessionItems = SessionStateItemCollection.Deserialize(reader);
            }

            return new SessionStateStoreData(sessionItems,
              SessionStateUtility.GetSessionStaticObjects(context),
              timeout);
        }

        public static SessionStateItemCollection DeserializeCore(string serializedItems)
        {
            SessionStateItemCollection sessionItems = new SessionStateItemCollection();

            MemoryStream ms = null;
            if (serializedItems != null && serializedItems.Trim().Length > 0)
                ms = new MemoryStream(Convert.FromBase64String(serializedItems));

            if (ms != null && ms.Length > 0)
            {
                BinaryReader reader = new BinaryReader(ms);
                sessionItems = SessionStateItemCollection.Deserialize(reader);
            }

            return sessionItems;
        }
    }
}