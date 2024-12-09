using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NightDrive.Enums;
using NightDrive._Helpers;

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

            // If the SelectionMode is not cell select, we won't be able to add a new one
            if (this.DataGridView.SelectionMode != DataGridViewSelectionMode.CellSelect)
            {
                this.DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }

            // Create the new column object (Textbox one)
            DataGridViewColumn newColumn = new ();
            newColumn.HeaderText = CustomDialogBox.ShowTextBoxToUser("Merci de saisir le nom de votre nouvelle colonne"); ;
            newColumn.Name = "newColumn";
            newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            newColumn.Selected = false;
            newColumn.CellTemplate = new DataGridViewTextBoxCell();

            // Add the column
            this.DataGridView.Columns.Add(newColumn);

            // Set back the selection mode from column header
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
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

        /// <summary>
        /// Deleted selected columns from the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteColumnOnClick(object sender, EventArgs e)
        {
            if (this.DataGridView.SelectedColumns.Count != 0)
            {
                Logger.Log(LogLevel.Info, $"Attempting to remove {this.DataGridView.SelectedColumns.Count} columns from the grid");

                foreach (DataGridViewColumn column in this.DataGridView.SelectedColumns)
                {
                    this.DataGridView.Columns.Remove(column);
                }
            }
            else
            {
                CustomDialogBox.ShowMessage("Please select columns to delete", CustomBoxIcon.Info, CustomBoxButton.Ok);
            }
        }

        private void DeleteRowOnClick(object sender, EventArgs e)
        {

        }
    }
}
