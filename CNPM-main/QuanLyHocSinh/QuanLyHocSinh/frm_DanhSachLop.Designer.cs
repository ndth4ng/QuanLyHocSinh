
namespace QuanLyHocSinh
{
    partial class frm_DanhSachLop
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.lbSiSoLop = new System.Windows.Forms.Label();
            this.dgvDanhSachLop = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lớp";
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(317, 9);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(121, 24);
            this.cbLop.TabIndex = 1;
            // 
            // lbSiSoLop
            // 
            this.lbSiSoLop.AutoSize = true;
            this.lbSiSoLop.Location = new System.Drawing.Point(459, 12);
            this.lbSiSoLop.Name = "lbSiSoLop";
            this.lbSiSoLop.Size = new System.Drawing.Size(43, 17);
            this.lbSiSoLop.TabIndex = 2;
            this.lbSiSoLop.Text = "Sỉ số:";
            // 
            // dgvDanhSachLop
            // 
            this.dgvDanhSachLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachLop.Location = new System.Drawing.Point(12, 43);
            this.dgvDanhSachLop.Name = "dgvDanhSachLop";
            this.dgvDanhSachLop.RowHeadersWidth = 51;
            this.dgvDanhSachLop.RowTemplate.Height = 24;
            this.dgvDanhSachLop.Size = new System.Drawing.Size(776, 395);
            this.dgvDanhSachLop.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(713, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frm_DanhSachLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvDanhSachLop);
            this.Controls.Add(this.lbSiSoLop);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.label1);
            this.Name = "frm_DanhSachLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DanhSachLop";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label lbSiSoLop;
        private System.Windows.Forms.DataGridView dgvDanhSachLop;
        private System.Windows.Forms.Button btnThoat;
    }
}