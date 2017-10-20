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
        List<Cat> cats = new List<Cat>();
        List<Cattery> catteries = new List<Cattery>();
        public enum FormCatInfoModes { NewPet, NewPartner, PartnerInfo, NewKitty, ChangeInfo, NewItem };

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
                labelPetName.Text = cats[listBoxPets.SelectedIndex].Name;
                labelPetBday.Text = cats[listBoxPets.SelectedIndex].BirthDate.ToShortDateString();
                labelPetColorCode.Text = cats[listBoxPets.SelectedIndex].ColorCode;
                labelPetEarsCode.Text = cats[listBoxPets.SelectedIndex].EarsTypeCode;

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
                            }
                        }
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Файл базы данных отсутствует");
            }
        }

        private void buttonChangePetInfo_Click(object sender, EventArgs e)
        {
            if (listBoxPets.SelectedIndex != -1)
            {
                FormCatInfo fci = new FormCatInfo("my_pets", "Изменение информации о питомце", FormCatInfoModes.ChangeInfo, cats[listBoxPets.SelectedIndex]);
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
                FormCatInfo fci = new FormCatInfo("cat_partners", "Информация", FormCatInfoModes.PartnerInfo, catteries[listBoxCatteries.SelectedIndex] );
                fci.ShowDialog();
                listBoxCatteries.SelectedIndex = selectedIndex;
            }
        }

        private void listBoxCatteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCatteries.SelectedIndex != -1)
            {
                labelPartnerName.Text = catteries[listBoxCatteries.SelectedIndex].Partner.Name;
                labelPartnerEarsCode.Text = catteries[listBoxCatteries.SelectedIndex].Partner.EarsTypeCode;
                labelPartnerColorCode.Text = catteries[listBoxCatteries.SelectedIndex].Partner.ColorCode;
                labelPartnerBday.Text = catteries[listBoxCatteries.SelectedIndex].Partner.BirthDate.ToShortDateString();
            }
        }
    }
}
