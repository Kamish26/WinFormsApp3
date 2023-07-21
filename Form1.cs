using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public static string DepSelected;
        public static string OrgSelected;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            SqlCommand command1 = new SqlCommand("EXEC DepNames", connection);

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            adapter.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Name";


            SqlCommand command2 = new SqlCommand("EXEC OrgLevel", connection);
            DataTable dt2 = new DataTable();

            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            adapter2.Fill(dt2);

            comboBox2.DataSource = dt2;
            comboBox2.ValueMember = "OrganizationLevel";

            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString2 = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(ConnectionString2);
            connection.Open();

            DepSelected = comboBox1.SelectedValue.ToString();

            OrgSelected = comboBox2.SelectedValue.ToString();

            SqlCommand command3 = new SqlCommand("EXEC GetPerInfo @Name, @OrganizationLevel", connection);
            command3.Parameters.AddWithValue("@Name", DepSelected);
            command3.Parameters.AddWithValue("@OrganizationLevel", OrgSelected);

            DataTable dt2 = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command3);

            adapter.Fill(dt2);

            dataGridView1.DataSource = dt2;

            dataGridView1.Visible = true;

            button2.Visible = true;

            connection.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString3 = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(ConnectionString3);
            connection.Open();
            connection.Close();

            

            Form2 secondForm = new Form2();
            secondForm.Show();


            

        }

        public void RefreshDataGrid()
        {
            string ConnectionString5 = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(ConnectionString5);
            connection.Open();

            string DepSelected = comboBox1.SelectedValue.ToString();

            string OrgSelected = comboBox2.SelectedValue.ToString();

            SqlCommand command3 = new SqlCommand("EXEC GetPerInfo @Name, @OrganizationLevel", connection);
            command3.Parameters.AddWithValue("@Name", DepSelected);
            command3.Parameters.AddWithValue("@OrganizationLevel", OrgSelected);

            DataTable dt2 = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command3);

            adapter.Fill(dt2);

            dataGridView1.DataSource = dt2;

            dataGridView1.Visible = true;

            button2.Visible = true;
        }
    }
}