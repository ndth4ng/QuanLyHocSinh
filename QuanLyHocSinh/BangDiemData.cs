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

        //public void AddClass(string tenLop, string tenMH, string hocKy)
        //{
        //    string sqlMH = "SELECT IDMonHoc FROM MONHOC";
        //    DataTable monHoc = this.AllSubject();
        //    foreach (DataRow dtRow in monHoc.Rows)
        //    {
        //        string sqlString = "INSERT INTO BANGDIEMMON(IDBangDiemMon, IDLop, IDMonHoc, HocKy) VALUES (CONCAT('BD',@tenLop,); ";
        //        List<SqlParameter> sqlParams = new List<SqlParameter>();
        //        sqlParams.Add(new SqlParameter());
        //        sqlParams.Add(new SqlParameter("@tenLop", tenLop));
        //        sqlParams.Add(new SqlParameter("@tenMH", tenMH));
        //        sqlParams.Add(new SqlParameter("@hocKy", hocKy));
        //    }
        //}

        //public DataTable AllSubject()
        //{
        //    string sqlString = "SELECT IDMonHoc FROM MONHOC";
        //    DataTable dataTable = dataProvider.GetDataTable(sqlString);
        //    return dataTable;
        //}
    }
}
