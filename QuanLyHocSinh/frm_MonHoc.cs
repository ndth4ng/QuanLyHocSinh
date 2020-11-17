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
    public partial class frm_MonHoc : Form
    {
        DataProvider dataProvider = new DataProvider();
        MonHocData data = new MonHocData();
        public frm_MonHoc()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void LoadData()
        {
            dgvMonHoc.DataSource = data.GetSubject().Tables[0];
            //dataProvider.disconnect();
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dgvMonHoc.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtMaMH.Text = row.Cells["Mã môn học"].Value.ToString().Trim();
                txtTenMH.Text = row.Cells["Tên môn học"].Value.ToString().Trim();
            }
        }

        private void frm_MonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frm_MonHoc_Them add = new frm_MonHoc_Them();
            add.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            data.delete(txtMaMH.Text);
            MessageBox.Show("Xóa lớp học thành công!");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            data.update(txtMaMH.Text, txtTenMH.Text);
            MessageBox.Show("Sửa lớp học thành công!");
            LoadData();
        }
    }
}
