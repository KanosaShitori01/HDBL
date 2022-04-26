
namespace HDBL
{
    partial class Form2
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QL_BANHANGDataSet1 = new HDBL.QL_BANHANGDataSet1();
            this.CHITIETHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CHITIETHDTableAdapter = new HDBL.QL_BANHANGDataSet1TableAdapters.CHITIETHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QL_BANHANGDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETHDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CHITIETHDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HDBL.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QL_BANHANGDataSet1
            // 
            this.QL_BANHANGDataSet1.DataSetName = "QL_BANHANGDataSet1";
            this.QL_BANHANGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CHITIETHDBindingSource
            // 
            this.CHITIETHDBindingSource.DataMember = "CHITIETHD";
            this.CHITIETHDBindingSource.DataSource = this.QL_BANHANGDataSet1;
            // 
            // CHITIETHDTableAdapter
            // 
            this.CHITIETHDTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QL_BANHANGDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETHDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CHITIETHDBindingSource;
        private QL_BANHANGDataSet1 QL_BANHANGDataSet1;
        private QL_BANHANGDataSet1TableAdapters.CHITIETHDTableAdapter CHITIETHDTableAdapter;
    }
}