
namespace PrestamosFinanciamiento
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTGCliente = new System.Windows.Forms.Button();
            this.BTPrestamo = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTGCliente
            // 
            this.BTGCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGCliente.Location = new System.Drawing.Point(12, 153);
            this.BTGCliente.Name = "BTGCliente";
            this.BTGCliente.Size = new System.Drawing.Size(170, 46);
            this.BTGCliente.TabIndex = 0;
            this.BTGCliente.Text = "Gestion Cliente";
            this.BTGCliente.UseVisualStyleBackColor = true;
            this.BTGCliente.Click += new System.EventHandler(this.BTGCliente_Click);
            // 
            // BTPrestamo
            // 
            this.BTPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPrestamo.Location = new System.Drawing.Point(12, 85);
            this.BTPrestamo.Name = "BTPrestamo";
            this.BTPrestamo.Size = new System.Drawing.Size(170, 46);
            this.BTPrestamo.TabIndex = 1;
            this.BTPrestamo.Text = "Gestion Prestamo";
            this.BTPrestamo.UseVisualStyleBackColor = true;
            this.BTPrestamo.Click += new System.EventHandler(this.BTPrestamo_Click);
            // 
            // BSalir
            // 
            this.BSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BSalir.AutoSize = true;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Location = new System.Drawing.Point(920, 20);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(66, 47);
            this.BSalir.TabIndex = 22;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 79);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 42);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(998, 608);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTPrestamo);
            this.Controls.Add(this.BTGCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTGCliente;
        private System.Windows.Forms.Button BTPrestamo;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

