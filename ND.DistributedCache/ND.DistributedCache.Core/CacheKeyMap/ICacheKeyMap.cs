//**********************************************************************
//
// 文件名称(File Name)：        
// 功能描述(Description)：     
// 作者(Author)：               
// 日期(Create Date)： 2016/4/19 14:14:12         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期: 2016/4/19 14:14:12           
//             修改理由：         
//
//       R2:
//             修改作者:          
//             修改日期:  2016/4/19 14:14:12         
//             修改理由：         
//
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND.DistributedCache.Core.CacheKeyMap
{
   public interface ICacheKeyMap
    {
        

       /// <summary>
       /// 获取单个key映射集合
       /// </summary>
       /// <param name="key"></param>
       /// <returns></returns>
       CacheKeyMapDescriptor GetCacheKeyMap(string key);

       /// <summary>
       /// 批量获取单个key映射集合
       /// </summary>
       /// <param name="keys"></param>
       /// <returns></returns>
       List<CacheKeyMapDescriptor> GetCacheKeyMap(List<string> keys);

       /// <summary>
       /// 批量获取映射集合列表
       /// </summary>
       /// <returns></returns>
       List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire);

       /// <summary>
       /// 批量获取映射集合列表
       /// </summary>
       /// <returns></returns>
       List<CacheKeyMapDescriptor> GetCacheKeyMapList(Cachelimit cacheLimit,DateTime? startDate,DateTime? endDate);

       /// <summary>
       /// 删除key映射集合
       /// </summary>
       /// <param name="key">The key.</param>
       List<CacheKeyMapDescriptor> GetCacheKeyMapList(CacheExpire cacheExpire, DateType dateType, DateTime startDate, DateTime endDate);

       /// <summary>
       /// 添加映射集合对象
       /// </summary>
       /// <param name="request"></param>
       void AddCacheKeyMap(CacheKeyMapDescriptor request);

       /// <summary>
       /// 批量添加映射集合对象
       /// </summary>
       /// <param name="requestList"></param>
       void AddCacheKeyMap(List<CacheKeyMapDescriptor> requestList);

       /// <summary>
       /// 根据key和id添加映射集合
       /// </summary>
       /// <param name="cacheKey"></param>
       /// <param name="cacheId"></param>
       void AddCacheKeyMap(string cacheKey,string cacheId);

        /// <summary>
       /// 根据key和id添加映射集合
       /// </summary>
       /// <param name="cacheKey"></param>
       /// <param name="cacheId"></param>
       void AddCacheKeyMap(string cacheKey, string cacheId, DateTime expireDate);

     

       /// <summary>
       /// 根据key和id添加映射集合
       /// </summary>
       /// <param name="cacheKey"></param>
       /// <param name="cacheId"></param>
       void AddCacheKeyMap(string cacheKey, string cacheId, DateTime? expireDate, Cachelimit cacheLimit);

      

       /// <summary>
       /// 删除key映射集合
       /// </summary>
       /// <param name="request"></param>
       bool DeleteCacheKeyMap(CacheKeyMapDescriptor request);

       /// <summary>
       /// 删除key映射集合
       /// </summary>
       /// <param name="key">The key.</param>
       bool DeleteCacheKeyMap(string key);

       /// <summary>
       /// 批量删除key映射集合
       /// </summary>
       /// <param name="key">The key.</param>
       bool DeleteCacheKeyMap(List<string> key);

       /// <summary>
       /// 删除key映射集合
       /// </summary>
       /// <param name="key">The key.</param>
       bool DeleteCacheKeyMap(CacheExpire cacheExpire);

    

       /// <summary>
       /// 删除key映射集合
       /// </summary>
       /// <param name="key">The key.</param>
       bool DeleteCacheKeyMap(CacheExpire cacheExpire,DateType dateType, DateTime startDate, DateTime endDate);
    }
}
