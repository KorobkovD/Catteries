namespace Catteries
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelPets = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAddCatPartner = new System.Windows.Forms.Button();
            this.pictureBoxPet = new System.Windows.Forms.PictureBox();
            this.labelPetColorCode = new System.Windows.Forms.Label();
            this.buttonChangePetInfo = new System.Windows.Forms.Button();
            this.labelPetBday = new System.Windows.Forms.Label();
            this.labelPetName = new System.Windows.Forms.Label();
            this.labelPetEarsCode = new System.Windows.Forms.Label();
            this.listBoxPets = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonPartnerInfo = new System.Windows.Forms.Button();
            this.buttonAddKitty = new System.Windows.Forms.Button();
            this.pictureBoxPartner = new System.Windows.Forms.PictureBox();
            this.labelPartnerColorCode = new System.Windows.Forms.Label();
            this.buttonChangePartnerInfo = new System.Windows.Forms.Button();
            this.labelPartnerBday = new System.Windows.Forms.Label();
            this.labelPartnerName = new System.Windows.Forms.Label();
            this.labelPartnerEarsCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxCatteries = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBoxKitty = new System.Windows.Forms.PictureBox();
            this.labelKittyColorCode = new System.Windows.Forms.Label();
            this.buttonChangeKittyInfo = new System.Windows.Forms.Button();
            this.labelKittyBday = new System.Windows.Forms.Label();
            this.labelKittyName = new System.Windows.Forms.Label();
            this.labelKittyEarsCode = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBoxKitties = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новыйПитомецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelPets.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPartner)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKitty)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33555F));
            this.tableLayoutPanelMain.Controls.Add(this.panelPets, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(838, 455);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelPets
            // 
            this.panelPets.BackColor = System.Drawing.Color.White;
            this.panelPets.Controls.Add(this.label1);
            this.panelPets.Controls.Add(this.panel3);
            this.panelPets.Controls.Add(this.listBoxPets);
            this.panelPets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPets.Location = new System.Drawing.Point(3, 3);
            this.panelPets.Name = "panelPets";
            this.panelPets.Size = new System.Drawing.Size(273, 449);
            this.panelPets.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Мои питомцы:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddCatPartner);
            this.panel3.Controls.Add(this.pictureBoxPet);
            this.panel3.Controls.Add(this.labelPetColorCode);
            this.panel3.Controls.Add(this.buttonChangePetInfo);
            this.panel3.Controls.Add(this.labelPetBday);
            this.panel3.Controls.Add(this.labelPetName);
            this.panel3.Controls.Add(this.labelPetEarsCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 116);
            this.panel3.TabIndex = 1;
            // 
            // buttonAddCatPartner
            // 
            this.buttonAddCatPartner.Location = new System.Drawing.Point(196, 70);
            this.buttonAddCatPartner.Name = "buttonAddCatPartner";
            this.buttonAddCatPartner.Size = new System.Drawing.Size(66, 43);
            this.buttonAddCatPartner.TabIndex = 3;
            this.buttonAddCatPartner.Text = "Добавить вязку";
            this.buttonAddCatPartner.UseVisualStyleBackColor = true;
            this.buttonAddCatPartner.Click += new System.EventHandler(this.buttonAddCatPartner_Click);
            // 
            // pictureBoxPet
            // 
            this.pictureBoxPet.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPet.Name = "pictureBoxPet";
            this.pictureBoxPet.Size = new System.Drawing.Size(115, 110);
            this.pictureBoxPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPet.TabIndex = 1;
            this.pictureBoxPet.TabStop = false;
            // 
            // labelPetColorCode
            // 
            this.labelPetColorCode.AutoSize = true;
            this.labelPetColorCode.Location = new System.Drawing.Point(124, 37);
            this.labelPetColorCode.Name = "labelPetColorCode";
            this.labelPetColorCode.Size = new System.Drawing.Size(94, 13);
            this.labelPetColorCode.TabIndex = 2;
            this.labelPetColorCode.Text = "labelPetColorCode";
            // 
            // buttonChangePetInfo
            // 
            this.buttonChangePetInfo.Location = new System.Drawing.Point(125, 70);
            this.buttonChangePetInfo.Name = "buttonChangePetInfo";
            this.buttonChangePetInfo.Size = new System.Drawing.Size(66, 43);
            this.buttonChangePetInfo.TabIndex = 3;
            this.buttonChangePetInfo.Text = "Изменить инфо";
            this.buttonChangePetInfo.UseVisualStyleBackColor = true;
            this.buttonChangePetInfo.Click += new System.EventHandler(this.buttonChangePetInfo_Click);
            // 
            // labelPetBday
            // 
            this.labelPetBday.AutoSize = true;
            this.labelPetBday.Location = new System.Drawing.Point(124, 20);
            this.labelPetBday.Name = "labelPetBday";
            this.labelPetBday.Size = new System.Drawing.Size(69, 13);
            this.labelPetBday.TabIndex = 2;
            this.labelPetBday.Text = "labelPetBday";
            // 
            // labelPetName
            // 
            this.labelPetName.AutoSize = true;
            this.labelPetName.Location = new System.Drawing.Point(124, 3);
            this.labelPetName.Name = "labelPetName";
            this.labelPetName.Size = new System.Drawing.Size(73, 13);
            this.labelPetName.TabIndex = 2;
            this.labelPetName.Text = "labelPetName";
            // 
            // labelPetEarsCode
            // 
            this.labelPetEarsCode.AutoSize = true;
            this.labelPetEarsCode.Location = new System.Drawing.Point(124, 54);
            this.labelPetEarsCode.Name = "labelPetEarsCode";
            this.labelPetEarsCode.Size = new System.Drawing.Size(91, 13);
            this.labelPetEarsCode.TabIndex = 2;
            this.labelPetEarsCode.Text = "labelPetEarsCode";
            // 
            // listBoxPets
            // 
            this.listBoxPets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPets.FormattingEnabled = true;
            this.listBoxPets.ItemHeight = 20;
            this.listBoxPets.Location = new System.Drawing.Point(3, 23);
            this.listBoxPets.Name = "listBoxPets";
            this.listBoxPets.Size = new System.Drawing.Size(267, 304);
            this.listBoxPets.TabIndex = 0;
            this.listBoxPets.SelectedIndexChanged += new System.EventHandler(this.listBoxPets_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBoxCatteries);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(282, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 449);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonPartnerInfo);
            this.panel4.Controls.Add(this.buttonAddKitty);
            this.panel4.Controls.Add(this.pictureBoxPartner);
            this.panel4.Controls.Add(this.labelPartnerColorCode);
            this.panel4.Controls.Add(this.buttonChangePartnerInfo);
            this.panel4.Controls.Add(this.labelPartnerBday);
            this.panel4.Controls.Add(this.labelPartnerName);
            this.panel4.Controls.Add(this.labelPartnerEarsCode);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 333);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 116);
            this.panel4.TabIndex = 3;
            // 
            // buttonPartnerInfo
            // 
            this.buttonPartnerInfo.Location = new System.Drawing.Point(124, 69);
            this.buttonPartnerInfo.Name = "buttonPartnerInfo";
            this.buttonPartnerInfo.Size = new System.Drawing.Size(138, 22);
            this.buttonPartnerInfo.TabIndex = 4;
            this.buttonPartnerInfo.Text = "Инфо о жив-м и хоз-х";
            this.buttonPartnerInfo.UseVisualStyleBackColor = true;
            this.buttonPartnerInfo.Click += new System.EventHandler(this.buttonPartnerInfo_Click);
            // 
            // buttonAddKitty
            // 
            this.buttonAddKitty.Location = new System.Drawing.Point(195, 93);
            this.buttonAddKitty.Name = "buttonAddKitty";
            this.buttonAddKitty.Size = new System.Drawing.Size(66, 20);
            this.buttonAddKitty.TabIndex = 3;
            this.buttonAddKitty.Text = "Котенок";
            this.buttonAddKitty.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPartner
            // 
            this.pictureBoxPartner.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPartner.Name = "pictureBoxPartner";
            this.pictureBoxPartner.Size = new System.Drawing.Size(115, 110);
            this.pictureBoxPartner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPartner.TabIndex = 1;
            this.pictureBoxPartner.TabStop = false;
            // 
            // labelPartnerColorCode
            // 
            this.labelPartnerColorCode.AutoSize = true;
            this.labelPartnerColorCode.Location = new System.Drawing.Point(124, 37);
            this.labelPartnerColorCode.Name = "labelPartnerColorCode";
            this.labelPartnerColorCode.Size = new System.Drawing.Size(112, 13);
            this.labelPartnerColorCode.TabIndex = 2;
            this.labelPartnerColorCode.Text = "labelPartnerColorCode";
            // 
            // buttonChangePartnerInfo
            // 
            this.buttonChangePartnerInfo.Location = new System.Drawing.Point(124, 93);
            this.buttonChangePartnerInfo.Name = "buttonChangePartnerInfo";
            this.buttonChangePartnerInfo.Size = new System.Drawing.Size(66, 20);
            this.buttonChangePartnerInfo.TabIndex = 3;
            this.buttonChangePartnerInfo.Text = "Изменить";
            this.buttonChangePartnerInfo.UseVisualStyleBackColor = true;
            this.buttonChangePartnerInfo.Click += new System.EventHandler(this.buttonChangePartnerInfo_Click);
            // 
            // labelPartnerBday
            // 
            this.labelPartnerBday.AutoSize = true;
            this.labelPartnerBday.Location = new System.Drawing.Point(124, 20);
            this.labelPartnerBday.Name = "labelPartnerBday";
            this.labelPartnerBday.Size = new System.Drawing.Size(87, 13);
            this.labelPartnerBday.TabIndex = 2;
            this.labelPartnerBday.Text = "labelPartnerBday";
            // 
            // labelPartnerName
            // 
            this.labelPartnerName.AutoSize = true;
            this.labelPartnerName.Location = new System.Drawing.Point(124, 3);
            this.labelPartnerName.Name = "labelPartnerName";
            this.labelPartnerName.Size = new System.Drawing.Size(91, 13);
            this.labelPartnerName.TabIndex = 2;
            this.labelPartnerName.Text = "labelPartnerName";
            // 
            // labelPartnerEarsCode
            // 
            this.labelPartnerEarsCode.AutoSize = true;
            this.labelPartnerEarsCode.Location = new System.Drawing.Point(124, 54);
            this.labelPartnerEarsCode.Name = "labelPartnerEarsCode";
            this.labelPartnerEarsCode.Size = new System.Drawing.Size(109, 13);
            this.labelPartnerEarsCode.TabIndex = 2;
            this.labelPartnerEarsCode.Text = "labelPartnerEarsCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Вязка с:";
            // 
            // listBoxCatteries
            // 
            this.listBoxCatteries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCatteries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxCatteries.FormattingEnabled = true;
            this.listBoxCatteries.ItemHeight = 20;
            this.listBoxCatteries.Location = new System.Drawing.Point(3, 23);
            this.listBoxCatteries.Name = "listBoxCatteries";
            this.listBoxCatteries.Size = new System.Drawing.Size(267, 304);
            this.listBoxCatteries.TabIndex = 0;
            this.listBoxCatteries.SelectedIndexChanged += new System.EventHandler(this.listBoxCatteries_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.listBoxKitties);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(561, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 449);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pictureBoxKitty);
            this.panel5.Controls.Add(this.labelKittyColorCode);
            this.panel5.Controls.Add(this.buttonChangeKittyInfo);
            this.panel5.Controls.Add(this.labelKittyBday);
            this.panel5.Controls.Add(this.labelKittyName);
            this.panel5.Controls.Add(this.labelKittyEarsCode);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 333);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(274, 116);
            this.panel5.TabIndex = 2;
            // 
            // pictureBoxKitty
            // 
            this.pictureBoxKitty.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxKitty.Name = "pictureBoxKitty";
            this.pictureBoxKitty.Size = new System.Drawing.Size(115, 110);
            this.pictureBoxKitty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxKitty.TabIndex = 1;
            this.pictureBoxKitty.TabStop = false;
            // 
            // labelKittyColorCode
            // 
            this.labelKittyColorCode.AutoSize = true;
            this.labelKittyColorCode.Location = new System.Drawing.Point(124, 37);
            this.labelKittyColorCode.Name = "labelKittyColorCode";
            this.labelKittyColorCode.Size = new System.Drawing.Size(98, 13);
            this.labelKittyColorCode.TabIndex = 2;
            this.labelKittyColorCode.Text = "labelKittyColorCode";
            // 
            // buttonChangeKittyInfo
            // 
            this.buttonChangeKittyInfo.Location = new System.Drawing.Point(125, 70);
            this.buttonChangeKittyInfo.Name = "buttonChangeKittyInfo";
            this.buttonChangeKittyInfo.Size = new System.Drawing.Size(66, 43);
            this.buttonChangeKittyInfo.TabIndex = 3;
            this.buttonChangeKittyInfo.Text = "Изменить инфо";
            this.buttonChangeKittyInfo.UseVisualStyleBackColor = true;
            // 
            // labelKittyBday
            // 
            this.labelKittyBday.AutoSize = true;
            this.labelKittyBday.Location = new System.Drawing.Point(124, 20);
            this.labelKittyBday.Name = "labelKittyBday";
            this.labelKittyBday.Size = new System.Drawing.Size(73, 13);
            this.labelKittyBday.TabIndex = 2;
            this.labelKittyBday.Text = "labelKittyBday";
            // 
            // labelKittyName
            // 
            this.labelKittyName.AutoSize = true;
            this.labelKittyName.Location = new System.Drawing.Point(124, 3);
            this.labelKittyName.Name = "labelKittyName";
            this.labelKittyName.Size = new System.Drawing.Size(77, 13);
            this.labelKittyName.TabIndex = 2;
            this.labelKittyName.Text = "labelKittyName";
            // 
            // labelKittyEarsCode
            // 
            this.labelKittyEarsCode.AutoSize = true;
            this.labelKittyEarsCode.Location = new System.Drawing.Point(124, 54);
            this.labelKittyEarsCode.Name = "labelKittyEarsCode";
            this.labelKittyEarsCode.Size = new System.Drawing.Size(95, 13);
            this.labelKittyEarsCode.TabIndex = 2;
            this.labelKittyEarsCode.Text = "labelKittyEarsCode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Котята вязки:";
            // 
            // listBoxKitties
            // 
            this.listBoxKitties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxKitties.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxKitties.FormattingEnabled = true;
            this.listBoxKitties.ItemHeight = 20;
            this.listBoxKitties.Location = new System.Drawing.Point(3, 23);
            this.listBoxKitties.Name = "listBoxKitties";
            this.listBoxKitties.Size = new System.Drawing.Size(268, 304);
            this.listBoxKitties.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПитомецToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новыйПитомецToolStripMenuItem
            // 
            this.новыйПитомецToolStripMenuItem.Name = "новыйПитомецToolStripMenuItem";
            this.новыйПитомецToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.новыйПитомецToolStripMenuItem.Text = "Новый питомец";
            this.новыйПитомецToolStripMenuItem.Click += new System.EventHandler(this.новыйПитомецToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 479);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Вязки";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelPets.ResumeLayout(false);
            this.panelPets.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPartner)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKitty)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelPets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonAddCatPartner;
        private System.Windows.Forms.Button buttonChangePetInfo;
        private System.Windows.Forms.Label labelPetEarsCode;
        private System.Windows.Forms.Label labelPetColorCode;
        private System.Windows.Forms.Label labelPetBday;
        private System.Windows.Forms.Label labelPetName;
        private System.Windows.Forms.PictureBox pictureBoxPet;
        private System.Windows.Forms.ListBox listBoxPets;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonAddKitty;
        private System.Windows.Forms.PictureBox pictureBoxPartner;
        private System.Windows.Forms.Label labelPartnerColorCode;
        private System.Windows.Forms.Button buttonChangePartnerInfo;
        private System.Windows.Forms.Label labelPartnerBday;
        private System.Windows.Forms.Label labelPartnerName;
        private System.Windows.Forms.Label labelPartnerEarsCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxCatteries;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBoxKitty;
        private System.Windows.Forms.Label labelKittyColorCode;
        private System.Windows.Forms.Button buttonChangeKittyInfo;
        private System.Windows.Forms.Label labelKittyBday;
        private System.Windows.Forms.Label labelKittyName;
        private System.Windows.Forms.Label labelKittyEarsCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxKitties;
        private System.Windows.Forms.Button buttonPartnerInfo;
        private System.Windows.Forms.ToolStripMenuItem новыйПитомецToolStripMenuItem;
    }
}

