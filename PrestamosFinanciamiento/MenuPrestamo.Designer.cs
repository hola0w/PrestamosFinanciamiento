
namespace PrestamosFinanciamiento
{
    partial class MenuPrestamo
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
            this.BTRegistrarPrestamo = new System.Windows.Forms.Button();
            this.BTReporteConsulta = new System.Windows.Forms.Button();
            this.BTGestionarPrestamo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTRegistrarPrestamo
            // 
            this.BTRegistrarPrestamo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTRegistrarPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTRegistrarPrestamo.Location = new System.Drawing.Point(12, 65);
            this.BTRegistrarPrestamo.Name = "BTRegistrarPrestamo";
            this.BTRegistrarPrestamo.Size = new System.Drawing.Size(204, 47);
            this.BTRegistrarPrestamo.TabIndex = 0;
            this.BTRegistrarPrestamo.Text = "Registrar Prestamo";
            this.BTRegistrarPrestamo.UseVisualStyleBackColor = false;
            this.BTRegistrarPrestamo.Click += new System.EventHandler(this.BTRegistrarPrestamo_Click);
            // 
            // BTReporteConsulta
            // 
            this.BTReporteConsulta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTReporteConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTReporteConsulta.Location = new System.Drawing.Point(12, 118);
            this.BTReporteConsulta.Name = "BTReporteConsulta";
            this.BTReporteConsulta.Size = new System.Drawing.Size(204, 47);
            this.BTReporteConsulta.TabIndex = 1;
            this.BTReporteConsulta.Text = "Reporte y Consulta";
            this.BTReporteConsulta.UseVisualStyleBackColor = false;
            this.BTReporteConsulta.Click += new System.EventHandler(this.BTReporteConsulta_Click);
            // 
            // BTGestionarPrestamo
            // 
            this.BTGestionarPrestamo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BTGestionarPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGestionarPrestamo.Location = new System.Drawing.Point(12, 12);
            this.BTGestionarPrestamo.Name = "BTGestionarPrestamo";
            this.BTGestionarPrestamo.Size = new System.Drawing.Size(204, 47);
            this.BTGestionarPrestamo.TabIndex = 2;
            this.BTGestionarPrestamo.Text = "Gestionar Prestamo";
            this.BTGestionarPrestamo.UseVisualStyleBackColor = false;
            this.BTGestionarPrestamo.Click += new System.EventHandler(this.BTGestionarPrestamo_Click);
            // 
            // MenuPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(228, 186);
            this.Controls.Add(this.BTGestionarPrestamo);
            this.Controls.Add(this.BTReporteConsulta);
            this.Controls.Add(this.BTRegistrarPrestamo);
            this.Name = "MenuPrestamo";
            this.Text = "MenuPrestamo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTRegistrarPrestamo;
        private System.Windows.Forms.Button BTReporteConsulta;
        private System.Windows.Forms.Button BTGestionarPrestamo;
    }
}