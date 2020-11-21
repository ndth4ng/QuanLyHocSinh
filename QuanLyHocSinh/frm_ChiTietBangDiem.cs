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
            dgvChiTietBangDiem.DataSource = data.GetScoreAll().Tables[0];
            cbMonHoc.Text = "Tất cả";
            cbMaHS.Text = "Tất cả";
            cbHocKy.Text = "Tất cả";
        }

        void FillComboBox()
        {
            DataTable table = data.AllSubject();
            table.Rows.Add("Tất cả");
            cbMonHoc.DataSource = table;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "TenMH";           

            table = data.AllStudent();
            table.Rows.Add("Tất cả");
            cbMaHS.DataSource = table;
            cbMaHS.DisplayMember = "MaHS";
            cbMaHS.ValueMember = "MaHS";
        }

        private void frm_ChiTietBangDiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbHocKy.Text != "Tất cả" && cbMonHoc.Text != "Tất cả" && cbMaHS.Text != "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore(cbHocKy.Text, cbMonHoc.Text, cbMaHS.Text).Tables[0];
            else if (cbHocKy.Text == "Tất cả" && cbMonHoc.Text != "Tất cả" && cbMaHS.Text != "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore2(cbMonHoc.Text, cbMaHS.Text).Tables[0];
            else if (cbHocKy.Text != "Tất cả" && cbMonHoc.Text == "Tất cả" && cbMaHS.Text != "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore3(cbHocKy.Text, cbMaHS.Text).Tables[0];
            else if (cbHocKy.Text != "Tất cả" && cbMonHoc.Text != "Tất cả" && cbMaHS.Text == "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore(cbHocKy.Text, cbMonHoc.Text).Tables[0];
            else if (cbHocKy.Text == "Tất cả" && cbMonHoc.Text == "Tất cả" && cbMaHS.Text != "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore3(cbMaHS.Text).Tables[0];
            else if (cbHocKy.Text == "Tất cả" && cbMonHoc.Text != "Tất cả" && cbMaHS.Text == "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore2(cbMonHoc.Text).Tables[0];
            else if (cbHocKy.Text != "Tất cả" && cbMonHoc.Text == "Tất cả" && cbMaHS.Text == "Tất cả")
                dgvChiTietBangDiem.DataSource = data.GetScore(cbHocKy.Text).Tables[0];
            else
                LoadData();

        }
    }
}
