using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Automobile
{
    public partial class Logare : Form
    {
        DataBase DataBase = new DataBase();
        public Logare()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Logare_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inregistrare inregistrare = new Inregistrare();
            inregistrare.Show();
            this.Hide();
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userName = textBox1.Text;
            var password = textBox2.Text;
            var function = comboBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querryString = $"select idClient,NumeClient,Parola,Functia from Logare where NumeClient = '{userName}' and Parola = '{password}' and Functia = '{function}' ";
            SqlCommand cmd = new SqlCommand(querryString, DataBase.getConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                AppAdmin AppAdmin = new AppAdmin();
                AppClient AppClient = new AppClient();
                if (function == "User")
                {
                    this.Hide();
                    AppClient.ShowDialog();
                    
                }
                else if(function == "Admin")
                {   
                    this.Hide();
                    AppAdmin.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Nu există așa funcție!");
                }
            }
            else
            {
                MessageBox.Show("Eroare! Nu există așa cont!", "Nu există așa cont!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.Visible = false;
        }

       

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            DataBase.closeConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
