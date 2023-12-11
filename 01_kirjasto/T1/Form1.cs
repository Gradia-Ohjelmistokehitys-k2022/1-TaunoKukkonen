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
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
    
            GetGroups();
            GetSudents();
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
                        lastName = reader["Sukunimi"].ToString()
                    };
                    opiskelija.Add(op);
                }

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

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }

            Form1_Load(sender, e);
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
