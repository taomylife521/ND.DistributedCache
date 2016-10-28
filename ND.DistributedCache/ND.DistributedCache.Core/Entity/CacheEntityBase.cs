using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheEntityBase.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 10:30:15         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 10:30:15          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.Entity
{
    /// <summary>
    /// 缓存实体Base
    /// </summary>
   public class CacheEntityBase
    {
        /// <summary>
        /// 缓存键
        /// </summary>
        [BsonId]
        public string CacheId { get; set; }

        /// <summary>
        /// 缓存Key
        /// </summary>
        public string CacheKey { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Created { get; set; }


        /// <summary>
        /// 缓存时间
        /// </summary>
         [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// 缓存值
        /// </summary>
     
        public string CacheValue { get; set; }
        
       /// <summary>
       /// 当前应用程序名称
       /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// 是否有效 0-无效 1-有效
        /// </summary>
        public CacheStatus CacheSta { get; set; }

        
    }
}
