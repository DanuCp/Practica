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
    public partial class AppClient : Form
    {
        List<int> cos = new List<int>();

        DataBase DataBase = new DataBase();
        public AppClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearColumns();
            DataBase.openConnection();
            
            string selectAll = "select * from Automobile order by Pretul";
            SqlCommand cmd = new SqlCommand(selectAll, DataBase.getConnection());

        
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            adapter.Fill(dtbl);

            dataGridView1.DataSource = dtbl;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBase.closeConnection();
        }
        private void ClearColumns()
        {
            dataGridView1.Columns.Clear();
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_automobil", "id"); //0
            dataGridView1.Columns.Add("Marca", "Marca");   //1
            dataGridView1.Columns.Add("Modelul", "Model");  //2
            dataGridView1.Columns.Add("Anul", "Anul");   // 3
            dataGridView1.Columns.Add("Parcurs", "Parcurs");  // 4
            dataGridView1.Columns.Add("Starea", "Starea");  // 5
            dataGridView1.Columns.Add("Tipul", "Tipul"); // 6
            dataGridView1.Columns.Add("Pretul", "Pretul"); //7
            dataGridView1.Columns.Add("Complectatie", "Complectatie");   //8
            dataGridView1.Columns.Add("TipulCombustibilului", "TipulCombustibilului");  //9
            dataGridView1.Columns.Add("VolumulMotorului", "VolumulMotorului");  //10
            dataGridView1.Columns.Add("TipulCutii", "TipulCutii");  //11
            dataGridView1.Columns.Add("Tractiune", "Tractiune");  // 12
            dataGridView1.Columns.Add("Culoarea", "Culoarea");  // 13
            dataGridView1.Columns.Add("NumarulInmatriculare", "NumarulInmatriculare");  //14
            dataGridView1.Columns.Add("Tara", "Tara");  //15
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetString(5), record.GetString(6), record.GetInt32(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), record.GetString(13), record.GetString(14), record.GetString(15));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.Rows.Clear();
            }
            string queryString = $"select * from Automobile";
            SqlCommand yey = new SqlCommand(queryString, DataBase.getConnection());
            DataBase.openConnection();
            SqlDataReader reader = yey.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void AppClient_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private bool listExists(int e)
        {
            for (int i = 0; i< cos.Count; ++i)
            {
                if (cos[i] == e)
                {
                    return true;
                }
            }

            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (!dataGridView1.SelectedCells[0].OwningColumn.Name.Equals("id_automobil"))
            {
                MessageBox.Show("Selectati id");
                return;
            }

            int o = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            if (listExists(o))
            {
                return;
            }
            cos.Add(o);
            MessageBox.Show("Automobilul a fost adaugat");
        }

        private void button4_Click(object sender, EventArgs e)
        {


            DataBase.openConnection();
            int id;
            string selectAll = $"select * from Automobile where id_automobil in (";
            for (int i = 0; i < cos.Count; ++i)
            {
                selectAll += i.ToString();
                if (i == cos.Count -1)
                {
                    selectAll += ")";
                } else
                {
                    selectAll += ",";
                }
            }

            SqlCommand cmd = new SqlCommand(selectAll, DataBase.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView2.DataSource = table;

        }
    }
}
