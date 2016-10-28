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
// 日期(Create Date)： 2016/4/18 16:12:10         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/4/18 16:12:10          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core
{
    /// <summary>
    /// key map集合
    /// </summary>
    public class CacheKeyMapCollection : IList<CacheKeyMapDescriptor>
    {
        private ConcurrentBag<CacheKeyMapDescriptor> mapList = new ConcurrentBag<CacheKeyMapDescriptor>();
        public int IndexOf(CacheKeyMapDescriptor item)
        {
            return mapList.ToList().IndexOf(item);
        }

        public void Insert(int index, CacheKeyMapDescriptor item)
        {
            mapList.ToList().Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            mapList.ToList().RemoveAt(index);
        }

        public CacheKeyMapDescriptor this[int index]
        {
            get
            {
               return mapList.ToList()[index];
            }
            set
            {
                mapList.ToList()[index] = value;
            }
        }

        public void Add(CacheKeyMapDescriptor item)
        {
            mapList.Add(item);
        }

        public void Clear()
        {
            mapList.ToList().Clear();
        }

        public bool Contains(CacheKeyMapDescriptor item)
        {
            return mapList.Contains(item);
        }

        public void CopyTo(CacheKeyMapDescriptor[] array, int arrayIndex)
        {
            mapList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return mapList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(CacheKeyMapDescriptor item)
        {
            return mapList.ToList().Remove(item);
        }

        public IEnumerator<CacheKeyMapDescriptor> GetEnumerator()
        {
            return mapList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
