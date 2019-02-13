namespace RBI.PRE.subForm.OutputDataForm
{
    partial class UCRisk
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
            this.gridControlRiskFull = new DevExpress.XtraGrid.GridControl();
            this.gridViewRiskFull = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRiskFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRiskFull)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlRiskFull
            // 
            this.gridControlRiskFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRiskFull.Location = new System.Drawing.Point(0, 0);
            this.gridControlRiskFull.MainView = this.gridViewRiskFull;
            this.gridControlRiskFull.Name = "gridControlRiskFull";
            this.gridControlRiskFull.Size = new System.Drawing.Size(936, 515);
            this.gridControlRiskFull.TabIndex = 2;
            this.gridControlRiskFull.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRiskFull});
            // 
            // gridViewRiskFull
            // 
            this.gridViewRiskFull.GridControl = this.gridControlRiskFull;
            this.gridViewRiskFull.Name = "gridViewRiskFull";
            this.gridViewRiskFull.OptionsBehavior.Editable = false;
            this.gridViewRiskFull.OptionsView.ColumnAutoWidth = false;
            // 
            // UCRisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlRiskFull);
            this.Name = "UCRisk";
            this.Size = new System.Drawing.Size(936, 515);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRiskFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRiskFull)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private DevExpress.XtraGrid.GridControl gridControlRiskFull;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRiskFull;
    }
}
