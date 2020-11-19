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

        public void update(string maHS, string stenHS, string email, string gioiTinh, DateTime ngaySinh, string diaChi, string lop)
        {
            try
            {
                dataProvider.open();
                string updateCommand = "UPDATE HOSOHOCSINH SET HoTen = @tenHS Email = @email GioiTinh = @gioiTinh DiaChi = @diaChi WHERE MaHS = @maHS; " + 
                                       "UPDATE TONGKETLOP SET TenLop = @lop WHERE MaHS = @maHS2;";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@tenHS", tenHS));
                sqlParams.Add(new SqlParameter("@email", email));
                sqlParams.Add(new SqlParameter("@gioiTinh", (gioiTinh == "Nam") ? true : false));
                sqlParams.Add(new SqlParameter("@diaChi", diaChi));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                sqlParams.Add(new SqlParameter("@lop", lop));
                dataProvider.executeNonQuery(updateCommand, sqlParams);
            }
            catch (Exception)
            {
                //return;
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
                string deleteCommand = "DELETE FROM HOSOHOCSINH WHERE MaHS = @maHS " +
                                       "DELETE FROM TONGKETLOP WHERE MaHS = @maHS2";
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("@maHS", maHS));
                sqlParams.Add(new SqlParameter("@maHS2", maHS));
                dataProvider.executeNonQuery(deleteCommand, sqlParams);          
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

        public DataTable AllClass()
        {    
            string sqlString = "SELECT TenLop FROM LOP";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }

        public DataSet GetStudent()
        {
            string sqlString = "select HOSO.MaHS as 'Mã học sinh', HoTen as 'Họ tên', case when GioiTinh = 1 then 'Nam' else 'Nữ' end as 'Giới tính', TenLop as 'Tên Lớp', NgaySinh as 'Ngày sinh', Email, DiaChi as 'Địa chỉ' " +
                "from HOSOHOCSINH as HOSO, LOP, TONGKETLOP as TK " +
                "WHERE HOSO.MaHS = TK.MaHS AND LOP.IDLop = TK.IDLop";
            return dataProvider.GetData(sqlString);
        }
    }
}
