using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace QuanLyHocSinh
{
    class DataProvider
    {
        protected static string connectionString = @"Data Source=DESKTOP-LK1FG64;Initial Catalog=QUANLYHOCSINH;Integrated Security=True";

        protected SqlConnection connection = new SqlConnection(ConnectionString);
        protected SqlDataAdapter adapter;
        protected SqlCommand command;

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }

        public void connect()
        {
            connection = new SqlConnection(connectionString);
        }

        public void disconnect()
        {
            connection.Close();
        }

        public SqlDataReader executeQuerry(string sqlString, List<SqlParameter> sqlParams)
        {
            connection.Open();
            command = new SqlCommand(sqlString, connection);
            foreach (SqlParameter param in sqlParams)
            {
                command.Parameters.Add(param);
            }
            return command.ExecuteReader();
        }

        //Data ComboBox
        public SqlDataReader executeQuerry(string sqlString)
        {
            connection.Open();
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteReader();
        }

        public void executeNonQuery(string sqlString, List<SqlParameter> sqlParams)
        {
            connection.Open();
            command = new SqlCommand(sqlString, connection);
            foreach(SqlParameter param in sqlParams) 
            {
                command.Parameters.Add(param);
            }
            command.ExecuteNonQuery();
            connection.Close();
        }

        public object executeScalar(string sqlString)
        {
            connection.Open();
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }

        //public object searchObject(string sqlString)
        //{
        //    this.connect();
        //    command = new SqlCommand(sqlString, connection);
        //    return command.ExecuteScalar();           
        //}       

        public DataSet GetData(string sqlString)
        {
            DataSet data = new DataSet();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, connection);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable GetDataTable(string sqlString)
        {
            DataTable data = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString, connection);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        //public SqlDataReader FillData(string sqlString)
        //{
        //    DataTable data = new DataTable();

        //    return this.executeQuerry(sqlString);
        //    //SqlDataAdapter adapter = new SqlDataAdapter(sqlString, connection);
        //    //adapter.Fill(data);
        //    connection.Close();
        //    return data;
        //}
    }
}
