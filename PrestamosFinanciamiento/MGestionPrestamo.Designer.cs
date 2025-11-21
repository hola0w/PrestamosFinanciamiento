
namespace PrestamosFinanciamiento
{
    partial class MGestionPrestamo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CodCliente = new System.Windows.Forms.Label();
            this.TBCodCliente = new System.Windows.Forms.TextBox();
            this.RBCodCliente = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RBFechainicio = new System.Windows.Forms.RadioButton();
            this.Fechainicio = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DTFechainicio = new System.Windows.Forms.DateTimePicker();
            this.DTFechafin = new System.Windows.Forms.DateTimePicker();
            this.RBFechafin = new System.Windows.Forms.RadioButton();
            this.Fechafin = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBcliente = new System.Windows.Forms.TextBox();
            this.RBCliente = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 83);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(307, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte y Consulta Prestamos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 504);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BSalir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 67);
            this.panel3.TabIndex = 0;
            // 
            // BSalir
            // 
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Location = new System.Drawing.Point(954, 10);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(67, 45);
            this.BSalir.TabIndex = 25;
            this.BSalir.Text = "Salir";
            this.BSalir.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(444, 346);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // CodCliente
            // 
            this.CodCliente.AutoSize = true;
            this.CodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodCliente.Location = new System.Drawing.Point(33, 43);
            this.CodCliente.Name = "CodCliente";
            this.CodCliente.Size = new System.Drawing.Size(113, 24);
            this.CodCliente.TabIndex = 2;
            this.CodCliente.Text = "Cod Cliente:";
            this.CodCliente.Click += new System.EventHandler(this.CodCliente_Click);
            // 
            // TBCodCliente
            // 
            this.TBCodCliente.Location = new System.Drawing.Point(152, 45);
            this.TBCodCliente.Name = "TBCodCliente";
            this.TBCodCliente.Size = new System.Drawing.Size(146, 20);
            this.TBCodCliente.TabIndex = 3;
            // 
            // RBCodCliente
            // 
            this.RBCodCliente.AutoSize = true;
            this.RBCodCliente.Location = new System.Drawing.Point(15, 49);
            this.RBCodCliente.Name = "RBCodCliente";
            this.RBCodCliente.Size = new System.Drawing.Size(14, 13);
            this.RBCodCliente.TabIndex = 4;
            this.RBCodCliente.TabStop = true;
            this.RBCodCliente.UseVisualStyleBackColor = true;
            this.RBCodCliente.CheckedChanged += new System.EventHandler(this.RBCodCliente_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(30, 105);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cod Prestamo:";
            // 
            // RBFechainicio
            // 
            this.RBFechainicio.AutoSize = true;
            this.RBFechainicio.Location = new System.Drawing.Point(16, 53);
            this.RBFechainicio.Name = "RBFechainicio";
            this.RBFechainicio.Size = new System.Drawing.Size(14, 13);
            this.RBFechainicio.TabIndex = 9;
            this.RBFechainicio.TabStop = true;
            this.RBFechainicio.UseVisualStyleBackColor = true;
            // 
            // Fechainicio
            // 
            this.Fechainicio.AutoSize = true;
            this.Fechainicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fechainicio.Location = new System.Drawing.Point(33, 47);
            this.Fechainicio.Name = "Fechainicio";
            this.Fechainicio.Size = new System.Drawing.Size(118, 24);
            this.Fechainicio.TabIndex = 8;
            this.Fechainicio.Text = "Fecha inicio:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DTFechafin);
            this.panel4.Controls.Add(this.RBFechafin);
            this.panel4.Controls.Add(this.Fechafin);
            this.panel4.Controls.Add(this.DTFechainicio);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.RBFechainicio);
            this.panel4.Controls.Add(this.Fechainicio);
            this.panel4.Location = new System.Drawing.Point(633, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 129);
            this.panel4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tiempo";
            // 
            // DTFechainicio
            // 
            this.DTFechainicio.Location = new System.Drawing.Point(157, 49);
            this.DTFechainicio.Name = "DTFechainicio";
            this.DTFechainicio.Size = new System.Drawing.Size(200, 20);
            this.DTFechainicio.TabIndex = 10;
            // 
            // DTFechafin
            // 
            this.DTFechafin.Location = new System.Drawing.Point(157, 88);
            this.DTFechafin.Name = "DTFechafin";
            this.DTFechafin.Size = new System.Drawing.Size(200, 20);
            this.DTFechafin.TabIndex = 13;
            // 
            // RBFechafin
            // 
            this.RBFechafin.AutoSize = true;
            this.RBFechafin.Location = new System.Drawing.Point(16, 92);
            this.RBFechafin.Name = "RBFechafin";
            this.RBFechafin.Size = new System.Drawing.Size(14, 13);
            this.RBFechafin.TabIndex = 12;
            this.RBFechafin.TabStop = true;
            this.RBFechafin.UseVisualStyleBackColor = true;
            // 
            // Fechafin
            // 
            this.Fechafin.AutoSize = true;
            this.Fechafin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fechafin.Location = new System.Drawing.Point(33, 86);
            this.Fechafin.Name = "Fechafin";
            this.Fechafin.Size = new System.Drawing.Size(93, 24);
            this.Fechafin.TabIndex = 11;
            this.Fechafin.Text = "Fecha fin:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.TBcliente);
            this.panel5.Controls.Add(this.RBCliente);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.CodCliente);
            this.panel5.Controls.Add(this.TBCodCliente);
            this.panel5.Controls.Add(this.RBCodCliente);
            this.panel5.Location = new System.Drawing.Point(633, 165);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(373, 129);
            this.panel5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(142, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cliente:";
            // 
            // TBcliente
            // 
            this.TBcliente.Location = new System.Drawing.Point(152, 82);
            this.TBcliente.Name = "TBcliente";
            this.TBcliente.Size = new System.Drawing.Size(146, 20);
            this.TBcliente.TabIndex = 6;
            // 
            // RBCliente
            // 
            this.RBCliente.AutoSize = true;
            this.RBCliente.Location = new System.Drawing.Point(15, 86);
            this.RBCliente.Name = "RBCliente";
            this.RBCliente.Size = new System.Drawing.Size(14, 13);
            this.RBCliente.TabIndex = 7;
            this.RBCliente.TabStop = true;
            this.RBCliente.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dateTimePicker1);
            this.panel6.Controls.Add(this.radioButton2);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.dateTimePicker2);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.radioButton3);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(254, 165);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(373, 129);
            this.panel6.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(157, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 92);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha fin:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(157, 49);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tiempo";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 53);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Fecha inicio:";
            // 
            // MGestionPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MGestionPrestamo";
            this.Text = "MGestionPrestamo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton RBCodCliente;
        private System.Windows.Forms.TextBox TBCodCliente;
        private System.Windows.Forms.Label CodCliente;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBcliente;
        private System.Windows.Forms.RadioButton RBCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker DTFechafin;
        private System.Windows.Forms.RadioButton RBFechafin;
        private System.Windows.Forms.Label Fechafin;
        private System.Windows.Forms.DateTimePicker DTFechainicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RBFechainicio;
        private System.Windows.Forms.Label Fechainicio;
    }
}