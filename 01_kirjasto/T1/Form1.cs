using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using T1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source = " + @"(localdb)\MSSQLLocalDB" + "; Initial Catalog =Opiskelijat");
        List<Ryhma> ryhmas = new List<Ryhma>();
        List<Opiskelija> opiskelija = new List<Opiskelija>();
        private bool finder = true;

        public Form1()
        {
            this.Load += new EventHandler(Form1_Load);
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            ConnectionOpen();

            GetGroups();
            GetSudents();

            ConnectionClose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void GetGroups()
        {
            using SqlCommand cmd = new SqlCommand("SELECT * FROM Ryhma", connection);
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ryhma ryhma = new Ryhma()
                {
                    Name = reader["Nimi"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                ryhmas.Add(ryhma);
            }
            for (int i = 0; i < ryhmas.Count; i++)
            {
                comboBox1.Items.Add(ryhmas[i].Name);
            }
        }
        private void GetSudents()
        {
            dataGridView1.Columns.Clear();
            opiskelija.Clear();
            try
            {
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Opiskelija o LEFT OUTER JOIN OpiskelijanRyhma opr ON o.Id=opr.OpiskelijaId", connection);
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Opiskelija op = new Opiskelija()
                    {
                        firstName = reader["Nimi"].ToString(),
                        lastName = reader["Sukunimi"].ToString(),
                        opiskelijaId = Convert.ToInt32(reader["Id"]),
                    };
                    opiskelija.Add(op);
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns.Add("firstName", "Etunimi");
                dataGridView1.Columns.Add("lastName", "Sukunimi");

                dataGridView1.Columns["firstName"].DataPropertyName = "firstName";
                dataGridView1.Columns["lastName"].DataPropertyName = "lastName";

                dataGridView1.DataSource = opiskelija;

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionOpen();
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string selectedGroup = comboBox1.Text;
            int insertedId;
            Ryhma matchingRyhma = ryhmas.FirstOrDefault(r => r.Name == selectedGroup);
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText = "INSERT INTO Opiskelija (Nimi,Sukunimi)  OUTPUT INSERTED.Id VALUES (@firstName,@lastName)";
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        insertedId = (int)cmd.ExecuteScalar(); ;

                        cmd.CommandText = "INSERT INTO OpiskelijanRyhma (OpiskelijaId ,RyhmaId) VALUES (@opId,@ryId)";
                        cmd.Parameters.AddWithValue("@opId", insertedId);
                        cmd.Parameters.AddWithValue("@ryId", matchingRyhma.Id);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            ConnectionClose();
            Form1_Load(sender, e);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void ConnectionOpen()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private void ConnectionClose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionOpen();

            if (dataGridView1.SelectedRows.Count == 1  )
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.DataBoundItem is Opiskelija opiskelija)
                {
                    int OpiskelijaId = opiskelija.opiskelijaId;

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Opiskelija WHERE Id = @Id", connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", OpiskelijaId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ei opiskelijaa valittuna tai likaa valittuna. valitse vain yksi");
            }
            ConnectionClose();
            Form1_Load(sender, e);
        }
    }

}
