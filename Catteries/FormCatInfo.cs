using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Collections.Generic;

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
        List<int> elemIDs = new List<int>();

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

        /// <summary>
        /// Вывести инфо о кошке
        /// </summary>
        private void ShowCatInfo()
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
            if (Image != null)
                pictureBox1.Image = Image;
        }
        
        private void FormCatInfo_Load(object sender, EventArgs e)
        {   
            if (mode != FormMain.FormCatInfoModes.Edit)
                panelElements.Visible = false;
            else
            {
                radioButtonPets.Checked = true;
                button1.Text = "Сохранить изменения";
            }
            if (mode == FormMain.FormCatInfoModes.ChangeInfo | 
                mode == FormMain.FormCatInfoModes.PartnerOrKittyInfo)
            {
                ShowCatInfo();
                this.Width = 590;
                this.Height = 341;
            }
            if (mode != FormMain.FormCatInfoModes.NewPartnerOrKitty & 
                mode != FormMain.FormCatInfoModes.PartnerOrKittyInfo &
                mode != FormMain.FormCatInfoModes.Edit)
            {
                groupBoxOwners.Visible = false;
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

        public void ChangePetInfo(NecessaryInfo ni, SQLiteCommand cmd, SQLiteConnection connection)
        {
            cmd = new SQLiteCommand(
                                String.Format("UPDATE '" + db_name + "' SET Name = '{0}', BirthDate = '{1}', ColorCode = '{2}', EarsTypeCode = '{3}', " +
                                "EarsTypeName = '{4}', ColorName = '{5}', IsMale = '{6}' where ID = " + cat.Id,
                                ni.name, ni.bDate, ni.colorCode, ni.earsCode, ni.earsName, ni.colorName, ni.isMale), connection);
            cmd.ExecuteNonQuery();
            if (imageBuffer != null)
            {
                cmd.CommandText = "UPDATE '" + db_name + "' SET Image = @photo WHERE ID = " + cat.Id;
                cmd.Parameters.Add("@photo", DbType.Binary, 8000).Value = imageBuffer;
                cmd.ExecuteNonQuery();
            }
        }

        public void ChangePartnerOrKittyInfo(NecessaryInfo ni, SQLiteCommand cmd, SQLiteConnection connection, string owners_db)
        {
            cmd = new SQLiteCommand(
                                    String.Format("UPDATE '" + db_name + "' SET Name = '{0}', BirthDate = '{1}', ColorCode = '{2}', EarsTypeCode = '{3}', " +
                                    "EarsTypeName = '{4}', ColorName = '{5}', IsMale = '{6}' where ID = " + cat.Id,
                                    ni.name, ni.bDate, ni.colorCode, ni.earsCode, ni.earsName, ni.colorName, ni.isMale), connection);
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
        }

        public struct NecessaryInfo
        {
            public string name;
            public string bDate;
            public string colorCode;
            public string earsCode;
            public string colorName;
            public string earsName;
            public bool isMale;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                NecessaryInfo ni;
                //string name = textBoxName.Text;
                //string bDate = dateTimePickerBday.Value.ToString("yyyy-MM-dd");
                //string colorCode = textBoxColorCode.Text;
                //string earsCode = textBoxEarsCode.Text;
                //string colorName = textBoxColorName.Text;
                //string earsName = comboBoxEarsName.Text;
                //bool isMale = (radioButtonMale.Checked) ? true : false;
                ni.name = textBoxName.Text;
                ni.bDate = dateTimePickerBday.Value.ToString("yyyy-MM-dd");
                ni.colorCode = textBoxColorCode.Text;
                ni.earsCode = textBoxEarsCode.Text;
                ni.colorName = textBoxColorName.Text;
                ni.earsName = comboBoxEarsName.Text;
                ni.isMale = (radioButtonMale.Checked) ? true : false;

                if (ni.name.Length > 0)
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        SQLiteCommand cmd = new SQLiteCommand();
                        connection.Open();
                        string owners_db = (db_name == "kitties") ? "kitties_owners" : "cats_owners";
                        switch (mode)
                        {
                            case FormMain.FormCatInfoModes.NewPet:
                                cmd = new SQLiteCommand(
                                    String.Format("INSERT INTO '" + db_name + "' (Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                    "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                    ni.name, ni.bDate, ni.colorCode, ni.earsCode, ni.earsName, ni.colorName, ni.isMale), connection);
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
                                ChangePetInfo(ni, cmd, connection);
                                break;
                            case FormMain.FormCatInfoModes.NewPartnerOrKitty:
                                cmd = new SQLiteCommand();
                                cmd.Connection = connection;
                                if (db_name != "kitties")
                                {
                                    cmd.CommandText = String.Format("INSERT INTO '" + db_name + "' (Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                    "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                    ni.name, ni.bDate, ni.colorCode, ni.earsCode, ni.earsName, ni.colorName, ni.isMale);
                                }
                                else
                                {
                                    cmd.CommandText = String.Format("INSERT INTO '" + db_name + "' (CatteryID, PetID, PartnerID, Name, BirthDate, ColorCode, EarsTypeCode, EarsTypeName, ColorName, IsMale) " +
                                    "values ({7}, {8}, {9}, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                    ni.name, ni.bDate, ni.colorCode, ni.earsCode, ni.earsName, ni.colorName, ni.isMale, cattery.Id, cattery.PetID, cattery.PartnerID);
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
                                ChangePartnerOrKittyInfo(ni, cmd, connection, owners_db);
                                break;
                            case FormMain.FormCatInfoModes.Edit:
                                if (textBoxName.Text.Length > 0)
                                    if (radioButtonPets.Checked)
                                    {
                                        ChangePetInfo(ni, cmd, connection);
                                    }
                                    else
                                    {
                                        db_name = (radioButtonKitties.Checked) ? "kitties" : "cat_partners";
                                        owners_db = (db_name == "kitties") ? "kitties_owners" : "cats_owners";
                                        ChangePartnerOrKittyInfo(ni, cmd, connection, owners_db);
                                    }
                                break;
                        }
                        connection.Close();
                    }
                else
                    MessageBox.Show("Для выполнения данной операции необходимо указать имя", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (mode != FormMain.FormCatInfoModes.Edit)
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

        /// <summary>
        /// Выборка элементов из БД
        /// </summary>
        /// <param name="table">Таблица</param>
        /// <param name="where">Условия выборки</param>
        private void SelectElements(string table, string where)
        {
            elemIDs.Clear();
            listBoxElements.Items.Clear();
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    SQLiteCommand cmd =
                        new SQLiteCommand(string.Format("SELECT ID, Name FROM '{0}'{1} ORDER BY Name",
                        table, (where.Length > 0) ? "WHERE " + where : string.Empty), connection);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                    DataSet sds = new DataSet();
                    sda.Fill(sds);
                    foreach (DataRow row in sds.Tables[0].Rows)
                    {
                        listBoxElements.Items.Add(row["Name"].ToString());
                        elemIDs.Add(Convert.ToInt32(row["ID"]));
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPets.Checked)
            {
                SelectElements("my_pets", "");
                groupBoxOwners.Visible = false;
            }
        }

        private void radioButtonPartners_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPartners.Checked)
            {
                SelectElements("cat_partners", "");
                groupBoxOwners.Visible = true;
            }
        }

        private void radioButtonKitties_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKitties.Checked)
            {
                SelectElements("kitties", "");
                groupBoxOwners.Visible = true;
            }
        }

        /// <summary>
        /// Запрос информации о кошке
        /// </summary>
        /// <param name="table">Таблица</param>
        /// <param name="where">Условие</param>
        private void ShowElementInfo(string table, string where)
        {
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    SQLiteCommand cmd =
                        new SQLiteCommand(string.Format("SELECT * FROM '{0}'{1}", table,
                        (where.Length > 0) ? "WHERE " + where : string.Empty), connection);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                    DataSet sds = new DataSet();
                    sda.Fill(sds);
                    foreach (DataRow row in sds.Tables[0].Rows)
                    {
                        this.cat = new Cat(row);
                        byte[] a = null;
                        try
                        {
                            a = (System.Byte[])row["Image"];
                        }
                        catch { }
                        Image = ByteToImage(a);
                    }
                    if (table != "my_pets")
                    {
                        cmd.CommandText = string.Format("SELECT * FROM '{0}' WHERE catid = {1}",
                            (table == "kitties") ? "kitties_owners" : "cats_owners", cat.Id);
                        sda = new SQLiteDataAdapter(cmd);
                        sds = new DataSet();
                        sda.Fill(sds);
                        foreach (DataRow row in sds.Tables[0].Rows)
                        {
                            textBoxOwnerName.Text = row["Name"].ToString();
                            textBoxOwnerContacts.Text = row["PhoneNumber"].ToString();
                            textBoxOwnerAddress.Text = row["Address"].ToString();
                        }
                    }
                }
                if (this.cat != null)
                    ShowCatInfo();
            }
        }

        private void listBoxElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = "", where = "";
            if (radioButtonKitties.Checked)
                table = "kitties";
            if (radioButtonPartners.Checked)
                table = "cat_partners";
            if (radioButtonPets.Checked)
                table = "my_pets";
            where = "ID = " + elemIDs[listBoxElements.SelectedIndex];
            ShowElementInfo(table, where);
        }

        /// <summary>
        /// Конвертер массива байт в объект изображения
        /// </summary>
        /// <param name="imageBytes">Массив байт</param>
        /// <returns></returns>
        public Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes != null)
            {
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = new Bitmap(ms);
                return image;
            }
            else
                return null;
        }

        private void listBoxElements_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int y = e.Y / listBoxElements.ItemHeight;

                if (y < listBoxElements.Items.Count)
                    listBoxElements.SelectedIndex = listBoxElements.TopIndex + y;

                if (listBoxElements.SelectedIndex != -1)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";
            string db = "";
            if (radioButtonKitties.Checked)
            {
                message = "Удалить котенка " + textBoxName.Text + "?";
                db = "kitties";
            }
            if (radioButtonPets.Checked)
            {
                message = "Удалить питомца " + textBoxName.Text + "?\nПри этом будет удалена вся информация о вязках и котятах этих вязок";
                db = "my_pets";
            }
            if (radioButtonPartners.Checked)
            {
                message = "Удалить " + textBoxName.Text + "?\nПри этом будет удалена вся информация о вязках и котятах этих вязок";
                db = "cat_partners";
            }
            if (MessageBox.Show(message, "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("PRAGMA FOREIGN_KEYS=ON", connection);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = String.Format("DELETE FROM '{0}' WHERE ID = {1}", db, elemIDs[listBoxElements.SelectedIndex]);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Success!");
                    }
                }

                switch (db)
                {
                    case "kitties":
                        radioButtonKitties.Checked = false;
                        radioButtonKitties.Checked = true;
                        break;
                    case "my_pets":
                        radioButtonPets.Checked = false;
                        radioButtonPets.Checked = true;
                        break;
                    case "cat_partners":
                        radioButtonPartners.Checked = false;
                        radioButtonPartners.Checked = true;
                        break;
                }
            }
        }
    }
}
