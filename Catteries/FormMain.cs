using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Catteries
{
    public partial class FormMain : Form
    {
        List<Cat> cats = new List<Cat>();                   // список питомцев
        List<Cattery> catteries = new List<Cattery>();      // список вязок
        List<Cat> kitties = new List<Cat>();                // список котят вязки
        List<byte[]> petsImages = new List<byte[]>();         // изображения питомцев
        List<byte[]> partnersImages = new List<byte[]>();     // изображения партнеров
        List<byte[]> kittiesImages = new List<byte[]>();     // изображения котят
        public enum FormCatInfoModes { NewPet, NewPartnerOrKitty, PartnerOrKittyInfo, ChangeInfo, NewItem, Edit };    // режимы запуска окна с информацией о кошке

        public FormMain()
        {
            InitializeComponent();
            Initialize();
        }

        private bool CheckAndCreateDBPathes()
        {
            bool result = false;
            try
            {
                string pathToDB = Application.StartupPath;
                string dataBase = Path.Combine(pathToDB, "catsdb2.db");           
                if (!File.Exists(dataBase))
                    System.IO.File.WriteAllBytes(dataBase, Properties.Resources.catsdb);
                result = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Произошла ошибка при создании папки к БД:\n" + exc.Message);
                result = false;
            }
            return result;
        }

        void Initialize()
        {
            labelPetBday.Text = textBoxPetColorCode.Text = textBoxPetEarsCode.Text = labelPetName.Text = String.Empty;
            labelPartnerBday.Text = textBoxPartnerColorCode.Text = textBoxPartnerEarsCode.Text = labelPartnerName.Text = String.Empty;
            labelKittyBday.Text = textBoxKittyColorCode.Text = textBoxKittyEarsCode.Text = labelKittyName.Text = String.Empty;
            pictureBoxPet.Image = pictureBoxPartner.Image = pictureBoxKitty.Image = null;
            pictureBoxPetGender.Image = pictureBoxPartnerGender.Image = pictureBoxKittyGender.Image = null;
            petsImages.Clear(); partnersImages.Clear(); kittiesImages.Clear();

            listBoxPets.Items.Clear();
            CatteriesInfoClear();
            KittiesInfoClear();

            CheckAndCreateDBPathes();

            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM 'my_pets'", connection);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                    DataSet sds = new DataSet();
                    sda.Fill(sds);
                    foreach (DataRow row in sds.Tables[0].Rows)
                    {
                        cats.Add(new Cat(row));
                        listBoxPets.Items.Add(row["Name"]);
                        byte[] a = null;
                        try
                        {
                            a = (System.Byte[])row["Image"];
                        }
                        catch { }
                        petsImages.Add(a);
                    }
                    cmd.CommandText = "PRAGMA FOREIGN_KEYS=ON";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Файл базы данных отсутствует");
        }

        private void новыйПитомецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatInfo fci = new FormCatInfo("my_pets", "Новый питомец", FormCatInfoModes.NewPet);
            fci.ShowDialog();
            this.Cursor = Cursors.WaitCursor;
            Initialize();
            this.Cursor = DefaultCursor;
        }

        private void listBoxPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPets.SelectedIndex != -1)
            {
                int index = listBoxPets.SelectedIndex;
                labelPetName.Text = cats[index].Name;
                labelPetBday.Text = cats[index].BirthDate.ToShortDateString();
                textBoxPetColorCode.Text = String.Format("Окрас: {0} [{1}]", cats[index].ColorName, cats[index].ColorCode);
                textBoxPetEarsCode.Text = String.Format("Ушки: {0} [{1}]", cats[index].EarsTypeName, cats[index].EarsTypeCode);
                pictureBoxPet.Image = ByteToImage(petsImages[index]);
                if (cats[index].IsMale)
                    pictureBoxPetGender.Image = Properties.Resources.male;
                else
                    pictureBoxPetGender.Image = Properties.Resources.female;

                CatteriesInfoClear();
                KittiesInfoClear();

                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM 'catteries' WHERE PetID = " + cats[listBoxPets.SelectedIndex].Id, connection);
                        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                        DataSet sds = new DataSet();
                        sda.Fill(sds);
                        foreach (DataRow row in sds.Tables[0].Rows)
                        {
                            catteries.Add(new Cattery(row));
                        }
                        foreach (Cattery ctt in catteries)
                        {
                            cmd.CommandText = "SELECT * FROM 'cat_partners' WHERE ID = " + ctt.PartnerID;
                            sda.SelectCommand = cmd;
                            sds = new DataSet();
                            sda.Fill(sds);
                            foreach (DataRow row in sds.Tables[0].Rows)
                            {
                                ctt.Partner = new Cat(row);
                                listBoxCatteries.Items.Add(ctt.Date.ToShortDateString() + " - " + ctt.Partner.Name);
                                byte[] buffer = null;
                                try
                                {
                                    buffer = (System.Byte[])row["Image"];
                                }
                                catch { }
                                partnersImages.Add(buffer);
                            }
                        }
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Файл базы данных отсутствует");
            }
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

        private void buttonChangePetInfo_Click(object sender, EventArgs e)
        {
            if (listBoxPets.SelectedIndex != -1)
            {
                int index = listBoxPets.SelectedIndex;
                FormCatInfo fci = new FormCatInfo("my_pets", "Изменение информации о питомце", FormCatInfoModes.ChangeInfo, cats[index]);                
                fci.Image = ByteToImage(petsImages[index]);
                fci.ShowDialog();
                this.Cursor = Cursors.WaitCursor;
                Initialize();
                this.Cursor = DefaultCursor;
            }
        }

        private void buttonAddCatPartner_Click(object sender, EventArgs e)
        {
            if (listBoxPets.SelectedIndex != -1)
            {
                int selectedIndex = listBoxPets.SelectedIndex;
                FormCattery fc = new FormCattery("Новая запись", FormCatInfoModes.NewItem, cats[listBoxPets.SelectedIndex].Id);
                fc.ShowDialog();
                listBoxPets.SelectedIndex = selectedIndex;
            }
        }

        private void buttonChangePartnerInfo_Click(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                int selectedIndex = listBoxCatteries.SelectedIndex;
                FormCattery fc = new FormCattery("Изменение", FormCatInfoModes.ChangeInfo, catteries[listBoxCatteries.SelectedIndex]);
                fc.ShowDialog();
                listBoxCatteries.SelectedIndex = selectedIndex;
            }
        }

        private void buttonPartnerInfo_Click(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                int catterySelectedIndex = listBoxCatteries.SelectedIndex;
                int petSelectedIndex = listBoxPets.SelectedIndex;
                FormCatInfo fci = new FormCatInfo("cat_partners", "Информация", FormCatInfoModes.PartnerOrKittyInfo, catteries[catterySelectedIndex]);
                fci.Image = ByteToImage(partnersImages[catterySelectedIndex]);
                fci.ShowDialog();  
                listBoxPets_SelectedIndexChanged(sender, e);
                listBoxCatteries.SelectedIndex = catterySelectedIndex;
            }
        }

        private void listBoxCatteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                int index = listBoxCatteries.SelectedIndex;
                labelPartnerName.Text = catteries[index].Partner.Name;
                textBoxPartnerEarsCode.Text = String.Format("Ушки: {0} [{1}]", catteries[index].Partner.EarsTypeName, catteries[index].Partner.EarsTypeCode);
                textBoxPartnerColorCode.Text = String.Format("Окрас: {0} [{1}]", catteries[index].Partner.ColorName, catteries[index].Partner.ColorCode);
                labelPartnerBday.Text = catteries[index].Partner.BirthDate.ToShortDateString();
                pictureBoxPartner.Image = ByteToImage(partnersImages[index]);
                if (catteries[index].Partner.IsMale)
                    pictureBoxPartnerGender.Image = Properties.Resources.male;
                else
                    pictureBoxPartnerGender.Image = Properties.Resources.female;

                KittiesInfoClear();

                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM 'kitties' WHERE CatteryID = " + catteries[index].Id, connection);
                        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                        DataSet sds = new DataSet();
                        sda.Fill(sds);
                        // TODO: оформить инициализацию котят по строке результата из БД
                        foreach (DataRow row in sds.Tables[0].Rows)
                        {
                            kitties.Add(new Cat(row));
                            listBoxKitties.Items.Add(string.Format("{0} ({1})", row["Name"], Convert.ToDateTime(row["BirthDate"]).ToShortDateString()));
                            byte[] buffer = null;
                            try
                            {
                                buffer = (System.Byte[])row["Image"];
                            }
                            catch { }
                            kittiesImages.Add(buffer);
                        }                        
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Файл базы данных отсутствует");
            }
        }

        private void buttonAddKitty_Click(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                FormCatInfo fci = new FormCatInfo("kitties", "Новый котёнок", FormMain.FormCatInfoModes.NewPartnerOrKitty, catteries[listBoxCatteries.SelectedIndex]);
                fci.ShowDialog();
                listBoxCatteries_SelectedIndexChanged(sender, e);
            }
        }

        private void buttonChangeKittyInfo_Click(object sender, EventArgs e)
        {
            if (listBoxKitties.SelectedIndex != -1)
            {
                int kittySelectedIndex = listBoxKitties.SelectedIndex;
                int catterySelectedIndex = listBoxCatteries.SelectedIndex;
                FormCatInfo fci = new FormCatInfo("kitties", "Информация", FormCatInfoModes.PartnerOrKittyInfo, kitties[kittySelectedIndex]);
                fci.Image = ByteToImage(kittiesImages[kittySelectedIndex]);
                fci.ShowDialog();
                listBoxCatteries_SelectedIndexChanged(sender, e);
                listBoxKitties.SelectedIndex = kittySelectedIndex;
            }
        }

        private void listBoxKitties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKitties.SelectedIndex != -1)
            {
                int index = listBoxKitties.SelectedIndex;
                labelKittyName.Text = kitties[index].Name;
                labelKittyBday.Text = kitties[index].BirthDate.ToShortDateString();
                textBoxKittyEarsCode.Text = String.Format("Ушки: {0} [{1}]", kitties[index].EarsTypeName, kitties[index].EarsTypeCode);
                textBoxKittyColorCode.Text = String.Format("Окрас: {0} [{1}]", kitties[index].ColorName, kitties[index].ColorCode);
                pictureBoxKitty.Image = ByteToImage(kittiesImages[index]);
                if (kitties[index].IsMale)
                    pictureBoxKittyGender.Image = Properties.Resources.male;
                else
                    pictureBoxKittyGender.Image = Properties.Resources.female;
            }
        }

        private void KittiesInfoClear()
        {
            listBoxKitties.Items.Clear();
            kittiesImages.Clear();
            kitties.Clear();

            labelKittyBday.Text = textBoxKittyColorCode.Text = 
                textBoxKittyEarsCode.Text = labelKittyName.Text = string.Empty;
            pictureBoxKitty.Image = pictureBoxKittyGender.Image = null;
        }

        private void CatteriesInfoClear()
        {
            listBoxCatteries.Items.Clear();
            catteries.Clear();
            partnersImages.Clear();

            labelPartnerBday.Text = textBoxKittyColorCode.Text =
                textBoxKittyEarsCode.Text = labelPartnerName.Text = string.Empty;
            pictureBoxPartner.Image = pictureBoxPartnerGender.Image = null;
        }

        private void listBoxPets_MouseDown(object sender, MouseEventArgs e)
        {
            ShowContextMenu(listBoxPets, "pets", sender, e);
        }

        private void listBoxCatteries_MouseDown(object sender, MouseEventArgs e)
        {
            ShowContextMenu(listBoxCatteries, "catteries", sender, e);
        }

        private void listBoxKitties_MouseDown(object sender, MouseEventArgs e)
        {
            ShowContextMenu(listBoxKitties, "kitties", sender, e);
        }

        /// <summary>
        /// Показать контекстное меню для определенного листбокса
        /// </summary>
        /// <param name="lb">Листбокс</param>
        /// <param name="lbName">Имя режима</param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowContextMenu(ListBox lb, string lbName, object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int y = e.Y / lb.ItemHeight;
            
                if (y < lb.Items.Count)
                    lb.SelectedIndex = lb.TopIndex + y;
            
                if (lb.SelectedIndex != -1)
                {
                    switch (lbName)
                    {
                        case "pets":
                            contextMenuStripPet.Show(Cursor.Position);
                            break;
                        case "catteries":
                            contextMenuStripCattery.Show(Cursor.Position);
                            break;
                        case "kitties":
                            contextMenuStripKitty.Show(Cursor.Position);
                            break;
                    }                    
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить питомца " + labelPetName.Text + "?\nПри этом будет удалена вся информация о вязках и котятах этих вязок",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("PRAGMA FOREIGN_KEYS=ON", connection);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM 'my_pets' WHERE ID = " + cats[listBoxPets.SelectedIndex].Id;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                Initialize();
            }
        }

        private void удалитьВыбраннуюВязкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить вязку " + listBoxCatteries.SelectedItem.ToString() + "?\nПри этом будет удалена вся информация о котятах этой вязки",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("PRAGMA FOREIGN_KEYS=ON", connection);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM 'catteries' WHERE ID = " + catteries[listBoxCatteries.SelectedIndex].Id;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                Initialize();
            }
        }

        private void удалитьВыбранногоКотёнкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить котенка " + labelKittyName.Text + "?",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                if (File.Exists(dataBase))
                {
                    using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                    {
                        connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand("PRAGMA FOREIGN_KEYS=ON", connection);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM 'kitties' WHERE ID = " + kitties[listBoxKitties.SelectedIndex].Id;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                Initialize();
            }
        }

        private void редакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatInfo fci = new FormCatInfo("my_pets", "Редактирование элементов", FormCatInfoModes.Edit);
            fci.ShowDialog();
        }
    }
}
