namespace iFolderList
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cb_txtList = new System.Windows.Forms.ComboBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbl_folderAddress = new System.Windows.Forms.Label();
            this.btn_dirsearch = new System.Windows.Forms.Button();
            this.btn_help = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_txtList
            // 
            this.cb_txtList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_txtList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_txtList.BackColor = System.Drawing.SystemColors.GrayText;
            this.cb_txtList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_txtList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_txtList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_txtList.ForeColor = System.Drawing.Color.White;
            this.cb_txtList.FormattingEnabled = true;
            this.cb_txtList.Location = new System.Drawing.Point(52, 34);
            this.cb_txtList.Name = "cb_txtList";
            this.cb_txtList.Size = new System.Drawing.Size(300, 28);
            this.cb_txtList.TabIndex = 0;
            this.cb_txtList.SelectedIndexChanged += new System.EventHandler(this.cb_txtList_SelectedIndexChanged);
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.Orange;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_create.Location = new System.Drawing.Point(52, 278);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(300, 45);
            this.btn_create.TabIndex = 1;
            this.btn_create.Text = "Dizinleri Oluştur";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Location = new System.Drawing.Point(293, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Çıkış \"esc\"";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Khaki;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(53, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(300, 208);
            this.listBox1.TabIndex = 6;
            this.listBox1.TabStop = false;
            // 
            // lbl_folderAddress
            // 
            this.lbl_folderAddress.AutoSize = true;
            this.lbl_folderAddress.BackColor = System.Drawing.Color.Firebrick;
            this.lbl_folderAddress.ForeColor = System.Drawing.Color.White;
            this.lbl_folderAddress.Location = new System.Drawing.Point(10, 9);
            this.lbl_folderAddress.Name = "lbl_folderAddress";
            this.lbl_folderAddress.Size = new System.Drawing.Size(71, 13);
            this.lbl_folderAddress.TabIndex = 5;
            this.lbl_folderAddress.Text = "folderAddress";
            // 
            // btn_dirsearch
            // 
            this.btn_dirsearch.BackColor = System.Drawing.Color.Maroon;
            this.btn_dirsearch.BackgroundImage = global::iFolderList.Properties.Resources.Search;
            this.btn_dirsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dirsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dirsearch.Location = new System.Drawing.Point(6, 278);
            this.btn_dirsearch.Name = "btn_dirsearch";
            this.btn_dirsearch.Size = new System.Drawing.Size(45, 45);
            this.btn_dirsearch.TabIndex = 7;
            this.btn_dirsearch.TabStop = false;
            this.btn_dirsearch.UseVisualStyleBackColor = false;
            this.btn_dirsearch.Click += new System.EventHandler(this.btn_dirsearch_Click);
            // 
            // btn_help
            // 
            this.btn_help.BackColor = System.Drawing.Color.Maroon;
            this.btn_help.BackgroundImage = global::iFolderList.Properties.Resources.Lightbulb;
            this.btn_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Location = new System.Drawing.Point(6, 233);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(45, 45);
            this.btn_help.TabIndex = 6;
            this.btn_help.TabStop = false;
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Maroon;
            this.btn_edit.BackgroundImage = global::iFolderList.Properties.Resources.Writing;
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Location = new System.Drawing.Point(6, 188);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(45, 45);
            this.btn_edit.TabIndex = 5;
            this.btn_edit.TabStop = false;
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.Maroon;
            this.btn_del.BackgroundImage = global::iFolderList.Properties.Resources.Xion;
            this.btn_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_del.Location = new System.Drawing.Point(6, 143);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(45, 45);
            this.btn_del.TabIndex = 4;
            this.btn_del.TabStop = false;
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Maroon;
            this.btn_add.BackgroundImage = global::iFolderList.Properties.Resources.Screenshot;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_add.Location = new System.Drawing.Point(6, 63);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(45, 45);
            this.btn_add.TabIndex = 3;
            this.btn_add.TabStop = false;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dirsearch);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.lbl_folderAddress);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.cb_txtList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iFolder@Creator";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDarkDark;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.set_background);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_txtList;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbl_folderAddress;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.Button btn_dirsearch;
    }
}

