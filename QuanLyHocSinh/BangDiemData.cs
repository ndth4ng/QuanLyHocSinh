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
            if (diem45 == "" && diem15 != "" && float.Parse(diem15) >= 0 && float.Parse(diem15) <= 10)
            {
                string sqlString = "UPDATE CTBANGDIEMMON SET Diem15 = @diem15, Diem45 = null, Diem1T = null WHERE IDCTBangDiemMon = @idct ";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@diem15", float.Parse(diem15)));
                sqlParams.Add(new SqlParameter("@idct", idct));
                SqlDataReader obj = dataProvider.executeQuerry(sqlString, sqlParams);
            }
            else
            if (diem15 != "" && diem45 != "" && float.Parse(diem45) >= 0 && float.Parse(diem45) <= 10 && float.Parse(diem15) >= 0 && float.Parse(diem15) <= 10)
            {
                string sqlString = "UPDATE CTBANGDIEMMON SET Diem15 = @diem15, Diem45 = @diem45, Diem1T = ROUND((@diem152 + (@diem452 * 2)) / 3, 1) WHERE IDCTBangDiemMon = @idct ";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@diem15", float.Parse(diem15)));
                sqlParams.Add(new SqlParameter("@diem45", float.Parse(diem45)));
                sqlParams.Add(new SqlParameter("@diem152", float.Parse(diem15)));
                sqlParams.Add(new SqlParameter("@diem452", float.Parse(diem45)));
                sqlParams.Add(new SqlParameter("@idct", idct));
                SqlDataReader obj = dataProvider.executeQuerry(sqlString, sqlParams);
            }
            else
            if (diem15 == "" && diem45 != "" && float.Parse(diem45) >= 0 && float.Parse(diem45) <= 10)
            {
                string sqlString = "UPDATE CTBANGDIEMMON SET Diem15 = null, Diem45 = @diem45, Diem1T = null WHERE IDCTBangDiemMon = @idct ";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@diem45", float.Parse(diem45)));
                sqlParams.Add(new SqlParameter("@idct", idct));
                SqlDataReader obj = dataProvider.executeQuerry(sqlString, sqlParams);
            }
            else
            if (diem15 == "" && diem45 == "")
            {
                string sqlString = "UPDATE CTBANGDIEMMON SET Diem15 = null, Diem45 = null, Diem1T = null WHERE IDCTBangDiemMon = @idct ";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@idct", idct));
                SqlDataReader obj = dataProvider.executeQuerry(sqlString, sqlParams);
            }
            else
            {
                dataProvider.disconnect();
                throw new Exception("Nhập điểm lớn hơn bằng 0 và nhỏ hơn bằng 10!");
            }
            dataProvider.disconnect();

            this.TinhDiem();
            this.SoLuongDat();
        }

        public void TinhDiem()
        {
            string sqlQuery = "SELECT MaHS FROM HOSOHOCSINH";
            DataTable table = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    dataProvider.open();
                    string insertCommand = "UPDATE TONGKETLOP SET TBHK1 = (SELECT ROUND(AVG(Diem1T), 1) " +
                                                                            "FROM CTBANGDIEMMON CT " +
                                                                            "WHERE MaHS = @maHS AND RIGHT(REPLACE(IDCTBangDiemMon,' ',''), 1) = '1'), " +
                                                                 "TBHK2 = (SELECT ROUND(AVG(Diem1T), 1) " +
                                                                            "FROM CTBANGDIEMMON CT " +
                                                                            "WHERE MaHS = @maHS AND RIGHT(REPLACE(IDCTBangDiemMon,' ',''), 1) = '2')" +
                                            "WHERE MaHS = @maHS; ";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maHS", row[0]));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                }
                catch (Exception)
                {

                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
        }

        public void SoLuongDat()
        {
            string sqlQuery = "SELECT BD.IDBangDiemMon, BD.IDLop, BD.IDMonHoc, SUM(case when Diem1T > DiemDat then 1 else 0 end) " +
                "FROM BANGDIEMMON BD, CTBANGDIEMMON CT, THAMSO " +
                "WHERE BD.IDBangDiemMon = CT.IDBangDiemMon " +
                "GROUP BY IDMonHoc, BD.IDBangDiemMon, IDLop";
            DataTable maHS = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in maHS.Rows)
            {
                try
                {
                    dataProvider.open();
                    string insertCommand = "UPDATE BANGDIEMMON " +
                        "SET SoLuongDat = @sld, TiLe = ROUND(1.0 * @sld / (SELECT COUNT(*) FROM TONGKETLOP WHERE IDLop = @maLop), 3) " +
                        "WHERE IDBangDiemMon = @id;";


                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@sld", row[3]));
                    sqlParams.Add(new SqlParameter("@sld", row[3]));
                    sqlParams.Add(new SqlParameter("@id", row[0]));
                    sqlParams.Add(new SqlParameter("@maLop", row[1]));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                }
                catch (Exception)
                {

                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
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
