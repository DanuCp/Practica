using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Automobile
{
    internal class DataBase
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-FUHUEFM\SQLEXPRESS;Initial Catalog=Automobile;Integrated Security=True");
        public void openConnection() 
        {
            if(conn.State == System.Data.ConnectionState.Closed) 
            {
                conn.Open();
            }
        }
        public void closeConnection()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return conn;
        }
    }
}
