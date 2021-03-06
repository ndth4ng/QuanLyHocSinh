﻿using System;
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
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void tracuuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TraCuu traCuu = new frm_TraCuu();
            this.Hide();
            traCuu.ShowDialog();
            this.Show();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnHS_Click(object sender, EventArgs e)
        {
            frm_QuanLyHocSinh quanLyHS = new frm_QuanLyHocSinh();
            this.Hide();
            quanLyHS.ShowDialog();
            this.Show();
        }

        private void btnLH_Click(object sender, EventArgs e)
        {
            frm_LopHoc lopHoc = new frm_LopHoc();
            this.Hide();
            lopHoc.ShowDialog();
            this.Show();
        }

        private void btnMH_Click(object sender, EventArgs e)
        {
            frm_MonHoc monHoc = new frm_MonHoc();
            this.Hide();
            monHoc.ShowDialog();
            this.Show();
        }

        private void btnDSL_Click(object sender, EventArgs e)
        {
            frm_DanhSachLop dsLop = new frm_DanhSachLop();
            this.Hide();
            dsLop.ShowDialog();
            this.Show();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            frm_ChiTietBangDiem bangDiem = new frm_ChiTietBangDiem();
            this.Hide();
            bangDiem.ShowDialog();
            this.Show();
        }

        private void btnTKMH_Click(object sender, EventArgs e)
        {
            frm_BaoCaoTongKetMon bcMon = new frm_BaoCaoTongKetMon();
            this.Hide();
            bcMon.ShowDialog();
            this.Show();
        }

        private void btnTKHK_Click(object sender, EventArgs e)
        {
            frm_BaoCaoTongKetHocKy bcHocKy = new frm_BaoCaoTongKetHocKy();
            this.Hide();
            bcHocKy.ShowDialog();
            this.Show();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Ban co that su muon thoat?", "Thoat?", MessageBoxButtons.YesNo);
            if (dlg == DialogResult.Yes)
                Application.Exit();
        }
    }
}
