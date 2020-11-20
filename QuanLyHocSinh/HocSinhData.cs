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
        BangDiemData bangDiem = new BangDiemData();

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
            dataProvider.disconnect();

            bangDiem.ThemHocSinh(maHS, lop);
        }

        public void update(string maHS, string tenHS, string email, string gioiTinh, DateTime ngaySinh, string diaChi, string lop)
        {
            try
            {
                dataProvider.open();                             
                string updateCommand = "UPDATE TONGKETLOP SET IDLop = (SELECT IDLop FROM LOP WHERE TenLop = @lop) WHERE MaHS = @maHS2;" +
                                       "UPDATE HOSOHOCSINH SET HoTen = @tenHS, Email = @email, GioiTinh = @gioiTinh, NgaySinh = @ngaySinh, DiaChi = @diaChi WHERE MaHS = @maHS; ";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@tenHS", tenHS));
                sqlParams.Add(new SqlParameter("@email", email));
                sqlParams.Add(new SqlParameter("@gioiTinh", (gioiTinh == "Nam") ? true : false));
                sqlParams.Add(new SqlParameter("@ngaySinh", ngaySinh.ToString("yyyy-MM-dd")));
                sqlParams.Add(new SqlParameter("@diaChi", diaChi));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                sqlParams.Add(new SqlParameter("@lop", lop));
                dataProvider.executeNonQuery(updateCommand, sqlParams);
            }
            catch (Exception)
            {
                throw new Exception("Lỗi");
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
                                       "DELETE FROM HOSOHOCSINH WHERE MaHS = @maHS2";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                dataProvider.executeNonQuery(deleteCommand, sqlParams);          
            }
            catch (Exception)
            {
                throw new Exception("Không thể xóa học sinh này!"); 
            }
            finally
            {
                dataProvider.disconnect();
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
            string sqlString = "select HOSO.MaHS as 'Mã học sinh', HoTen as 'Họ tên', case when GioiTinh = 1 then 'Nam' else N'Nữ' end as 'Giới tính', NgaySinh as 'Ngày sinh', DiaChi as 'Địa chỉ' " +
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
