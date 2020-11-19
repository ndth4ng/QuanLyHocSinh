
namespace QuanLyHocSinh
{
    partial class frm_BaoCaoTongKetHocKy
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvTongKetHocKy = new System.Windows.Forms.DataGridView();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongKetHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(712, 13);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(56, 19);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvTongKetHocKy
            // 
            this.dgvTongKetHocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongKetHocKy.Location = new System.Drawing.Point(9, 49);
            this.dgvTongKetHocKy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvTongKetHocKy.Name = "dgvTongKetHocKy";
            this.dgvTongKetHocKy.RowHeadersWidth = 51;
            this.dgvTongKetHocKy.RowTemplate.Height = 24;
            this.dgvTongKetHocKy.Size = new System.Drawing.Size(768, 539);
            this.dgvTongKetHocKy.TabIndex = 16;
            // 
            // cbHocKy
            // 
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(366, 13);
            this.cbHocKy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(92, 21);
            this.cbHocKy.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Học kỳ";
            // 
            // frm_BaoCaoTongKetHocKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 599);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvTongKetHocKy);
            this.Controls.Add(this.cbHocKy);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frm_BaoCaoTongKetHocKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_BaoCaoTongKetHocKy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongKetHocKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvTongKetHocKy;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Label label3;
    }
}