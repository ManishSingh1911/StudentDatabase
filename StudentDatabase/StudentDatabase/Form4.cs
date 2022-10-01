using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDatabase
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

       
        private void Form4_Load(object sender, EventArgs e)
        {

        }

       
        //for course
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
