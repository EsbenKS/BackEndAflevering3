using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Google.Cloud.Translation.V2;


namespace AfleveringUge8.Util
{
    public class GoogleTranslate
    {
        public string TranslateText(string input, string targetLanguage)

        {
            var toLanguage = targetLanguage;
            var fromLanguage = "da";//danish (Could have been a parm....  
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
      
    }
}








