namespace BTL_nhom4_LaptrinhWindows
{
    partial class frmReport_DSSV
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.thongkesinhvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BTL_N04DataSet = new BTL_nhom4_LaptrinhWindows.BTL_N04DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.thongkesinhvienTableAdapter = new BTL_nhom4_LaptrinhWindows.BTL_N04DataSetTableAdapters.thongkesinhvienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.thongkesinhvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTL_N04DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // thongkesinhvienBindingSource
            // 
            this.thongkesinhvienBindingSource.DataMember = "thongkesinhvien";
            this.thongkesinhvienBindingSource.DataSource = this.BTL_N04DataSet;
            // 
            // BTL_N04DataSet
            // 
            this.BTL_N04DataSet.DataSetName = "BTL_N04DataSet";
            this.BTL_N04DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.thongkesinhvienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_nhom4_LaptrinhWindows.Report.DSSV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(822, 391);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập mã lớp ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Lọc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // thongkesinhvienTableAdapter
            // 
            this.thongkesinhvienTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport_DSSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport_DSSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê danh sách sinh viên";
            this.Load += new System.EventHandler(this.frmReport_DSSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thongkesinhvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTL_N04DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource thongkesinhvienBindingSource;
        private BTL_N04DataSet BTL_N04DataSet;
        private BTL_N04DataSetTableAdapters.thongkesinhvienTableAdapter thongkesinhvienTableAdapter;
    }
}