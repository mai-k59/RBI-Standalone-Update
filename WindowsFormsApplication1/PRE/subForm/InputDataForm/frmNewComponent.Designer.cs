namespace RBI.PRE.subForm.InputDataForm
{
    partial class frmNewComponent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewComponent));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAPIComponentType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbComponentType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbFacility = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbSites = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.cbEquipmentNumber = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.picAPIComponent = new System.Windows.Forms.PictureBox();
            this.picComponentType = new System.Windows.Forms.PictureBox();
            this.picComponentNumber = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkLinks = new System.Windows.Forms.CheckBox();
            this.txtComponentName = new System.Windows.Forms.TextBox();
            this.txtComponentNumber = new System.Windows.Forms.TextBox();
            this.txtEquipmentType = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblNameComp = new System.Windows.Forms.Label();
            this.lblAPIType = new System.Windows.Forms.Label();
            this.lbltypeComp = new System.Windows.Forms.Label();
            this.lblNumComp = new System.Windows.Forms.Label();
            this.lblFacility = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblTypeEq = new System.Windows.Forms.Label();
            this.lblNumEq = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAPIComponentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComponentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFacility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSites.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEquipmentNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAPIComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentNumber)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cbAPIComponentType);
            this.panel1.Controls.Add(this.cbComponentType);
            this.panel1.Controls.Add(this.cbFacility);
            this.panel1.Controls.Add(this.cbSites);
            this.panel1.Controls.Add(this.cbEquipmentNumber);
            this.panel1.Controls.Add(this.picAPIComponent);
            this.panel1.Controls.Add(this.picComponentType);
            this.panel1.Controls.Add(this.picComponentNumber);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.chkLinks);
            this.panel1.Controls.Add(this.txtComponentName);
            this.panel1.Controls.Add(this.txtComponentNumber);
            this.panel1.Controls.Add(this.txtEquipmentType);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblCheck);
            this.panel1.Controls.Add(this.lblNameComp);
            this.panel1.Controls.Add(this.lblAPIType);
            this.panel1.Controls.Add(this.lbltypeComp);
            this.panel1.Controls.Add(this.lblNumComp);
            this.panel1.Controls.Add(this.lblFacility);
            this.panel1.Controls.Add(this.lblSite);
            this.panel1.Controls.Add(this.lblTypeEq);
            this.panel1.Controls.Add(this.lblNumEq);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 451);
            this.panel1.TabIndex = 1;
            // 
            // cbAPIComponentType
            // 
            this.cbAPIComponentType.Location = new System.Drawing.Point(288, 234);
            this.cbAPIComponentType.Name = "cbAPIComponentType";
            this.cbAPIComponentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAPIComponentType.Size = new System.Drawing.Size(314, 20);
            this.cbAPIComponentType.TabIndex = 7;
            this.cbAPIComponentType.SelectedIndexChanged += new System.EventHandler(this.cbAPIComponentType_SelectedIndexChanged);
            // 
            // cbComponentType
            // 
            this.cbComponentType.Location = new System.Drawing.Point(288, 208);
            this.cbComponentType.Name = "cbComponentType";
            this.cbComponentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbComponentType.Size = new System.Drawing.Size(314, 20);
            this.cbComponentType.TabIndex = 6;
            this.cbComponentType.SelectedValueChanged += new System.EventHandler(this.cbComponentType_SelectedValueChanged);
            // 
            // cbFacility
            // 
            this.cbFacility.Location = new System.Drawing.Point(288, 150);
            this.cbFacility.Name = "cbFacility";
            this.cbFacility.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbFacility.Size = new System.Drawing.Size(314, 20);
            this.cbFacility.TabIndex = 4;
            this.cbFacility.SelectedValueChanged += new System.EventHandler(this.cbFacility_SelectedValueChanged);
            // 
            // cbSites
            // 
            this.cbSites.Location = new System.Drawing.Point(288, 124);
            this.cbSites.Name = "cbSites";
            this.cbSites.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSites.Size = new System.Drawing.Size(314, 20);
            this.cbSites.TabIndex = 3;
            this.cbSites.SelectedValueChanged += new System.EventHandler(this.cbSites_SelectedValueChanged);
            // 
            // cbEquipmentNumber
            // 
            this.cbEquipmentNumber.Location = new System.Drawing.Point(288, 66);
            this.cbEquipmentNumber.Name = "cbEquipmentNumber";
            this.cbEquipmentNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEquipmentNumber.Size = new System.Drawing.Size(314, 20);
            this.cbEquipmentNumber.TabIndex = 1;
            // 
            // picAPIComponent
            // 
            this.picAPIComponent.Image = ((System.Drawing.Image)(resources.GetObject("picAPIComponent.Image")));
            this.picAPIComponent.Location = new System.Drawing.Point(263, 231);
            this.picAPIComponent.Name = "picAPIComponent";
            this.picAPIComponent.Size = new System.Drawing.Size(17, 19);
            this.picAPIComponent.TabIndex = 2;
            this.picAPIComponent.TabStop = false;
            // 
            // picComponentType
            // 
            this.picComponentType.Image = ((System.Drawing.Image)(resources.GetObject("picComponentType.Image")));
            this.picComponentType.Location = new System.Drawing.Point(263, 206);
            this.picComponentType.Name = "picComponentType";
            this.picComponentType.Size = new System.Drawing.Size(17, 19);
            this.picComponentType.TabIndex = 2;
            this.picComponentType.TabStop = false;
            // 
            // picComponentNumber
            // 
            this.picComponentNumber.Image = ((System.Drawing.Image)(resources.GetObject("picComponentNumber.Image")));
            this.picComponentNumber.Location = new System.Drawing.Point(263, 179);
            this.picComponentNumber.Name = "picComponentNumber";
            this.picComponentNumber.Size = new System.Drawing.Size(17, 19);
            this.picComponentNumber.TabIndex = 2;
            this.picComponentNumber.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(427, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 29);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(288, 311);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(314, 80);
            this.txtDescription.TabIndex = 10;
            // 
            // chkLinks
            // 
            this.chkLinks.AutoSize = true;
            this.chkLinks.Location = new System.Drawing.Point(288, 288);
            this.chkLinks.Name = "chkLinks";
            this.chkLinks.Size = new System.Drawing.Size(15, 14);
            this.chkLinks.TabIndex = 9;
            this.chkLinks.UseVisualStyleBackColor = true;
            // 
            // txtComponentName
            // 
            this.txtComponentName.Location = new System.Drawing.Point(288, 260);
            this.txtComponentName.Name = "txtComponentName";
            this.txtComponentName.Size = new System.Drawing.Size(314, 20);
            this.txtComponentName.TabIndex = 8;
            // 
            // txtComponentNumber
            // 
            this.txtComponentNumber.Location = new System.Drawing.Point(288, 181);
            this.txtComponentNumber.Name = "txtComponentNumber";
            this.txtComponentNumber.Size = new System.Drawing.Size(314, 20);
            this.txtComponentNumber.TabIndex = 5;
            this.txtComponentNumber.TextChanged += new System.EventHandler(this.txtComponentNumber_TextChanged);
            // 
            // txtEquipmentType
            // 
            this.txtEquipmentType.Location = new System.Drawing.Point(288, 93);
            this.txtEquipmentType.Name = "txtEquipmentType";
            this.txtEquipmentType.Size = new System.Drawing.Size(314, 20);
            this.txtEquipmentType.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDescription.Location = new System.Drawing.Point(28, 311);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(76, 16);
            this.lblDescription.TabIndex = 43;
            this.lblDescription.Text = "Description";
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCheck.Location = new System.Drawing.Point(28, 286);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(252, 16);
            this.lblCheck.TabIndex = 42;
            this.lblCheck.Text = "Component Risk Links to Equipment Risk";
            // 
            // lblNameComp
            // 
            this.lblNameComp.AutoSize = true;
            this.lblNameComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNameComp.Location = new System.Drawing.Point(28, 261);
            this.lblNameComp.Name = "lblNameComp";
            this.lblNameComp.Size = new System.Drawing.Size(117, 16);
            this.lblNameComp.TabIndex = 41;
            this.lblNameComp.Text = "Component Name";
            // 
            // lblAPIType
            // 
            this.lblAPIType.AutoSize = true;
            this.lblAPIType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAPIType.Location = new System.Drawing.Point(28, 235);
            this.lblAPIType.Name = "lblAPIType";
            this.lblAPIType.Size = new System.Drawing.Size(136, 16);
            this.lblAPIType.TabIndex = 40;
            this.lblAPIType.Text = "API Component Type";
            // 
            // lbltypeComp
            // 
            this.lbltypeComp.AutoSize = true;
            this.lbltypeComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltypeComp.Location = new System.Drawing.Point(28, 209);
            this.lbltypeComp.Name = "lbltypeComp";
            this.lbltypeComp.Size = new System.Drawing.Size(112, 16);
            this.lbltypeComp.TabIndex = 39;
            this.lbltypeComp.Text = "Component Type";
            // 
            // lblNumComp
            // 
            this.lblNumComp.AutoSize = true;
            this.lblNumComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNumComp.Location = new System.Drawing.Point(28, 182);
            this.lblNumComp.Name = "lblNumComp";
            this.lblNumComp.Size = new System.Drawing.Size(128, 16);
            this.lblNumComp.TabIndex = 38;
            this.lblNumComp.Text = "Component Number";
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblFacility.Location = new System.Drawing.Point(28, 155);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(50, 16);
            this.lblFacility.TabIndex = 37;
            this.lblFacility.Text = "Facility";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSite.Location = new System.Drawing.Point(28, 128);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(31, 16);
            this.lblSite.TabIndex = 36;
            this.lblSite.Text = "Site";
            // 
            // lblTypeEq
            // 
            this.lblTypeEq.AutoSize = true;
            this.lblTypeEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTypeEq.Location = new System.Drawing.Point(28, 94);
            this.lblTypeEq.Name = "lblTypeEq";
            this.lblTypeEq.Size = new System.Drawing.Size(107, 16);
            this.lblTypeEq.TabIndex = 33;
            this.lblTypeEq.Text = "Equipment Type";
            // 
            // lblNumEq
            // 
            this.lblNumEq.AutoSize = true;
            this.lblNumEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNumEq.Location = new System.Drawing.Point(28, 67);
            this.lblNumEq.Name = "lblNumEq";
            this.lblNumEq.Size = new System.Drawing.Size(123, 16);
            this.lblNumEq.TabIndex = 32;
            this.lblNumEq.Text = "Equipment Number";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 73);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 49);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Add a new Component";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Component";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(527, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNewComponent
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewComponent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Component";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAPIComponentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComponentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFacility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSites.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEquipmentNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAPIComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComponentNumber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkLinks;
        private System.Windows.Forms.TextBox txtComponentName;
        private System.Windows.Forms.TextBox txtComponentNumber;
        private System.Windows.Forms.TextBox txtEquipmentType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblNameComp;
        private System.Windows.Forms.Label lblAPIType;
        private System.Windows.Forms.Label lbltypeComp;
        private System.Windows.Forms.Label lblNumComp;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblTypeEq;
        private System.Windows.Forms.Label lblNumEq;
        private System.Windows.Forms.PictureBox picAPIComponent;
        private System.Windows.Forms.PictureBox picComponentType;
        private System.Windows.Forms.PictureBox picComponentNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbEquipmentNumber;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbAPIComponentType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbComponentType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbFacility;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbSites;
        private System.Windows.Forms.Button btnCancel;
    }
}