using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyHocSinh
{
    class BaoCaoData
    {
        DataProvider dataProvider = new DataProvider();

        public DataTable AllSubject()
        {
            string sqlString = "SELECT TenMH FROM MONHOC";
            DataTable dataTable = dataProvider.GetDataTable(sqlString);
            return dataTable;
        }

        public DataSet GetData(string tenMH, string hocKy)
        {
                string searchCommand = "SELECT BD.IDMonHoc, RIGHT(REPLACE(BD.IDBangDiemMon,' ',''),1) as 'HocKy', BD.IDLop, SiSo, SUM(case when Diem1T > DiemDat then 1 else 0 end) as 'SLD' , ROUND((1.0 * (SUM(case when Diem1T > DiemDat then 1 else 0 end))/SiSo),3) as 'Ti le' " +
                    "FROM BANGDIEMMON BD, CTBANGDIEMMON CT, THAMSO, LOP " +
                    "WHERE BD.IDBangDiemMon = CT.IDBangDiemMon AND RIGHT(REPLACE(BD.IDBangDiemMon,' ',''),1) = '"+hocKy+"' AND IDMonHoc = (SELECT IDMonHoc FROM MONHOC WHERE TenMH = '"+tenMH+"') AND BD.IDLop = LOP.IDLop " +
                    "GROUP BY BD.IDMonHoc, BD.IDBangDiemMon, BD.IDLop, SiSo";
            return dataProvider.GetData(searchCommand);
        }
    }
}
