using Newtonsoft.Json;

namespace DiscordBot.Models.FortniteApi
{
    public class Main
    {
        [JsonProperty("status")]
        public int status { get; set; }

        [JsonProperty("data")]
        public Data data { get; set; }
    }

    public class Data
    {
        [JsonProperty("account")]
        public Account account { get; set; }

        [JsonProperty("battlePass")]
        public BattlePass battlePass { get; set; }

        [JsonProperty("images")]
        public Images images { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("verified")]
        public string verified { get; set; }
    }

    public class Images
    {
        [JsonProperty("blank")]
        public string blank { get; set; }

        [JsonProperty("pois")]
        public string pois { get; set; }
    }

    public class Account
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class BattlePass
    {
        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("progress")]
        public string progress { get; set; }
    }
}
