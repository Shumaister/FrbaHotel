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
            this.añoNUD = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridEstadisticas = new System.Windows.Forms.DataGridView();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(533, 279);
            this.logo.Size = new System.Drawing.Size(29, 36);
            // 
            // añoNUD
            // 
            this.añoNUD.Location = new System.Drawing.Point(24, 210);
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
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Año:";
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
            this.dataGridEstadisticas.Location = new System.Drawing.Point(23, 341);
            this.dataGridEstadisticas.Name = "dataGridEstadisticas";
            this.dataGridEstadisticas.ReadOnly = true;
            this.dataGridEstadisticas.Size = new System.Drawing.Size(539, 125);
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
            this.cmbTrimestre.Location = new System.Drawing.Point(23, 146);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(366, 21);
            this.cmbTrimestre.TabIndex = 10;
            this.cmbTrimestre.Text = "Seleccione";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Clasificacion";
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
            this.cmbTipo.Location = new System.Drawing.Point(25, 76);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(366, 21);
            this.cmbTipo.TabIndex = 7;
            this.cmbTipo.Text = "Seleccione...";
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(20, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Trimestre:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(22, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(81, 16);
            this.label32.TabIndex = 285;
            this.label32.Text = "Estadisticas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(22, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 286;
            this.label1.Text = "TOP 5";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(23, 258);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 287;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // VentanaListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 534);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.añoNUD);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dataGridEstadisticas);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.label16);
            this.Name = "VentanaListadoEstadistico";
            this.Text = "Estadisticas - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.cmbTrimestre, 0);
            this.Controls.SetChildIndex(this.cmbTipo, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.dataGridEstadisticas, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.añoNUD, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.añoNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridEstadisticas;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown añoNUD;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultar;
    }
}