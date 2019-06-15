using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class DataProvider
    {
        private string connectStr= @"Data Source=DESKTOP-TKDN4VB\SQLEXPRESS;Initial Catalog=BTL_N04;Integrated Security=True";

        private static DataProvider instance = new DataProvider();
        public static DataProvider Instance { get => instance; set => instance = value; }

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection=new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close(); 
            }
            return data;
        }
        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            using(SqlConnection connection=new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExcuteScalar(string query)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }

}

  