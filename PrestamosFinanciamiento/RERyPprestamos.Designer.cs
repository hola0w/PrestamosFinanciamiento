
namespace PrestamosFinanciamiento
{
    partial class RERyPprestamos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new PrestamosFinanciamiento.DataSet1();
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClienteTableAdapter = new PrestamosFinanciamiento.DataSet1TableAdapters.ClienteTableAdapter();
            this.PrestamosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrestamosTableAdapter = new PrestamosFinanciamiento.DataSet1TableAdapters.PrestamosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrestamosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ClienteBindingSource;
            reportDataSource2.Name = "Prestamo";
            reportDataSource2.Value = this.PrestamosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PrestamosFinanciamiento.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataMember = "Cliente";
            this.ClienteBindingSource.DataSource = this.DataSet1;
            // 
            // ClienteTableAdapter
            // 
            this.ClienteTableAdapter.ClearBeforeFill = true;
            // 
            // PrestamosBindingSource
            // 
            this.PrestamosBindingSource.DataMember = "Prestamos";
            this.PrestamosBindingSource.DataSource = this.DataSet1;
            // 
            // PrestamosTableAdapter
            // 
            this.PrestamosTableAdapter.ClearBeforeFill = true;
            // 
            // RERyPprestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RERyPprestamos";
            this.Text = "RERyPprestamos";
            this.Load += new System.EventHandler(this.RERyPprestamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrestamosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource PrestamosBindingSource;
        private DataSet1TableAdapters.ClienteTableAdapter ClienteTableAdapter;
        private DataSet1TableAdapters.PrestamosTableAdapter PrestamosTableAdapter;
    }
}