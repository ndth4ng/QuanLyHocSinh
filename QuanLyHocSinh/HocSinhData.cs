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

        //public void insert(string maMH, string tenMH)
        //{
        //    string insertCommand = "INSERT INTO MONHOC VALUES('" + maMH + "', '" + tenMH + "')";
        //    dataProvider.executeNonQuery(insertCommand);
        //}

        //public void update(string maMH, string tenMH)
        //{
        //    string updateCommand = "UPDATE MONHOC SET TenMH = '" + tenMH + "' WHERE IDMonHoc = '" + maMH + "'";
        //    dataProvider.executeNonQuery(updateCommand);
        //}

        //public void delete(string maMH)
        //{
        //    string deleteCommand = "DELETE FROM MONHOC WHERE IDMonHoc = '" + maMH + "'";
        //    dataProvider.executeNonQuery(deleteCommand);
        //}

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
