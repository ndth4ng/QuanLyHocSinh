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
    public partial class frm_TraCuu : Form
    {
        public frm_TraCuu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frm_Main main = new frm_Main();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
    }
}
