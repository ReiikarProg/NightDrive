using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NightDrive._Helpers;
using NightDrive._Helpers.Interface;
using NightDrive._Models;
using NightDrive.Enums;

namespace NightDrive
{
    public partial class MainForm
    {
        /// <summary>
        ///  DefaultColumn number to be used when creating a new grid file.
        /// </summary>
        private const int DefaultColumnNumber = 3;

        /// <summary>
        /// Init all components related to the data grid view editor with a default empty grid.
        /// </summary>
        ///
        /// <param name="columnNumber">Default number of column to create, 3 by default</param>
        private void InitializeDataGridEditor(int columnNumber = MainForm.DefaultColumnNumber)
        {
            // Location & size
            this.DataGridView.Size = new Size(760, 479);
            this.DataGridView.Location = new Point(12, 57); 
            this.DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Clear all columns
            this.DataGridView.Columns.Clear();

            // Create new columns
            for (int i = 1; i <= columnNumber; i++)
            {
                this.DataGridView.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = $"Colonne {i}", 
                    Name = $"column{i}", 
                    SortMode = DataGridViewColumnSortMode.NotSortable, 
                    Selected = false
                });
            }

            // Switch selection mode to full column
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            // Allow the possibility to write multi lines
            foreach (DataGridViewColumn col in this.DataGridView.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        /// <summary>
        /// Init all components related to the data grid view editor with the given grid model.
        /// </summary>
        /// 
        /// <param name="model"></param>
        internal void InitializeDataGridEditor(GridEditorModel model)
        {
            Logger.Log(LogLevel.Info, $"Init DataGridView with {model.ColumnCount} columns and {model.RowCount} rows...");
            
            // Location & size
            this.DataGridView.Size = new Size(760, 479);
            this.DataGridView.Location = new Point(12, 57);
            this.DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Clear all columns
            this.DataGridView.Columns.Clear();

            // Create columns
            for (int i = 0; i < model.ColumnCount; i++)
            {
                GridEditorColumnModel currentColumn = model.ColumnList[i];

                Logger.Log(LogLevel.Info, $"Setting column {i} with name \"{currentColumn.HeaderName}\"");

                // Create the Column 
                this.DataGridView.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = currentColumn.HeaderName,
                    Name = $"column{i}",
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Selected = false
                });
            }

            // Create rows (there's one by default, so create one less than planned)
            for (int i = 1; i < model.RowCount; i++)
            {
                // Create the Column 
                this.DataGridView.Rows.Add(new DataGridViewRow()
                {
                    Selected = false
                });
            }

            /* Populate cells */

            // Loop columns
            for (int i = 0; i < model.ColumnCount; i++)
            {
                // Data of the column number i, which should have same length as the row number
                List<string> currentList = model.ColumnList[i].DataList;

                // Loop rows
                for (int j = 0; j < model.RowCount; j++)
                {
                    this.DataGridView.Rows[j].Cells[i].Value = currentList[j];
                }
            }

            // Allow the possibility to write multi lines
            foreach (DataGridViewColumn col in this.DataGridView.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
    }
}
