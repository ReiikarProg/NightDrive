﻿using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using NightDrive.Enums;
using System.Drawing;
using System.Collections.Generic;
using NightDrive._Models;

namespace NightDrive._Helpers
{
    public static class Tools
    {
        /// <summary>
        /// Intermediate method used in the Fill action.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="stackPoint"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="oldColor"></param>
        /// <param name="newColor"></param>
        public static void Validate(Bitmap bitmap, Stack<Point> stackPoint, int x, int y, Color oldColor, Color newColor)
        {
            Color color = bitmap.GetPixel(x, y);

            // Only proceed same color
            if (color == oldColor)
            {
                stackPoint.Push(new Point(x, y));
                bitmap.SetPixel(x, y, newColor);
            }
        }

        /// <summary>
        /// Get currently set data in the data grid view and return a model to be serialized.
        /// </summary>
        /// 
        /// <returns>GridEditorModel to serialize before saving.</returns>
        public static GridEditorModel GetGridDataToSave(DataGridView grid)
        {
            Logger.Log(LogLevel.Info, $"Preparing data grid object before saving");

            GridEditorModel model = new()
            {
                RowCount = grid.RowCount,
                ColumnCount = grid.ColumnCount,
            };

            // A list of several columns
            List<GridEditorColumnModel> columnList = new();

            // Create a GridEditorColumnModel for each column in the Grid
            foreach (DataGridViewColumn c in grid.Columns)
            {
                // List of row values for that column
                List<string> dataList = new();

                // Current column object
                GridEditorColumnModel currentColumn = new()
                {
                    Id = c.Index,
                    HeaderName = c.HeaderText,
                    RowNumber = model.RowCount
                };

                // Loop all rows 
                foreach (DataGridViewRow row in grid.Rows)
                {
                    dataList.Add(row.Cells[currentColumn.Id].Value?.ToString() ?? string.Empty);
                }

                // Add data to the column object
                currentColumn.DataList = dataList;

                // Add column to the column list
                columnList.Add(currentColumn);
            }

            // Add column list to the final model
            model.ColumnList = columnList;

            Logger.Log(LogLevel.Info, $"GridModel to save: {model}");

            return model;
        }

        /// <summary>
        /// Enables a context menu on a given RichTextBox/
        /// </summary>
        /// <param name="richTextBox"></param>
        public static void EnableContextMenu(this RichTextBox richTextBox)
        {
            if (richTextBox.ContextMenuStrip == null)
            {
                // CreateEmptyFile a ContextMenuStrip without icons
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;

                // 1. Add the Undo option
                ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Annuler");
                tsmiUndo.Click += (sender, e) => richTextBox.Undo();
                cms.Items.Add(tsmiUndo);

                // 2. Add the Redo option
                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Réappliquer");
                tsmiRedo.Click += (sender, e) => richTextBox.Redo();
                cms.Items.Add(tsmiRedo);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 3. Add the Cut option (cuts the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Couper");
                tsmiCut.Click += (sender, e) => richTextBox.Cut();
                cms.Items.Add(tsmiCut);

                // 4. Add the Copy option (copies the selected text inside the richtextbox)
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copier");
                tsmiCopy.Click += (sender, e) => richTextBox.Copy();
                cms.Items.Add(tsmiCopy);

                // 5. Add the Paste option (adds the text from the clipboard into the richtextbox)
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Coller");
                tsmiPaste.Click += (sender, e) => richTextBox.Paste();
                cms.Items.Add(tsmiPaste);

                // 6. Add the Delete Option (remove the selected text in the richtextbox)
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Supprimer");
                tsmiDelete.Click += (sender, e) => richTextBox.SelectedText = "";
                cms.Items.Add(tsmiDelete);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 7. Add the Select All Option (selects all the text inside the richtextbox)
                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Selectionner tout");
                tsmiSelectAll.Click += (sender, e) => richTextBox.SelectAll();
                cms.Items.Add(tsmiSelectAll);

                // When opening the menu, check if the condition is fulfilled 
                // in order to enable the action
                cms.Opening += (sender, e) =>
                {
                    tsmiUndo.Enabled = !richTextBox.ReadOnly && richTextBox.CanUndo;
                    tsmiRedo.Enabled = !richTextBox.ReadOnly && richTextBox.CanRedo;
                    tsmiCut.Enabled = !richTextBox.ReadOnly && richTextBox.SelectionLength > 0;
                    tsmiCopy.Enabled = richTextBox.SelectionLength > 0;
                    tsmiPaste.Enabled = !richTextBox.ReadOnly && Clipboard.ContainsText();
                    tsmiDelete.Enabled = !richTextBox.ReadOnly && richTextBox.SelectionLength > 0;
                    tsmiSelectAll.Enabled = richTextBox.TextLength > 0 && richTextBox.SelectionLength < richTextBox.TextLength;
                };

                richTextBox.ContextMenuStrip = cms;
            }
        }

        /// <summary>
        /// Update the header of the app with respect to the CurrentFile.
        /// </summary>
        /// <param name="form"></param>
        public static void UpdateHeader(this MainForm form)
        {
            form.Text = Assembly.GetEntryAssembly()?.GetName().Name + " - " + form.CurrentFile.AbsolutePath +
                        (form.CurrentFile.IsSaved ? "" : "*");
        }

        /// <summary>
        /// Update labels located at the bottom of the window.
        /// </summary>
        /// <param name="form"></param>
        /// <exception cref="Exception"></exception>
        public static void UpdateFootNotes(this MainForm form)
        {
            // File format label
            form.FileFormatLabel.Text = form.CurrentFile.Format switch
            {
                FileFormat.Text => "Normal text file",
                FileFormat.RichText => "Rich text file",
                FileFormat.Image => "Image file",
                FileFormat.Grid => "Grid view file",
                _ => throw new Exception("Unsupported file format")
            };

            // File encoding label
            form.FileEncodingLabel.Text = form.CurrentFile.Encoding switch
            {
                FileEncoding.Utf8 => "UTF-8",
                FileEncoding.Unicode => "Unicode",
                FileEncoding.Ascii => "ASCII",
                FileEncoding.None => "***",
                _ => throw new Exception("Unsupported file encoding")
            };
        }

        /// <summary>
        /// Converter FileEncoding -> Encoding
        /// </summary>
        public static Encoding GetEncodingFromEnumFileEncoding(FileEncoding fileEncoding)
        {
           return  fileEncoding switch
            {
                FileEncoding.Utf8 => Encoding.UTF8,
                FileEncoding.Unicode => Encoding.Unicode,
                FileEncoding.Ascii => Encoding.ASCII,
                FileEncoding.None => Encoding.UTF8,        // default value for image files
                _ => throw new Exception($"Unsupported text encoding")
            };
        }

        /// <summary>
        /// Converter Encoding -> FileEncoding
        /// </summary>
        public static FileEncoding GetFileEncodingEnumFromEncoding(Encoding encoding)
        {
            return encoding switch
            {
                UTF8Encoding => FileEncoding.Utf8,
                UnicodeEncoding => FileEncoding.Unicode,
                ASCIIEncoding => FileEncoding.Ascii,
                _ => throw new Exception($"Unsupported text encoding: {encoding.EncodingName}")
            };
        }
    }
}
