namespace Catteries
{
    partial class FormCatInfo
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxColorCode = new System.Windows.Forms.TextBox();
            this.textBoxEarsCode = new System.Windows.Forms.TextBox();
            this.dateTimePickerBday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxOwners = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOwnerAddress = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxOwnerContacts = new System.Windows.Forms.TextBox();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.buttonPhoto = new System.Windows.Forms.Button();
            this.textBoxColorName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxEarsName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonPets = new System.Windows.Forms.RadioButton();
            this.radioButtonPartners = new System.Windows.Forms.RadioButton();
            this.radioButtonKitties = new System.Windows.Forms.RadioButton();
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.panelElements = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOwners.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelElements.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(208, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(132, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxColorCode
            // 
            this.textBoxColorCode.Location = new System.Drawing.Point(523, 30);
            this.textBoxColorCode.MaxLength = 4;
            this.textBoxColorCode.Name = "textBoxColorCode";
            this.textBoxColorCode.Size = new System.Drawing.Size(30, 20);
            this.textBoxColorCode.TabIndex = 4;
            // 
            // textBoxEarsCode
            // 
            this.textBoxEarsCode.Location = new System.Drawing.Point(429, 56);
            this.textBoxEarsCode.MaxLength = 2;
            this.textBoxEarsCode.Name = "textBoxEarsCode";
            this.textBoxEarsCode.Size = new System.Drawing.Size(20, 20);
            this.textBoxEarsCode.TabIndex = 6;
            // 
            // dateTimePickerBday
            // 
            this.dateTimePickerBday.Location = new System.Drawing.Point(429, 4);
            this.dateTimePickerBday.Name = "dateTimePickerBday";
            this.dateTimePickerBday.Size = new System.Drawing.Size(124, 20);
            this.dateTimePickerBday.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кличка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата рождения:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Код окраса:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Код типа ушей:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(637, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Добавить в базу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxOwners
            // 
            this.groupBoxOwners.Controls.Add(this.label7);
            this.groupBoxOwners.Controls.Add(this.label6);
            this.groupBoxOwners.Controls.Add(this.label5);
            this.groupBoxOwners.Controls.Add(this.textBoxOwnerAddress);
            this.groupBoxOwners.Controls.Add(this.textBox2);
            this.groupBoxOwners.Controls.Add(this.textBoxOwnerContacts);
            this.groupBoxOwners.Controls.Add(this.textBoxOwnerName);
            this.groupBoxOwners.Location = new System.Drawing.Point(3, 151);
            this.groupBoxOwners.Name = "groupBoxOwners";
            this.groupBoxOwners.Size = new System.Drawing.Size(394, 97);
            this.groupBoxOwners.TabIndex = 6;
            this.groupBoxOwners.TabStop = false;
            this.groupBoxOwners.Text = "Информация о хозяевах";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Адрес:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Контакты:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Имя:";
            // 
            // textBoxOwnerAddress
            // 
            this.textBoxOwnerAddress.Location = new System.Drawing.Point(72, 71);
            this.textBoxOwnerAddress.Name = "textBoxOwnerAddress";
            this.textBoxOwnerAddress.Size = new System.Drawing.Size(277, 20);
            this.textBoxOwnerAddress.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBoxOwnerContacts
            // 
            this.textBoxOwnerContacts.Location = new System.Drawing.Point(72, 45);
            this.textBoxOwnerContacts.Name = "textBoxOwnerContacts";
            this.textBoxOwnerContacts.Size = new System.Drawing.Size(277, 20);
            this.textBoxOwnerContacts.TabIndex = 11;
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(72, 19);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(277, 20);
            this.textBoxOwnerName.TabIndex = 10;
            // 
            // buttonPhoto
            // 
            this.buttonPhoto.Location = new System.Drawing.Point(163, 122);
            this.buttonPhoto.Name = "buttonPhoto";
            this.buttonPhoto.Size = new System.Drawing.Size(106, 23);
            this.buttonPhoto.TabIndex = 9;
            this.buttonPhoto.Text = "Изменить фото";
            this.buttonPhoto.UseVisualStyleBackColor = true;
            this.buttonPhoto.Click += new System.EventHandler(this.buttonPhoto_Click);
            // 
            // textBoxColorName
            // 
            this.textBoxColorName.Location = new System.Drawing.Point(208, 30);
            this.textBoxColorName.Name = "textBoxColorName";
            this.textBoxColorName.Size = new System.Drawing.Size(241, 20);
            this.textBoxColorName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Окрас:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Тип ушей";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(43, 17);
            this.radioButtonMale.TabIndex = 7;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Кот";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(6, 42);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(58, 17);
            this.radioButtonFemale.TabIndex = 8;
            this.radioButtonFemale.Text = "Кошка";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonMale);
            this.groupBox2.Controls.Add(this.radioButtonFemale);
            this.groupBox2.Location = new System.Drawing.Point(466, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(77, 63);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пол";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxEarsName
            // 
            this.comboBoxEarsName.FormattingEnabled = true;
            this.comboBoxEarsName.Items.AddRange(new object[] {
            "Страйт (прямые)",
            "Керл (закручены назад)",
            "Фолд (закручены вперед)"});
            this.comboBoxEarsName.Location = new System.Drawing.Point(208, 56);
            this.comboBoxEarsName.Name = "comboBoxEarsName";
            this.comboBoxEarsName.Size = new System.Drawing.Size(132, 21);
            this.comboBoxEarsName.TabIndex = 15;
            this.comboBoxEarsName.SelectedIndexChanged += new System.EventHandler(this.comboBoxEarsName_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.comboBoxEarsName);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.textBoxColorCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxEarsCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePickerBday);
            this.panel1.Controls.Add(this.textBoxColorName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonPhoto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBoxOwners);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(201, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 250);
            this.panel1.TabIndex = 16;
            // 
            // radioButtonPets
            // 
            this.radioButtonPets.AutoSize = true;
            this.radioButtonPets.Location = new System.Drawing.Point(3, 1);
            this.radioButtonPets.Name = "radioButtonPets";
            this.radioButtonPets.Size = new System.Drawing.Size(72, 17);
            this.radioButtonPets.TabIndex = 17;
            this.radioButtonPets.Text = "Питомцы";
            this.radioButtonPets.UseVisualStyleBackColor = true;
            this.radioButtonPets.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonPartners
            // 
            this.radioButtonPartners.AutoSize = true;
            this.radioButtonPartners.Location = new System.Drawing.Point(71, 1);
            this.radioButtonPartners.Name = "radioButtonPartners";
            this.radioButtonPartners.Size = new System.Drawing.Size(76, 17);
            this.radioButtonPartners.TabIndex = 17;
            this.radioButtonPartners.Text = "Партнеры";
            this.radioButtonPartners.UseVisualStyleBackColor = true;
            this.radioButtonPartners.CheckedChanged += new System.EventHandler(this.radioButtonPartners_CheckedChanged);
            // 
            // radioButtonKitties
            // 
            this.radioButtonKitties.AutoSize = true;
            this.radioButtonKitties.Location = new System.Drawing.Point(143, 2);
            this.radioButtonKitties.Name = "radioButtonKitties";
            this.radioButtonKitties.Size = new System.Drawing.Size(60, 17);
            this.radioButtonKitties.TabIndex = 17;
            this.radioButtonKitties.Text = "Котята";
            this.radioButtonKitties.UseVisualStyleBackColor = true;
            this.radioButtonKitties.CheckedChanged += new System.EventHandler(this.radioButtonKitties_CheckedChanged);
            // 
            // listBoxElements
            // 
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.Location = new System.Drawing.Point(3, 26);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(197, 225);
            this.listBoxElements.TabIndex = 18;
            this.listBoxElements.SelectedIndexChanged += new System.EventHandler(this.listBoxElements_SelectedIndexChanged);
            this.listBoxElements.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxElements_MouseDown);
            // 
            // panelElements
            // 
            this.panelElements.Controls.Add(this.listBoxElements);
            this.panelElements.Controls.Add(this.radioButtonKitties);
            this.panelElements.Controls.Add(this.radioButtonPartners);
            this.panelElements.Controls.Add(this.radioButtonPets);
            this.panelElements.Location = new System.Drawing.Point(-2, 5);
            this.panelElements.Name = "panelElements";
            this.panelElements.Size = new System.Drawing.Size(200, 296);
            this.panelElements.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // FormCatInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 302);
            this.Controls.Add(this.panelElements);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCatInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormCatInfo";
            this.Load += new System.EventHandler(this.FormCatInfo_Load);
            this.groupBoxOwners.ResumeLayout(false);
            this.groupBoxOwners.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelElements.ResumeLayout(false);
            this.panelElements.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxColorCode;
        private System.Windows.Forms.TextBox textBoxEarsCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerBday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxOwners;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOwnerAddress;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxOwnerContacts;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Button buttonPhoto;
        private System.Windows.Forms.TextBox textBoxColorName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxEarsName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonPets;
        private System.Windows.Forms.RadioButton radioButtonPartners;
        private System.Windows.Forms.RadioButton radioButtonKitties;
        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.Panel panelElements;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}