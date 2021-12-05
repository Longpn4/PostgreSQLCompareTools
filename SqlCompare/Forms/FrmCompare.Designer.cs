using System.Windows.Forms;

namespace SqlCompare
{
    partial class FrmCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompare));
            this.openFileImport = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bangCompareTwoFileBackupDifferent = new System.Windows.Forms.DataGridView();
            this.bangResultCompareFileBackup = new System.Windows.Forms.DataGridView();
            this.menuStripCompare = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainerCompareDetail = new System.Windows.Forms.SplitContainer();
            this.splitContainerTableCompare = new System.Windows.Forms.SplitContainer();
            this.btnCompareTwoDb = new System.Windows.Forms.Button();
            this.lblNoteSync = new System.Windows.Forms.Label();
            this.btnChangePositionCompare = new System.Windows.Forms.Button();
            this.btnMultiSync = new System.Windows.Forms.Button();
            this.bangCompare = new System.Windows.Forms.DataGridView();
            this.tabControlCompare = new System.Windows.Forms.TabControl();
            this.tabPageCompareDetail = new System.Windows.Forms.TabPage();
            this.txtCompareOnly = new FastColoredTextBoxNS.FastColoredTextBox();
            this.bangResultCompareDiffence = new System.Windows.Forms.DataGridView();
            this.tabPageSyncResult = new System.Windows.Forms.TabPage();
            this.txtSyncResult = new FastColoredTextBoxNS.FastColoredTextBox();
            this.syncColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bangCompareTwoFileBackupDifferent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareFileBackup)).BeginInit();
            this.menuStripCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCompareDetail)).BeginInit();
            this.splitContainerCompareDetail.Panel1.SuspendLayout();
            this.splitContainerCompareDetail.Panel2.SuspendLayout();
            this.splitContainerCompareDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTableCompare)).BeginInit();
            this.splitContainerTableCompare.Panel1.SuspendLayout();
            this.splitContainerTableCompare.Panel2.SuspendLayout();
            this.splitContainerTableCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bangCompare)).BeginInit();
            this.tabControlCompare.SuspendLayout();
            this.tabPageCompareDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompareOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareDiffence)).BeginInit();
            this.tabPageSyncResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncResult)).BeginInit();
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
            this.menuStripCompare.Size = new System.Drawing.Size(181, 114);
            // 
            // splitContainerCompareDetail
            // 
            this.splitContainerCompareDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerCompareDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCompareDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerCompareDetail.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCompareDetail.Name = "splitContainerCompareDetail";
            // 
            // splitContainerCompareDetail.Panel1
            // 
            this.splitContainerCompareDetail.Panel1.Controls.Add(this.splitContainerTableCompare);
            this.splitContainerCompareDetail.Panel1MinSize = 361;
            // 
            // splitContainerCompareDetail.Panel2
            // 
            this.splitContainerCompareDetail.Panel2.Controls.Add(this.tabControlCompare);
            this.splitContainerCompareDetail.Size = new System.Drawing.Size(1374, 827);
            this.splitContainerCompareDetail.SplitterDistance = 761;
            this.splitContainerCompareDetail.TabIndex = 22;
            // 
            // splitContainerTableCompare
            // 
            this.splitContainerTableCompare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerTableCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTableCompare.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTableCompare.IsSplitterFixed = true;
            this.splitContainerTableCompare.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTableCompare.Name = "splitContainerTableCompare";
            this.splitContainerTableCompare.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTableCompare.Panel1
            // 
            this.splitContainerTableCompare.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerTableCompare.Panel1.Controls.Add(this.btnCompareTwoDb);
            this.splitContainerTableCompare.Panel1.Controls.Add(this.lblNoteSync);
            this.splitContainerTableCompare.Panel1.Controls.Add(this.btnChangePositionCompare);
            this.splitContainerTableCompare.Panel1.Controls.Add(this.btnMultiSync);
            this.splitContainerTableCompare.Panel1MinSize = 0;
            // 
            // splitContainerTableCompare.Panel2
            // 
            this.splitContainerTableCompare.Panel2.Controls.Add(this.bangCompare);
            this.splitContainerTableCompare.Size = new System.Drawing.Size(761, 827);
            this.splitContainerTableCompare.SplitterDistance = 126;
            this.splitContainerTableCompare.TabIndex = 23;
            this.splitContainerTableCompare.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer5_SplitterMoved);
            // 
            // btnCompareTwoDb
            // 
            this.btnCompareTwoDb.ForeColor = System.Drawing.Color.Black;
            this.btnCompareTwoDb.Location = new System.Drawing.Point(28, 40);
            this.btnCompareTwoDb.Name = "btnCompareTwoDb";
            this.btnCompareTwoDb.Size = new System.Drawing.Size(116, 23);
            this.btnCompareTwoDb.TabIndex = 18;
            this.btnCompareTwoDb.Text = "Compare Two Db";
            this.btnCompareTwoDb.UseVisualStyleBackColor = true;
            this.btnCompareTwoDb.Click += new System.EventHandler(this.btnCompareTwoDb_Click);
            // 
            // lblNoteSync
            // 
            this.lblNoteSync.AutoSize = true;
            this.lblNoteSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteSync.ForeColor = System.Drawing.Color.Black;
            this.lblNoteSync.Location = new System.Drawing.Point(25, 79);
            this.lblNoteSync.Name = "lblNoteSync";
            this.lblNoteSync.Size = new System.Drawing.Size(430, 13);
            this.lblNoteSync.TabIndex = 23;
            this.lblNoteSync.Text = "Note: Double click vào \"=>\", \"<=\" để Sync Fuction, Table chỉ định hoặc dùng Sync " +
    "Multi";
            // 
            // btnChangePositionCompare
            // 
            this.btnChangePositionCompare.ForeColor = System.Drawing.Color.Black;
            this.btnChangePositionCompare.Location = new System.Drawing.Point(166, 40);
            this.btnChangePositionCompare.Name = "btnChangePositionCompare";
            this.btnChangePositionCompare.Size = new System.Drawing.Size(144, 23);
            this.btnChangePositionCompare.TabIndex = 18;
            this.btnChangePositionCompare.Text = "<= Swich Position =>";
            this.btnChangePositionCompare.UseVisualStyleBackColor = true;
            this.btnChangePositionCompare.Click += new System.EventHandler(this.btnChangePositionCompare_Click);
            // 
            // btnMultiSync
            // 
            this.btnMultiSync.ForeColor = System.Drawing.Color.Black;
            this.btnMultiSync.Location = new System.Drawing.Point(332, 40);
            this.btnMultiSync.Name = "btnMultiSync";
            this.btnMultiSync.Size = new System.Drawing.Size(91, 23);
            this.btnMultiSync.TabIndex = 18;
            this.btnMultiSync.Text = "Multi Sync";
            this.btnMultiSync.UseVisualStyleBackColor = true;
            this.btnMultiSync.Click += new System.EventHandler(this.btnMultiSync_Click);
            // 
            // bangCompare
            // 
            this.bangCompare.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.bangCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bangCompare.Location = new System.Drawing.Point(0, 0);
            this.bangCompare.Name = "bangCompare";
            this.bangCompare.ReadOnly = true;
            this.bangCompare.RowHeadersVisible = false;
            this.bangCompare.Size = new System.Drawing.Size(759, 695);
            this.bangCompare.TabIndex = 19;
            this.bangCompare.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bangCompareLeft_CellClick);
            this.bangCompare.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bangCompare_CellContentClick);
            this.bangCompare.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.bangCompare_CellContextMenuStripNeeded);
            this.bangCompare.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bangCompareLeft_CellDoubleClick);
            this.bangCompare.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bangCompare_MouseClick);
            // 
            // tabControlCompare
            // 
            this.tabControlCompare.Controls.Add(this.tabPageCompareDetail);
            this.tabControlCompare.Controls.Add(this.tabPageSyncResult);
            this.tabControlCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCompare.Location = new System.Drawing.Point(0, 0);
            this.tabControlCompare.Name = "tabControlCompare";
            this.tabControlCompare.SelectedIndex = 0;
            this.tabControlCompare.Size = new System.Drawing.Size(607, 825);
            this.tabControlCompare.TabIndex = 2;
            // 
            // tabPageCompareDetail
            // 
            this.tabPageCompareDetail.Controls.Add(this.txtCompareOnly);
            this.tabPageCompareDetail.Controls.Add(this.bangResultCompareDiffence);
            this.tabPageCompareDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompareDetail.Name = "tabPageCompareDetail";
            this.tabPageCompareDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompareDetail.Size = new System.Drawing.Size(599, 799);
            this.tabPageCompareDetail.TabIndex = 0;
            this.tabPageCompareDetail.Text = "Compare Detail";
            this.tabPageCompareDetail.UseVisualStyleBackColor = true;
            // 
            // txtCompareOnly
            // 
            this.txtCompareOnly.AutoCompleteBracketsList = new char[] {
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
            this.txtCompareOnly.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtCompareOnly.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtCompareOnly.BackBrush = null;
            this.txtCompareOnly.CharHeight = 14;
            this.txtCompareOnly.CharWidth = 8;
            this.txtCompareOnly.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompareOnly.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtCompareOnly.IsReplaceMode = false;
            this.txtCompareOnly.Location = new System.Drawing.Point(51, 32);
            this.txtCompareOnly.Name = "txtCompareOnly";
            this.txtCompareOnly.Paddings = new System.Windows.Forms.Padding(0);
            this.txtCompareOnly.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtCompareOnly.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtCompareOnly.ServiceColors")));
            this.txtCompareOnly.Size = new System.Drawing.Size(365, 226);
            this.txtCompareOnly.TabIndex = 2;
            this.txtCompareOnly.Zoom = 100;
            // 
            // bangResultCompareDiffence
            // 
            this.bangResultCompareDiffence.AllowUserToAddRows = false;
            this.bangResultCompareDiffence.AllowUserToDeleteRows = false;
            this.bangResultCompareDiffence.AllowUserToResizeColumns = false;
            this.bangResultCompareDiffence.AllowUserToResizeRows = false;
            this.bangResultCompareDiffence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bangResultCompareDiffence.BackgroundColor = System.Drawing.SystemColors.Window;
            this.bangResultCompareDiffence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bangResultCompareDiffence.Location = new System.Drawing.Point(51, 285);
            this.bangResultCompareDiffence.Name = "bangResultCompareDiffence";
            this.bangResultCompareDiffence.RowHeadersVisible = false;
            this.bangResultCompareDiffence.Size = new System.Drawing.Size(365, 282);
            this.bangResultCompareDiffence.TabIndex = 1;
            // 
            // tabPageSyncResult
            // 
            this.tabPageSyncResult.Controls.Add(this.txtSyncResult);
            this.tabPageSyncResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageSyncResult.Name = "tabPageSyncResult";
            this.tabPageSyncResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSyncResult.Size = new System.Drawing.Size(599, 799);
            this.tabPageSyncResult.TabIndex = 1;
            this.tabPageSyncResult.Text = "Sync Result";
            this.tabPageSyncResult.UseVisualStyleBackColor = true;
            // 
            // txtSyncResult
            // 
            this.txtSyncResult.AutoCompleteBracketsList = new char[] {
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
            this.txtSyncResult.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtSyncResult.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtSyncResult.BackBrush = null;
            this.txtSyncResult.CharHeight = 14;
            this.txtSyncResult.CharWidth = 8;
            this.txtSyncResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSyncResult.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSyncResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSyncResult.IsReplaceMode = false;
            this.txtSyncResult.Location = new System.Drawing.Point(3, 3);
            this.txtSyncResult.Name = "txtSyncResult";
            this.txtSyncResult.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSyncResult.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSyncResult.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSyncResult.ServiceColors")));
            this.txtSyncResult.Size = new System.Drawing.Size(593, 793);
            this.txtSyncResult.TabIndex = 0;
            this.txtSyncResult.Zoom = 100;
            // 
            // syncColumnToolStripMenuItem
            // 
            this.syncColumnToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.sync;
            this.syncColumnToolStripMenuItem.Name = "syncColumnToolStripMenuItem";
            this.syncColumnToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.syncColumnToolStripMenuItem.Text = "Sync Column";
            this.syncColumnToolStripMenuItem.Click += new System.EventHandler(this.syncColumnToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // copyCodeToolStripMenuItem
            // 
            this.copyCodeToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.Copy;
            this.copyCodeToolStripMenuItem.Name = "copyCodeToolStripMenuItem";
            this.copyCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyCodeToolStripMenuItem.Text = "Copy Code";
            this.copyCodeToolStripMenuItem.Click += new System.EventHandler(this.copyCodeToolStripMenuItem_Click);
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.save;
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.copyNameToolStripMenuItem_Click);
            // 
            // FrmCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1374, 827);
            this.Controls.Add(this.splitContainerCompareDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1153, 827);
            this.Name = "FrmCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compare Database";
            this.Load += new System.EventHandler(this.FrmAuto_Load);
            this.SizeChanged += new System.EventHandler(this.FrmAuto_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bangCompareTwoFileBackupDifferent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareFileBackup)).EndInit();
            this.menuStripCompare.ResumeLayout(false);
            this.splitContainerCompareDetail.Panel1.ResumeLayout(false);
            this.splitContainerCompareDetail.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCompareDetail)).EndInit();
            this.splitContainerCompareDetail.ResumeLayout(false);
            this.splitContainerTableCompare.Panel1.ResumeLayout(false);
            this.splitContainerTableCompare.Panel1.PerformLayout();
            this.splitContainerTableCompare.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTableCompare)).EndInit();
            this.splitContainerTableCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bangCompare)).EndInit();
            this.tabControlCompare.ResumeLayout(false);
            this.tabPageCompareDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCompareOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bangResultCompareDiffence)).EndInit();
            this.tabPageSyncResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileImport;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView bangResultCompareFileBackup;
        private RichTextBox txtDifferntConpareTwoBackup;
        private System.Windows.Forms.DataGridView bangCompareTwoFileBackupDifferent;
        private System.Windows.Forms.ContextMenuStrip menuStripCompare;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerCompareDetail;
        private System.Windows.Forms.SplitContainer splitContainerTableCompare;
        private System.Windows.Forms.Button btnCompareTwoDb;
        private System.Windows.Forms.Label lblNoteSync;
        private System.Windows.Forms.Button btnChangePositionCompare;
        private System.Windows.Forms.Button btnMultiSync;
        private System.Windows.Forms.DataGridView bangCompare;
        private System.Windows.Forms.TabControl tabControlCompare;
        private System.Windows.Forms.TabPage tabPageCompareDetail;
        private System.Windows.Forms.DataGridView bangResultCompareDiffence;
        //private RichTextBox txtCompareOnly;
        private System.Windows.Forms.TabPage tabPageSyncResult;
        private FastColoredTextBoxNS.FastColoredTextBox txtSyncResult;
        private FastColoredTextBoxNS.FastColoredTextBox txtCompareOnly;
        private ToolStripMenuItem syncColumnToolStripMenuItem;
    }
}