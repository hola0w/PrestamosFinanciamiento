
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PrestamosFinanciamiento
{
    partial class FREGCLIENTE
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
            this.PanelCentro = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CoClient = new System.Windows.Forms.Label();
            this.BCacelar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
            this.BNuevo = new System.Windows.Forms.Button();
            this.TBEmcliente = new System.Windows.Forms.TextBox();
            this.Emcliente = new System.Windows.Forms.Label();
            this.TBDirCliente = new System.Windows.Forms.TextBox();
            this.DirCliente = new System.Windows.Forms.Label();
            this.TBTelCliente = new System.Windows.Forms.TextBox();
            this.TelCliente = new System.Windows.Forms.Label();
            this.TBCedCliente = new System.Windows.Forms.TextBox();
            this.CedCliente = new System.Windows.Forms.Label();
            this.TBApeClient = new System.Windows.Forms.TextBox();
            this.ApeClient = new System.Windows.Forms.Label();
            this.TBNombreC = new System.Windows.Forms.TextBox();
            this.noCliente = new System.Windows.Forms.Label();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.PanelCentro.SuspendLayout();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(154, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION CLIENTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelCentro
            // 
            this.PanelCentro.BackColor = System.Drawing.SystemColors.Menu;
            this.PanelCentro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelCentro.Controls.Add(this.BSalir);
            this.PanelCentro.Controls.Add(this.BGuardar);
            this.PanelCentro.Controls.Add(this.BBuscar);
            this.PanelCentro.Controls.Add(this.textBox1);
            this.PanelCentro.Controls.Add(this.CoClient);
            this.PanelCentro.Controls.Add(this.BCacelar);
            this.PanelCentro.Controls.Add(this.BEliminar);
            this.PanelCentro.Controls.Add(this.BEditar);
            this.PanelCentro.Controls.Add(this.BNuevo);
            this.PanelCentro.Controls.Add(this.TBEmcliente);
            this.PanelCentro.Controls.Add(this.Emcliente);
            this.PanelCentro.Controls.Add(this.TBDirCliente);
            this.PanelCentro.Controls.Add(this.DirCliente);
            this.PanelCentro.Controls.Add(this.TBTelCliente);
            this.PanelCentro.Controls.Add(this.TelCliente);
            this.PanelCentro.Controls.Add(this.TBCedCliente);
            this.PanelCentro.Controls.Add(this.CedCliente);
            this.PanelCentro.Controls.Add(this.TBApeClient);
            this.PanelCentro.Controls.Add(this.ApeClient);
            this.PanelCentro.Controls.Add(this.TBNombreC);
            this.PanelCentro.Controls.Add(this.noCliente);
            this.PanelCentro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelCentro.Location = new System.Drawing.Point(0, 96);
            this.PanelCentro.Name = "PanelCentro";
            this.PanelCentro.Size = new System.Drawing.Size(888, 468);
            this.PanelCentro.TabIndex = 1;
            // 
            // BSalir
            // 
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Location = new System.Drawing.Point(807, 409);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(67, 45);
            this.BSalir.TabIndex = 21;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click_1);
            // 
            // BGuardar
            // 
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BGuardar.Location = new System.Drawing.Point(613, 306);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(123, 33);
            this.BGuardar.TabIndex = 20;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click_1);
            // 
            // BBuscar
            // 
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Location = new System.Drawing.Point(303, 49);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(111, 23);
            this.BBuscar.TabIndex = 19;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 18;
            // 
            // CoClient
            // 
            this.CoClient.AutoSize = true;
            this.CoClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoClient.Location = new System.Drawing.Point(43, 46);
            this.CoClient.Name = "CoClient";
            this.CoClient.Size = new System.Drawing.Size(76, 24);
            this.CoClient.TabIndex = 17;
            this.CoClient.Text = "Codigo:";
            // 
            // BCacelar
            // 
            this.BCacelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCacelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BCacelar.Location = new System.Drawing.Point(325, 354);
            this.BCacelar.Name = "BCacelar";
            this.BCacelar.Size = new System.Drawing.Size(273, 36);
            this.BCacelar.TabIndex = 16;
            this.BCacelar.Text = "Cancelar";
            this.BCacelar.UseVisualStyleBackColor = true;
            this.BCacelar.Click += new System.EventHandler(this.BCacelar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BEliminar.Location = new System.Drawing.Point(471, 306);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(123, 33);
            this.BEliminar.TabIndex = 15;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.UseVisualStyleBackColor = true;
            // 
            // BEditar
            // 
            this.BEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BEditar.Location = new System.Drawing.Point(329, 306);
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(123, 33);
            this.BEditar.TabIndex = 14;
            this.BEditar.Text = "Editar";
            this.BEditar.UseVisualStyleBackColor = true;
            // 
            // BNuevo
            // 
            this.BNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.BNuevo.Location = new System.Drawing.Point(187, 306);
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Size = new System.Drawing.Size(123, 33);
            this.BNuevo.TabIndex = 13;
            this.BNuevo.Text = "Crear";
            this.BNuevo.UseVisualStyleBackColor = true;
            // 
            // TBEmcliente
            // 
            this.TBEmcliente.Location = new System.Drawing.Point(529, 135);
            this.TBEmcliente.Name = "TBEmcliente";
            this.TBEmcliente.Size = new System.Drawing.Size(277, 20);
            this.TBEmcliente.TabIndex = 12;
            // 
            // Emcliente
            // 
            this.Emcliente.AutoSize = true;
            this.Emcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emcliente.Location = new System.Drawing.Point(435, 131);
            this.Emcliente.Name = "Emcliente";
            this.Emcliente.Size = new System.Drawing.Size(62, 24);
            this.Emcliente.TabIndex = 11;
            this.Emcliente.Text = "Email:";
            // 
            // TBDirCliente
            // 
            this.TBDirCliente.Location = new System.Drawing.Point(137, 223);
            this.TBDirCliente.Name = "TBDirCliente";
            this.TBDirCliente.Size = new System.Drawing.Size(669, 20);
            this.TBDirCliente.TabIndex = 10;
            // 
            // DirCliente
            // 
            this.DirCliente.AutoSize = true;
            this.DirCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirCliente.Location = new System.Drawing.Point(43, 219);
            this.DirCliente.Name = "DirCliente";
            this.DirCliente.Size = new System.Drawing.Size(91, 24);
            this.DirCliente.TabIndex = 9;
            this.DirCliente.Text = "Dirrecion:";
            // 
            // TBTelCliente
            // 
            this.TBTelCliente.Location = new System.Drawing.Point(529, 91);
            this.TBTelCliente.Name = "TBTelCliente";
            this.TBTelCliente.Size = new System.Drawing.Size(277, 20);
            this.TBTelCliente.TabIndex = 8;
            // 
            // TelCliente
            // 
            this.TelCliente.AutoSize = true;
            this.TelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelCliente.Location = new System.Drawing.Point(435, 87);
            this.TelCliente.Name = "TelCliente";
            this.TelCliente.Size = new System.Drawing.Size(90, 24);
            this.TelCliente.TabIndex = 7;
            this.TelCliente.Text = "Telefono:";
            // 
            // TBCedCliente
            // 
            this.TBCedCliente.Location = new System.Drawing.Point(137, 178);
            this.TBCedCliente.Name = "TBCedCliente";
            this.TBCedCliente.Size = new System.Drawing.Size(277, 20);
            this.TBCedCliente.TabIndex = 6;
            // 
            // CedCliente
            // 
            this.CedCliente.AutoSize = true;
            this.CedCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CedCliente.Location = new System.Drawing.Point(43, 174);
            this.CedCliente.Name = "CedCliente";
            this.CedCliente.Size = new System.Drawing.Size(75, 24);
            this.CedCliente.TabIndex = 5;
            this.CedCliente.Text = "Cedula:";
            // 
            // TBApeClient
            // 
            this.TBApeClient.Location = new System.Drawing.Point(137, 134);
            this.TBApeClient.Name = "TBApeClient";
            this.TBApeClient.Size = new System.Drawing.Size(277, 20);
            this.TBApeClient.TabIndex = 4;
            // 
            // ApeClient
            // 
            this.ApeClient.AutoSize = true;
            this.ApeClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApeClient.Location = new System.Drawing.Point(43, 130);
            this.ApeClient.Name = "ApeClient";
            this.ApeClient.Size = new System.Drawing.Size(84, 24);
            this.ApeClient.TabIndex = 3;
            this.ApeClient.Text = "Apellido:";
            // 
            // TBNombreC
            // 
            this.TBNombreC.Location = new System.Drawing.Point(137, 90);
            this.TBNombreC.Name = "TBNombreC";
            this.TBNombreC.Size = new System.Drawing.Size(277, 20);
            this.TBNombreC.TabIndex = 2;
            // 
            // noCliente
            // 
            this.noCliente.AutoSize = true;
            this.noCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noCliente.Location = new System.Drawing.Point(43, 86);
            this.noCliente.Name = "noCliente";
            this.noCliente.Size = new System.Drawing.Size(84, 24);
            this.noCliente.TabIndex = 1;
            this.noCliente.Text = "Nombre:";
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.SystemColors.Menu;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTitulo.Location = new System.Drawing.Point(0, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(888, 90);
            this.PTitulo.TabIndex = 2;
            // 
            // FREGCLIENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(888, 564);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.PanelCentro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FREGCLIENTE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANTENIMIENTO CLIENTE";
            this.PanelCentro.ResumeLayout(false);
            this.PanelCentro.PerformLayout();
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelCentro;
        private System.Windows.Forms.Button BCacelar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BNuevo;
        private System.Windows.Forms.TextBox TBEmcliente;
        private System.Windows.Forms.Label Emcliente;
        private System.Windows.Forms.TextBox TBDirCliente;
        private System.Windows.Forms.Label DirCliente;
        private System.Windows.Forms.TextBox TBTelCliente;
        private System.Windows.Forms.Label TelCliente;
        private System.Windows.Forms.TextBox TBCedCliente;
        private System.Windows.Forms.Label CedCliente;
        private System.Windows.Forms.TextBox TBApeClient;
        private System.Windows.Forms.Label ApeClient;
        private System.Windows.Forms.TextBox TBNombreC;
        private System.Windows.Forms.Label noCliente;
        private Button BBuscar;
        private TextBox textBox1;
        private Label CoClient;
        private Panel PTitulo;
        private Button BGuardar;
        private Button BSalir;
    }
}


