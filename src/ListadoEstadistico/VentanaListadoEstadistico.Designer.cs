namespace FrbaHotel.ListadoEstadistico
{
    partial class VentanaListadoEstadistico
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.añoNUD = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dataGridEstadisticas = new System.Windows.Forms.DataGridView();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(255, 147);
            this.logo.Size = new System.Drawing.Size(10, 70);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.añoNUD);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.dataGridEstadisticas);
            this.groupBox1.Controls.Add(this.cmbTrimestre);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 254);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOP 5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "A continuación, seleccione el top 5 que desea visualizar:";
            // 
            // añoNUD
            // 
            this.añoNUD.Location = new System.Drawing.Point(81, 85);
            this.añoNUD.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.añoNUD.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.añoNUD.Name = "añoNUD";
            this.añoNUD.Size = new System.Drawing.Size(67, 20);
            this.añoNUD.TabIndex = 17;
            this.añoNUD.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.añoNUD.ValueChanged += new System.EventHandler(this.añoNUD_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Año:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(424, 79);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dataGridEstadisticas
            // 
            this.dataGridEstadisticas.AllowUserToAddRows = false;
            this.dataGridEstadisticas.AllowUserToDeleteRows = false;
            this.dataGridEstadisticas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEstadisticas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridEstadisticas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstadisticas.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridEstadisticas.Location = new System.Drawing.Point(39, 119);
            this.dataGridEstadisticas.Name = "dataGridEstadisticas";
            this.dataGridEstadisticas.ReadOnly = true;
            this.dataGridEstadisticas.Size = new System.Drawing.Size(496, 115);
            this.dataGridEstadisticas.TabIndex = 11;
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Enero-Marzo",
            "Abril-Junio",
            "Julio-Septiembre",
            "Octubre-Diciembre"});
            this.cmbTrimestre.Location = new System.Drawing.Point(81, 56);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(315, 21);
            this.cmbTrimestre.TabIndex = 10;
            this.cmbTrimestre.Text = "Seleccione";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas.",
            "Hoteles con mayor cantidad de consumibles facturados.",
            "Hoteles con mayor cantidad de días fuera de servicio.",
            "Habitaciones con mayor cantidad de días y veces que fueron ocupadas.",
            "Cliente con mayor cantidad de puntos."});
            this.cmbTipo.Location = new System.Drawing.Point(81, 28);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(315, 21);
            this.cmbTipo.TabIndex = 7;
            this.cmbTipo.Text = "Seleccione...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Trimestre:";
            // 
            // VentanaListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 254);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentanaListadoEstadistico";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dataGridEstadisticas;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown añoNUD;
    }
}