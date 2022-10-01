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
    public partial class Form3 : Form
    {
        String CourseId = null;
        String CourseName = null;
        String Credits = null;
        String connectionString;
        SqlConnection cnn;

        SqlCommand command;
        SqlDataReader dataReader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        String sql = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madhu\source\repos\StudentDatabase\StudentDatabase\Database1.mdf;Integrated Security=True";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Connection Open");

                sql = "Insert into dbo.Course values(" + "'" + CourseId + "','" + CourseName + "','" + Credits + "'" + ")";

                command = new SqlCommand(sql, cnn);

                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
                //Console.WriteLine(Id + "," + firstName + "," + lastName + "," + email);


            }
            catch (Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Update
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madhu\source\repos\StudentDatabase\StudentDatabase\Database1.mdf;Integrated Security=True";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Connection Open");

                sql = "update dbo.Course set CourseName='" + CourseName + "',Credits ='" + Credits + "' where CourseId = '" + CourseId + "'";


                command = new SqlCommand(sql, cnn);

                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CourseId = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CourseName = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Credits = textBox3.Text;
        }
        //Delete
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madhu\source\repos\StudentDatabase\StudentDatabase\Database1.mdf;Integrated Security=True";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Connection Open");

                sql = "delete dbo.Course where CourseId = '" + CourseId + "'";

                command = new SqlCommand(sql, cnn);

                adapter.DeleteCommand = new SqlCommand(sql, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }
        //GetDetails
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madhu\source\repos\StudentDatabase\StudentDatabase\Database1.mdf;Integrated Security=True";

                String Output = "";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                MessageBox.Show("Connection Open");

                sql = "select * from dbo.Course where CourseId = '" + CourseId + "'";

                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2);
                }

                MessageBox.Show(Output);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }
    }
}
