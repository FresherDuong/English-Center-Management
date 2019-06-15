namespace BTL_nhom4_LaptrinhWindows
{
    partial class frmReport_HocPhi
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
            this.thongkehocphiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BTL_N04DataSet1_thongkehocphi = new BTL_nhom4_LaptrinhWindows.BTL_N04DataSet1_thongkehocphi();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.thongkehocphiTableAdapter = new BTL_nhom4_LaptrinhWindows.BTL_N04DataSet1_thongkehocphiTableAdapters.thongkehocphiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.thongkehocphiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTL_N04DataSet1_thongkehocphi)).BeginInit();
            this.SuspendLayout();
            // 
            // thongkehocphiBindingSource
            // 
            this.thongkehocphiBindingSource.DataMember = "thongkehocphi";
            this.thongkehocphiBindingSource.DataSource = this.BTL_N04DataSet1_thongkehocphi;
            // 
            // BTL_N04DataSet1_thongkehocphi
            // 
            this.BTL_N04DataSet1_thongkehocphi.DataSetName = "BTL_N04DataSet1_thongkehocphi";
            this.BTL_N04DataSet1_thongkehocphi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.thongkehocphiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_nhom4_LaptrinhWindows.Report.NoHocPHi.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(691, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // thongkehocphiTableAdapter
            // 
            this.thongkehocphiTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport_HocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport_HocPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sinh viên nợ học phí";
            this.Load += new System.EventHandler(this.frmReport_HocPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thongkehocphiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTL_N04DataSet1_thongkehocphi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource thongkehocphiBindingSource;
        private BTL_N04DataSet1_thongkehocphi BTL_N04DataSet1_thongkehocphi;
        private BTL_N04DataSet1_thongkehocphiTableAdapters.thongkehocphiTableAdapter thongkehocphiTableAdapter;
    }
}