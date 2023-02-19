using System.Collections.Specialized;
using System.Configuration;

namespace Zoo
{
    public class Config
    {
        private static readonly NameValueCollection AppSettings = ConfigurationManager.AppSettings;
        public static readonly string LOG_PATH = AppSettings["LogFile"];
        public static readonly string JSON_PATH = AppSettings["JsonFiles"];
        public static readonly string XML_PATH = AppSettings["XmlFiles"];
        public static readonly string ERROR_TXT = AppSettings["ErrorText"];
    }
}