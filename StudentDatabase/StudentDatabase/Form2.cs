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

namespace StudentDatabase
{
    public partial class Form2 : Form
    {

        String userName = null;
        String password = null;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            password = textBox1.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {


            String connectionString;
            SqlConnection cnn;

            SqlCommand command;
            SqlDataAdapter adapter;
            String sql = "";
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madhu\source\repos\StudentDatabase\StudentDatabase\Database1.mdf;Integrated Security=True";


            try
            {



                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Connection Open");
                sql = "select count(*) from dbo.LoginDetails where Username='" + userName+ "' and Password = '"+password+"'" ;
                //sql = "Insert into dbo.StudentDetails values(" + "'" + firstName + "','" + lastName + "','" + Id + "','" + email + "'" + ")";

                command = new SqlCommand(sql, cnn);

                adapter = new SqlDataAdapter(sql, cnn);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    new Form4().Show();
                }
                else MessageBox.Show("Invalid Username or Password");


               // adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                //Console.WriteLine(Id + "," + firstName + "," + lastName + "," + email);



            }
            catch (Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
