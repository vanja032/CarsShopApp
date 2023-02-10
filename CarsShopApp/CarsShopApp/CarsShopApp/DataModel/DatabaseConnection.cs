using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarsShopApp.DataModel
{
    public class DatabaseConnection
    {
        private string connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Files\\VP2022\\CarsShopApp\\CarsShopDatabase\\CarsDatabase\\CarsDatabase.mdf;Integrated Security=True";
        private SqlDataAdapter adapter;
        public DataSet GetData(string query)
        {
            /*try
            {*/
                SqlConnection connection = new SqlConnection(connection_string);
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                DataSet set = new DataSet();
                adapter.Fill(set);
                connection.Close();
                return set;
            /*}
            catch(Exception e) { return null; }*/
        }
        public void RefreshDatabase(DataSet set)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.DataAdapter.Update(set);
        }
        public void ExecuteExternalTableCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
