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
    public partial class AutoNew : Form
    {
        DataBase DataBase = new DataBase();
        public AutoNew()
        {
            InitializeComponent();
        }

        private void AutoNew_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Marca = textBox1.Text;
            string Modelul = textBox2.Text;
            string Anul = textBox3.Text;
            string Parcurs = textBox4.Text;
            string Starea = comboBox1.Text;
            string Tipul = comboBox2.Text;
            string Pretul = textBox5.Text;
            string Complectatie = comboBox3.Text;
            string Comb = comboBox4.Text;
            string Volumul = textBox6.Text;
            string Cutia = comboBox5.Text;
            string Tractiune = comboBox6.Text;
            string Culoarea = textBox7.Text;
            string Numarul = textBox8.Text;
            string Producator = textBox9.Text;

            string interogare = $"insert into Automobile(Marca,Modelul,Anul,Parcurs,Starea,Tipul,Pretul,Complectatie,TipulCombustibilului,VolumulMotorului,TipulCutii,Tractiune,Culoarea,NumarulInmatriculare,Tara) values ('{Marca}','{Modelul}', '{Anul}', '{Parcurs}', '{Starea}', '{Tipul}', '{Pretul}','{Complectatie}','{Comb}',{Volumul},'{Cutia}','{Tractiune}','{Culoarea}','{Numarul}','{Producator}')";
            SqlCommand cmd = new SqlCommand(interogare, DataBase.getConnection());
            DataBase.openConnection();

            cmd.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            MessageBox.Show("Ați întrodus un automobil nou.");
            this.Hide();
            AppAdmin AppAdmin = new AppAdmin();
            AppAdmin.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
                AppAdmin AppAdmin = new AppAdmin();
                AppAdmin.Show();
        }
    }
}
