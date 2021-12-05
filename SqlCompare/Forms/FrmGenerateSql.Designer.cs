using System.Windows.Forms;

namespace SqlCompare
{
    partial class FrmGenerateSql
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
            this.splitContainerGenerateSql = new System.Windows.Forms.SplitContainer();
            this.ckUpdateTable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.cboBang = new System.Windows.Forms.ComboBox();
            this.lbColumGet = new System.Windows.Forms.ListBox();
            this.ckOrCondition = new System.Windows.Forms.CheckBox();
            this.lbConditions = new System.Windows.Forms.ListBox();
            this.ckInsertNoReturn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckPaging = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckSelectAll = new System.Windows.Forms.CheckBox();
            this.ckGetListCondition = new System.Windows.Forms.CheckBox();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.ckCount = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckDelete = new System.Windows.Forms.CheckBox();
            this.ckCreateTable = new System.Windows.Forms.CheckBox();
            this.ckInsertReturnId = new System.Windows.Forms.CheckBox();
            this.txtGenerateSql = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGenerateSql)).BeginInit();
            this.splitContainerGenerateSql.Panel1.SuspendLayout();
            this.splitContainerGenerateSql.Panel2.SuspendLayout();
            this.splitContainerGenerateSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerGenerateSql
            // 
            this.splitContainerGenerateSql.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainerGenerateSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerGenerateSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGenerateSql.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerGenerateSql.IsSplitterFixed = true;
            this.splitContainerGenerateSql.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGenerateSql.Name = "splitContainerGenerateSql";
            // 
            // splitContainerGenerateSql.Panel1
            // 
            this.splitContainerGenerateSql.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckUpdateTable);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.label2);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.btnAction);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.cboBang);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.lbColumGet);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckOrCondition);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.lbConditions);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckInsertNoReturn);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.label3);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckPaging);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.label4);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckSelectAll);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckGetListCondition);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.cboDatabase);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckCount);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.label1);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckDelete);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckCreateTable);
            this.splitContainerGenerateSql.Panel1.Controls.Add(this.ckInsertReturnId);
            this.splitContainerGenerateSql.Panel1MinSize = 410;
            // 
            // splitContainerGenerateSql.Panel2
            // 
            this.splitContainerGenerateSql.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerGenerateSql.Panel2.Controls.Add(this.txtGenerateSql);
            this.splitContainerGenerateSql.Size = new System.Drawing.Size(1113, 574);
            this.splitContainerGenerateSql.SplitterDistance = 410;
            this.splitContainerGenerateSql.SplitterWidth = 7;
            this.splitContainerGenerateSql.TabIndex = 5;
            // 
            // ckUpdateTable
            // 
            this.ckUpdateTable.AutoSize = true;
            this.ckUpdateTable.Location = new System.Drawing.Point(201, 402);
            this.ckUpdateTable.Name = "ckUpdateTable";
            this.ckUpdateTable.Size = new System.Drawing.Size(98, 17);
            this.ckUpdateTable.TabIndex = 13;
            this.ckUpdateTable.Text = "Script cập nhât";
            this.ckUpdateTable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Database";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(201, 502);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // cboBang
            // 
            this.cboBang.FormattingEnabled = true;
            this.cboBang.Location = new System.Drawing.Point(149, 74);
            this.cboBang.Name = "cboBang";
            this.cboBang.Size = new System.Drawing.Size(237, 21);
            this.cboBang.TabIndex = 0;
            this.cboBang.SelectedIndexChanged += new System.EventHandler(this.cboBang_SelectedIndexChanged);
            // 
            // lbColumGet
            // 
            this.lbColumGet.FormattingEnabled = true;
            this.lbColumGet.Location = new System.Drawing.Point(149, 108);
            this.lbColumGet.Name = "lbColumGet";
            this.lbColumGet.Size = new System.Drawing.Size(237, 121);
            this.lbColumGet.TabIndex = 2;
            // 
            // ckOrCondition
            // 
            this.ckOrCondition.AutoSize = true;
            this.ckOrCondition.Checked = true;
            this.ckOrCondition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOrCondition.Location = new System.Drawing.Point(22, 302);
            this.ckOrCondition.Name = "ckOrCondition";
            this.ckOrCondition.Size = new System.Drawing.Size(108, 17);
            this.ckOrCondition.TabIndex = 13;
            this.ckOrCondition.Text = "Or theo điều kiện";
            this.ckOrCondition.UseVisualStyleBackColor = true;
            // 
            // lbConditions
            // 
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.Location = new System.Drawing.Point(149, 259);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new System.Drawing.Size(237, 121);
            this.lbConditions.TabIndex = 2;
            // 
            // ckInsertNoReturn
            // 
            this.ckInsertNoReturn.AutoSize = true;
            this.ckInsertNoReturn.Location = new System.Drawing.Point(201, 425);
            this.ckInsertNoReturn.Name = "ckInsertNoReturn";
            this.ckInsertNoReturn.Size = new System.Drawing.Size(172, 17);
            this.ckInsertNoReturn.TabIndex = 13;
            this.ckInsertNoReturn.Text = "Script thêm mới không trả về id";
            this.ckInsertNoReturn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Columns Get";
            // 
            // ckPaging
            // 
            this.ckPaging.AutoSize = true;
            this.ckPaging.Checked = true;
            this.ckPaging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckPaging.Location = new System.Drawing.Point(22, 279);
            this.ckPaging.Name = "ckPaging";
            this.ckPaging.Size = new System.Drawing.Size(78, 17);
            this.ckPaging.TabIndex = 13;
            this.ckPaging.Text = "Phân trang";
            this.ckPaging.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Columns Condition";
            // 
            // ckSelectAll
            // 
            this.ckSelectAll.AutoSize = true;
            this.ckSelectAll.Location = new System.Drawing.Point(201, 471);
            this.ckSelectAll.Name = "ckSelectAll";
            this.ckSelectAll.Size = new System.Drawing.Size(70, 17);
            this.ckSelectAll.TabIndex = 13;
            this.ckSelectAll.Text = "Select All";
            this.ckSelectAll.UseVisualStyleBackColor = true;
            this.ckSelectAll.CheckedChanged += new System.EventHandler(this.ckSelectAll_CheckedChanged);
            // 
            // ckGetListCondition
            // 
            this.ckGetListCondition.AutoSize = true;
            this.ckGetListCondition.Location = new System.Drawing.Point(201, 448);
            this.ckGetListCondition.Name = "ckGetListCondition";
            this.ckGetListCondition.Size = new System.Drawing.Size(146, 17);
            this.ckGetListCondition.TabIndex = 13;
            this.ckGetListCondition.Text = "Script get list by condition";
            this.ckGetListCondition.UseVisualStyleBackColor = true;
            // 
            // cboDatabase
            // 
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboDatabase.Location = new System.Drawing.Point(149, 41);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(237, 21);
            this.cboDatabase.TabIndex = 12;
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            // 
            // ckCount
            // 
            this.ckCount.AutoSize = true;
            this.ckCount.Location = new System.Drawing.Point(22, 471);
            this.ckCount.Name = "ckCount";
            this.ckCount.Size = new System.Drawing.Size(83, 17);
            this.ckCount.TabIndex = 13;
            this.ckCount.Text = "Script count";
            this.ckCount.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tables";
            // 
            // ckDelete
            // 
            this.ckDelete.AutoSize = true;
            this.ckDelete.Location = new System.Drawing.Point(22, 448);
            this.ckDelete.Name = "ckDelete";
            this.ckDelete.Size = new System.Drawing.Size(108, 17);
            this.ckDelete.TabIndex = 13;
            this.ckDelete.Text = "Script xóa theo id";
            this.ckDelete.UseVisualStyleBackColor = true;
            // 
            // ckCreateTable
            // 
            this.ckCreateTable.AutoSize = true;
            this.ckCreateTable.Location = new System.Drawing.Point(22, 402);
            this.ckCreateTable.Name = "ckCreateTable";
            this.ckCreateTable.Size = new System.Drawing.Size(106, 17);
            this.ckCreateTable.TabIndex = 13;
            this.ckCreateTable.Text = "Script thêm bảng";
            this.ckCreateTable.UseVisualStyleBackColor = true;
            // 
            // ckInsertReturnId
            // 
            this.ckInsertReturnId.AutoSize = true;
            this.ckInsertReturnId.Location = new System.Drawing.Point(22, 425);
            this.ckInsertReturnId.Name = "ckInsertReturnId";
            this.ckInsertReturnId.Size = new System.Drawing.Size(139, 17);
            this.ckInsertReturnId.TabIndex = 13;
            this.ckInsertReturnId.Text = "Script thêm mới trả về id";
            this.ckInsertReturnId.UseVisualStyleBackColor = true;
            // 
            // txtGenerateSql
            // 
            this.txtGenerateSql.BackColor = System.Drawing.Color.White;
            this.txtGenerateSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGenerateSql.Location = new System.Drawing.Point(0, 0);
            this.txtGenerateSql.Name = "txtGenerateSql";
            this.txtGenerateSql.Size = new System.Drawing.Size(694, 572);
            this.txtGenerateSql.TabIndex = 2;
            this.txtGenerateSql.Text = "";
            // 
            // FrmGenerateSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 574);
            this.Controls.Add(this.splitContainerGenerateSql);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenerateSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\\ư";
            this.Load += new System.EventHandler(this.FrmGenerateSql_Load);
            this.splitContainerGenerateSql.Panel1.ResumeLayout(false);
            this.splitContainerGenerateSql.Panel1.PerformLayout();
            this.splitContainerGenerateSql.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGenerateSql)).EndInit();
            this.splitContainerGenerateSql.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerGenerateSql;
        private System.Windows.Forms.CheckBox ckUpdateTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ComboBox cboBang;
        private System.Windows.Forms.ListBox lbColumGet;
        private System.Windows.Forms.CheckBox ckOrCondition;
        private System.Windows.Forms.ListBox lbConditions;
        private System.Windows.Forms.CheckBox ckInsertNoReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckPaging;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckSelectAll;
        private System.Windows.Forms.CheckBox ckGetListCondition;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.CheckBox ckCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckDelete;
        private System.Windows.Forms.CheckBox ckCreateTable;
        private System.Windows.Forms.CheckBox ckInsertReturnId;
        private RichTextBox txtGenerateSql;
    }
}