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
        public enum FormCatInfoModes { NewPet, NewPartner, NewKitty };

        public FormMain()
        {
            InitializeComponent();

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
            FormCatInfo fci = new FormCatInfo("Новый питомец", FormCatInfoModes.NewPet);
            fci.ShowDialog();
        }

        private void listBoxPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPetName.Text = cats[listBoxPets.SelectedIndex].Name;
            labelPetBday.Text = cats[listBoxPets.SelectedIndex].BirthDate.ToShortDateString();
            labelPetColorCode.Text = cats[listBoxPets.SelectedIndex].ColorCode;
            labelPetEarsCode.Text = cats[listBoxPets.SelectedIndex].EarsTypeCode;
        }
    }
}
