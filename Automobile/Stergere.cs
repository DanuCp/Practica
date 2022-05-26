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
    enum RowState
    {
        Existed,
        New,
        ModifedNew,
        Deleted
    }
    public partial class Stergere : Form
    {
        DataBase DataBase = new DataBase();

       
        public Stergere()
        {
           
            InitializeComponent();
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string Marca = textBox2.Text;
            string Modelul = textBox3.Text;
            string Numarul = textBox4.Text;
            
            string aux = $"delete from Automobile where id_automobil = {id}";

            SqlCommand cmd = new SqlCommand(aux, DataBase.getConnection());
            DataBase.openConnection();
            cmd.ExecuteNonQuery();

            MessageBox.Show($"Ați șters automobilul {Marca} {Modelul} cu numerele {Numarul}.");
            AppAdmin appAdmin = new AppAdmin();
            this.Hide();
            appAdmin.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            AppAdmin appAdmin = new AppAdmin();
            appAdmin.Show();
        }
    }
}
