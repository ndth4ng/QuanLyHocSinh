using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh
{
    class HocSinhData
    {
        private DataProvider dataProvider = new DataProvider();

        public HocSinhData()
        {
            dataProvider.connect();
        }

        public bool search(string maHS)
        {
            dataProvider.open();
            string searchQuery = "SELECT * FROM HOSOHOCSINH WHERE MaHS = @maHS";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@maHS", maHS));
            SqlDataReader obj = dataProvider.executeQuerry(searchQuery, sqlParams);

            if (obj.HasRows)
            {
                //dataProvider.disconnect();
                return true;
            }
            dataProvider.disconnect();
            return false;
        }

        public void insert(string maHS, string tenHS, string email, string gioiTinh, DateTime ngaySinh, string diaChi, string lop)
        {
            try
            {
                dataProvider.open();
                string insertCommand = "INSERT INTO HOSOHOCSINH VALUES (@maHS, @tenHS, @email, @gioiTinh, @ngaySinh, @diaChi); " +
                                       "INSERT INTO TONGKETLOP(MaHS, IDLop) VALUES (@maHS2, (SELECT IDLop FROM LOP WHERE TenLop = @lop));";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@tenHS", tenHS));
                sqlParams.Add(new SqlParameter("@email", email));
                sqlParams.Add(new SqlParameter("@gioiTinh", (gioiTinh == "Nam") ? true : false));
                sqlParams.Add(new SqlParameter("@ngaySinh", ngaySinh.ToString("yyyy-MM-dd")));
                sqlParams.Add(new SqlParameter("@diaChi", diaChi));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                sqlParams.Add(new SqlParameter("@lop", lop));
                dataProvider.executeNonQuery(insertCommand, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }

            this.ThemHocSinh(maHS, lop);
        }

        public void update(string maHS, string tenHS, string email, string gioiTinh, DateTime ngaySinh, string diaChi, string lop)
        {
            try
            {
                string sqlString = "SELECT IDLop FROM TONGKETLOP WHERE MaHS = @ma";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@ma", maHS));
                object lopCu = dataProvider.executeScalar(sqlString, sqlParams);

                dataProvider.open();  
                
                string updateCommand = "UPDATE TONGKETLOP SET IDLop = (SELECT IDLop FROM LOP WHERE TenLop = @lop) WHERE MaHS = @maHS2;" +
                                       "UPDATE HOSOHOCSINH SET HoTen = @tenHS, Email = @email, GioiTinh = @gioiTinh, NgaySinh = @ngaySinh, DiaChi = @diaChi WHERE MaHS = @maHS; ";
                sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@tenHS", tenHS));
                sqlParams.Add(new SqlParameter("@email", email));
                sqlParams.Add(new SqlParameter("@gioiTinh", (gioiTinh == "Nam") ? true : false));
                sqlParams.Add(new SqlParameter("@ngaySinh", ngaySinh.ToString("yyyy-MM-dd")));
                sqlParams.Add(new SqlParameter("@diaChi", diaChi));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                sqlParams.Add(new SqlParameter("@lop", lop));
                dataProvider.executeNonQuery(updateCommand, sqlParams);

                this.SuaHocSinh(maHS, lopCu.ToString(), lop);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();
            }
        }

        public void delete(string maHS)
        {
            try
            {
                dataProvider.open();
                string deleteCommand = "DELETE FROM TONGKETLOP WHERE MaHS = @maHS " +
                                       "DELETE FROM CTBANGDIEMMON WHERE MaHS = @maHS3 " +
                                       "DELETE FROM HOSOHOCSINH WHERE MaHS = @maHS2";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                sqlParams.Add(new SqlParameter("@maHS3", maHS));
                dataProvider.executeNonQuery(deleteCommand, sqlParams);          
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
            finally
            {
                dataProvider.disconnect();
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
                try
                {
                    dataProvider.open();
                    string insertCommand = "UPDATE CTBANGDIEMMON " +
                        "SET IDCTBangDiemMon = CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@maBD as char)), ' ', ''),5)), IDBangDiemMon = @maBD2" +
                        " WHERE IDCTBangDiemMon = CONCAT('CT', RIGHT(REPLACE((SELECT CAST(@maHS2 as char)), ' ', ''), 2), RIGHT(REPLACE((SELECT CAST(@lopCu as char)), ' ', ''),2), RIGHT(REPLACE((SELECT CAST(@maMH as char)), ' ', ''),2), @hocKy ); ";
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("@maHS", maHS));
                    sqlParams.Add(new SqlParameter("@maHS2", maHS));
                    sqlParams.Add(new SqlParameter("@maBD", row[3]));
                    sqlParams.Add(new SqlParameter("@maBD2", row[3]));
                    sqlParams.Add(new SqlParameter("@maMH", row[1]));
                    sqlParams.Add(new SqlParameter("@lopCu", lopCu));
                    sqlParams.Add(new SqlParameter("@hocKy", row[2]));
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

        public DataTable AllClass()
        {    
            string sqlString = "SELECT TenLop FROM LOP";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }

        public DataSet GetStudent()
        {
            string sqlString = "select HOSO.MaHS as 'Mã học sinh', HoTen as 'Họ tên', case when GioiTinh = 1 then 'Nam' else N'Nữ' end as 'Giới tính', TenLop as 'Lớp', NgaySinh as 'Ngày sinh', Email, DiaChi as 'Địa chỉ' " +
                "from HOSOHOCSINH as HOSO, LOP, TONGKETLOP as TK " +
                "WHERE HOSO.MaHS = TK.MaHS AND LOP.IDLop = TK.IDLop";
            return dataProvider.GetData(sqlString);
        }

        public DataSet GetStudentFromClass(string tenLop)
        {
            string sqlString = "select HOSO.MaHS as 'Mã học sinh', HoTen as 'Họ tên', case when GioiTinh = 1 then 'Nam' else N'Nữ' end as 'Giới tính', NgaySinh as 'Ngày sinh', DiaChi as 'Địa chỉ' " +
               "from HOSOHOCSINH as HOSO, LOP, TONGKETLOP as TK " +
               "WHERE HOSO.MaHS = TK.MaHS AND LOP.IDLop = TK.IDLop AND TenLop = '"+tenLop+"'";
            return dataProvider.GetData(sqlString); 
        }

        public DataSet GetStudentFromClass()
        {
            string sqlString = "select HOSO.MaHS as 'Mã học sinh', HoTen as 'Họ tên', case when GioiTinh = 1 then 'Nam' else N'Nữ' end as 'Giới tính', NgaySinh as 'Ngày sinh',TenLop as 'Lớp', DiaChi as 'Địa chỉ' " +
               "from HOSOHOCSINH as HOSO, LOP, TONGKETLOP as TK " +
               "WHERE HOSO.MaHS = TK.MaHS AND LOP.IDLop = TK.IDLop";
            return dataProvider.GetData(sqlString);
        }

        public object Count(string tenLop)
        {
            string sqlString = "SELECT COUNT(MaHS) FROM TONGKETLOP WHERE IDLop = (SELECT IDLop FROM LOP WHERE TenLop = @tenLop);";
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@tenLop", tenLop));
            return dataProvider.executeScalar(sqlString, sqlParams);

        }


    }
}
