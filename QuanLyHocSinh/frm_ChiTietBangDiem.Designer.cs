
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
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt15 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt45 = new System.Windows.Forms.TextBox();
            this.dgvChiTietBangDiem = new System.Windows.Forms.DataGridView();
            this.gbBangDiem = new System.Windows.Forms.GroupBox();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBangDiem)).BeginInit();
            this.gbBangDiem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMonHoc
            // 
            this.cbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonHoc.FormattingEnabled = true;
            this.cbMonHoc.Location = new System.Drawing.Point(121, 71);
            this.cbMonHoc.Name = "cbMonHoc";
            this.cbMonHoc.Size = new System.Drawing.Size(126, 24);
            this.cbMonHoc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Môn học";
            // 
            // cbLop
            // 
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(121, 28);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(126, 24);
            this.cbLop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Điểm 15 phút";
            // 
            // txt15
            // 
            this.txt15.Location = new System.Drawing.Point(229, 72);
            this.txt15.Name = "txt15";
            this.txt15.Size = new System.Drawing.Size(126, 22);
            this.txt15.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm 45 phút";
            // 
            // txt45
            // 
            this.txt45.Location = new System.Drawing.Point(229, 110);
            this.txt45.Name = "txt45";
            this.txt45.Size = new System.Drawing.Size(128, 22);
            this.txt45.TabIndex = 6;
            // 
            // dgvChiTietBangDiem
            // 
            this.dgvChiTietBangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBangDiem.Location = new System.Drawing.Point(24, 241);
            this.dgvChiTietBangDiem.Name = "dgvChiTietBangDiem";
            this.dgvChiTietBangDiem.ReadOnly = true;
            this.dgvChiTietBangDiem.RowHeadersWidth = 51;
            this.dgvChiTietBangDiem.RowTemplate.Height = 24;
            this.dgvChiTietBangDiem.Size = new System.Drawing.Size(807, 323);
            this.dgvChiTietBangDiem.TabIndex = 100;
            this.dgvChiTietBangDiem.SelectionChanged += new System.EventHandler(this.dgvChiTietBangDiem_SelectionChanged);
            // 
            // gbBangDiem
            // 
            this.gbBangDiem.Controls.Add(this.btnThoat);
            this.gbBangDiem.Controls.Add(this.txtMaHS);
            this.gbBangDiem.Controls.Add(this.btnCapNhat);
            this.gbBangDiem.Controls.Add(this.txt45);
            this.gbBangDiem.Controls.Add(this.label4);
            this.gbBangDiem.Controls.Add(this.label7);
            this.gbBangDiem.Controls.Add(this.txt15);
            this.gbBangDiem.Controls.Add(this.label3);
            this.gbBangDiem.Location = new System.Drawing.Point(351, 12);
            this.gbBangDiem.Name = "gbBangDiem";
            this.gbBangDiem.Size = new System.Drawing.Size(480, 214);
            this.gbBangDiem.TabIndex = 1;
            this.gbBangDiem.TabStop = false;
            this.gbBangDiem.Text = "Thông tin";
            // 
            // txtMaHS
            // 
            this.txtMaHS.Location = new System.Drawing.Point(229, 29);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.ReadOnly = true;
            this.txtMaHS.Size = new System.Drawing.Size(126, 22);
            this.txtMaHS.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mã học sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Học kỳ";
            // 
            // cbHocKy
            // 
            this.cbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbHocKy.Location = new System.Drawing.Point(119, 115);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(128, 24);
            this.cbHocKy.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(247, 154);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 40);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(130, 154);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(92, 40);
            this.btnCapNhat.TabIndex = 7;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(46, 154);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(201, 33);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbHocKy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbMonHoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbLop);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra cứu";
            // 
            // frm_ChiTietBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 574);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbBangDiem);
            this.Controls.Add(this.dgvChiTietBangDiem);
            this.Name = "frm_ChiTietBangDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ChiTietBangDiem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ChiTietBangDiem_FormClosing);
            this.Load += new System.EventHandler(this.frm_ChiTietBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBangDiem)).EndInit();
            this.gbBangDiem.ResumeLayout(false);
            this.gbBangDiem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt45;
        private System.Windows.Forms.DataGridView dgvChiTietBangDiem;
        private System.Windows.Forms.GroupBox gbBangDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label label7;
    }
}