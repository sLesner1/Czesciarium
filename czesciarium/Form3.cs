using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace czesciarium
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            // Dodaj obsługę zdarzeń TextChanged dla TextBoxów
            textBox1.TextChanged += PolaTekstowe_TextChanged;
            textBox2.TextChanged += PolaTekstowe_TextChanged;
            textBox3.TextChanged += PolaTekstowe_TextChanged;
            textBox4.TextChanged += PolaTekstowe_TextChanged;
            button3.ForeColor = ColorTranslator.FromHtml("#606461");
            button3.BackColor = ColorTranslator.FromHtml("#8BB59A");

            // Na początku ustaw przycisk na Disabled
            button3.Enabled = false;
        }

        private void PolaTekstowe_TextChanged(object sender, EventArgs e)
        {
            // Sprawdź, czy wszystkie pola są wypełnione
            bool wszystkiePolaWypelnione = !string.IsNullOrWhiteSpace(textBox1.Text)
                                          && !string.IsNullOrWhiteSpace(textBox2.Text)
                                          && !string.IsNullOrWhiteSpace(textBox3.Text)
                                          && !string.IsNullOrWhiteSpace(textBox4.Text);

            // Ustaw właściwość Enabled przycisku w zależności od wypełnienia pól
            button3.Enabled = wszystkiePolaWypelnione;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Pobierz dane z TextBoxów
            string imie = textBox1.Text;
            string nazwisko = textBox3.Text;
            string haslo = textBox2.Text;
            string powtorzHaslo = textBox4.Text;

            // Sprawdź, czy hasła są identyczne
            if (haslo != powtorzHaslo)
            {
                MessageBox.Show("Hasła nie są identyczne. Sprawdź i spróbuj ponownie.");
                return;
            }

            // Sprawdź, czy hasło spełnia kryteria walidacji
            if (WalidujHaslo(haslo))
            {
                Form4 form4 = new Form4(imie, nazwisko, haslo);
                this.Hide();
                form4.ShowDialog();
            }
            else
            {
                // Hasło nie spełnia kryteriów walidacji
                MessageBox.Show("Hasło nie spełnia wymagań. Sprawdź kryteria i spróbuj ponownie.");
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool WalidujHaslo(string haslo)
        {
            // Sprawdź, czy hasło ma przynajmniej 8 znaków
            if (haslo.Length < 8)
                return false;

            // Sprawdź, czy hasło zawiera przynajmniej jedną cyfrę
            if (!haslo.Any(char.IsDigit))
                return false;

            // Sprawdź, czy hasło zawiera przynajmniej jedną wielką literę
            if (!haslo.Any(char.IsUpper))
                return false;

            // Sprawdź, czy hasło zawiera przynajmniej jedną małą literę
            if (!haslo.Any(char.IsLower))
                return false;

            // Sprawdź, czy hasło zawiera przynajmniej jeden znak specjalny
            string znakiSpecjalne = @"!@#$%^&*()_+.,";
            if (!haslo.Any(c => znakiSpecjalne.Contains(c)))
                return false;

            // Jeżeli wszystkie kryteria są spełnione, zwróć true
            return true;
        }

        private void button3_EnabledChanged(object sender, EventArgs e)
        {
            if (button3.Enabled == false)
            {
                button3.ForeColor = ColorTranslator.FromHtml("#606461");
                button3.BackColor = ColorTranslator.FromHtml("#8BB59A");
                button3.Cursor = Cursors.Default;
            }
            else
            {
                button3.ForeColor = ColorTranslator.FromHtml("#464E47");
                button3.BackColor = ColorTranslator.FromHtml("#96E6B3");
                button3.Cursor = Cursors.Hand;
            }
        }

        private bool hasloOdkryte = false;

        private void button4_Click(object sender, EventArgs e)
        {
            hasloOdkryte = !hasloOdkryte; // Przełącz stan widoczności hasła
            UstawWidocznoscHasla(!hasloOdkryte); // Ustaw widoczność hasła
            if (!hasloOdkryte)
            {
                button4.BackgroundImage = global::czesciarium.Properties.Resources.oko;
            }
            else
            {
                button4.BackgroundImage = global::czesciarium.Properties.Resources.nieoko;
            }
        }

        private void UstawWidocznoscHasla(bool widoczne)
        {
            textBox2.UseSystemPasswordChar = widoczne; // Hasło
            textBox4.UseSystemPasswordChar = widoczne; // Powtórzenie hasła
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
