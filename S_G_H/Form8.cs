using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace S_G_H
{

    public partial class Form8 : Form
    {
        MySqlConnection SQLc = new MySqlConnection();
        MySqlCommand SQLcmd = new MySqlCommand();
        DataTable SQLdt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter SQLda = new MySqlDataAdapter();
        MySqlDataReader SQLrd;

        DataSet ds = new DataSet();
        String server = "localhost";
        String user = "root";
        String psw = "";
        String database = "bd_Hopital_3";

        public Form8()
        {
            InitializeComponent();
            charger_data();
        }

        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            SQLc.Open();
            SQLcmd.Connection = SQLc;
            SQLcmd.CommandText = "SELECT * FROM Admin_App";
            SQLrd = SQLcmd.ExecuteReader();
            SQLdt.Load(SQLrd);
            SQLrd.Close();
            SQLc.Close();
            dataGridView1.DataSource = SQLdt;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult q;
            try
            {
                q = MessageBox.Show("voulez-vous vraiment quitter l'application?", "Gestion Hopital", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string g;
            if (radioButton1.Checked == true)   {   g = "M";    }
            else {      g = "F";    }

            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;

            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO Admin_App (cin_admin, nom_admin, pnom_admin, genre_admin,email_admin) VaLUES        ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + g + "', '" + textBox5.Text + "');";
                SQLcmd = new MySqlCommand(sqlQuery, SQLc);
                SQLrd = SQLcmd.ExecuteReader();
                SQLc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLc.Close();
            }
            charger_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            SQLc.Open();
            string g;
            if (radioButton1.Checked == true) { g = "M"; } else { g = "F"; }
            try
            {
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Admin_App set cin_admin = @cin_admin, nom_admin = @nom_admin, pnom_admin = @pnom_admin,genre_admin=@genre_admin, email_admin = @email_admin WHERE cin_admin = @cin_admin";
                SQLcmd.Parameters.AddWithValue("@cin_admin", textBox1.Text);
                SQLcmd.Parameters.AddWithValue("@nom_admin", textBox2.Text);
                SQLcmd.Parameters.AddWithValue("@pnom_admin", textBox3.Text);
                SQLcmd.Parameters.AddWithValue("@genre_admin", g);
                SQLcmd.Parameters.AddWithValue("@email_admin", textBox5.Text);

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            finally {   SQLc.Close();   }
            charger_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            string query = "DELETE FROM Admin_App WHERE cin_admin ='" + textBox1.Text + "';";
            MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
            MySqlDataReader my_reader;
            try
            {
                connection_database.Open();
                my_reader = cmd_databes.ExecuteReader();
                MessageBox.Show("Suppression Avec Succès");
                while (my_reader.Read())    {}
            }
            catch (Exception ex)    {   MessageBox.Show(ex.Message);    }
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            charger_data();
            SQLc.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }
    }
}
