using ND.DistributedCache.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//**********************************************************************
//
// 文件名称(File Name)：CacheConfigurationBase.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 10:35:43         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 10:35:43          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.Configuration
{
    public abstract class CacheConfigurationBase : ICacheConfiguration
    {
        //public static string[] CacheServerIdentities = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string[] CacheServerIdentities;
        public static Dictionary<string, string> CacheIdentityDBMap;
        public static string DBName="CacheDB";
        public static string TableName = "Caches";
        public static string CacheKeyMapDBName = "CacheKeyMapDB";
        public static string CacheKeyMapTableName = "CacheKeyMaps";
        public static string CacheKeyMapMongoDBConnStr = "";
        private static DB dataBase; 
        public CacheConfigurationBase()
        {
            CacheIdentityDBMap = new Dictionary<string, string>();
            dataBase = InitializeDB();
            InitializeConfig();//初始化配置
        }
        //static CacheConfigurationBase()
        //{
        //    XElement root = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ND.DistributedCache.config"));
        //    CacheServerIdentities= root.Element("CacheMachines").Value.Split(',');
           
        //}

        /// <summary>
        /// 初始化配置
        /// </summary>
        public virtual void InitializeConfig(){

         Dictionary<string, string> map = new Dictionary<string, string>();
         string xml_URL = "http://res.niding.net/api/ND.DistributedCache.xml";
         if (!ValidateHelper.CheckUrlValid(xml_URL))
         {
             xml_URL = "http://soa.niding.net/data/ND.DistributedCache.xml";
         }
        // XElement root = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ND.DistributedCache.config"));
         XElement root = XElement.Load(xml_URL);
         string APIUrl_Type = System.Configuration.ConfigurationManager.AppSettings["APIURL_Type"];

        

         root= root.Element(APIUrl_Type.Equals("1") ? "TrueCacheConfig" : "TestCacheConfig");
         #region Cache
         XElement rootCache = root.Element(dataBase + "Cache");
         if (rootCache == null)
             throw new Exception(dataBase + "Cache" + "Cache node not exists");
         CacheServerIdentities = rootCache.Element("CacheMachines").Value.Split(',');

         foreach (var elm in rootCache.Elements("IdentityMap"))
         {
             string identity = elm.Attribute("Identity").Value;
             string dbConnectionString = elm.Value;
             map[identity] = dbConnectionString;
         }
         CacheIdentityDBMap = map;
         DBName = rootCache.Element("DbName").Value;//数据库名称
         TableName = rootCache.Element("TableName").Value;//表名称 
         #endregion

         #region CacheKeyMap
         //XElement root2 = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ND.DistributedCache.config"));
        

         XElement root2 = root.Element(dataBase + "CacheKeyMap");
         if (root2 == null)
             throw new Exception(dataBase + "CacheKeyMap" + "Cache node not exists");
        // CacheKeyMapServerIdentities = root2.Element("CacheKeyMapMachines").Value.Split(',');
         //foreach (var elm in root2.Elements("IdentityMap"))
         //{
         //    string identity = elm.Attribute("Identity").Value;
         //    string dbConnectionString = elm.Value;
         //    cacheKeyMap[identity] = dbConnectionString;
         //}
         CacheKeyMapMongoDBConnStr = root2.Element("MongoDBCacheKeyMapConnStr").Value;
         CacheKeyMapDBName = root2.Element("DbName").Value;//数据库名称
         CacheKeyMapTableName = root2.Element("TableName").Value;//表名称 
         #endregion

        }


        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns></returns>
        public abstract DB InitializeDB();
       
    }
}
