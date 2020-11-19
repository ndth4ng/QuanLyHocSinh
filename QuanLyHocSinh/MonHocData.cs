using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyHocSinh
{
    class MonHocData
    {
        private DataProvider dataProvider = new DataProvider();

        public MonHocData()
        {
            dataProvider.connect();
        }

        public bool search(string maMH)
        {
            dataProvider.open();
            string searchQuery = "SELECT * FROM MONHOC WHERE IDMonHoc = @maMH";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            SqlDataReader obj = dataProvider.executeQuerry(searchQuery, sqlParams);

            if (obj.HasRows)
            {
                dataProvider.disconnect();
                return true;
            }
            dataProvider.disconnect();
            return false;
        }

        public void insert(string maMH, string tenMH)
        {
            dataProvider.open();
            string insertCommand = "INSERT INTO MONHOC VALUES(@maMH, @tenMH)";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            sqlParams.Add(new SqlParameter("@tenMH", tenMH));
            dataProvider.executeNonQuery(insertCommand, sqlParams);
            dataProvider.disconnect();
        }

        public void update(string maMH, string tenMH)
        {
            dataProvider.open();
            string updateCommand = "UPDATE MONHOC SET TenMH = @tenMH WHERE IDMonHoc = @maMH";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            sqlParams.Add(new SqlParameter("@tenMH", tenMH));
            dataProvider.executeNonQuery(updateCommand, sqlParams);
            dataProvider.disconnect();
        }

        public void delete(string maMH)
        {
            dataProvider.open();
            string deleteCommand = "DELETE FROM MONHOC WHERE IDMonHoc = @maMH";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            dataProvider.executeNonQuery(deleteCommand, sqlParams);
            dataProvider.disconnect();
        }

        public DataSet GetSubject()
        {
            string sqlString = "select IDMonHoc as 'Mã môn học' , TenMH as 'Tên môn học' from MONHOC";
            return dataProvider.GetData(sqlString);
        }
    }
}
