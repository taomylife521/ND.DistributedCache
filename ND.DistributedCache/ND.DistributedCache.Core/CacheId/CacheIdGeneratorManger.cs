using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheIdGeneratorManger.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 11:47:01         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 11:47:01          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
   internal class CacheIdGeneratorManger
    {
        private static CacheIdGeneratorManger _instance = null;
       /// <summary>
       /// 缓存id生成器
       /// </summary>
       private static ICacheIdGenerator generator;
       public static CacheIdGeneratorManger Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }
       private CacheIdGeneratorManger()
        { }
        static CacheIdGeneratorManger()
       {
           _instance = new CacheIdGeneratorManger();
           generator = new DefaultCacheIdGenerator();
       }
       /// <summary>
       /// 生成缓存id
       /// </summary>
       /// <returns></returns>
       public  string GenerateCacheId()
       {
           return generator.GenerateCacheId();
       }
    }
}
