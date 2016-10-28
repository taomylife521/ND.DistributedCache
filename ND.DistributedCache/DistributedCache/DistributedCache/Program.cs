using ND.DistributedCache.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
           // for (int i = 100001; i < 100; i++)
           // {
                //CacheManger.Instance.SetValue(i.ToString(), i.ToString());
           // }

            Console.WriteLine(DateTime.Now.ToString("yyMMdd"));
            CacheManger.Instance.SetValue("10003", "123");
            CacheManger.Instance.SetValue("10004", "123");
            //A a = new A();
            //bool o = CacheManger.Instance.TryGetValue("10003",out a);
            //Console.WriteLine(JsonConvert.SerializeObject(a));
            //st.Stop();
            //Console.WriteLine("写入完成:耗时:"+st.ElapsedMilliseconds/1000);
            Console.ReadKey();
           // CacheManger.Instance.SetValue();
        }
    }
  
}
