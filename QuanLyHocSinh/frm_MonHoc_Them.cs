using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHocSinh
{
    public partial class frm_MonHoc_Them : Form
    {
        DataProvider dataProvider = new DataProvider();
        MonHocData data = new MonHocData();
        public frm_MonHoc_Them()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = data.search(txtMaMH.Text);

            if (check)
            {
                MessageBox.Show("Mã môn học đã tồn tại!");
            }
            else
            {
                data.insert(txtMaMH.Text, txtTenMH.Text);
                MessageBox.Show("Thêm môn học mới thành công!");
                this.Hide();
                this.Close();
            }

            //dataProvider.disconnect();
        }
    }
}
