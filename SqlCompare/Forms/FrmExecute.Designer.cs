using System.Windows.Forms;

namespace SqlCompare
{
    partial class FrmExecute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary> 
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExecute));
            this.openFileImport = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bangCompareTwoFileBackupDifferent = new System.Windows.Forms.DataGridView();
            this.bangResultCompareFileBackup = new System.Windows.Forms.DataGridView();
            this.menuStripCompare = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMultiSync = new System.Windows.Forms.Button();
            this.txtExecute = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lblSync = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bangCompareTwoFileBackupDifferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareFileBackup)).BeginInit();
            this.menuStripCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExecute)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bangCompareTwoFileBackupDifferent
            // 
            this.bangCompareTwoFileBackupDifferent.AllowUserToAddRows = false;
            this.bangCompareTwoFileBackupDifferent.AllowUserToDeleteRows = false;
            this.bangCompareTwoFileBackupDifferent.AllowUserToResizeColumns = false;
            this.bangCompareTwoFileBackupDifferent.AllowUserToResizeRows = false;
            this.bangCompareTwoFileBackupDifferent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bangCompareTwoFileBackupDifferent.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bangCompareTwoFileBackupDifferent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bangCompareTwoFileBackupDifferent.Location = new System.Drawing.Point(111, 27);
            this.bangCompareTwoFileBackupDifferent.Name = "bangCompareTwoFileBackupDifferent";
            this.bangCompareTwoFileBackupDifferent.RowHeadersVisible = false;
            this.bangCompareTwoFileBackupDifferent.Size = new System.Drawing.Size(212, 105);
            this.bangCompareTwoFileBackupDifferent.TabIndex = 3;
            // 
            // bangResultCompareFileBackup
            // 
            this.bangResultCompareFileBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangResultCompareFileBackup.Location = new System.Drawing.Point(0, 0);
            this.bangResultCompareFileBackup.Name = "bangResultCompareFileBackup";
            this.bangResultCompareFileBackup.ReadOnly = true;
            this.bangResultCompareFileBackup.RowHeadersVisible = false;
            this.bangResultCompareFileBackup.Size = new System.Drawing.Size(770, 294);
            this.bangResultCompareFileBackup.TabIndex = 20;
            // 
            // menuStripCompare
            // 
            this.menuStripCompare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.copyCodeToolStripMenuItem,
            this.copyNameToolStripMenuItem,
            this.syncColumnToolStripMenuItem});
            this.menuStripCompare.Name = "contextMenuStripCompare";
            this.menuStripCompare.Size = new System.Drawing.Size(146, 92);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // copyCodeToolStripMenuItem
            // 
            this.copyCodeToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.Copy;
            this.copyCodeToolStripMenuItem.Name = "copyCodeToolStripMenuItem";
            this.copyCodeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyCodeToolStripMenuItem.Text = "Copy Code";
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.save;
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            // 
            // syncColumnToolStripMenuItem
            // 
            this.syncColumnToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.sync;
            this.syncColumnToolStripMenuItem.Name = "syncColumnToolStripMenuItem";
            this.syncColumnToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.syncColumnToolStripMenuItem.Text = "Sync Column";
            // 
            // btnMultiSync
            // 
            this.btnMultiSync.ForeColor = System.Drawing.Color.Black;
            this.btnMultiSync.Location = new System.Drawing.Point(35, 446);
            this.btnMultiSync.Name = "btnMultiSync";
            this.btnMultiSync.Size = new System.Drawing.Size(74, 23);
            this.btnMultiSync.TabIndex = 18;
            this.btnMultiSync.Text = "Execute";
            this.btnMultiSync.UseVisualStyleBackColor = true;
            this.btnMultiSync.Click += new System.EventHandler(this.btnMultiSync_Click);
            // 
            // txtExecute
            // 
            this.txtExecute.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtExecute.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtExecute.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtExecute.BackBrush = null;
            this.txtExecute.CharHeight = 14;
            this.txtExecute.CharWidth = 8;
            this.txtExecute.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExecute.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtExecute.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtExecute.IsReplaceMode = false;
            this.txtExecute.Location = new System.Drawing.Point(35, 53);
            this.txtExecute.Name = "txtExecute";
            this.txtExecute.Paddings = new System.Windows.Forms.Padding(0);
            this.txtExecute.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtExecute.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtExecute.ServiceColors")));
            this.txtExecute.Size = new System.Drawing.Size(653, 376);
            this.txtExecute.TabIndex = 2;
            this.txtExecute.Zoom = 100;
            // 
            // lblSync
            // 
            this.lblSync.AutoSize = true;
            this.lblSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSync.Location = new System.Drawing.Point(32, 23);
            this.lblSync.Name = "lblSync";
            this.lblSync.Size = new System.Drawing.Size(112, 16);
            this.lblSync.TabIndex = 19;
            this.lblSync.Text = "Sync table to A";
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(115, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(741, 489);
            this.Controls.Add(this.lblSync);
            this.Controls.Add(this.txtExecute);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMultiSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmExecute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compare Database";
            ((System.ComponentModel.ISupportInitialize)(this.bangCompareTwoFileBackupDifferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareFileBackup)).EndInit();
            this.menuStripCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtExecute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileImport;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView bangResultCompareFileBackup;
        private System.Windows.Forms.DataGridView bangCompareTwoFileBackupDifferent;
        private System.Windows.Forms.ContextMenuStrip menuStripCompare;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
        private System.Windows.Forms.Button btnMultiSync;
        private FastColoredTextBoxNS.FastColoredTextBox txtExecute;
        private ToolStripMenuItem syncColumnToolStripMenuItem;
        private Label lblSync;
        private Button btnClose;
    }
}