using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyHocSinh
{
    class BangDiemData
    {
        DataProvider dataProvider = new DataProvider();

        public BangDiemData()
        {
            dataProvider.connect();
        }

        public bool search(string id, string maHS)
        {
            dataProvider.open();
            string searchQuery = "SELECT * FROM CTBANGDIEMMON WHERE IDBangDiemMon = @ID AND MaHS = @maHS";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@ID", id));
            sqlParams.Add(new SqlParameter("@maHS", maHS));
            SqlDataReader obj = dataProvider.executeQuerry(searchQuery, sqlParams);

            if (obj.HasRows)
            {
                dataProvider.disconnect();
                return true;
            }
            dataProvider.disconnect();
            return false;
        }

        public void update(string idct, string diem15, string diem45)
        {
            dataProvider.open();
            string sqlString = "UPDATE CTBANGDIEMMON SET Diem15 = @diem15, Diem45 = @diem45, Diem1T = ROUND((@diem152 + (@diem452 * 2)) / 3, 1) WHERE IDCTBangDiemMon = @idct ";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@diem15", float.Parse(diem15)));
            sqlParams.Add(new SqlParameter("@diem45", float.Parse(diem45)));
            sqlParams.Add(new SqlParameter("@diem152", float.Parse(diem15)));
            sqlParams.Add(new SqlParameter("@diem452", float.Parse(diem45)));
            sqlParams.Add(new SqlParameter("@idct", idct));
            SqlDataReader obj = dataProvider.executeQuerry(sqlString, sqlParams);
            dataProvider.disconnect();
        }

        public DataTable AllSubject()
        {
            string sqlString = "SELECT TenMH FROM MONHOC";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }

        public DataTable AllStudent()
        {
            string sqlString = "SELECT MaHS FROM HOSOHOCSINH";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }

        public DataTable AllClass()
        {
            string sqlString = "SELECT TenLop FROM LOP";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }       

        public DataSet GetScore(string hocKy, string tenMH, string lop)
        {
            string sqlString = "SELECT CTBD.MaHS as 'Mã HS', CTBD.IDCTBangDiemMon as 'Mã CT', HoTen as 'Họ tên' , Diem15 as 'Điểm 15', Diem45 as 'Điểm 45', Diem1T as 'Điểm trung bình'" +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND HocKy = " + hocKy + " AND BD.IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lop + "') AND BD.IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = N'" + tenMH + "');";
            return dataProvider.GetData(sqlString);
        }
    }
}
