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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.pracownicyTabTableAdapter.Fill(this.pracownicyDataSet1.pracownicyTab);
            this.operacjeTableAdapter.Fill(this.pracownicyDataSet.Operacje);
            if (pracownicyTabComboBox1.SelectedItem != null)
            {
                string selectedLogin = pracownicyTabComboBox1.Text.ToString();
                int idprac = 0;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string query = "SELECT Id FROM pracownicyTab WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", selectedLogin);
                        object result = cmd.ExecuteScalar();
                        idprac = Convert.ToInt32(result);
                    }
                }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Operacje WHERE IdPracownika = @pracid";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@pracid", idprac);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            operacjeDataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
        }

        private void pracownicyTabComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pracownicyTabComboBox1.SelectedItem != null)
            {
                string selectedLogin = pracownicyTabComboBox1.Text.ToString();
                int idprac = 0;
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();

                        string query = "SELECT Id FROM pracownicyTab WHERE Login = @Login";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Login", selectedLogin);
                            object result = cmd.ExecuteScalar();
                        idprac = Convert.ToInt32(result);
                        }
                    }
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Operacje WHERE IdPracownika = @pracid";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@pracid", idprac);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            operacjeDataGridView.DataSource = dataTable;
                        }
                    }
                }
            }
        }

        private void operacjeDataGridView_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.operacjeDataGridView.ClientRectangle, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
