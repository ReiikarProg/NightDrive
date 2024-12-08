using Newtonsoft.Json;

namespace NightDrive._Models
{
    internal class GridEditorModel
    {
        /// <summary>
        /// Column number of the data grid
        /// </summary>
        [JsonProperty("ColumnCount")]
        public string ColumnCount { get; set; }

        /// <summary>
        /// Row number of the data grid
        /// </summary>
        [JsonProperty("RowCount")]
        public string RowCount { get; set; }
    }
}
