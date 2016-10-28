using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：MongoDBCacheConfiguration.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 10:47:41         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 10:47:41          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.Configuration
{
    public class MongoDBCacheConfiguration : CacheConfigurationBase
    {
        public override DB InitializeDB()
        {
            return DB.MongoDB;
        }
    }
}
