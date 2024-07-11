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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace czesciarium
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'pracownicyDataSet.pracownicyTab' . Możesz go przenieść lub usunąć.
            this.pracownicyTabTableAdapter.Fill(this.pracownicyDataSet.pracownicyTab);

        }

        private void pracownicyTabDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pracownicyTabDataGridView.CurrentRow.Selected = true;
            DataGridViewRow currentRow = pracownicyTabDataGridView.CurrentRow;
            tabControl1.SelectedIndex = 2;
            label12.Text = "Imię: " + currentRow.Cells[1].Value.ToString();
            label14.Text = "Nazwisko: " + currentRow.Cells[2].Value.ToString();
            label13.Text = "Login: " + currentRow.Cells[3].Value.ToString();
            label15.Text = "Hasło: " + currentRow.Cells[4].Value.ToString();
            textBox1.Text = currentRow.Cells[1].Value.ToString();
            textBox3.Text = currentRow.Cells[2].Value.ToString();
            textBox8.Text = currentRow.Cells[3].Value.ToString();
            textBox4.Text = currentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pracownicyTabDataGridView.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć ten element?", "Usunąć?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow currentRow = pracownicyTabDataGridView.CurrentRow;
                    int partIdToRemove = Convert.ToInt32(currentRow.Cells[0].Value);
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Czesci WHERE Identyfikator = @ID";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", partIdToRemove);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Odswiez();
                }
            }
            else
            {
                MessageBox.Show("nie wybrano nic" + pracownicyTabDataGridView.SelectedRows);
            }
        }
        private void Odswiez()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Czesci";
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    pracownicyTabDataGridView.DataSource = dataTable;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();
        }

        private void pracownicyTabDataGridView_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pracownicyTabDataGridView.ClientRectangle, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.groupBox1.ClientRectangle, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            tabControl1.SelectedTab = tabPage3;
            DataGridViewRow currentRow = pracownicyTabDataGridView.CurrentRow;
            textBox1.Text = currentRow.Cells[1].Value.ToString();
            textBox3.Text = currentRow.Cells[2].Value.ToString();
            textBox8.Text = currentRow.Cells[3].Value.ToString();
            textBox4.Text = currentRow.Cells[4].Value.ToString();
            tabControl1.SelectedIndex = 2;
            if (pracownicyTabDataGridView.CurrentRow != null)
            {
                DataGridViewRow currentRow1 = pracownicyTabDataGridView.CurrentRow;
                int x = Convert.ToInt32(currentRow.Cells[0].Value);
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE PracownicyTab SET Imie = @imie, Nazwisko = @nazwisko, Login = @login, Hasło = @hasło WHERE Identyfikator = @Id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                            cmd.Parameters.AddWithValue("@Imie", textBox3.Text);
                            cmd.Parameters.AddWithValue("@Nazwisko", textBox8.Text);
                            cmd.Parameters.AddWithValue("@Haslo", textBox4.Text);
                            cmd.Parameters.AddWithValue("@Id", x);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Odswiez();
                    button1.Focus();
                }
            }
    }
}
