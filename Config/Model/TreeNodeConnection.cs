using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Config.Model
{
    [Serializable]
    public class TreeNodeConnection : TreeNode
    {
        public TreeNodeConnection()
        {

        }

        public TreeNodeConnection(SerializationInfo info, StreamingContext context) : base(info, context) {

        }

        public TreeNodeConnection(string text, int imageIndex, int selectedImageIndex)
        {
            this.Text = text;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImageIndex;
        }

        public TreeNodeConnection(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
        {
            this.Text = text;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImageIndex;
            this.Nodes.AddRange(children);
        }

        private string _description;
        private string _connection;

        [CategoryAttribute("Settings"), DescriptionAttribute("Description of the Database")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        //[CategoryAttribute("Settings"), DescriptionAttribute("Type of the Database"), Bindable(false)]
        public int Type;

        [CategoryAttribute("Settings"), DescriptionAttribute("Connection of the Database")]
        public string Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        [Browsable(false)]
        public virtual ContextMenu ContextMenu { get; set; }

        [Browsable(false)]
        public virtual ContextMenuStrip ContextMenuStrip { get; set; }

        [Browsable(false)]
        public bool Checked { get; set; }

        [Browsable(false)]
        public string ImageKey { get; set; }

        [Browsable(false)]
        public int Index { get; }

        [Browsable(false)]
        public string Name { get; set; }

        [Browsable(false)]
        public Font NodeFont { get; set; }
        
        [Browsable(false)]
        public string SelectedImageKey { get; set; }

        [Browsable(false)]
        public int StateImageIndex { get; set; }

        [Browsable(false)]
        public string StateImageKey { get; set; }

        [Browsable(false)]
        public object Tag { get; set; }

        [Browsable(false)]
        public string ToolTipText { get; set; }

        [Browsable(false)]
        public Color BackColor { get; set; }

        [Browsable(false)]
        public Color ForeColor { get; set; }

        //[Browsable(false)]
        //public  int ImageIndex { get; set; }

        //[Browsable(false)]
        //public int SelectedImageIndex { get; set; }
    }
}
