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
    public class GoogleTranslate2
    {
        
        public string TranslateText()
        {
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(
                text: "Hello World.",
                targetLanguage: "ru",  // Russian
                sourceLanguage: "en");  // English
            Console.WriteLine(response.TranslatedText);
            return response.TranslatedText;
        }
    }
}








