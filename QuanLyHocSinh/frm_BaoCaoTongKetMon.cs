using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class frm_BaoCaoTongKetMon : Form
    {
        BaoCaoData data = new BaoCaoData();
        public frm_BaoCaoTongKetMon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void LoadData()
        {
           
            FillComboBox();
            cbMonHoc.SelectedIndex = -1;
            cbHocKy.SelectedIndex = -1;
            //dgvTongKetMon.DataSource = data.GetSubject().Tables[0];
            ////dataProvider.disconnect();
            //dgvTongKetMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void FillComboBox()
        {
            DataTable table = data.AllSubject();
            cbMonHoc.DataSource = table;
            cbMonHoc.DisplayMember = "TenMH";
            cbMonHoc.ValueMember = "TenMH";

        }

        private void frm_BaoCaoTongKetMon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbHocKy.Text != "" && cbMonHoc.Text != "")
            {
                dgvTongKetMon.DataSource = data.GetData(cbMonHoc.Text, cbHocKy.Text).Tables[0];
                dgvTongKetMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                setRowNumber(dgvTongKetMon);
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
