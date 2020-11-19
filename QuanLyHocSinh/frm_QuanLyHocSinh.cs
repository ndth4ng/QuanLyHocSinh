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
    public partial class frm_QuanLyHocSinh : Form
    {
        DataProvider dataProvider = new DataProvider();
        HocSinhData data = new HocSinhData();

        public frm_QuanLyHocSinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            FillComboBox();
            dgvDanhSachHS.DataSource = data.GetStudent().Tables[0];           
            dgvDanhSachHS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvDanhSachHS.Columns[4] = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void FillComboBox()
        {
            DataTable table = data.AllClass();
            cbLop.DataSource = table;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "TenLop";
        }

        private void dgvDanhSachHS_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dgvDanhSachHS.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                try { 
                    DataGridViewRow row = cell.OwningRow;
                    txtMaHS.Text = row.Cells["Mã học sinh"].Value.ToString().Trim();
                    txtTenHS.Text = row.Cells["Họ tên"].Value.ToString().Trim();
                    if (row.Cells["Giới tính"].Value.ToString() == "Nam")
                        cbGioiTinh.SelectedItem = "Nam";
                    else
                        cbGioiTinh.SelectedItem = "Nữ";
                    cbLop.SelectedValue = row.Cells["Lớp"].Value;
                    txtEmail.Text = row.Cells["Email"].Value.ToString().Trim();
                    txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString().Trim();
                    dateNgaySinh.Text = row.Cells["Ngày sinh"].Value.ToString();               
                }
                catch (Exception)
                {
                    return;
                }
                //MessageBox.Show(dateNgaySinh.Value.ToString());
                //MessageBox.Show(cbGioiTinh.SelectedItem.ToString() == "Nam" ? "true" : "false");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {            
            frm_QuanLyHocSinh_Them add = new frm_QuanLyHocSinh_Them();
            add.ShowDialog();
            this.Show();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool check = true;
            try
            {
                data.delete(txtMaHS.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                check = false;
                
            }
            finally
            {
                LoadData();
            }
            if (check)
                MessageBox.Show("Xóa học sinh thành công!");                   
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check = true;
            try
            {
                data.update(txtMaHS.Text, txtTenHS.Text, txtEmail.Text, cbGioiTinh.SelectedItem.ToString(), dateNgaySinh.Value.Date, txtDiaChi.Text, cbLop.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                check = false;
            }
            finally
            {
                LoadData();
            }
            if (check)
                MessageBox.Show("Cập nhật thông tin học sinh thành công!");
        }
    }
}
