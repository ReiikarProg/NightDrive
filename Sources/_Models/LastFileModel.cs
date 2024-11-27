using Newtonsoft.Json;

namespace NightDrive._Models
{
    internal class LastFileModel
    {
        [JsonProperty("lastFileName")]
        public string LastFileName { get; set; }

        [JsonProperty("lastFileLocation")]
        public string LastFileLocation { get; set; }

        [JsonProperty("lastFileFormat")]
        public string LastFileFormat { get; set; }

        [JsonProperty("lastFileEncoding")]
        public string LastFileEncoding { get; set; }
    }
}
