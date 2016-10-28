using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheStatus.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 13:11:24         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 13:11:24          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
  public  enum CacheStatus
    {
      /// <summary>
      /// 无效
      /// </summary>
      Invalid=0,

      /// <summary>
      /// 有效
      /// </summary>
      Effective=1
    }

  public enum Cachelimit
  {
       /// <summary>
      ///当天缓存
      /// </summary>
      CurrentDay = 0,
      

      /// <summary>
      /// 永久缓存
      /// </summary>
      Forever = 1,  

      /// <summary>
      /// 以过期时间来决定缓存期限 
      /// </summary>
      ByExpireDate = 2,

     
  }
}
