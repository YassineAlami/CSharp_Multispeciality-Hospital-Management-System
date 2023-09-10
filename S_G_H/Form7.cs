using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace S_G_H
{
    public partial class Form7 : Form
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


        public Form7()
        {
            InitializeComponent();
        }


        private void charger_data()
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + "" + ";" + "database=" + database;
            SQLc.Open();
            SQLcmd.Connection = SQLc;
            SQLcmd.CommandText = "SELECT * FROM Infirmiere";
            SQLrd = SQLcmd.ExecuteReader();
            SQLdt.Load(SQLrd);
            SQLrd.Close();
            SQLc.Close();
            dataGridView1.DataSource = SQLdt;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            charger_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string g;
            if (radioButton1.Checked == true)
            {
                g = "M";
            }
            else
            {
                g = "F";
            }

            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            try
            {
                SQLc.Open();
                sqlQuery = "INSERT INTO Infirmiere (cin_inf, nom_inf, pnom_inf, genre_inf, tel_inf, email_inf) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + g + "','" + textBox5.Text + "','"+textBox6.Text +"');";
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text== "CIN Infirmier")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nom Infirmier")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Prenom Infirmier")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Telephone Infirmier")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "CIN Inf")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            SQLc.Open();
            string g;
            if (radioButton1.Checked == true){g = "M";} else g = "F";

            try
            {
                MySqlCommand SQLcmd = new MySqlCommand();
                SQLcmd.Connection = SQLc;

                SQLcmd.CommandText = "UPDATE Infirmiere set cin_inf = @cin_inf, nom_inf = @nom_inf, pnom_inf = @pnom_inf, genre_inf=@genre_inf, tel_inf=@tel_inf,email_inf=@email_inf WHERE cin_inf = @cin_inf";
                SQLcmd.Parameters.AddWithValue("@cin_inf", textBox1.Text);
                SQLcmd.Parameters.AddWithValue("@nom_inf", textBox2.Text);
                SQLcmd.Parameters.AddWithValue("@pnom_inf", textBox3.Text);
                SQLcmd.Parameters.AddWithValue("@genre_inf",g );
                SQLcmd.Parameters.AddWithValue("@tel_inf", textBox5.Text);
                SQLcmd.Parameters.AddWithValue("@email_inf", textBox6.Text);

                SQLcmd.ExecuteNonQuery();
                SQLc.Close();
                charger_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLc.ConnectionString = "server=" + server + ";" + "user id=" + user + ";" + "password=" + psw + ";" + "database=" + database;
            string query = "DELETE FROM Infirmiere WHERE cin_inf ='" + textBox1.Text + "';";
            MySqlConnection connection_database = new MySqlConnection(SQLc.ConnectionString);
            MySqlCommand cmd_databes = new MySqlCommand(query, connection_database);
            MySqlDataReader my_reader;
            try
            {
                connection_database.Open();
                my_reader = cmd_databes.ExecuteReader();
                MessageBox.Show("Suppression Avec Succès");
                while (my_reader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            charger_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "M") radioButton1.Checked = true; else radioButton2.Checked = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataView dv = SQLdt.DefaultView;
                dv.RowFilter = string.Format("cin_inf LIKE '%{0}%'", textBox4.Text);
                dataGridView1.DataSource = dv.ToTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5 f1 = new Form5();
            f1.Visible = true;
        }
    }
}
