namespace RBI
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            this.imageTreeList = new DevExpress.Utils.ImageCollection(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // imageTreeList
            // 
            this.imageTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageTreeList.ImageStream")));
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(513, 391);
            this.textBox1.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 448);
            this.Controls.Add(this.textBox1);
            this.Name = "test";
            this.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private DevExpress.Utils.ImageCollection imageTreeList;
        private System.Windows.Forms.TextBox textBox1;
    }
}