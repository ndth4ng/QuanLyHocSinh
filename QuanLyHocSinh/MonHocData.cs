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

        public void insert(string maMH, string tenMH)
        {
            string insertCommand = "INSERT INTO MONHOC VALUES(@maMH, @tenMH)";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            sqlParams.Add(new SqlParameter("@tenMH", tenMH));
            dataProvider.executeNonQuery(insertCommand, sqlParams);
        }

        public void update(string maMH, string tenMH)
        {
            string updateCommand = "UPDATE MONHOC SET TenMH = @tenMH WHERE IDMonHoc = @maMH";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            sqlParams.Add(new SqlParameter("@tenMH", tenMH));
            dataProvider.executeNonQuery(updateCommand, sqlParams);
        }

        public void delete(string maMH)
        {
            string deleteCommand = "DELETE FROM MONHOC WHERE IDMonHoc = @maMH";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            dataProvider.executeNonQuery(deleteCommand, sqlParams);
        }

        public DataSet GetSubject()
        {
            string sqlString = "select IDMonHoc as 'Mã môn học' , TenMH as 'Tên môn học' from MONHOC";
            return dataProvider.GetData(sqlString);
        }
    }
}
