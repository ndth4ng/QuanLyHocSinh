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
    public partial class frm_ChiTietBangDiem : Form
    {
        BangDiemData data = new BangDiemData();
        public frm_ChiTietBangDiem()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LoadData()
        {
            FillComboBox();
            //dgvChiTietBangDiem.DataSource = data.GetScoreAll().Tables[0];
            dgvChiTietBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbMonHoc.SelectedIndex = -1;
            cbLop.SelectedIndex = -1;
        }

        void FillComboBox()
        {
            DataTable table = data.AllSubject();
            cbMonHoc.DataSource = table;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "TenMH";           

            table = data.AllClass();
            cbLop.DataSource = table;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "TenLop";
        }

        private void frm_ChiTietBangDiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbHocKy.Text != "" && cbMonHoc.Text != "" && cbLop.Text != "")
            {
                
                dgvChiTietBangDiem.DataSource = data.GetScore(cbHocKy.Text, cbMonHoc.Text, cbLop.Text).Tables[0];
                setRowNumber(dgvChiTietBangDiem);
            }
            else
                MessageBox.Show("Thiếu thông tin tìm kiếm!");

        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
    }
}
