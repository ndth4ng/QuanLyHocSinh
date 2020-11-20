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
        //LopHocData lop = new LopHocData();

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
                //dataProvider.disconnect();
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

            string sqlQuery = "SELECT IDLop FROM LOP";
            DataTable lopHoc = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in lopHoc.Rows)
            {
                dataProvider.open();
                insertCommand = "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '1'), @maLop2, @monHoc2, @hocKy1)" +
                    "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '2'), @maLop2, @monHoc2, @hocKy2)";
                sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maLop", row[0]));
                sqlParams.Add(new SqlParameter("@monHoc", maMH));
                sqlParams.Add(new SqlParameter("@maLop2", row[0]));
                sqlParams.Add(new SqlParameter("@monHoc2", maMH));
                sqlParams.Add(new SqlParameter("@hocKy1", 1));
                sqlParams.Add(new SqlParameter("@hocKy2", 2));
                dataProvider.executeNonQuery(insertCommand, sqlParams);
                dataProvider.disconnect();
            }
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
            string deleteCommand = "DELETE FROM BANGDIEMMON WHERE IDMonHoc = @maMH " +
                "DELETE FROM MONHOC WHERE IDMonHoc = @maMH2";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maMH", maMH));
            sqlParams.Add(new SqlParameter("@maMH2", maMH));
            dataProvider.executeNonQuery(deleteCommand, sqlParams);
            dataProvider.disconnect();
        }

        public DataSet GetSubject()
        {
            string sqlString = "select IDMonHoc as 'Mã môn học' , TenMH as 'Tên môn học' from MONHOC";
            return dataProvider.GetData(sqlString);
        }

        //public DataTable AllSubject()
        //{
        //    string sqlString = "SELECT IDMonHoc FROM MONHOC";
        //    DataTable dataTable = dataProvider.GetDataTable(sqlString);
        //    return dataTable;
        //}
    }
}
