using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheKeyDescriptor.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 16:12:41         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 16:12:41          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   /// <summary>
   /// 缓存key映射描述
   /// </summary>
   [BsonIgnoreExtraElements]
   public class CacheKeyMapDescriptor
    {
       private Cachelimit _cachelimit = Cachelimit.ByExpireDate;

      // [BsonId]
      // public string CacheKeyMapId { get { return Guid.NewGuid().ToString("N"); } }
       /// <summary>
       /// 缓存key
       /// </summary>
       public string CacheKey { get; set; }

       /// <summary>
       /// 缓存id
       /// </summary>
       [BsonId]
       public string CacheId { get; set; }

       /// <summary>
       /// 缓存限制
       /// </summary>
       public Cachelimit Cachelimit { get { return _cachelimit; } set { _cachelimit = value; } }

       /// <summary>
       /// 缓存时间
       /// </summary>
         [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
       public DateTime ExpireDate { get; set; }

       /// <summary>
       /// 创建时间
       /// </summary>
       [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
       public DateTime CreateTime { get { return DateTime.Now; } }

       /// <summary>
       /// 是否有效 0-无效 1-有效
       /// </summary>
       public CacheStatus CacheSta { get; set; }
    }
}
