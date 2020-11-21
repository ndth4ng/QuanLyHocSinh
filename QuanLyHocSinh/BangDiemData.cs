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

        public void ThemLopHoc(string maLop)
        {
            string sqlQuery = "SELECT IDMonHoc FROM MONHOC";
            DataTable monHoc = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in monHoc.Rows)
            {
                try
                {
                    dataProvider.open();
                    string insertCommand = "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '1'), @maLop2, @monHoc2, @hocKy1)" +
                        "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '2'), @maLop2, @monHoc2, @hocKy2)";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maLop", maLop));
                    sqlParams.Add(new SqlParameter("@monHoc", row[0]));
                    sqlParams.Add(new SqlParameter("@maLop2", maLop));
                    sqlParams.Add(new SqlParameter("@monHoc2", row[0]));
                    sqlParams.Add(new SqlParameter("@hocKy1", 1));
                    sqlParams.Add(new SqlParameter("@hocKy2", 2));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
        }
        public void ThemMonHoc(string maMH)
        {
            string sqlQuery = "SELECT IDLop FROM LOP";
            DataTable lopHoc = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in lopHoc.Rows)
            {
                try
                {
                    dataProvider.open();
                    string insertCommand = "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '1'), @maLop2, @monHoc2, @hocKy1)" +
                        "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES(CONCAT('BD', REPLACE((SELECT CAST(@maLop as char)),' ', ''), RIGHT(REPLACE((SELECT CAST(@monHoc as char)), ' ', ''), 2), '2'), @maLop2, @monHoc2, @hocKy2)";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maLop", row[0]));
                    sqlParams.Add(new SqlParameter("@monHoc", maMH));
                    sqlParams.Add(new SqlParameter("@maLop2", row[0]));
                    sqlParams.Add(new SqlParameter("@monHoc2", maMH));
                    sqlParams.Add(new SqlParameter("@hocKy1", 1));
                    sqlParams.Add(new SqlParameter("@hocKy2", 2));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
        }
        public void ThemHocSinh()
        {
            string sqlQuery = "SELECT MaHS, IDBangDiemMon FROM BANGDIEMMON BD, TONGKETLOP TK WHERE BD.IDLop = TK.IDLop;";
            DataTable bangDiem = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in bangDiem.Rows)
            {
                string insertCommand = "INSERT INTO CTBANGDIEMMON(IDCTBangDiemMon, MaHS, IDBangDiemMon) VALUES (CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@maBD as char)),' ',''),5)), @maHS2, @maBD2)";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", row[0]));
                sqlParams.Add(new SqlParameter("@maHS2", row[0]));
                sqlParams.Add(new SqlParameter("@maBD", row[1]));
                sqlParams.Add(new SqlParameter("@maBD2", row[1]));
                if (this.search(row[1].ToString().Trim(), row[0].ToString().Trim()) == false)
                {
                    try
                    {
                        dataProvider.open();
                        dataProvider.executeNonQuery(insertCommand, sqlParams);
                    }
                    catch (Exception) { }
                    finally
                    {
                        dataProvider.disconnect();
                    }
                }
            }
        }

        public void ThemHocSinh(string maHS, string lop)
        {
            string sqlQuery = "SELECT IDLop, IDBangDiemMon FROM BANGDIEMMON WHERE IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lop + "');";
            DataTable bangDiem = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in bangDiem.Rows)
            {
                try
                {
                    dataProvider.open();
                    string insertCommand = "INSERT INTO CTBANGDIEMMON(IDCTBangDiemMon, MaHS, IDBangDiemMon) VALUES (CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@maBD as char)),' ',''),5)), @maHS2, @maBD2)";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maHS", maHS));
                    sqlParams.Add(new SqlParameter("@maHS2", maHS));
                    sqlParams.Add(new SqlParameter("@maBD", row[1]));
                    sqlParams.Add(new SqlParameter("@maBD2", row[1]));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
        }

        public void SuaHocSinh(string maHS, string lopCu, string lopMoi)
        {
            string sqlQuery = "SELECT IDLop, IDMonHoc, HocKy, IDBangDiemMon FROM BANGDIEMMON WHERE IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lopMoi + "');";
            DataTable bangDiem = dataProvider.GetDataTable(sqlQuery);
            foreach (DataRow row in bangDiem.Rows)
            {
                //try
                //{
                    dataProvider.open();
                    string insertCommand = "UPDATE CTBANGDIEMMON" +
                        "SET IDCTBangDiemMon = CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@maBD as char)), ' ', ''),5)), IDBangDiemMon = @maBD" +
                        "WHERE IDCTBangDiemMon = CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS2 as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@lopCu as char)), ' ', ''),2), RIGHT(REPLACE((SELECT CAST(@maMon as char)), ' ', ''),2), @hocKy ); ";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maHS", maHS));
                    sqlParams.Add(new SqlParameter("@maHS2", maHS));
                    sqlParams.Add(new SqlParameter("@maBD", row[3]));
                    sqlParams.Add(new SqlParameter("@maBD2", row[3]));
                    sqlParams.Add(new SqlParameter("@maMH", row[1]));
                    sqlParams.Add(new SqlParameter("@hocKy", row[2]));
                    dataProvider.executeNonQuery(insertCommand, sqlParams);
                //}
                //catch (Exception)
                //{
                //    return;
                //}
                //finally
                //{
                    dataProvider.disconnect();
                //}
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

        //public DataSet GetScoreAll()
        //{
        //    string sqlString = "SELECT HocKy, CTBD.MaHS, HoTen, TenMH,  Diem15, Diem45, Diem1T " +
        //        "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
        //        "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon;";
        //    return dataProvider.GetData(sqlString);
        //}

        public DataSet GetScoreAll()
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon;";
            return dataProvider.GetData(sqlString);
        }
        public DataSet GetScore(string hocKy)
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND HocKy = " + hocKy + ";";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore2(string tenMH)
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND BD.IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = N'" + tenMH + "');";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore3(string lop)
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND BD.IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lop + "');";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore(string hocKy, string tenMH)
        {
            string sqlString = "SELECT HoTen,  Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND HocKy = " + hocKy + " AND BD.IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = N'" + tenMH + "');";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore2(string tenMH, string lop)
        {
            string sqlString = "HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND BD.IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '"+lop+"') AND BD.IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = N'" + tenMH + "');";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore3(string hocKy, string lop)
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND BD.IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lop + "') AND HocKy = " + hocKy + ";";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetScore(string hocKy, string tenMH, string lop)
        {
            string sqlString = "SELECT HoTen, Diem15, Diem45, Diem1T " +
                "FROM BANGDIEMMON BD, MONHOC MH, CTBANGDIEMMON CTBD, HOSOHOCSINH HS " +
                "WHERE CTBD.MaHS = HS.MaHS AND BD.IDMonHoc = MH.IDMonHoc AND BD.IDBangDiemMon = CTBD.IDBangDiemMon AND HocKy = " + hocKy + " AND BD.IDLop = (SELECT IDLop FROM LOP WHERE TenLop = '" + lop + "') AND BD.IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = N'" + tenMH + "');";
            return dataProvider.GetData(sqlString);
        }
    }
}
