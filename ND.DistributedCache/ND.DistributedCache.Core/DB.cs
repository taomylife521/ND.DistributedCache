using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：DB.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 10:41:20         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 10:41:20          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   public enum DB
    {
       MongoDB,
       Redis,
       Memcached,
    }

    public enum DateType
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime=0,

        /// <summary>
        /// 过期时间
        /// </summary>
        ExpireTime=1,
    }

    public enum CacheExpire
    {
        /// <summary>
        /// 不限
        /// </summary>
        All=0,

        /// <summary>
        /// 已过期
        /// </summary>
        Expired=1,

        /// <summary>
        /// 未过期
        /// </summary>
        NoExpired=2
    }
}
