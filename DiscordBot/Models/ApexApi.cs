using Newtonsoft.Json;

namespace DiscordBot.Models
{
    public class MapRotation
    {
        [JsonProperty("battle_royale")]
        public BattleRroyale battle_royale { get; set; }
    }

    public class BattleRroyale
    {
        [JsonProperty("current")]
        public Current current { get; set; }

        [JsonProperty("next")]
        public Next next { get; set; }
    }

    public class Current
    {
        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("readableDate_start")]
        public string readableDate_start { get; set; }

        [JsonProperty("readableDate_end")]
        public string readableDate_end { get; set; }

        [JsonProperty("map")]
        public string map { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("DurationInSecs")]
        public string DurationInSecs { get; set; }

        [JsonProperty("DurationInMinutes")]
        public string DurationInMinutes { get; set; }

        [JsonProperty("asset")]
        public string asset { get; set; }

        [JsonProperty("remainingSecs")]
        public string remainingSecs { get; set; }

        [JsonProperty("remainingMins")]
        public string remainingMins { get; set; }

        [JsonProperty("remainingTimer")]
        public string remainingTimer { get; set; }
    }

    public class Next
    {
        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("readableDate_start")]
        public string readableDate_start { get; set; }

        [JsonProperty("readableDate_end")]
        public string readableDate_end { get; set; }

        [JsonProperty("map")]
        public string map { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("DurationInSecs")]
        public string DurationInSecs { get; set; }

        [JsonProperty("DurationInMinutes")]
        public string DurationInMinutes { get; set; }
    }
}
