using System;
using System.IO;
using System.Net;

namespace DiscordBot.Utilities
{
    public class ApexApi
    {
        public static string Main_URL = "https://api.mozambiquehe.re/";

        public static string auth = File.ReadAllText(Path.GetTempPath() + "SALKDH891.KAEDE");

        public static string MapRotation = $"maprotation?version={Version}&auth={auth}";

        public static string Version = "5";

        public static string GetData(string api)
        {
            try
            {
                Logs.ReqAPI("Making GET request to " + api);
                WebClient WB = new WebClient();
                return WB.DownloadString(api);
            }
            catch (Exception ex)
            {
                return "";
            }

        }

    }
}
