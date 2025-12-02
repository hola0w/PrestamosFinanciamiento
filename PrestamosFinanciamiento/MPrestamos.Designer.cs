
namespace PrestamosFinanciamiento
{
    partial class MPrestamos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numeroprestamoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoprestamoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldopendienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestamoSeleccionarActivosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBPrestamosDataSet3 = new PrestamosFinanciamiento.DBPrestamosDataSet3();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TBBuscarPrestamo = new System.Windows.Forms.TextBox();
            this.BSeleccionar = new System.Windows.Forms.Button();
            this.BCacelar = new System.Windows.Forms.Button();
            this.dBPrestamosDataSet2 = new PrestamosFinanciamiento.DBPrestamosDataSet2();
            this.prestamoSeleccionarTodosActivosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prestamo_SeleccionarTodosActivosTableAdapter = new PrestamosFinanciamiento.DBPrestamosDataSet2TableAdapters.Prestamo_SeleccionarTodosActivosTableAdapter();
            this.prestamo_SeleccionarActivosTableAdapter = new PrestamosFinanciamiento.DBPrestamosDataSet3TableAdapters.Prestamo_SeleccionarActivosTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestamoSeleccionarActivosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBPrestamosDataSet3)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dBPrestamosDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestamoSeleccionarTodosActivosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroprestamoDataGridViewTextBoxColumn,
            this.nombreclienteDataGridViewTextBoxColumn,
            this.cedulaDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.montoprestamoDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.saldopendienteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.prestamoSeleccionarActivosBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 282);
            this.dataGridView1.TabIndex = 2;
            // 
            // numeroprestamoDataGridViewTextBoxColumn
            // 
            this.numeroprestamoDataGridViewTextBoxColumn.DataPropertyName = "numero_prestamo";
            this.numeroprestamoDataGridViewTextBoxColumn.HeaderText = "numero_prestamo";
            this.numeroprestamoDataGridViewTextBoxColumn.Name = "numeroprestamoDataGridViewTextBoxColumn";
            this.numeroprestamoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreclienteDataGridViewTextBoxColumn
            // 
            this.nombreclienteDataGridViewTextBoxColumn.DataPropertyName = "nombre_cliente";
            this.nombreclienteDataGridViewTextBoxColumn.HeaderText = "nombre_cliente";
            this.nombreclienteDataGridViewTextBoxColumn.Name = "nombreclienteDataGridViewTextBoxColumn";
            this.nombreclienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cedulaDataGridViewTextBoxColumn
            // 
            this.cedulaDataGridViewTextBoxColumn.DataPropertyName = "cedula";
            this.cedulaDataGridViewTextBoxColumn.HeaderText = "cedula";
            this.cedulaDataGridViewTextBoxColumn.Name = "cedulaDataGridViewTextBoxColumn";
            this.cedulaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoprestamoDataGridViewTextBoxColumn
            // 
            this.montoprestamoDataGridViewTextBoxColumn.DataPropertyName = "monto_prestamo";
            this.montoprestamoDataGridViewTextBoxColumn.HeaderText = "monto_prestamo";
            this.montoprestamoDataGridViewTextBoxColumn.Name = "montoprestamoDataGridViewTextBoxColumn";
            this.montoprestamoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldopendienteDataGridViewTextBoxColumn
            // 
            this.saldopendienteDataGridViewTextBoxColumn.DataPropertyName = "saldo_pendiente";
            this.saldopendienteDataGridViewTextBoxColumn.HeaderText = "saldo_pendiente";
            this.saldopendienteDataGridViewTextBoxColumn.Name = "saldopendienteDataGridViewTextBoxColumn";
            this.saldopendienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prestamoSeleccionarActivosBindingSource
            // 
            this.prestamoSeleccionarActivosBindingSource.DataMember = "Prestamo-SeleccionarActivos";
            this.prestamoSeleccionarActivosBindingSource.DataSource = this.dBPrestamosDataSet3;
            // 
            // dBPrestamosDataSet3
            // 
            this.dBPrestamosDataSet3.DataSetName = "DBPrestamosDataSet3";
            this.dBPrestamosDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 75);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(276, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vista de Prestamo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TBBuscarPrestamo);
            this.panel2.Controls.Add(this.BSeleccionar);
            this.panel2.Controls.Add(this.BCacelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 93);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Buscar:";
            // 
            // TBBuscarPrestamo
            // 
            this.TBBuscarPrestamo.Location = new System.Drawing.Point(86, 10);
            this.TBBuscarPrestamo.Name = "TBBuscarPrestamo";
            this.TBBuscarPrestamo.Size = new System.Drawing.Size(702, 20);
            this.TBBuscarPrestamo.TabIndex = 26;
            // 
            // BSeleccionar
            // 
            this.BSeleccionar.BackColor = System.Drawing.Color.Green;
            this.BSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BSeleccionar.Location = new System.Drawing.Point(282, 48);
            this.BSeleccionar.Name = "BSeleccionar";
            this.BSeleccionar.Size = new System.Drawing.Size(123, 33);
            this.BSeleccionar.TabIndex = 25;
            this.BSeleccionar.Text = "Seleccionar";
            this.BSeleccionar.UseVisualStyleBackColor = false;
            // 
            // BCacelar
            // 
            this.BCacelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BCacelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BCacelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BCacelar.ForeColor = System.Drawing.Color.White;
            this.BCacelar.Location = new System.Drawing.Point(411, 48);
            this.BCacelar.Name = "BCacelar";
            this.BCacelar.Size = new System.Drawing.Size(123, 33);
            this.BCacelar.TabIndex = 24;
            this.BCacelar.Text = "Cancelar";
            this.BCacelar.UseVisualStyleBackColor = false;
            // 
            // dBPrestamosDataSet2
            // 
            this.dBPrestamosDataSet2.DataSetName = "DBPrestamosDataSet2";
            this.dBPrestamosDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prestamoSeleccionarTodosActivosBindingSource
            // 
            this.prestamoSeleccionarTodosActivosBindingSource.DataMember = "Prestamo-SeleccionarTodosActivos";
            this.prestamoSeleccionarTodosActivosBindingSource.DataSource = this.dBPrestamosDataSet2;
            // 
            // prestamo_SeleccionarTodosActivosTableAdapter
            // 
            this.prestamo_SeleccionarTodosActivosTableAdapter.ClearBeforeFill = true;
            // 
            // prestamo_SeleccionarActivosTableAdapter
            // 
            this.prestamo_SeleccionarActivosTableAdapter.ClearBeforeFill = true;
            // 
            // MPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MPrestamos";
            this.Text = " bb ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestamoSeleccionarActivosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBPrestamosDataSet3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dBPrestamosDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestamoSeleccionarTodosActivosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource prestamoSeleccionarTodosActivosBindingSource;
        private DBPrestamosDataSet2 dBPrestamosDataSet2;
        private DBPrestamosDataSet2TableAdapters.Prestamo_SeleccionarTodosActivosTableAdapter prestamo_SeleccionarTodosActivosTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBBuscarPrestamo;
        private System.Windows.Forms.Button BSeleccionar;
        private System.Windows.Forms.Button BCacelar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroprestamoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoprestamoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldopendienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource prestamoSeleccionarActivosBindingSource;
        private DBPrestamosDataSet3 dBPrestamosDataSet3;
        private DBPrestamosDataSet3TableAdapters.Prestamo_SeleccionarActivosTableAdapter prestamo_SeleccionarActivosTableAdapter;
    }
}