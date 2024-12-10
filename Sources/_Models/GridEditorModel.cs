using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NightDrive._Models
{
    public class GridEditorModel
    {
        /// <summary>
        /// Column number of the data grid.
        /// </summary>
        [JsonProperty("column-count")]
        public int ColumnCount { get; set; }

        /// <summary>
        /// Row number of the data grid.
        /// </summary>
        [JsonProperty("row-count")]
        public int RowCount { get; set; }

        /// <summary>
        /// List of column objects.
        /// </summary>
        [JsonProperty("column-list")]
        public List<GridEditorColumnModel> ColumnList { get; set; }
    }
}
