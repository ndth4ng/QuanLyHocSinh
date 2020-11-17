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
            //dgvMonHoc.Columns[0].Name = "Mã môn học";
            //dgvMonHoc.Columns[1].Name = "Tên môn học";
            //string sqlString = "select IDMonHoc as 'Mã môn học' , TenMH as 'Tên môn học' from MONHOC";
            dgvDanhSachHS.DataSource = data.GetStudent().Tables[0];
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
                DataGridViewRow row = cell.OwningRow;
                txtMaHS.Text = row.Cells["Mã học sinh"].Value.ToString().Trim();
                txtTenHS.Text = row.Cells["Họ tên"].Value.ToString().Trim();
                if (row.Cells["Giới tính"].Value.ToString() == "Nam")
                    cbGioiTinh.SelectedItem = "Nam";
                else
                    cbGioiTinh.SelectedItem = "Nữ";               
                txtEmail.Text = row.Cells["Email"].Value.ToString().Trim();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString().Trim();
                try
                {
                    dateNgaySinh.Value = Convert.ToDateTime(row.Cells["Ngày sinh"].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("?");
                }
                //MessageBox.Show(dateNgaySinh.Value.ToString());
                //MessageBox.Show(cbGioiTinh.SelectedItem.ToString() == "Nam" ? "true" : "false");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //string maLop = "";
            //bool flag = false;
            //SqlCommand command;
            //using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            //{
            //    con.Open();
            //    using (command = new SqlCommand("SELECT * FROM HOSOHOCSINH WHERE MaHS = '" + txtMaHS.Text + "'", con))
            //    {
            //        SqlDataReader reader = command.ExecuteReader();
            //        if (reader.HasRows)
            //            flag = true;
            //        reader.Close();

            //        command = new SqlCommand("SELECT IDLop FROM LOP WHERE TenLop = '" + cbLop.SelectedItem.ToString() + "'", con);
            //        using (reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //                maLop = (reader["IDLop"].ToString());
            //            MessageBox.Show(maLop);
            //            reader.Close();
            //        }
            //    }
            //    if (!flag)
            //    {
            //        //string date = dateNgaySinh.Value.ToString("yyyy-MM-dd");
            //        string query = "INSERT INTO HOSOHOCSINH " +
            //            "VALUES (@MaHS, @TenHS, @Email, @GioiTinh, @NgaySinh, @DiaChi);" + 
            //            "INSERT INTO TONGKETLOP(MaHS, IDLop) VALUES(@MaHS2, @IDLop);";
            //        //try
            //        //{                       
            //            command = new SqlCommand(query, con);
            //        command.Parameters.AddWithValue("MaHS", txtMaHS.Text);
            //        command.Parameters.AddWithValue("TenHS", txtTenHS.Text);
            //        command.Parameters.AddWithValue("Email", txtEmail.Text);
            //        command.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = cbGioiTinh.SelectedItem.ToString() == "Nam" ? true : false;
            //        command.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dateNgaySinh.Value.Date;
            //        command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            //        command.Parameters.AddWithValue("@MaHS2", txtMaHS.Text);
            //        command.Parameters.AddWithValue("@IDLop", maLop);

            //        command.ExecuteNonQuery();
            //        //}
            //        //catch (Exception) { MessageBox.Show("Error"); }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ma hoc sinh ton tai");
            //    }
            //    con.Close();
            //    LoadData();
            //}

            frm_QuanLyHocSinh_Them add = new frm_QuanLyHocSinh_Them();
            add.ShowDialog();
            this.Show();
        }
    }
}
