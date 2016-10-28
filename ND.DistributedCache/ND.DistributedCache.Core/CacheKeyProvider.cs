using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheKeyProvider.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 14:27:22         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 14:27:22          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   public  class CacheKeyProvider
    {
         private static CacheKeyProvider _instance = null;
         private  CacheKeyDictionary _cacheKeyCollection;
         public  CacheKeyDictionary CacheKeyCollection { get { return _cacheKeyCollection; } }
         public static CacheKeyProvider Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }
        private CacheKeyProvider()
        {
            _cacheKeyCollection = new CacheKeyDictionary();
        }

       static CacheKeyProvider()
        {
            _instance = new CacheKeyProvider();
        }
    }
}
