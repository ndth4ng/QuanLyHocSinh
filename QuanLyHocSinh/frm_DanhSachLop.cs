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
    public partial class frm_DanhSachLop : Form
    {
        HocSinhData hs = new HocSinhData();
        //LopHocData lop = new LopHocData();
        //DataProvider dataProvider = new DataProvider();
        public frm_DanhSachLop()
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
            cbLop.Text = "Tất cả";
            dgvDanhSachLop.DataSource = hs.GetStudent().Tables[0];
        }
        void FillComboBox()
        {
            DataTable table = hs.AllClass();
            table.Rows.Add("Tất cả");
            cbLop.DataSource = table;           
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "TenLop";          
        }

        private void frm_DanhSachLop_Load(object sender, EventArgs e)
        {
            LoadData();         
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = hs.AllClass();
            if (cbLop.Text == "Tất cả")
            {
                dgvDanhSachLop.DataSource = hs.GetStudentFromClass().Tables[0];
                lbSiSoLop.Text = "Sỉ số: ";
            }
            else
            {
                dgvDanhSachLop.DataSource = hs.GetStudentFromClass(cbLop.Text).Tables[0];
                lbSiSoLop.Text = "Sỉ số: " + hs.Count(cbLop.Text).ToString();
            }
        }
    }
}
