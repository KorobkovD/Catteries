using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Drawing;

namespace Catteries
{
    public partial class FormCatInfo : Form
    {
        FormMain.FormCatInfoModes mode;
        string db_name;
        Cat cat;
        Cattery cattery;
        Array imageBuffer;
        Image image;

        public Image Image { get => image; set => image = value; }  

        public FormCatInfo(string db_name, string title, FormMain.FormCatInfoModes mode)
        {
            InitializeComponent();
            this.Text = title;
            this.mode = mode;
            this.db_name = db_name;
        }

        public FormCatInfo(string db_name, string title, FormMain.FormCatInfoModes mode, Cat cat)
        {
            InitializeComponent();
            this.Text = title;
            this.mode = mode;
            this.db_name = db_name;
            this.cat = cat;
            button1.Text = "Сохранить изменения";
        }

        public FormCatInfo(string db_name, string title, FormMain.FormCatInfoModes mode, Cattery cattery)
        {
            InitializeComponent();
            this.Text = title;
            this.mode = mode;
            this.db_name = db_name;
            this.cattery = cattery;
            this.cat = cattery.Partner;
            button1.Text = "Сохранить изменения";
        }

        private void FormCatInfo_Load(object sender, EventArgs e)
        {
            if (Image != null)
                pictureBox1.Image = Image;
            if (mode == FormMain.FormCatInfoModes.ChangeInfo | 
                mode == FormMain.FormCatInfoModes.PartnerOrKittyInfo)
            {
                textBoxName.Text = cat.Name;
                comboBoxEarsName.Text = cat.EarsTypeName;
                textBoxColorCode.Text = cat.ColorCode;
                dateTimePickerBday.Value = cat.BirthDate;
                textBoxColorName.Text = cat.ColorName;
                if (cat.IsMale)
                    radioButtonMale.Checked = true;
                else
                    radioButtonFemale.Checked = true;
            }
            if (mode != FormMain.FormCatInfoModes.NewPartnerOrKitty & mode != FormMain.FormCatInfoModes.PartnerOrKittyInfo)
            {
                groupBox1.Visible = false;
                this.Width = 590;
                this.Height = 200;
            }
            if (mode == FormMain.FormCatInfoModes.PartnerOrKittyInfo)
            {
                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        SQLiteCommand cmd = 
                            new SQLiteCommand(string.Format("SELECT * FROM '{0}' WHERE catid = {1}", 
                            (db_name == "kitties") ? "kitties_owners" : "cats_owners",
                            (db_name == "kitties") ? cat.Id : cattery.PartnerID), connection);
                        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                        DataSet sds = new DataSet();                        
                        sda.Fill(sds);
                        foreach (DataRow row in sds.Tables[0].Rows)
                        {
                            textBoxOwnerName.Text = row["Name"].ToString();
                            textBoxOwnerContacts.Text = row["PhoneNumber"].ToString();
                            textBoxOwnerAddress.Text = row["Address"].ToString();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                string name = textBoxName.Text;
                string bDate = dateTimePickerBday.Value.ToString("yyyy-MM-dd");
                string colorCode = textBoxColorCode.Text;
                string earsCode = textBoxEarsCode.Text;
                string colorName = textBoxColorName.Text;
                string earsName = comboBoxEarsName.Text;
                bool isMale = (radioButtonMale.Checked) ? true : false;

                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    SQLiteCommand cmd;
                    connection.Open();
                    string owners_db = (db_name == "kitties") ? "kitties_owners" : "cats_owners";
                    switch (mode)
                    {
                        case FormMain.FormCatInfoModes.NewPet:
                            cmd = new SQLiteCommand(
                                String.Format("INSERT INTO '" + db_name + "' (Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                name, bDate, colorCode, earsCode, earsName, colorName, isMale), connection);
                            cmd.ExecuteNonQuery();
                            if (imageBuffer != null)
                            {
                                cmd.CommandText = "SELECT max(ID) FROM '" + db_name + "'";
                                int petid = Convert.ToInt32(cmd.ExecuteScalar());
                                cmd.CommandText = "UPDATE '" + db_name + "' SET Image = @photo WHERE ID = " + petid;
                                cmd.Parameters.Add("@photo", DbType.Binary, 8000).Value = imageBuffer;
                                cmd.ExecuteNonQuery();
                            }
                            break;
                        case FormMain.FormCatInfoModes.ChangeInfo:
                            cmd = new SQLiteCommand(
                                String.Format("UPDATE '" + db_name + "' SET Name = '{0}', BirthDate = '{1}', ColorCode = '{2}', EarsTypeCode = '{3}', " +
                                "EarsTypeName = '{4}', ColorName = '{5}', IsMale = '{6}' where ID = " + cat.Id,
                                name, bDate, colorCode, earsCode, earsName, colorName, isMale), connection);
                            cmd.ExecuteNonQuery();
                            if (imageBuffer != null)
                            {
                                cmd.CommandText = "UPDATE '" + db_name + "' SET Image = @photo WHERE ID = " + cat.Id;
                                cmd.Parameters.Add("@photo", DbType.Binary, 8000).Value = imageBuffer;
                                cmd.ExecuteNonQuery();
                            }
                            break;
                        case FormMain.FormCatInfoModes.NewPartnerOrKitty:
                            cmd = new SQLiteCommand();
                            cmd.Connection = connection;
                            if (db_name != "kitties")
                            {
                                cmd.CommandText = String.Format("INSERT INTO '" + db_name + "' (Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                name, bDate, colorCode, earsCode, earsName, colorName, isMale);
                            }
                            else
                            {
                                cmd.CommandText = String.Format("INSERT INTO '" + db_name + "' (CatteryID, PetID, PartnerID, Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                "values ({7}, {8}, {9}, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                name, bDate, colorCode, earsCode, earsName, colorName, isMale, cattery.Id, cattery.PetID, cattery.PartnerID);
                            }
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "SELECT max(ID) FROM '" + db_name + "'";
                            int cid = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.CommandText = "UPDATE '" + db_name + "' SET Image = @photo WHERE ID = " + cid;
                            cmd.Parameters.Add("@photo", DbType.Binary, 8000).Value = imageBuffer;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = String.Format("INSERT INTO '" + owners_db + "' (Name, PhoneNumber, Address, CatID) VALUES ('{0}', '{1}', '{2}', {3})",
                                textBoxOwnerName.Text, textBoxOwnerContacts.Text, textBoxOwnerAddress.Text, cid);
                            cmd.ExecuteNonQuery();                            
                            break;
                        case FormMain.FormCatInfoModes.PartnerOrKittyInfo:
                            cmd = new SQLiteCommand(
                                String.Format("UPDATE '" + db_name + "' SET Name = '{0}', BirthDate = '{1}', ColorCode = '{2}', EarsTypeCode = '{3}', " +
                                "EarsTypeName = '{4}', ColorName = '{5}', IsMale = '{6}' where ID = " + cat.Id,
                                name, bDate, colorCode, earsCode, earsName, colorName, isMale), connection);
                            cmd.ExecuteNonQuery();
                            if (imageBuffer != null)
                            {
                                cmd.CommandText = "UPDATE '" + db_name + "' SET Image = @photo WHERE ID = " + cat.Id;
                                cmd.Parameters.Add("@photo", DbType.Binary, 8000).Value = imageBuffer;
                                cmd.ExecuteNonQuery();
                            }
                            cmd.CommandText = "SELECT ID FROM '" + owners_db + "' WHERE CatID = " + cat.Id;
                            object res = cmd.ExecuteScalar();
                            int id = (res != null) ? Convert.ToInt32(res) : -1;
                            if (id != -1)
                            {
                                cmd.CommandText = String.Format("UPDATE '" + owners_db + "' SET Name = '{0}', PhoneNumber = '{1}', Address = '{2}' WHERE CatID = " + cat.Id,
                                    textBoxOwnerName.Text, textBoxOwnerContacts.Text, textBoxOwnerAddress.Text);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = String.Format("INSERT INTO '" + owners_db + "' (Name, PhoneNumber, Address, catID) VALUES ('{0}', '{1}', '{2}', {3})",
                                textBoxOwnerName.Text, textBoxOwnerContacts.Text, textBoxOwnerAddress.Text, cat.Id);
                                cmd.ExecuteNonQuery();
                            }
                            break;
                    }
                    connection.Close();
                }
            }
            Close();
        }

        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBuffer = ms.ToArray();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEarsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEarsName.SelectedIndex)
            {
                case 0:
                    textBoxEarsCode.Text = "71";
                    break;
                case 1:
                    textBoxEarsCode.Text = "72";
                    break;
                case 2:
                    textBoxEarsCode.Text = "73";
                    break;
            }
        }
    }
}
