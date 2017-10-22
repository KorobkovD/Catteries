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
        public enum FormCatInfoModes { NewPet, NewPartner, PartnerInfo, NewKitty, ChangeInfo, NewItem };    // режимы запуска окна с информацией о кошке

        public FormMain()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            labelPetBday.Text = labelPetColorCode.Text = labelPetEarsCode.Text = labelPetName.Text = String.Empty;
            labelPartnerBday.Text = labelPartnerColorCode.Text = labelPartnerEarsCode.Text = labelPartnerName.Text = String.Empty;
            labelKittyBday.Text = labelKittyColorCode.Text = labelKittyEarsCode.Text = labelKittyName.Text = String.Empty;
            pictureBoxPet.Image = pictureBoxPartner.Image = pictureBoxKitty.Image = null;

            listBoxPets.Items.Clear();
            listBoxCatteries.Items.Clear();
            listBoxKitties.Items.Clear();

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
                        byte[] a = (System.Byte[])row["Image"];
                        petsImages.Add(a);
                    }
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
                labelPetColorCode.Text = cats[index].ColorCode;
                labelPetEarsCode.Text = cats[index].EarsTypeCode;
                pictureBoxPet.Image = ByteToImage(petsImages[index]);

                listBoxCatteries.Items.Clear();
                catteries.Clear();
                partnersImages.Clear();
                listBoxKitties.Items.Clear();

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
                int selectedIndex = listBoxCatteries.SelectedIndex;
                FormCatInfo fci = new FormCatInfo("cat_partners", "Информация", FormCatInfoModes.PartnerInfo, catteries[selectedIndex]);
                fci.Image = ByteToImage(partnersImages[selectedIndex]);
                fci.ShowDialog();
                listBoxCatteries.SelectedIndex = selectedIndex;
            }
        }

        private void listBoxCatteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                int index = listBoxCatteries.SelectedIndex;
                labelPartnerName.Text = catteries[index].Partner.Name;
                labelPartnerEarsCode.Text = catteries[index].Partner.EarsTypeCode;
                labelPartnerColorCode.Text = catteries[index].Partner.ColorCode;
                labelPartnerBday.Text = catteries[index].Partner.BirthDate.ToShortDateString();
                pictureBoxPartner.Image = ByteToImage(partnersImages[index]);
            }
        }
    }
}
