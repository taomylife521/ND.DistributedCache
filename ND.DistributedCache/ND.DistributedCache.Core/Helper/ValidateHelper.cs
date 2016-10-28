using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：ValidateHelper.CS        
// 功能描述(Description)：     
// 作者(Author)：Administrator               
// 日期(Create Date)： 2016/6/24 13:38:41         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2016/6/24 13:38:41          
//             修改理由：         
//**********************************************************************
namespace ND.DistributedCache.Core.Helper
{
   public class ValidateHelper
    {
        /// <summary>
        /// 检测网址是否有效
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CheckUrlValid(String url)
        {
            bool result = false;
            try
            {
                // Creates an HttpWebRequest for the specified URL.
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                // 有些网站会阻止程序访问，需要加入下面这句
                myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                myHttpWebRequest.Method = "GET";
                // Sends the HttpWebRequest and waits for a response.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                    result = true;   //Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}", myHttpWebResponse.StatusDescription);                
                myHttpWebResponse.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occured : {0}", e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
            return result;
        }

    }
}
