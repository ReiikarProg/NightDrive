using System;
using System.Collections.Generic;
using System.Linq;
using NightDrive.Enums;
using NightDrive.Helpers;

namespace NightDrive
{
    public partial class MainForm
    {
        /// <summary>
        /// Add a new column to the data grid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddColumnOnClick(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, $"Adding a new column to the data grid view {this.DataGridView.ColumnCount} => {this.DataGridView.ColumnCount + 1}");

            this.DataGridView.Columns.Add("newColumn", "nouveau");
        }

        /// <summary>
        /// Add a new line to the data grid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRowOnClick(object sender, EventArgs e)
        {
            Logger.Log(LogLevel.Info, $"Adding a new row to the data grid view {this.DataGridView.RowCount} => {this.DataGridView.RowCount + 1}");

            this.DataGridView.Rows.Add("");
        }
    }
}
