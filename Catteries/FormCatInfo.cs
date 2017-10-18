using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Catteries
{
    public partial class FormCatInfo : Form
    {
        FormMain.FormCatInfoModes mode;

        public FormCatInfo(string title, FormMain.FormCatInfoModes mode)
        {
            InitializeComponent();
            this.Text = title;
            this.mode = mode;
        }

        private void FormCatInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case FormMain.FormCatInfoModes.NewPet:
                    string dataBase = System.IO.Path.Combine(Application.StartupPath, "catsdb2.db");
                    if (File.Exists(dataBase))
                    {
                        using (var connection = new SQLiteConnection(String.Format("Data Source={0};", dataBase)))
                        {
                            connection.Open();
                            SQLiteCommand cmd = new SQLiteCommand(
                                String.Format("INSERT INTO 'my_pets' (Name, BirthDate, ColorCode, EarsTypeCode) values ('{0}', '{1}', '{2}', '{3}')",
                                textBoxName.Text, dateTimePickerBday.Value.ToString("yyyy-MM-dd"), textBoxColorCode.Text, textBoxEarsCode.Text), connection);
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    break;
            }
        }
    }
}
