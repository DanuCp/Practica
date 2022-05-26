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
    public partial class Inregistrare : Form
    {
        DataBase DataBase = new DataBase();

        public Inregistrare()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Logare Logare = new Logare();
            this.Hide();
            Logare.Show();
        }
        private Boolean CheckUser()
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querryString = $"select idClient, NumeClient, Parola from Logare where NumeClient = '{loginUser}' and Parola = '{passUser}'";
            SqlCommand command = new SqlCommand(querryString, DataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;
            var confpassword = textBox3.Text;
            var function = comboBox1.Text;

            string querrystring = $"insert into Logare(NumeClient, Parola,Functia) values ('{login}','{password}','{function}')";

            SqlCommand command = new SqlCommand(querrystring, DataBase.getConnection());

            DataBase.openConnection();
            
            {

                if (password == confpassword)
                {
                    if(CheckUser())
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Succes! Contul vostru a fost creat!", "Succes!");
                        Logare logare = new Logare();
                        this.Hide();
                        logare.ShowDialog();
                    } 
                    else
                    {
                        MessageBox.Show("Așa cont deja există!");
                    }
                    

                   
                }
                else
                {
                    MessageBox.Show("Confirmați parola!");
                }

            }
            DataBase.closeConnection();
        }
        
        private void Inregistrare_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBase.closeConnection();
        }
    }
}