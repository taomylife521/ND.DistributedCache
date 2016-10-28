using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：CacheKeyCollection.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/4/18 13:59:19         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 13:59:19          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
    public  class CacheKeyDictionary : IDictionary<string,string>
    {
        private ConcurrentDictionary<string, string> cacheKeyCollection = new ConcurrentDictionary<string, string>();
       
        public void Add(string key, string value)
        {
            try
            {
                string a = "";
                cacheKeyCollection.TryRemove(key, out a);
                cacheKeyCollection.TryAdd(key, value);
            }
            catch(Exception ex)
            {

            }
        }
      
        public bool ContainsKey(string key)
        {
            return cacheKeyCollection.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return cacheKeyCollection.Keys; }
        }

        public bool Remove(string key)
        {
            try
            {
                string value = "";
                return cacheKeyCollection.TryRemove(key, out value);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool TryGetValue(string key, out string value)
        {
            return cacheKeyCollection.TryGetValue(key, out value);
        }

        public ICollection<string> Values
        {
            get { return cacheKeyCollection.Values; }
        }

        public string this[string key]
        {
            get { return cacheKeyCollection[key]; }
            set { cacheKeyCollection[key] = value; }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            cacheKeyCollection.TryAdd(item.Key, item.Value);
        }

        public void Clear()
        {
            cacheKeyCollection.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return cacheKeyCollection.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            
        }

        public int Count
        {
            get { return cacheKeyCollection.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            try
            {
                string val = "";
                return cacheKeyCollection.TryRemove(item.Key, out val);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return cacheKeyCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        
        }
    }
}
