namespace FrbaHotel.AbmHotel
{
    partial class VentanaEliminarHotel
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
            this.label32 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxFechaInicio = new System.Windows.Forms.TextBox();
            this.tbxFechaFin = new System.Windows.Forms.TextBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxMotivo = new System.Windows.Forms.TextBox();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btnSeleccionarFechaInicio = new System.Windows.Forms.Button();
            this.btnSeleccionarFechaIFin = new System.Windows.Forms.Button();
            this.btnAceptarFecha = new System.Windows.Forms.Button();
            this.btnElminarGuardar = new System.Windows.Forms.Button();
            this.btnEliminarLimpiar = new System.Windows.Forms.Button();
            this.lblHotel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(427, 265);
            this.logo.Size = new System.Drawing.Size(22, 35);
            this.logo.Visible = false;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(18, 17);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 16);
            this.label32.TabIndex = 366;
            this.label32.Text = "Datos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(87, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 22);
            this.label11.TabIndex = 365;
            this.label11.Text = "*";
            // 
            // tbxFechaInicio
            // 
            this.tbxFechaInicio.Enabled = false;
            this.tbxFechaInicio.Location = new System.Drawing.Point(21, 107);
            this.tbxFechaInicio.Name = "tbxFechaInicio";
            this.tbxFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.tbxFechaInicio.TabIndex = 361;
            this.tbxFechaInicio.TabStop = false;
            // 
            // tbxFechaFin
            // 
            this.tbxFechaFin.Enabled = false;
            this.tbxFechaFin.Location = new System.Drawing.Point(21, 173);
            this.tbxFechaFin.Name = "tbxFechaFin";
            this.tbxFechaFin.Size = new System.Drawing.Size(100, 20);
            this.tbxFechaFin.TabIndex = 364;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 80);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(80, 13);
            this.lblFechaInicio.TabIndex = 360;
            this.lblFechaInicio.Text = "Fecha de Inicio";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 363;
            this.label12.Text = "Fecha de Fin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(96, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 362;
            this.label7.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(55, 267);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 22);
            this.label21.TabIndex = 349;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 268);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 347;
            this.label22.Text = "Motivo";
            // 
            // tbxMotivo
            // 
            this.tbxMotivo.Location = new System.Drawing.Point(21, 294);
            this.tbxMotivo.Multiline = true;
            this.tbxMotivo.Name = "tbxMotivo";
            this.tbxMotivo.Size = new System.Drawing.Size(499, 137);
            this.tbxMotivo.TabIndex = 348;
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(252, 80);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 367;
            // 
            // btnSeleccionarFechaInicio
            // 
            this.btnSeleccionarFechaInicio.Location = new System.Drawing.Point(136, 104);
            this.btnSeleccionarFechaInicio.Name = "btnSeleccionarFechaInicio";
            this.btnSeleccionarFechaInicio.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarFechaInicio.TabIndex = 368;
            this.btnSeleccionarFechaInicio.Text = "Seleccionar";
            this.btnSeleccionarFechaInicio.UseVisualStyleBackColor = true;
            this.btnSeleccionarFechaInicio.Click += new System.EventHandler(this.btnSeleccionarFechaInicio_Click);
            // 
            // btnSeleccionarFechaIFin
            // 
            this.btnSeleccionarFechaIFin.Location = new System.Drawing.Point(136, 170);
            this.btnSeleccionarFechaIFin.Name = "btnSeleccionarFechaIFin";
            this.btnSeleccionarFechaIFin.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarFechaIFin.TabIndex = 369;
            this.btnSeleccionarFechaIFin.Text = "Seleccionar";
            this.btnSeleccionarFechaIFin.UseVisualStyleBackColor = true;
            this.btnSeleccionarFechaIFin.Click += new System.EventHandler(this.btnSeleccionarFechaIFin_Click);
            // 
            // btnAceptarFecha
            // 
            this.btnAceptarFecha.Location = new System.Drawing.Point(332, 254);
            this.btnAceptarFecha.Name = "btnAceptarFecha";
            this.btnAceptarFecha.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarFecha.TabIndex = 370;
            this.btnAceptarFecha.Text = "Aceptar";
            this.btnAceptarFecha.UseVisualStyleBackColor = true;
            this.btnAceptarFecha.Click += new System.EventHandler(this.btnAceptarFecha_Click);
            // 
            // btnElminarGuardar
            // 
            this.btnElminarGuardar.Location = new System.Drawing.Point(301, 453);
            this.btnElminarGuardar.Name = "btnElminarGuardar";
            this.btnElminarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnElminarGuardar.TabIndex = 371;
            this.btnElminarGuardar.Text = "Guardar";
            this.btnElminarGuardar.UseVisualStyleBackColor = true;
            this.btnElminarGuardar.Click += new System.EventHandler(this.btnElminarGuardar_Click);
            // 
            // btnEliminarLimpiar
            // 
            this.btnEliminarLimpiar.Location = new System.Drawing.Point(144, 453);
            this.btnEliminarLimpiar.Name = "btnEliminarLimpiar";
            this.btnEliminarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLimpiar.TabIndex = 372;
            this.btnEliminarLimpiar.Text = "Limpiar";
            this.btnEliminarLimpiar.UseVisualStyleBackColor = true;
            this.btnEliminarLimpiar.Click += new System.EventHandler(this.btnEliminarLimpiar_Click);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(18, 49);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(35, 13);
            this.lblHotel.TabIndex = 373;
            this.lblHotel.Text = "label1";
            // 
            // VentanaEliminarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 493);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.btnEliminarLimpiar);
            this.Controls.Add(this.btnElminarGuardar);
            this.Controls.Add(this.btnAceptarFecha);
            this.Controls.Add(this.btnSeleccionarFechaIFin);
            this.Controls.Add(this.btnSeleccionarFechaInicio);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxFechaInicio);
            this.Controls.Add(this.tbxFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbxMotivo);
            this.Name = "VentanaEliminarHotel";
            this.Text = "Eliminar Hotel  - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaEliminarHotel_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.tbxMotivo, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblFechaInicio, 0);
            this.Controls.SetChildIndex(this.tbxFechaFin, 0);
            this.Controls.SetChildIndex(this.tbxFechaInicio, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.calendario, 0);
            this.Controls.SetChildIndex(this.btnSeleccionarFechaInicio, 0);
            this.Controls.SetChildIndex(this.btnSeleccionarFechaIFin, 0);
            this.Controls.SetChildIndex(this.btnAceptarFecha, 0);
            this.Controls.SetChildIndex(this.btnElminarGuardar, 0);
            this.Controls.SetChildIndex(this.btnEliminarLimpiar, 0);
            this.Controls.SetChildIndex(this.lblHotel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxFechaInicio;
        private System.Windows.Forms.TextBox tbxFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbxMotivo;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Button btnSeleccionarFechaInicio;
        private System.Windows.Forms.Button btnSeleccionarFechaIFin;
        private System.Windows.Forms.Button btnAceptarFecha;
        private System.Windows.Forms.Button btnElminarGuardar;
        private System.Windows.Forms.Button btnEliminarLimpiar;
        private System.Windows.Forms.Label lblHotel;
    }
}