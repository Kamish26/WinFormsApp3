using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            //connection.Open();

            string National = textBox1.Text;
            string Login = textBox2.Text;
            string Job = textBox3.Text;
            string Birth = textBox4.Text;
            string Marital = textBox5.Text;
            string Gender = textBox6.Text;
            string Hire = textBox7.Text;
            string Salary = textBox8.Text;
            string Vacation = textBox9.Text;
            string Sick = textBox10.Text;
            string Current = textBox11.Text;
            string Buisness = textBox14.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string ConnectionString2 = @"Data Source=HQ-W10-L111\SQLEXPRESS; Initial Catalog=AdventureWorks2022; User ID = Kamish2; Password = Welcome123!; TrustServerCertificate=True";
            

            
            SqlConnection connection1 = new SqlConnection(ConnectionString2);
            connection1.Open();

            SqlCommand command1 = new SqlCommand("EXEC InserInEmp @Buisness, @National, @Login, @Job, @Birth, @Marital, @Gender, @Hire, @Salary, @Vacation, @Sick, @Current  ", connection1);
            command1.Parameters.AddWithValue("@National", textBox1.Text);
            command1.Parameters.AddWithValue("@Login", textBox2.Text);
            command1.Parameters.AddWithValue("@Job", textBox3.Text);
            command1.Parameters.AddWithValue("@Birth", textBox4.Text);
            command1.Parameters.AddWithValue("@Marital", textBox5.Text);
            command1.Parameters.AddWithValue("@Gender", textBox6.Text);
            command1.Parameters.AddWithValue("@Hire", textBox7.Text);
            command1.Parameters.AddWithValue("@Salary", textBox8.Text);
            command1.Parameters.AddWithValue("@Vacation", textBox9.Text);
            command1.Parameters.AddWithValue("@Sick", textBox10.Text);
            command1.Parameters.AddWithValue("@Current", textBox11.Text);
            command1.Parameters.AddWithValue("@Buisness", textBox14.Text);
            

            command1.ExecuteNonQuery();

            connection1.Close();

            SqlConnection connection2 = new SqlConnection(ConnectionString2);
            connection2.Open();

            SqlCommand command3 = new SqlCommand("EXEC nmDep '" + Form1.DepSelected + "' ", connection2);
            // int DepID = (int)command3.ExecuteScalar();

            DataTable dtable2 = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command3);

            adapter.Fill(dtable2); 

            var depID = dtable2.Rows[0].ItemArray[0]; 
            
            connection2.Close();


            SqlConnection connection3 = new SqlConnection(ConnectionString2);
            connection3.Open();


            SqlCommand command2 = new SqlCommand("EXEC insDep @Business = @Busi, @Name = @Nm ", connection3);
            command2.Parameters.AddWithValue("@Busi", textBox14.Text);
            command2.Parameters.AddWithValue("@Nm", depID);

            command2.ExecuteNonQuery(); 

            connection3.Close();

            
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.RefreshDataGrid();



            



            
        }
    }
}
