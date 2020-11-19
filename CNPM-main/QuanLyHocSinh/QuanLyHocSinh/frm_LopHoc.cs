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
    public partial class frm_LopHoc : Form
    {

        DataProvider dataProvider = new DataProvider();
        LopHocData data = new LopHocData();
        public frm_LopHoc()
        {
            InitializeComponent();
            txtMaLop.Enabled = false;
        }

        void LoadData()
        {
            dgvLopHoc.DataSource = data.GetClass().Tables[0];
            //dataProvider.disconnect();
            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Main main = new frm_Main();
            main.ShowDialog();
            this.Close();
        }

        private void frm_LopHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dgvLopHoc.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
            DataGridViewRow row = cell.OwningRow;
            txtMaLop.Text = row.Cells["Mã lớp"].Value.ToString().Trim();
            txtTenLop.Text = row.Cells["Tên lớp"].Value.ToString().Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frm_LopHoc_Them add = new frm_LopHoc_Them();
            add.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            data.delete(txtMaLop.Text);
            MessageBox.Show("Xóa lớp học thành công!");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            data.update(txtMaLop.Text, txtTenLop.Text);
            MessageBox.Show("Cập nhập lớp học thành công!");
            LoadData();
        }
    }
}
