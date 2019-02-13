namespace RBI.PRE.subForm.InputDataForm
{
    partial class UCDamageMechanism
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colActive = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.coNotes = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colExpected = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLastInsp = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInspDueDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDF = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDF_1AP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDF_2AP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDF_3AP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRecord = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeList1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 521);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Damage Mechanism";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colType,
            this.colActive,
            this.coNotes,
            this.colExpected,
            this.colLastInsp,
            this.colInspDueDate,
            this.colEL,
            this.colValue,
            this.colDF,
            this.colDF_1AP,
            this.colDF_2AP,
            this.colDF_3AP,
            this.colRecord});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(3, 17);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.treeList1.Size = new System.Drawing.Size(971, 501);
            this.treeList1.TabIndex = 2;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.MinWidth = 52;
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            this.colType.Width = 293;
            // 
            // colActive
            // 
            this.colActive.Caption = "Active";
            this.colActive.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 1;
            this.colActive.Width = 39;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // coNotes
            // 
            this.coNotes.Caption = "Notes";
            this.coNotes.FieldName = "Notess";
            this.coNotes.Name = "coNotes";
            this.coNotes.Visible = true;
            this.coNotes.VisibleIndex = 2;
            this.coNotes.Width = 36;
            // 
            // colExpected
            // 
            this.colExpected.Caption = "Expected Type/Location";
            this.colExpected.FieldName = "Expected Type/Location";
            this.colExpected.Name = "colExpected";
            this.colExpected.Visible = true;
            this.colExpected.VisibleIndex = 3;
            this.colExpected.Width = 139;
            // 
            // colLastInsp
            // 
            this.colLastInsp.Caption = "Last Insp, Date";
            this.colLastInsp.FieldName = "Last Insp, Date";
            this.colLastInsp.Name = "colLastInsp";
            this.colLastInsp.Visible = true;
            this.colLastInsp.VisibleIndex = 4;
            this.colLastInsp.Width = 62;
            // 
            // colInspDueDate
            // 
            this.colInspDueDate.Caption = "Insp. Due Date";
            this.colInspDueDate.FieldName = "Insp. Due Date";
            this.colInspDueDate.Name = "colInspDueDate";
            this.colInspDueDate.Visible = true;
            this.colInspDueDate.VisibleIndex = 5;
            this.colInspDueDate.Width = 63;
            // 
            // colEL
            // 
            this.colEL.Caption = "EL?";
            this.colEL.FieldName = "EL?";
            this.colEL.Name = "colEL";
            this.colEL.Visible = true;
            this.colEL.VisibleIndex = 6;
            this.colEL.Width = 28;
            // 
            // colValue
            // 
            this.colValue.Caption = "EL Value";
            this.colValue.FieldName = "EL Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 7;
            this.colValue.Width = 48;
            // 
            // colDF
            // 
            this.colDF.Caption = "DF?";
            this.colDF.FieldName = "DF?";
            this.colDF.Name = "colDF";
            this.colDF.Visible = true;
            this.colDF.VisibleIndex = 8;
            this.colDF.Width = 26;
            // 
            // colDF_1AP
            // 
            this.colDF_1AP.Caption = "DF 1AP";
            this.colDF_1AP.FieldName = "DF 1AP";
            this.colDF_1AP.Name = "colDF_1AP";
            this.colDF_1AP.Visible = true;
            this.colDF_1AP.VisibleIndex = 9;
            this.colDF_1AP.Width = 44;
            // 
            // colDF_2AP
            // 
            this.colDF_2AP.Caption = "DF 2AP";
            this.colDF_2AP.FieldName = "DF 2AP";
            this.colDF_2AP.Name = "colDF_2AP";
            this.colDF_2AP.Visible = true;
            this.colDF_2AP.VisibleIndex = 10;
            this.colDF_2AP.Width = 48;
            // 
            // colDF_3AP
            // 
            this.colDF_3AP.Caption = "DF 3AP";
            this.colDF_3AP.FieldName = "DF 3AP";
            this.colDF_3AP.Name = "colDF_3AP";
            this.colDF_3AP.Visible = true;
            this.colDF_3AP.VisibleIndex = 11;
            this.colDF_3AP.Width = 56;
            // 
            // colRecord
            // 
            this.colRecord.Caption = "Record";
            this.colRecord.FieldName = "Record";
            this.colRecord.Name = "colRecord";
            this.colRecord.Visible = true;
            this.colRecord.VisibleIndex = 12;
            this.colRecord.Width = 45;
            // 
            // UCDamageMechanism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCDamageMechanism";
            this.Size = new System.Drawing.Size(983, 527);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coNotes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colExpected;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLastInsp;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInspDueDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDF;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDF_1AP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDF_2AP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDF_3AP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRecord;

    }
}
