
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskPlatform.TaskInterface;

namespace ND.DistributedCache.Task
{
    /// <summary>
    /// 清空分布式缓存任务
    /// </summary>
    public class ClearDistributedCacheTask:AbstractTask
    {
        /// <summary>
        /// 运行任务
        /// </summary>
        /// <returns></returns>
        public override RunTaskResult RunTask()
        {
            RunTaskResult res = new RunTaskResult();
            HttpClient client = new HttpClient();
            
            return res;
        }

        /// <summary>
        /// 任务描述
        /// </summary>
        /// <returns></returns>
        public override string TaskDescription()
        {
            return "实时清除分布式缓存的任务和删除过期集合";
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        /// <returns></returns>
        public override string TaskName()
        {
            return "ClearDistributedCacheTask";
        }
        public override Dictionary<string, string> UploadConfig()
        {
            if (!base.CustomConfig.ContainsKey("flightTestUrl"))
            {
                base.CustomConfig["flightTestUrl"] = "http://flightapi.nidingtravel.com/index.html";
            }
            if (!base.CustomConfig.ContainsKey("baseTestUrl"))
            {
                base.CustomConfig["baseTestUrl"] = "http://baseapi.nidingtravel.com/index.html";
            }
            if (!base.CustomConfig.ContainsKey("hotelTestUrl"))
            {
                base.CustomConfig["hotelTestUrl"] = "http://hotelapi.nidingtravel.com/index.html";
            }
            if (!base.CustomConfig.ContainsKey("travelTestUrl"))
            {
                base.CustomConfig["travelTestUrl"] = "http://travelapi.nidingtravel.com/index.html";
            }

            if (!base.CustomConfig.ContainsKey("flightUrl"))
            {
                base.CustomConfig["flightUrl"] = "http://flightapi.niding.net/index.html";
            }
            if (!base.CustomConfig.ContainsKey("baseUrl"))
            {
                base.CustomConfig["baseUrl"] = "http://baseapi.niding.net/index.html";
            }
           
            if (!base.CustomConfig.ContainsKey("hotelUrl"))
            {
                base.CustomConfig["hotelUrl"] = "http://hotelapi.niding.net/index.html";
            }
            if (!base.CustomConfig.ContainsKey("travelUrl"))
            {
                base.CustomConfig["travelUrl"] = "http://travelapi.niding.net/index.html";
            }

            if (!base.CustomConfig.ContainsKey("publicKey"))
            {
                base.CustomConfig["publicKey"] = "http://travelapi.niding.net/index.html";
            }
            if (!base.CustomConfig.ContainsKey("privateKey"))
            {
                base.CustomConfig["privateKey"] = "http://travelapi.niding.net/index.html";
            }
            if (!base.CustomConfig.ContainsKey("publicTestKey"))
            {
                base.CustomConfig["publicTestKey"] = "http://travelapi.niding.net/index.html";
            }
            if (!base.CustomConfig.ContainsKey("privateTestKey"))
            {
                base.CustomConfig["privateTestKey"] = "http://travelapi.niding.net/index.html";
            }
            return base.UploadConfig();
        }

       

       

        
         
    }
}
