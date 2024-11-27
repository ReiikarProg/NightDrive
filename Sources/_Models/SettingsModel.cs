using Newtonsoft.Json;
using NightDrive.Enums;

namespace NightDrive._Models
{
    internal class SettingsModel
    {
        [JsonProperty("themeColor")]
        public Theme ThemeColor { get; set; }
    }
}
