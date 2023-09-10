using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
	

namespace S_G_H
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        MySqlConnection connection;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            try
            {
                connection = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=");
                connection.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                label1.Text = "DECONNECTÉ";
                label1.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                label1.Text = "CONNECTÉ";
                label1.ForeColor = Color.SpringGreen;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
