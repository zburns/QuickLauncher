namespace QuickLauncher
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewBusiness = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewPersonal = new System.Windows.Forms.ListView();
            this.labelBusinessTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBusinessViewMode = new System.Windows.Forms.ComboBox();
            this.comboBoxPersonalViewMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewBusiness);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 475);
            this.panel1.TabIndex = 0;
            // 
            // listViewBusiness
            // 
            this.listViewBusiness.AllowDrop = true;
            this.listViewBusiness.Location = new System.Drawing.Point(4, 3);
            this.listViewBusiness.MultiSelect = false;
            this.listViewBusiness.Name = "listViewBusiness";
            this.listViewBusiness.Size = new System.Drawing.Size(349, 469);
            this.listViewBusiness.TabIndex = 0;
            this.listViewBusiness.UseCompatibleStateImageBehavior = false;
            this.listViewBusiness.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewBusiness_DragDrop);
            this.listViewBusiness.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewBusiness_DragEnter);
            this.listViewBusiness.DoubleClick += new System.EventHandler(this.listViewBusiness_DoubleClick);
            this.listViewBusiness.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewBusiness_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewPersonal);
            this.panel2.Location = new System.Drawing.Point(403, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 475);
            this.panel2.TabIndex = 1;
            // 
            // listViewPersonal
            // 
            this.listViewPersonal.AllowDrop = true;
            this.listViewPersonal.Location = new System.Drawing.Point(4, 3);
            this.listViewPersonal.MultiSelect = false;
            this.listViewPersonal.Name = "listViewPersonal";
            this.listViewPersonal.Size = new System.Drawing.Size(349, 469);
            this.listViewPersonal.TabIndex = 1;
            this.listViewPersonal.UseCompatibleStateImageBehavior = false;
            this.listViewPersonal.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewPersonal_DragDrop);
            this.listViewPersonal.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewPersonal_DragEnter);
            this.listViewPersonal.DoubleClick += new System.EventHandler(this.listViewPersonal_DoubleClick);
            this.listViewPersonal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewPersonal_MouseDown);
            // 
            // labelBusinessTitle
            // 
            this.labelBusinessTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBusinessTitle.Location = new System.Drawing.Point(12, 9);
            this.labelBusinessTitle.Name = "labelBusinessTitle";
            this.labelBusinessTitle.Size = new System.Drawing.Size(356, 25);
            this.labelBusinessTitle.TabIndex = 2;
            this.labelBusinessTitle.Text = "Business";
            this.labelBusinessTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Personal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxBusinessViewMode
            // 
            this.comboBoxBusinessViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBusinessViewMode.FormattingEnabled = true;
            this.comboBoxBusinessViewMode.Items.AddRange(new object[] {
            "LargeIcon",
            "SmallIcon",
            "List",
            "Tile"});
            this.comboBoxBusinessViewMode.Location = new System.Drawing.Point(78, 515);
            this.comboBoxBusinessViewMode.Name = "comboBoxBusinessViewMode";
            this.comboBoxBusinessViewMode.Size = new System.Drawing.Size(287, 21);
            this.comboBoxBusinessViewMode.TabIndex = 4;
            this.comboBoxBusinessViewMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxBusinessViewMode_SelectedIndexChanged);
            // 
            // comboBoxPersonalViewMode
            // 
            this.comboBoxPersonalViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPersonalViewMode.FormattingEnabled = true;
            this.comboBoxPersonalViewMode.Items.AddRange(new object[] {
            "LargeIcon",
            "SmallIcon",
            "List",
            "Tile"});
            this.comboBoxPersonalViewMode.Location = new System.Drawing.Point(472, 515);
            this.comboBoxPersonalViewMode.Name = "comboBoxPersonalViewMode";
            this.comboBoxPersonalViewMode.Size = new System.Drawing.Size(287, 21);
            this.comboBoxPersonalViewMode.TabIndex = 5;
            this.comboBoxPersonalViewMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPersonalViewMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "View Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "View Mode";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 542);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPersonalViewMode);
            this.Controls.Add(this.comboBoxBusinessViewMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBusinessTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Launcher";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormMain_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewBusiness;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewPersonal;
        private System.Windows.Forms.Label labelBusinessTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBusinessViewMode;
        private System.Windows.Forms.ComboBox comboBoxPersonalViewMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

