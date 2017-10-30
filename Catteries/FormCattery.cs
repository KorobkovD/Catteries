using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Catteries
{
    public partial class FormCattery : Form
    {
        List<int> cat_ids = new List<int>();
        FormMain.FormCatInfoModes mode;
        int petID;
        Cattery cattery;

        public FormCattery(string title, FormMain.FormCatInfoModes mode, int petID)
        {
            InitializeComponent();
            this.mode = mode;
            this.Text = title;
            this.petID = petID;
        }

        public FormCattery(string title, FormMain.FormCatInfoModes mode, Cattery cattery)
        {
            InitializeComponent();
            this.mode = mode;
            this.Text = title;
            this.cattery = cattery;
        }

        private void buttonAddPartner_Click(object sender, EventArgs e)
        {
            FormCatInfo fci = new FormCatInfo("cat_partners", "Новый партнер", FormMain.FormCatInfoModes.NewPartnerOrKitty);
            fci.ShowDialog();
            Initialize();
        }

        private void FormCattery_Load(object sender, EventArgs e)
        {
            Initialize();
            if (mode == FormMain.FormCatInfoModes.ChangeInfo)
            {
                textBoxPrice.Text = cattery.Price.ToString();
                dateTimePicker1.Value = cattery.Date;
                comboBoxPartners.SelectedIndex = cat_ids.IndexOf(cattery.PartnerID);
            }
        }

        void Initialize()
        {
            comboBoxPartners.Items.Clear();
            cat_ids.Clear();
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand(
                        string.Format("SELECT * FROM 'cat_partners' WHERE IsMale IS NOT " +
                        "(SELECT IsMale FROM 'my_pets' where ID = {0})", petID), connection);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                    DataSet sds = new DataSet();
                    sda.Fill(sds);
                    foreach (DataRow row in sds.Tables[0].Rows)
                    {
                        cat_ids.Add(Convert.ToInt32(row["ID"]));
                        comboBoxPartners.Items.Add(row["Name"].ToString());
                    }
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Файл базы данных отсутствует");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
            if (File.Exists(dataBase))
            {
                using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                {
                    connection.Open();
                    SQLiteCommand cmd;
                    switch (mode)
                    {
                        case FormMain.FormCatInfoModes.NewItem:
                            cmd = new SQLiteCommand(
                                String.Format("INSERT INTO 'catteries' (PetID, CatPartnerID, Date, Price) VALUES ({0}, {1}, '{2}', '{3}')",
                                petID, cat_ids[comboBoxPartners.SelectedIndex], dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBoxPrice.Text), connection);
                            cmd.ExecuteNonQuery();
                            break;
                        case FormMain.FormCatInfoModes.ChangeInfo:
                            cmd = new SQLiteCommand(
                                String.Format("UPDATE 'catteries' SET PetID = {0}, CatPartnerID = {1}, Date = '{2}', Price = '{3}' WHERE ID = " + cattery.Id,
                                cattery.PetID, cat_ids[comboBoxPartners.SelectedIndex], dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBoxPrice.Text), connection);
                            cmd.ExecuteNonQuery();
                            break;
                    }
                    connection.Close();
                }
            }
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxPrice.Text.IndexOf(',', 0) == -1)
            {
                if ((char)(',') == (e.KeyChar))
                    return;
            }

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
