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
    public partial class frm_LopHoc_Them : Form
    {
        DataProvider dataProvider = new DataProvider();
        LopHocData data = new LopHocData();
        public frm_LopHoc_Them()
        {
            InitializeComponent();
            txtTenLop.MaxLength = 20;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = data.search(txtMaLop.Text);

            if (check)
            {
                MessageBox.Show("Mã lớp đã tồn tại!");
            }
            else
            {                
                data.insert(txtMaLop.Text, txtTenLop.Text);
                MessageBox.Show("Thêm lớp mới thành công!");
                this.Hide();
                this.Close();
            }

        }
    }
}
