using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace czesciarium
{
    public partial class Form4 : Form
    {
        private string Imie { get; set; }
        private string Nazwisko { get; set; }
        private string Haslo { get; set; }
        private string Login { get; set; }

        public Form4(string imie, string nazwisko, string haslo)
        {
            InitializeComponent();

            Imie = imie;
            Nazwisko = nazwisko;
            Haslo = haslo;

            button3.ForeColor = ColorTranslator.FromHtml("#606461");
            button3.BackColor = ColorTranslator.FromHtml("#8BB59A");

            // Generuj i wyświetl login
            GenerujILogin();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button3.Enabled = true;
                button3.Cursor = Cursors.Hand;
            }
            else
            {
                button3.Enabled = false;
                button3.Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZapiszDoBazyDanych();
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_EnabledChanged(object sender, EventArgs e)
        {
            if (button3.Enabled == false)
            {
                button3.ForeColor = ColorTranslator.FromHtml("#606461");
                button3.BackColor = ColorTranslator.FromHtml("#8BB59A");
            }
            else
            {
                button3.ForeColor = ColorTranslator.FromHtml("#464E47");
                button3.BackColor = ColorTranslator.FromHtml("#96E6B3");
            }
        }

        private void GenerujILogin()
        {
            // Generuj login na podstawie imienia i nazwiska
            string podstawowyLogin = $"{Imie.Substring(0, 3)}{Nazwisko.Substring(0, 3)}";

            // Sprawdź, czy już istnieje pracownik o takim samym loginie
            Login = $"{podstawowyLogin}01"; // Początkowo ustaw jako 01
            int numer = 2; // Zaczynamy od liczby 2

            while (CzyLoginIstnieje(Login))
            {
                Login = $"{podstawowyLogin}{NumerFormatowany(numer)}";
                numer++;
            }

            label3.Text = $"Login: {Login}";
        }

        private bool CzyLoginIstnieje(string login)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM pracownicyTab WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas sprawdzania loginu w bazie danych: {ex.Message}");
                return true;
            }
        }

        private string NumerFormatowany(int numer)
        {
            return numer.ToString("D2");
        }

        private void ZapiszDoBazyDanych()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO pracownicyTab (Imie, Nazwisko, Haslo, Login) VALUES (@Imie, @Nazwisko, @Haslo, @Login)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Imie", Imie);
                        cmd.Parameters.AddWithValue("@Nazwisko", Nazwisko);
                        cmd.Parameters.AddWithValue("@Haslo", Haslo);
                        cmd.Parameters.AddWithValue("@Login", Login);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisywania do bazy danych: {ex.Message}");
            }
        }
    }
}
