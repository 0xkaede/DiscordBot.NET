using System.IO;
using System.Net;

namespace DiscordBot.Utilities
{
    internal class FortniteApi
    {
        public static string FortniteApi_v1 = "https://fortnite-api.com/v1/";
        public static string FortniteApi_v2 = "https://fortnite-api.com/v2/";

        public static string FortniteApi_Auth = File.ReadAllText(Path.GetTempPath() + "SALKDH892.KAEDE");

        public static string GetStats(string username, string accountType = "epic", string timeWindow = "lifetime", string image = "all")
        {
            Logs.ReqAPI("Making GET request to " + $"{FortniteApi_v2}stats/br/v2?name={username}&image={image}");

            var webRequest = WebRequest.Create($"{FortniteApi_v2}stats/br/v2?name={username}&image={image}");
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("x-api-key", FortniteApi_Auth);

            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static string GetCreatorCode(string username)
        {
            Logs.ReqAPI("Making GET request to " + $"{FortniteApi_v2}creatorcode?name={username}");

            var webRequest = WebRequest.Create($"{FortniteApi_v2}creatorcode?name={username}");
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("x-api-key", FortniteApi_Auth);

            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static string GetNews()
        {
            Logs.ReqAPI("Making GET request to " + $"{FortniteApi_v2}news/br");

            var webRequest = WebRequest.Create($"{FortniteApi_v2}news/br");
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("x-api-key", FortniteApi_Auth);

            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static string GetMap()
        {
            Logs.ReqAPI("Making GET request to " + $"{FortniteApi_v1}map");

            var webRequest = System.Net.WebRequest.Create($"{FortniteApi_v1}map");
            webRequest.Method = "GET";
            webRequest.Timeout = 12000;
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("x-api-key", FortniteApi_Auth);

            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
