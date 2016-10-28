//**********************************************************************
//
// 文件名称(File Name)：        
// 功能描述(Description)：     
// 作者(Author)：               
// 日期(Create Date)： 2016/4/18 10:33:09         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期: 2016/4/18 10:33:09           
//             修改理由：         
//
//       R2:
//             修改作者:          
//             修改日期:  2016/4/18 10:33:09         
//             修改理由：         
//
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND.DistributedCache.Core.Configuration
{
    /// <summary>
    /// 缓存配置接口
    /// </summary>
   public interface ICacheConfiguration
    {
       /// <summary>
       /// 初始化配置
       /// </summary>
       void InitializeConfig();

       //初始化数据库名称
       DB InitializeDB();

       ////初始化数据库表名称
       //void InitializeTableName();
    }
}
