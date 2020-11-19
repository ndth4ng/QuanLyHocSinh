using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class frm_QuanLyHocSinh_Them : Form
    {
        HocSinhData data = new HocSinhData();
        public frm_QuanLyHocSinh_Them()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        void FillComboBox()
        {
            DataTable table = data.AllClass();
            cbLop.DataSource = table;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "TenLop";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = data.search(txtMaHS.Text);

            if (check)
            {
                MessageBox.Show("Mã học sinh đã tồn tại!");
            }
            else
            {
                data.insert(txtMaHS.Text, txtTenHS.Text, txtEmail.Text, cbGioiTinh.SelectedItem.ToString(), dateNgaySinh.Value.Date, txtDiaChi.Text, cbLop.Text);
                MessageBox.Show("Thêm học sinh mới thành công!");
                this.Hide();
                this.Close();
            }
        }

        private void frm_QuanLyHocSinh_Them_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }
    }
}
