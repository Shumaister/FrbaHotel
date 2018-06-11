namespace FrbaHotel.GenerarModificacionReserva
{
    partial class VentanaGenerarReserva
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
            this.btnConfirmarPaso1 = new System.Windows.Forms.Button();
            this.calendarInicio = new System.Windows.Forms.MonthCalendar();
            this.tbxCantidadHuespedes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblerrorcantidad = new System.Windows.Forms.Label();
            this.lblerrorfechas = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblErrorPaso1 = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCheckear = new System.Windows.Forms.Button();
            this.lblResumenReserva = new System.Windows.Forms.Label();
            this.cbxRegimenEstadia = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calendarFin = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(1011, 527);
            this.logo.Size = new System.Drawing.Size(10, 10);
            // 
            // btnConfirmarPaso1
            // 
            this.btnConfirmarPaso1.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmarPaso1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarPaso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPaso1.Location = new System.Drawing.Point(372, 503);
            this.btnConfirmarPaso1.Name = "btnConfirmarPaso1";
            this.btnConfirmarPaso1.Size = new System.Drawing.Size(114, 40);
            this.btnConfirmarPaso1.TabIndex = 308;
            this.btnConfirmarPaso1.Text = "Confirmar Datos!";
            this.btnConfirmarPaso1.UseVisualStyleBackColor = false;
            this.btnConfirmarPaso1.Click += new System.EventHandler(this.btnGuardarFecha_Click);
            // 
            // calendarInicio
            // 
            this.calendarInicio.Location = new System.Drawing.Point(14, 170);
            this.calendarInicio.Name = "calendarInicio";
            this.calendarInicio.TabIndex = 307;
            this.calendarInicio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendarInicio_DateChanged);
            // 
            // tbxCantidadHuespedes
            // 
            this.tbxCantidadHuespedes.Location = new System.Drawing.Point(143, 63);
            this.tbxCantidadHuespedes.MaxLength = 100;
            this.tbxCantidadHuespedes.Name = "tbxCantidadHuespedes";
            this.tbxCantidadHuespedes.Size = new System.Drawing.Size(98, 20);
            this.tbxCantidadHuespedes.TabIndex = 291;
            this.tbxCantidadHuespedes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidadHuespedes_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 290;
            this.label8.Text = "Cantidad Huespedes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(120, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 292;
            this.label7.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(169, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 309;
            this.label1.Text = "Paso 1 - Completar datos";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.lblerrorcantidad);
            this.groupBox1.Controls.Add(this.lblerrorfechas);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblErrorPaso1);
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnCheckear);
            this.groupBox1.Controls.Add(this.lblResumenReserva);
            this.groupBox1.Controls.Add(this.cbxRegimenEstadia);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbxTipoHabitacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.calendarFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.calendarInicio);
            this.groupBox1.Controls.Add(this.btnConfirmarPaso1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxCantidadHuespedes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 549);
            this.groupBox1.TabIndex = 310;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblerrorcantidad
            // 
            this.lblerrorcantidad.AutoSize = true;
            this.lblerrorcantidad.ForeColor = System.Drawing.Color.Red;
            this.lblerrorcantidad.Location = new System.Drawing.Point(266, 66);
            this.lblerrorcantidad.Name = "lblerrorcantidad";
            this.lblerrorcantidad.Size = new System.Drawing.Size(209, 13);
            this.lblerrorcantidad.TabIndex = 329;
            this.lblerrorcantidad.Text = "La cantidad debe ser un numero mayor a 0";
            this.lblerrorcantidad.Visible = false;
            // 
            // lblerrorfechas
            // 
            this.lblerrorfechas.AutoSize = true;
            this.lblerrorfechas.ForeColor = System.Drawing.Color.Red;
            this.lblerrorfechas.Location = new System.Drawing.Point(112, 350);
            this.lblerrorfechas.Name = "lblerrorfechas";
            this.lblerrorfechas.Size = new System.Drawing.Size(294, 13);
            this.lblerrorfechas.TabIndex = 328;
            this.lblerrorfechas.Text = "Verifique que la fecha de fin sea mayor que la fecha de inicio";
            this.lblerrorfechas.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 422);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 327;
            this.label10.Text = "Su reserva es: ";
            // 
            // lblErrorPaso1
            // 
            this.lblErrorPaso1.AutoSize = true;
            this.lblErrorPaso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPaso1.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPaso1.Location = new System.Drawing.Point(88, 455);
            this.lblErrorPaso1.Name = "lblErrorPaso1";
            this.lblErrorPaso1.Size = new System.Drawing.Size(344, 13);
            this.lblErrorPaso1.TabIndex = 326;
            this.lblErrorPaso1.Text = "Ya hay una reserva dentro de los dias que ha seleccionado";
            this.lblErrorPaso1.Visible = false;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(396, 148);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(10, 13);
            this.lblFechaFin.TabIndex = 325;
            this.lblFechaFin.Text = " ";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(161, 148);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(10, 13);
            this.lblFechaInicio.TabIndex = 324;
            this.lblFechaInicio.Text = " ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(6, 515);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(85, 28);
            this.btnLimpiar.TabIndex = 323;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCheckear
            // 
            this.btnCheckear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCheckear.Location = new System.Drawing.Point(269, 503);
            this.btnCheckear.Name = "btnCheckear";
            this.btnCheckear.Size = new System.Drawing.Size(97, 40);
            this.btnCheckear.TabIndex = 322;
            this.btnCheckear.Text = "Checkear";
            this.btnCheckear.UseVisualStyleBackColor = false;
            this.btnCheckear.Click += new System.EventHandler(this.btnCheckear_Click);
            // 
            // lblResumenReserva
            // 
            this.lblResumenReserva.AutoSize = true;
            this.lblResumenReserva.Location = new System.Drawing.Point(127, 422);
            this.lblResumenReserva.Name = "lblResumenReserva";
            this.lblResumenReserva.Size = new System.Drawing.Size(10, 13);
            this.lblResumenReserva.TabIndex = 321;
            this.lblResumenReserva.Text = " ";
            // 
            // cbxRegimenEstadia
            // 
            this.cbxRegimenEstadia.FormattingEnabled = true;
            this.cbxRegimenEstadia.Location = new System.Drawing.Point(141, 376);
            this.cbxRegimenEstadia.Name = "cbxRegimenEstadia";
            this.cbxRegimenEstadia.Size = new System.Drawing.Size(98, 21);
            this.cbxRegimenEstadia.TabIndex = 320;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 318;
            this.label11.Text = "Regimen de Estadia";
            // 
            // cbxTipoHabitacion
            // 
            this.cbxTipoHabitacion.FormattingEnabled = true;
            this.cbxTipoHabitacion.Location = new System.Drawing.Point(143, 104);
            this.cbxTipoHabitacion.Name = "cbxTipoHabitacion";
            this.cbxTipoHabitacion.Size = new System.Drawing.Size(98, 21);
            this.cbxTipoHabitacion.TabIndex = 317;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(111, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 22);
            this.label6.TabIndex = 316;
            this.label6.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 315;
            this.label9.Text = "Tipo de Habitacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(362, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 314;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(87, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 313;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 312;
            this.label3.Text = "Fecha de Finalizacion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // calendarFin
            // 
            this.calendarFin.Location = new System.Drawing.Point(259, 170);
            this.calendarFin.Name = "calendarFin";
            this.calendarFin.TabIndex = 311;
            this.calendarFin.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Fecha de Inicio";
            // 
            // VentanaGenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 573);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentanaGenerarReserva";
            this.Text = "VentanaGenerarReserva";
            this.Load += new System.EventHandler(this.VentanaGenerarReserva_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmarPaso1;
        private System.Windows.Forms.MonthCalendar calendarInicio;
        private System.Windows.Forms.TextBox tbxCantidadHuespedes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar calendarFin;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCheckear;
        private System.Windows.Forms.Label lblResumenReserva;
        private System.Windows.Forms.ComboBox cbxRegimenEstadia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxTipoHabitacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblErrorPaso1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblerrorfechas;
        private System.Windows.Forms.Label lblerrorcantidad;
    }
}