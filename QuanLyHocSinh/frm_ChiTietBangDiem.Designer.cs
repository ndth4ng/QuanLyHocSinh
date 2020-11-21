
namespace QuanLyHocSinh
{
    partial class frm_ChiTietBangDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMonHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaHS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt15 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt45 = new System.Windows.Forms.TextBox();
            this.dgvChiTietBangDiem = new System.Windows.Forms.DataGridView();
            this.gbBangDiem = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBangDiem)).BeginInit();
            this.gbBangDiem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMonHoc
            // 
            this.cbMonHoc.FormattingEnabled = true;
            this.cbMonHoc.Location = new System.Drawing.Point(116, 61);
            this.cbMonHoc.Name = "cbMonHoc";
            this.cbMonHoc.Size = new System.Drawing.Size(121, 24);
            this.cbMonHoc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Môn học";
            // 
            // cbMaHS
            // 
            this.cbMaHS.FormattingEnabled = true;
            this.cbMaHS.Location = new System.Drawing.Point(116, 97);
            this.cbMaHS.Name = "cbMaHS";
            this.cbMaHS.Size = new System.Drawing.Size(121, 24);
            this.cbMaHS.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã học sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Điểm 15 phút";
            // 
            // txt15
            // 
            this.txt15.Location = new System.Drawing.Point(116, 132);
            this.txt15.Name = "txt15";
            this.txt15.Size = new System.Drawing.Size(121, 22);
            this.txt15.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm 45 phút";
            // 
            // txt45
            // 
            this.txt45.Location = new System.Drawing.Point(116, 165);
            this.txt45.Name = "txt45";
            this.txt45.Size = new System.Drawing.Size(121, 22);
            this.txt45.TabIndex = 7;
            // 
            // dgvChiTietBangDiem
            // 
            this.dgvChiTietBangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBangDiem.Location = new System.Drawing.Point(283, 39);
            this.dgvChiTietBangDiem.Name = "dgvChiTietBangDiem";
            this.dgvChiTietBangDiem.RowHeadersWidth = 51;
            this.dgvChiTietBangDiem.RowTemplate.Height = 24;
            this.dgvChiTietBangDiem.Size = new System.Drawing.Size(1049, 352);
            this.dgvChiTietBangDiem.TabIndex = 8;
            // 
            // gbBangDiem
            // 
            this.gbBangDiem.Controls.Add(this.label5);
            this.gbBangDiem.Controls.Add(this.label2);
            this.gbBangDiem.Controls.Add(this.label1);
            this.gbBangDiem.Controls.Add(this.txt45);
            this.gbBangDiem.Controls.Add(this.cbMaHS);
            this.gbBangDiem.Controls.Add(this.cbHocKy);
            this.gbBangDiem.Controls.Add(this.label4);
            this.gbBangDiem.Controls.Add(this.cbMonHoc);
            this.gbBangDiem.Controls.Add(this.txt15);
            this.gbBangDiem.Controls.Add(this.label3);
            this.gbBangDiem.Location = new System.Drawing.Point(12, 19);
            this.gbBangDiem.Name = "gbBangDiem";
            this.gbBangDiem.Size = new System.Drawing.Size(265, 203);
            this.gbBangDiem.TabIndex = 9;
            this.gbBangDiem.TabStop = false;
            this.gbBangDiem.Text = "Thông tin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Học kỳ";
            // 
            // cbHocKy
            // 
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Items.AddRange(new object[] {
            "1",
            "2",
            "Tất cả"});
            this.cbHocKy.Location = new System.Drawing.Point(116, 27);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(121, 24);
            this.cbHocKy.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Location = new System.Drawing.Point(12, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 109);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(140, 35);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 48);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(33, 35);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(92, 48);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bảng điểm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(30, 228);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(230, 48);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frm_ChiTietBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 410);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbBangDiem);
            this.Controls.Add(this.dgvChiTietBangDiem);
            this.Name = "frm_ChiTietBangDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ChiTietBangDiem";
            this.Load += new System.EventHandler(this.frm_ChiTietBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBangDiem)).EndInit();
            this.gbBangDiem.ResumeLayout(false);
            this.gbBangDiem.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaHS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt45;
        private System.Windows.Forms.DataGridView dgvChiTietBangDiem;
        private System.Windows.Forms.GroupBox gbBangDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTimKiem;
    }
}