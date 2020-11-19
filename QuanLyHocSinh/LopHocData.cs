using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHocSinh
{
    class LopHocData
    {
        private DataProvider dataProvider = new DataProvider();

        public LopHocData()
        {
            dataProvider.connect();
        }

        public bool search(string maLop)
        {
            dataProvider.open();
            string searchQuery = "SELECT * FROM LOP WHERE IDLop = @maLop";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maLop", maLop));
            SqlDataReader obj = dataProvider.executeQuerry(searchQuery, sqlParams);

            if (obj.HasRows)
            {
                //dataProvider.disconnect();
                return true;
            }
            dataProvider.disconnect();
            return false;
        }

        public void insert(string maLop, string tenLop)
        {
            dataProvider.open();
            string insertCommand = "INSERT INTO LOP(IDLop, TenLop) VALUES(@maLop, @tenLop)";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maLop", maLop));
            sqlParams.Add(new SqlParameter("@tenLop", tenLop));
            dataProvider.executeNonQuery(insertCommand, sqlParams);
            dataProvider.disconnect();
        }

        public void update(string maLop, string tenLop)
        {
            dataProvider.open();
            string updateCommand = "UPDATE LOP SET TenLop = @tenLop WHERE IDLop = @maLop";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maLop", maLop));
            sqlParams.Add(new SqlParameter("@tenLop", tenLop));
            dataProvider.executeNonQuery(updateCommand, sqlParams);
            dataProvider.disconnect();
        }

        public void delete(string maLop)
        {
            dataProvider.open();
            string deleteCommand = "DELETE FROM LOP WHERE IDLop = @maLop";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maLop", maLop));
            dataProvider.executeNonQuery(deleteCommand, sqlParams);
            dataProvider.disconnect();
        }

        public DataSet GetClass()
        {
            string sqlString = "select IDLop as 'Mã lớp' , TenLop as 'Tên lớp' from LOP";
            return dataProvider.GetData(sqlString); 
        }
    }
}
