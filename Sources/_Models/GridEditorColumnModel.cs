using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NightDrive._Models
{
    /// <summary>
    /// Represents a model for a data grid view column object
    /// </summary>
    public class GridEditorColumnModel
    {
        /// <summary>
        /// Index of the current column in the whole grid.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Header name of the column.
        /// </summary>
        [JsonProperty("header-name")]
        public string HeaderName { get; set; }

        /// <summary>
        /// Number of row in the given 
        /// </summary>
        [JsonProperty("row-number")]
        public int RowNumber { get; set; }

        /// <summary>
        /// Contains data of the given row.
        /// </summary>
        [JsonProperty("data-list")]
        public List<string> DataList { get; set; }
    }
}
