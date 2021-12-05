using DiffPlex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Config.BLL
{
    public static class Extension
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void AppendText(this RichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void AppendText(this RichTextBox box, string text, Color color, Color backColor)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionBackColor = backColor;
            box.AppendText(text);
            //box.SelectionColor = box.ForeColor;

            //box.Select(box.GetFirstCharIndexFromLine(box.Lines.Count()-1), findText.Length);
            //box.SelectionColor = Color.Red;

            var index1 = box.GetFirstCharIndexFromLine(0);
            var index2 = box.GetFirstCharIndexFromLine(1);
            var index3 = box.GetFirstCharIndexFromLine(2);
        }


        public static void AppendText(this RichTextBox box, string text, Color color, Color backColor, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionBackColor = backColor;
            //box.Selection = backColor;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void AddRow(this DataGridView bang, Color color, Color backColor, string position, string value)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.ForeColor = color;
            row.DefaultCellStyle.BackColor = backColor;
            addCellPosition(row, position);
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = value });
            bang.Rows.Add(row);
        }

        public static void addCellPosition(DataGridViewRow row, string position)
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            cell.Value = position;
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells.Add(cell);
        }

        public static void AddRow(this DataGridView bang, string position, string value)
        {
            DataGridViewRow row = new DataGridViewRow();
            addCellPosition(row, position);
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = value });
            bang.Rows.Add(row);
        }

        public static void AddRow(this DataGridView box, string text, Color color, Color backColor, string position, string value)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.DefaultCellStyle.ForeColor = color;
            row.DefaultCellStyle.BackColor = backColor;
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = position });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = value });
            box.Rows.Add(row);
        }

        public static void AddText(this DataGridView bang, ChangeType changeType, string position, string value)
        {
            if (changeType == DiffPlex.ChangeType.Deleted)
            {
                bang.AddRow(Color.Black, Color.FromArgb(255, 200, 100), position, value);
            }
            else if (changeType == DiffPlex.ChangeType.Imaginary)
            {
                bang.AddRow(Color.Black, Color.FromArgb(200, 200, 200), position, value);
            }
            else if (changeType == DiffPlex.ChangeType.Unchanged)
            {
                bang.AddRow(position, value);
            }
            else if (changeType == DiffPlex.ChangeType.Inserted)
            {
                bang.AddRow(Color.Black, Color.FromArgb(255, 255, 0), position, value);
            }
            else if (changeType == DiffPlex.ChangeType.Modified)
            {
                bang.AddRow(Color.Black, Color.FromArgb(220, 220, 255), position, value);
            }
        }

        public static void setDataSource(this DataGridView bang, Object obj)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = obj;
            bang.DataSource = bs;
        }

        public static void setDataSource(this ComboBox bang, Object obj, string displayName = "")
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = obj;
            bang.DataSource = bs;
            if (!string.IsNullOrWhiteSpace(displayName))
            {
                bang.DisplayMember = "Name";
            }
        }

        public static IEnumerable<T> GetControlsOfType<T>(Control root) where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as ContainerControl;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }

        public static List<Control> GetListControls(this Control.ControlCollection formControls, Type type)
        {
            List<Control> listControls = new List<Control>();
            FindControlsOfType(type, formControls, ref listControls);
            return listControls;
        }

        public static void FindControlsOfType(Type type, Control.ControlCollection formControls, ref List<Control> controls)
        {
            foreach (Control control in formControls)
            {
                if (control.GetType() == type)
                    controls.Add(control);
                if (control.Controls.Count > 0)
                    FindControlsOfType(type, control.Controls, ref controls);
            }
        }

        public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
        where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
