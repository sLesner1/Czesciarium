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
    public partial class Form5 : Form
    {
        private string login1 { get; set; }
        public Form5(string login)
        {
            login1 = login;
            InitializeComponent();
            tabControl1.SelectedIndex = 2;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void czesciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.czesciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pracownicyDataSet);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.czesciTableAdapter.Fill(this.pracownicyDataSet.Czesci);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (czesciDataGridView.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć ten element?", "Usunąć?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
                    int partIdToRemove = Convert.ToInt32(currentRow.Cells[0].Value);
                    string nazwa = Convert.ToString(currentRow.Cells[1].Value);
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();

                        string opisOperacji = $"Usunięcie elementu {nazwa}";

                        string insertQuery = "INSERT INTO Operacje (IdPracownika, OpisOperacji) VALUES (@IdPracownika, @OpisOperacji)";
                        string employeeId = "";
                        string query = "SELECT Id FROM pracownicyTab WHERE Login = @Login";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@Login", login1);
                                object result1 = cmd.ExecuteScalar();
                                employeeId = Convert.ToString(result1);
                            }

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@IdPracownika", employeeId);
                            insertCmd.Parameters.AddWithValue("@OpisOperacji", opisOperacji);
                            insertCmd.ExecuteNonQuery();
                        }

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
                MessageBox.Show("nie wybrano nic" + czesciDataGridView.SelectedRows);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
            string nazwa = (currentRow.Cells[1].Value).ToString();
            label2.Text = nazwa;
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
                    czesciDataGridView.DataSource = dataTable;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (czesciDataGridView.CurrentRow != null)
            {
                DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
                int x = Convert.ToInt32(currentRow.Cells[0].Value);
                if (int.TryParse(textBox2.Text, out int ilosc))
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE Czesci SET IloscWMagazynie = @Ilosc WHERE Identyfikator = @Id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Ilosc", ilosc);
                            cmd.Parameters.AddWithValue("@Id", x);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Odswiez();
                    button1.Focus();
                }
                else
                {
                    MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
                textBox2.Text = currentRow.Cells[3].Value.ToString();
            }
            if (int.TryParse(textBox2.Text, out int i))
            {
                textBox2.Text = (i + 1).ToString();
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
                textBox2.Text = currentRow.Cells[3].Value.ToString();
            }
            
                if (int.TryParse(textBox2.Text, out int i))
                {
                    if (i > 0)
                    {
                        textBox2.Text = (i - 1).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void czesciDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            czesciDataGridView.CurrentRow.Selected = true;
            DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
            tabControl1.SelectedIndex = 2;
            label11.Text = "Wybrano: "+ currentRow.Cells[1].Value.ToString();
            label12.Text = "Kategoria: "+ currentRow.Cells[2].Value.ToString();
            label13.Text = "Ilość: "+ currentRow.Cells[3].Value.ToString() + "szt";
            label14.Text = "Cena: "+ currentRow.Cells[4].Value.ToString() + " zł";
            label15.Text = "Numer kat.: "+ currentRow.Cells[5].Value.ToString();
            label16.Text = "Producent: "+ currentRow.Cells[6].Value.ToString();
            label17.Text = "Rok prod.: "+ currentRow.Cells[7].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LOLIPOP\\source\\repos\\czesciarium\\czesciarium\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Czesci (Nazwa, NumerKatalogowy, Producent, Kategoria, Cena, RokProdukcji, IloscWMagazynie) VALUES (@Nazwa, @NrKat, @Producent, @Kategoria, @Cena, @RokProdukcji, @Ilosc)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Nazwa", textBox1.Text);
                    cmd.Parameters.AddWithValue("@NrKat", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Producent", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Kategoria", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Cena", Convert.ToDouble(textBox4.Text));
                    cmd.Parameters.AddWithValue("@RokProdukcji", Convert.ToInt32(textBox5.Text));
                    cmd.Parameters.AddWithValue("@Ilosc", Convert.ToInt32(textBox8.Text));

                    cmd.ExecuteNonQuery();
                }
            }
            Odswiez();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }
            if (int.TryParse(textBox8.Text, out int i))
            {
                if (i > 0)
                {
                    textBox8.Text = (i - 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "0";
            }
            if (int.TryParse(textBox8.Text, out int i))
            {
                textBox8.Text = (i + 1).ToString();
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
            if (float.TryParse(textBox4.Text, out float i))
            {
                if (i > 0)
                {
                    textBox4.Text = (i - 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
            if (float.TryParse(textBox4.Text, out float i))
            {
                textBox4.Text = (i + 1).ToString();
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void czesciDataGridView_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.czesciDataGridView.ClientRectangle, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.groupBox1.ClientRectangle, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid, Color.FromArgb(255, 86, 130, 89), 3, ButtonBorderStyle.Solid);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
            textBox15.Text = currentRow.Cells[1].Value.ToString();
            textBox14.Text = currentRow.Cells[2].Value.ToString();
            textBox12.Text = currentRow.Cells[3].Value.ToString();
            textBox10.Text = currentRow.Cells[4].Value.ToString();
            textBox13.Text = currentRow.Cells[5].Value.ToString();
            textBox11.Text = currentRow.Cells[6].Value.ToString();
            textBox9.Text = currentRow.Cells[7].Value.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (czesciDataGridView.CurrentRow != null)
            {
                DataGridViewRow currentRow = czesciDataGridView.CurrentRow;
                int x = Convert.ToInt32(currentRow.Cells[0].Value);
                if (int.TryParse(textBox12.Text, out int ilosc) && float.TryParse(textBox10.Text, out float cena))
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE Czesci SET IloscWMagazynie = @Ilosc, Nazwa = @Nazwa, NumerKatalogowy = @nrkat, Producent = @prod, Kategoria = @kat, Cena = @cena, RokProdukcji = @rok WHERE Identyfikator = @Id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Ilosc", ilosc);
                            cmd.Parameters.AddWithValue("@Nazwa", textBox15.Text);
                            cmd.Parameters.AddWithValue("@nrkat", textBox13.Text);
                            cmd.Parameters.AddWithValue("@prod", textBox11.Text);
                            cmd.Parameters.AddWithValue("@kat", textBox14.Text);
                            cmd.Parameters.AddWithValue("@cena", cena);
                            cmd.Parameters.AddWithValue("@rok", textBox9.Text);
                            cmd.Parameters.AddWithValue("@Id", x);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Odswiez();
                    button1.Focus();
                }
                else
                {
                    MessageBox.Show("Podane dane nie są poprawne. Sprawdź pola ilość i cena.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("nie wybrano nic" + czesciDataGridView.SelectedRows);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "0";
            }
            if (int.TryParse(textBox12.Text, out int i))
            {
                if (i > 0)
                {
                    textBox12.Text = (i - 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "0";
            }
            if (int.TryParse(textBox12.Text, out int i))
            {
                textBox12.Text = (i + 1).ToString();
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "0";
            }
            if (int.TryParse(textBox10.Text, out int i))
            {
                if (i > 0)
                {
                    textBox10.Text = (i - 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "0";
            }
            if (int.TryParse(textBox10.Text, out int i))
            {
                textBox10.Text = (i + 1).ToString();
            }
            else
            {
                MessageBox.Show("Podana wartość nie jest liczbą całkowitą. Wprowadź poprawną liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool klikniete18 = true;
        private void button18_Click(object sender, EventArgs e)
        {
            if (klikniete18)
            {
                button18.BackgroundImage = czesciarium.Properties.Resources.x;
                klikniete18 = false;
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\pracownicy.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();
                    string tekst = textBox16.Text;
                    string[] wyrazy = tekst.Split(' ');
                    string nrkat = "";
                    string rok = "";
                    if (tekst.Any(char.IsDigit))
                    {
                        foreach (string wyraz in wyrazy)
                        {
                            if (wyraz.Any(char.IsDigit))
                            {
                                if (wyraz.Length > 4)
                                {
                                    nrkat = wyraz;
                                }
                                else
                                {
                                    rok = wyraz;
                                }
                            }
                        }
                    }
                    if (tekst.Any(char.IsLetter))
                    {
                        string nazwa = "";
                        string kategoria = "";
                        string producent = "";
                        int i = 0;
                        int rowsCount = 0;
                        do
                        {
                            if (i == 0)
                                nazwa += wyrazy[i];
                            else
                                nazwa += " " + wyrazy[i];
                            string selectQuery = "SELECT * FROM Czesci WHERE LOWER(Nazwa) LIKE LOWER(@Nazwa)";
                            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                            {
                                adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa + "%");
                                DataTable dataTable = new DataTable();
                                rowsCount = adapter.Fill(dataTable);
                            }
                            if (rowsCount == 0 && i != 0)
                            {
                                nazwa = "";
                                string nazwa1 = "";
                                for (int x = 0; x < i; x++)
                                {
                                    if (x == 0)
                                        nazwa1 += wyrazy[x];
                                    else
                                        nazwa1 += " " + wyrazy[x];
                                }
                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                                {
                                    adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    czesciDataGridView.DataSource = dataTable;
                                }
                                string[] nazwaWyr = nazwa1.Split(' ');
                                string[] roznica = wyrazy.Except(nazwaWyr).ToArray();
                                string roznica1 = string.Join(" ", roznica);
                                int a = 0;
                                rowsCount = 0;
                                do
                                {
                                    if (a == 0)
                                        kategoria += roznica[a];
                                    else
                                        kategoria += " " + roznica[a];
                                    string selectQuery1 = "SELECT * FROM Czesci WHERE LOWER(Kategoria) LIKE LOWER(@Kategoria) AND LOWER(Nazwa) LIKE LOWER(@Nazwa)";
                                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                    {
                                        adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria + "%");
                                        adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                        DataTable dataTable = new DataTable();
                                        rowsCount = adapter.Fill(dataTable);
                                    }
                                    if (rowsCount == 0 && a != 0)
                                    {
                                        string kategoria1 = "";
                                        for (int x = 0; x < a; x++)
                                        {
                                            if (x == 0)
                                                kategoria1 += roznica[x];
                                            else
                                                kategoria1 += " " + roznica[x];
                                        }
                                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                        {
                                            adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria1 + "%");
                                            adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                            DataTable dataTable = new DataTable();
                                            adapter.Fill(dataTable);
                                            czesciDataGridView.DataSource = dataTable;
                                        }
                                    }
                                    else if (kategoria == roznica1 && rowsCount > 0)
                                    {
                                        string kategoria1 = "";
                                        for (int x = 0; x <= a; x++)
                                        {
                                            if (x == 0)
                                                kategoria1 += roznica[x];
                                            else
                                                kategoria1 += " " + roznica[x];
                                        }
                                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                        {
                                            adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria1 + "%");
                                            adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                            DataTable dataTable = new DataTable();
                                            adapter.Fill(dataTable);
                                            czesciDataGridView.DataSource = dataTable;
                                        }
                                    }
                                    else if (a == 0 && rowsCount == 0)
                                    {
                                        a = 0;
                                        rowsCount = 0;
                                        do
                                        {
                                            if (a == 0)
                                                producent += roznica[a];
                                            else
                                                producent += " " + roznica[a];
                                            string selectQuery2 = "SELECT * FROM Czesci WHERE LOWER(Producent) LIKE LOWER(@Producent) AND LOWER(Nazwa) LIKE LOWER(@Nazwa)";
                                            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                            {
                                                adapter.SelectCommand.Parameters.AddWithValue("@Producent", "%" + producent + "%");
                                                adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                                DataTable dataTable = new DataTable();
                                                rowsCount = adapter.Fill(dataTable);
                                            }
                                            if (rowsCount == 0 && a != 0)
                                            {
                                                string producent1 = "";
                                                for (int x = 0; x < a; x++)
                                                {
                                                    if (x == 0)
                                                        producent1 += roznica[x];
                                                    else
                                                        producent1 += " " + roznica[x];
                                                }
                                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                                {
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Producent", "%" + producent1 + "%");
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                                    DataTable dataTable = new DataTable();
                                                    adapter.Fill(dataTable);
                                                    czesciDataGridView.DataSource = dataTable;
                                                }
                                            }
                                            else if (producent == roznica1 && rowsCount > 0)
                                            {
                                                string producent1 = "";
                                                for (int x = 0; x <= a; x++)
                                                {
                                                    if (x == 0)
                                                        producent1 += roznica[x];
                                                    else
                                                        producent1 += " " + roznica[x];
                                                }
                                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                                {
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Producent", "%" + producent1 + "%");
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                                    DataTable dataTable = new DataTable();
                                                    adapter.Fill(dataTable);
                                                    czesciDataGridView.DataSource = dataTable;
                                                }
                                            }
                                            else if (a == 0 && rowsCount == 0)
                                            {
                                            }
                                            a++;
                                        }
                                        while (rowsCount > 0 && a < roznica.Length);
                                    }
                                    a++;
                                }
                                while (rowsCount > 0 && a < roznica.Length);
                                i++;
                            }
                            else if (nazwa == tekst && rowsCount > 0)
                            {
                                nazwa = "";
                                string nazwa1 = "";
                                for (int x = 0; x <= i; x++)
                                {
                                    if (x == 0)
                                        nazwa1 += wyrazy[x];
                                    else
                                        nazwa1 += " " + wyrazy[x];
                                }
                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                                {
                                    adapter.SelectCommand.Parameters.AddWithValue("@Nazwa", "%" + nazwa1 + "%");
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    czesciDataGridView.DataSource = dataTable;
                                }
                            }
                            else if (i == 0 && rowsCount == 0)
                            {
                                nazwa = "";
                                i = 0;
                                rowsCount = 0;
                                do
                                {
                                    if (i == 0)
                                        kategoria += wyrazy[i];
                                    else
                                        kategoria += " " + wyrazy[i];
                                    string selectQuery1 = "SELECT * FROM Czesci WHERE LOWER(Kategoria) LIKE LOWER(@Kategoria)";
                                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                    {
                                        adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria + "%");
                                        DataTable dataTable = new DataTable();
                                        rowsCount = adapter.Fill(dataTable);
                                    }
                                    if (rowsCount == 0 && i != 0)
                                    {
                                        string kategoria1 = "";
                                        for (int x = 0; x < i; x++)
                                        {
                                            if (x == 0)
                                                kategoria1 += wyrazy[x];
                                            else
                                                kategoria1 += " " + wyrazy[x];
                                        }
                                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                        {
                                            adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria1 + "%");
                                            DataTable dataTable = new DataTable();
                                            adapter.Fill(dataTable);
                                            czesciDataGridView.DataSource = dataTable;
                                        }
                                    }
                                    else if (kategoria == tekst && rowsCount > 0)
                                    {
                                        string kategoria1 = "";
                                        for (int x = 0; x <= i; x++)
                                        {
                                            if (x == 0)
                                                kategoria1 += wyrazy[x];
                                            else
                                                kategoria1 += " " + wyrazy[x];
                                        }
                                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery1, connection))
                                        {
                                            adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + kategoria1 + "%");
                                            DataTable dataTable = new DataTable();
                                            adapter.Fill(dataTable);
                                            czesciDataGridView.DataSource = dataTable;
                                        }
                                    }
                                    else if (i == 0 && rowsCount == 0)
                                    {
                                        i = 0;
                                        rowsCount = 0;
                                        do
                                        {
                                            if (i == 0)
                                                producent += wyrazy[i];
                                            else
                                                producent += " " + wyrazy[i];
                                            string selectQuery2 = "SELECT * FROM Czesci WHERE LOWER(Producent) LIKE LOWER(@Producent)";
                                            using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                            {
                                                adapter.SelectCommand.Parameters.AddWithValue("@Producent", "%" + producent + "%");
                                                DataTable dataTable = new DataTable();
                                                rowsCount = adapter.Fill(dataTable);
                                            }
                                            if (rowsCount == 0 && i != 0)
                                            {
                                                string producent1 = "";
                                                for (int x = 0; x < i; x++)
                                                {
                                                    if (x == 0)
                                                        producent1 += wyrazy[x];
                                                    else
                                                        producent1 += " " + wyrazy[x];
                                                }
                                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                                {
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Kategoria", "%" + producent1 + "%");
                                                    DataTable dataTable = new DataTable();
                                                    adapter.Fill(dataTable);
                                                    czesciDataGridView.DataSource = dataTable;
                                                }
                                            }
                                            else if (producent == tekst && rowsCount > 0)
                                            {
                                                string producent1 = "";
                                                for (int x = 0; x <= i; x++)
                                                {
                                                    if (x == 0)
                                                        producent1 += wyrazy[x];
                                                    else
                                                        producent1 += " " + wyrazy[x];
                                                }
                                                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery2, connection))
                                                {
                                                    adapter.SelectCommand.Parameters.AddWithValue("@Producent", "%" + producent1 + "%");
                                                    DataTable dataTable = new DataTable();
                                                    adapter.Fill(dataTable);
                                                    czesciDataGridView.DataSource = dataTable;
                                                }
                                            }
                                            else if (i == 0 && rowsCount == 0)
                                            {
                                                DataTable dataTable = new DataTable();
                                                czesciDataGridView.DataSource = dataTable;
                                                MessageBox.Show("Nie znaleziono żadnych wyników.", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            i++;
                                        }
                                        while (rowsCount > 0 && i < wyrazy.Length);
                                    }
                                    i++;
                                }
                                while (rowsCount > 0 && i < wyrazy.Length);
                            }
                            i++;
                        }
                        while (rowsCount > 0 && i < wyrazy.Length);
                        if (nazwa != "")
                        {
                            string selectQuery = "SELECT * FROM Czesci WHERE LOWER(Nazwa) LIKE LOWER(@Nazwa)";
                        }
                    }
                }
            }
            else
            {
                button18.BackgroundImage = czesciarium.Properties.Resources.LUPA;
                klikniete18 = true;
                Odswiez();
            }
            
        }
    }
}
