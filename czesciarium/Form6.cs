using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace czesciarium
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string haslo = textBox2.Text;

            if (Zaloguj(login, haslo))
            {
                Form7 form7 = new Form7();
                this.Hide();
                form7.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błąd logowania. Sprawdź login i hasło.");
            }
        }
        private bool Zaloguj(string login, string haslo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Administrator WHERE Login = @Login AND Haslo = @Haslo";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Haslo", haslo);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas logowania: {ex.Message}");
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool hasloOdkryteForm2 = false;

        private void button1_Click(object sender, EventArgs e)
        {
            hasloOdkryteForm2 = !hasloOdkryteForm2;
            UstawWidocznoscHaslaForm2(!hasloOdkryteForm2);
            if (!hasloOdkryteForm2)
            {
                button1.BackgroundImage = global::czesciarium.Properties.Resources.oko;
            }
            else
            {
                button1.BackgroundImage = global::czesciarium.Properties.Resources.nieoko;
            }
        }

        private void UstawWidocznoscHaslaForm2(bool widoczne)
        {
            textBox2.UseSystemPasswordChar = widoczne;
        }
    }
}
