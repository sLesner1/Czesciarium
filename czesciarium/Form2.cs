using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace czesciarium
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool Zaloguj(string login, string haslo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM pracownicyTab WHERE Login = @Login AND Haslo = @Haslo";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string haslo = textBox2.Text;

            if (Zaloguj(login, haslo))
            {
                Form5 form5 = new Form5(login);
                this.Hide();
                form5.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błąd logowania. Sprawdź login i hasło.");
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.ShowDialog();
        }
    }
}
