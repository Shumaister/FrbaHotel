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
            this.calendarInicio = new System.Windows.Forms.MonthCalendar();
            this.tbxCantidadHuespedes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblErroHabitacionesHotel = new System.Windows.Forms.Label();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblpreciodiahab = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblcantidaddias = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblErrorPaso2 = new System.Windows.Forms.Label();
            this.lblrecargahotel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPrecioHab = new System.Windows.Forms.Label();
            this.lblTipoRegimen = new System.Windows.Forms.Label();
            this.lblCantHabi = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConfirmarPrecio = new System.Windows.Forms.Button();
            this.lblNumeroPrecioFinal = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxRegimenEstadiaObligatorio = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblcodreserva = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnClienteExistente = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnVolverPaso2 = new System.Windows.Forms.Button();
            this.btnConfirmarReserva = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(1053, 655);
            this.logo.Size = new System.Drawing.Size(10, 10);
            // 
            // calendarInicio
            // 
            this.calendarInicio.Location = new System.Drawing.Point(16, 308);
            this.calendarInicio.Name = "calendarInicio";
            this.calendarInicio.ShowToday = false;
            this.calendarInicio.TabIndex = 307;
            this.calendarInicio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendarInicio_DateChanged);
            // 
            // tbxCantidadHuespedes
            // 
            this.tbxCantidadHuespedes.Location = new System.Drawing.Point(261, 151);
            this.tbxCantidadHuespedes.MaxLength = 17;
            this.tbxCantidadHuespedes.Name = "tbxCantidadHuespedes";
            this.tbxCantidadHuespedes.Size = new System.Drawing.Size(124, 20);
            this.tbxCantidadHuespedes.TabIndex = 291;
            this.tbxCantidadHuespedes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidadHuespedes_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 154);
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
            this.label7.Location = new System.Drawing.Point(226, 154);
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
            this.groupBox1.Controls.Add(this.lblErroHabitacionesHotel);
            this.groupBox1.Controls.Add(this.cbxHoteles);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
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
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxCantidadHuespedes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 653);
            this.groupBox1.TabIndex = 310;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblErroHabitacionesHotel
            // 
            this.lblErroHabitacionesHotel.AutoSize = true;
            this.lblErroHabitacionesHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErroHabitacionesHotel.ForeColor = System.Drawing.Color.Red;
            this.lblErroHabitacionesHotel.Location = new System.Drawing.Point(40, 253);
            this.lblErroHabitacionesHotel.Name = "lblErroHabitacionesHotel";
            this.lblErroHabitacionesHotel.Size = new System.Drawing.Size(459, 13);
            this.lblErroHabitacionesHotel.TabIndex = 334;
            this.lblErroHabitacionesHotel.Text = "No se disponen de la cantidad de habitaciones necesarias para el hotel elegido";
            this.lblErroHabitacionesHotel.Visible = false;
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(261, 64);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(254, 21);
            this.cbxHoteles.TabIndex = 333;
            this.cbxHoteles.SelectedIndexChanged += new System.EventHandler(this.cbxHoteles_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 332;
            this.label12.Text = "Hotel";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(224, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 22);
            this.label13.TabIndex = 331;
            this.label13.Text = "*";
            // 
            // lblerrorcantidad
            // 
            this.lblerrorcantidad.AutoSize = true;
            this.lblerrorcantidad.ForeColor = System.Drawing.Color.Red;
            this.lblerrorcantidad.Location = new System.Drawing.Point(258, 176);
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
            this.lblerrorfechas.Location = new System.Drawing.Point(130, 488);
            this.lblerrorfechas.Name = "lblerrorfechas";
            this.lblerrorfechas.Size = new System.Drawing.Size(294, 13);
            this.lblerrorfechas.TabIndex = 328;
            this.lblerrorfechas.Text = "Verifique que la fecha de fin sea mayor que la fecha de inicio";
            this.lblerrorfechas.Visible = false;
            this.lblerrorfechas.Click += new System.EventHandler(this.lblerrorfechas_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 516);
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
            this.lblErrorPaso1.Location = new System.Drawing.Point(90, 565);
            this.lblErrorPaso1.Name = "lblErrorPaso1";
            this.lblErrorPaso1.Size = new System.Drawing.Size(344, 13);
            this.lblErrorPaso1.TabIndex = 326;
            this.lblErrorPaso1.Text = "Ya hay una reserva dentro de los dias que ha seleccionado";
            this.lblErrorPaso1.Visible = false;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(414, 286);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(10, 13);
            this.lblFechaFin.TabIndex = 325;
            this.lblFechaFin.Text = " ";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(163, 286);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(10, 13);
            this.lblFechaInicio.TabIndex = 324;
            this.lblFechaInicio.Text = " ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(6, 615);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(85, 28);
            this.btnLimpiar.TabIndex = 323;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCheckear
            // 
            this.btnCheckear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCheckear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheckear.Location = new System.Drawing.Point(427, 603);
            this.btnCheckear.Name = "btnCheckear";
            this.btnCheckear.Size = new System.Drawing.Size(108, 40);
            this.btnCheckear.TabIndex = 322;
            this.btnCheckear.Text = "Siguiente Paso!";
            this.btnCheckear.UseVisualStyleBackColor = false;
            this.btnCheckear.Click += new System.EventHandler(this.btnCheckear_Click);
            // 
            // lblResumenReserva
            // 
            this.lblResumenReserva.AutoSize = true;
            this.lblResumenReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenReserva.Location = new System.Drawing.Point(129, 516);
            this.lblResumenReserva.Name = "lblResumenReserva";
            this.lblResumenReserva.Size = new System.Drawing.Size(11, 16);
            this.lblResumenReserva.TabIndex = 321;
            this.lblResumenReserva.Text = " ";
            // 
            // cbxRegimenEstadia
            // 
            this.cbxRegimenEstadia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegimenEstadia.FormattingEnabled = true;
            this.cbxRegimenEstadia.Location = new System.Drawing.Point(261, 205);
            this.cbxRegimenEstadia.Name = "cbxRegimenEstadia";
            this.cbxRegimenEstadia.Size = new System.Drawing.Size(124, 21);
            this.cbxRegimenEstadia.TabIndex = 320;
            this.cbxRegimenEstadia.SelectedIndexChanged += new System.EventHandler(this.cbxRegimenEstadia_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 318;
            this.label11.Text = "Regimen de Estadia";
            // 
            // cbxTipoHabitacion
            // 
            this.cbxTipoHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoHabitacion.FormattingEnabled = true;
            this.cbxTipoHabitacion.Location = new System.Drawing.Point(261, 107);
            this.cbxTipoHabitacion.Name = "cbxTipoHabitacion";
            this.cbxTipoHabitacion.Size = new System.Drawing.Size(122, 21);
            this.cbxTipoHabitacion.TabIndex = 317;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(224, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 22);
            this.label6.TabIndex = 316;
            this.label6.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 110);
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
            this.label5.Location = new System.Drawing.Point(391, 286);
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
            this.label4.Location = new System.Drawing.Point(89, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 313;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 312;
            this.label3.Text = "Fecha de Finalizacion";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // calendarFin
            // 
            this.calendarFin.Location = new System.Drawing.Point(288, 308);
            this.calendarFin.Name = "calendarFin";
            this.calendarFin.ShowToday = false;
            this.calendarFin.TabIndex = 311;
            this.calendarFin.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Fecha de Inicio";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.lblpreciodiahab);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblcantidaddias);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblErrorPaso2);
            this.groupBox2.Controls.Add(this.lblrecargahotel);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lblPrecioHab);
            this.groupBox2.Controls.Add(this.lblTipoRegimen);
            this.groupBox2.Controls.Add(this.lblCantHabi);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnConfirmarPrecio);
            this.groupBox2.Controls.Add(this.lblNumeroPrecioFinal);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbxRegimenEstadiaObligatorio);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Location = new System.Drawing.Point(559, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 364);
            this.groupBox2.TabIndex = 335;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paso 2";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblpreciodiahab
            // 
            this.lblpreciodiahab.AutoSize = true;
            this.lblpreciodiahab.Location = new System.Drawing.Point(348, 236);
            this.lblpreciodiahab.Name = "lblpreciodiahab";
            this.lblpreciodiahab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblpreciodiahab.Size = new System.Drawing.Size(10, 13);
            this.lblpreciodiahab.TabIndex = 344;
            this.lblpreciodiahab.Text = "-";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(236, 236);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 13);
            this.label26.TabIndex = 343;
            this.label26.Text = "Precio por dia";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(348, 221);
            this.label25.Name = "label25";
            this.label25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label25.Size = new System.Drawing.Size(136, 13);
            this.label25.TabIndex = 342;
            this.label25.Text = "-------------------------------------------";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(179, 221);
            this.label23.Name = "label23";
            this.label23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label23.Size = new System.Drawing.Size(136, 13);
            this.label23.TabIndex = 341;
            this.label23.Text = "-------------------------------------------";
            // 
            // lblcantidaddias
            // 
            this.lblcantidaddias.AutoSize = true;
            this.lblcantidaddias.Location = new System.Drawing.Point(348, 272);
            this.lblcantidaddias.Name = "lblcantidaddias";
            this.lblcantidaddias.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblcantidaddias.Size = new System.Drawing.Size(10, 13);
            this.lblcantidaddias.TabIndex = 340;
            this.lblcantidaddias.Text = "-";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(222, 272);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 13);
            this.label24.TabIndex = 339;
            this.label24.Text = "Cantidad de dias";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(285, 107);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 16);
            this.label22.TabIndex = 338;
            this.label22.Text = "Resumen";
            // 
            // lblErrorPaso2
            // 
            this.lblErrorPaso2.AutoSize = true;
            this.lblErrorPaso2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPaso2.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPaso2.Location = new System.Drawing.Point(314, 62);
            this.lblErrorPaso2.Name = "lblErrorPaso2";
            this.lblErrorPaso2.Size = new System.Drawing.Size(243, 13);
            this.lblErrorPaso2.TabIndex = 337;
            this.lblErrorPaso2.Text = "Debe Seleccionar un Regimen de Estadia";
            this.lblErrorPaso2.Visible = false;
            // 
            // lblrecargahotel
            // 
            this.lblrecargahotel.AutoSize = true;
            this.lblrecargahotel.Location = new System.Drawing.Point(348, 185);
            this.lblrecargahotel.Name = "lblrecargahotel";
            this.lblrecargahotel.Size = new System.Drawing.Size(10, 13);
            this.lblrecargahotel.TabIndex = 336;
            this.lblrecargahotel.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(192, 185);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 13);
            this.label20.TabIndex = 335;
            this.label20.Text = "Recarga Estrellas hotel";
            // 
            // lblPrecioHab
            // 
            this.lblPrecioHab.AutoSize = true;
            this.lblPrecioHab.Location = new System.Drawing.Point(348, 138);
            this.lblPrecioHab.Name = "lblPrecioHab";
            this.lblPrecioHab.Size = new System.Drawing.Size(10, 13);
            this.lblPrecioHab.TabIndex = 334;
            this.lblPrecioHab.Text = "-";
            // 
            // lblTipoRegimen
            // 
            this.lblTipoRegimen.AutoSize = true;
            this.lblTipoRegimen.Location = new System.Drawing.Point(348, 208);
            this.lblTipoRegimen.Name = "lblTipoRegimen";
            this.lblTipoRegimen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTipoRegimen.Size = new System.Drawing.Size(10, 13);
            this.lblTipoRegimen.TabIndex = 333;
            this.lblTipoRegimen.Text = "-";
            // 
            // lblCantHabi
            // 
            this.lblCantHabi.AutoSize = true;
            this.lblCantHabi.Location = new System.Drawing.Point(348, 162);
            this.lblCantHabi.Name = "lblCantHabi";
            this.lblCantHabi.Size = new System.Drawing.Size(10, 13);
            this.lblCantHabi.TabIndex = 332;
            this.lblCantHabi.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(217, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 13);
            this.label19.TabIndex = 331;
            this.label19.Text = "Precio Habitacion";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(179, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 13);
            this.label18.TabIndex = 330;
            this.label18.Text = "Cantidad de Habitaciones";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(6, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 40);
            this.button1.TabIndex = 329;
            this.button1.Text = "Volver a Paso 1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirmarPrecio
            // 
            this.btnConfirmarPrecio.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirmarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPrecio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmarPrecio.Location = new System.Drawing.Point(516, 318);
            this.btnConfirmarPrecio.Name = "btnConfirmarPrecio";
            this.btnConfirmarPrecio.Size = new System.Drawing.Size(107, 40);
            this.btnConfirmarPrecio.TabIndex = 328;
            this.btnConfirmarPrecio.Text = "Siguiente Paso!";
            this.btnConfirmarPrecio.UseVisualStyleBackColor = false;
            this.btnConfirmarPrecio.Click += new System.EventHandler(this.btnConfirmarPrecio_Click);
            // 
            // lblNumeroPrecioFinal
            // 
            this.lblNumeroPrecioFinal.AutoSize = true;
            this.lblNumeroPrecioFinal.Location = new System.Drawing.Point(348, 295);
            this.lblNumeroPrecioFinal.Name = "lblNumeroPrecioFinal";
            this.lblNumeroPrecioFinal.Size = new System.Drawing.Size(10, 13);
            this.lblNumeroPrecioFinal.TabIndex = 327;
            this.lblNumeroPrecioFinal.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(226, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 326;
            this.label17.Text = "Precio Regimen";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(217, 293);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 16);
            this.label16.TabIndex = 324;
            this.label16.Text = "Precio Final";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(123, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 22);
            this.label15.TabIndex = 323;
            this.label15.Text = "*";
            // 
            // cbxRegimenEstadiaObligatorio
            // 
            this.cbxRegimenEstadiaObligatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegimenEstadiaObligatorio.FormattingEnabled = true;
            this.cbxRegimenEstadiaObligatorio.Location = new System.Drawing.Point(155, 59);
            this.cbxRegimenEstadiaObligatorio.Name = "cbxRegimenEstadiaObligatorio";
            this.cbxRegimenEstadiaObligatorio.Size = new System.Drawing.Size(153, 21);
            this.cbxRegimenEstadiaObligatorio.TabIndex = 322;
            this.cbxRegimenEstadiaObligatorio.SelectedIndexChanged += new System.EventHandler(this.cbxRegimenEstadiaObligatorio_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 321;
            this.label14.Text = "Regimen de Estadia";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DarkBlue;
            this.label31.Location = new System.Drawing.Point(249, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(159, 16);
            this.label31.TabIndex = 309;
            this.label31.Text = "Paso 2 - Confirmar Precio";
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.lblcodreserva);
            this.groupBox3.Controls.Add(this.lblCliente);
            this.groupBox3.Controls.Add(this.btnNuevo);
            this.groupBox3.Controls.Add(this.btnClienteExistente);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.btnVolverPaso2);
            this.groupBox3.Controls.Add(this.btnConfirmarReserva);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Location = new System.Drawing.Point(559, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 283);
            this.groupBox3.TabIndex = 338;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paso 3";
            // 
            // lblcodreserva
            // 
            this.lblcodreserva.AutoSize = true;
            this.lblcodreserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcodreserva.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblcodreserva.Location = new System.Drawing.Point(199, 247);
            this.lblcodreserva.Name = "lblcodreserva";
            this.lblcodreserva.Size = new System.Drawing.Size(13, 16);
            this.lblcodreserva.TabIndex = 334;
            this.lblcodreserva.Text = "-";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCliente.Location = new System.Drawing.Point(108, 194);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(13, 16);
            this.lblCliente.TabIndex = 333;
            this.lblCliente.Text = "-";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.Location = new System.Drawing.Point(317, 146);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(85, 28);
            this.btnNuevo.TabIndex = 332;
            this.btnNuevo.Text = "Soy nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnClienteExistente
            // 
            this.btnClienteExistente.BackColor = System.Drawing.SystemColors.Control;
            this.btnClienteExistente.Location = new System.Drawing.Point(317, 92);
            this.btnClienteExistente.Name = "btnClienteExistente";
            this.btnClienteExistente.Size = new System.Drawing.Size(85, 28);
            this.btnClienteExistente.TabIndex = 331;
            this.btnClienteExistente.Text = "Ya soy cliente";
            this.btnClienteExistente.UseVisualStyleBackColor = false;
            this.btnClienteExistente.Click += new System.EventHandler(this.btnClienteExistente_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(108, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(147, 13);
            this.label21.TabIndex = 330;
            this.label21.Text = "Ingrese sus datos personales:";
            // 
            // btnVolverPaso2
            // 
            this.btnVolverPaso2.BackColor = System.Drawing.Color.DarkRed;
            this.btnVolverPaso2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverPaso2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolverPaso2.Location = new System.Drawing.Point(6, 235);
            this.btnVolverPaso2.Name = "btnVolverPaso2";
            this.btnVolverPaso2.Size = new System.Drawing.Size(112, 40);
            this.btnVolverPaso2.TabIndex = 329;
            this.btnVolverPaso2.Text = "Volver a Paso 2";
            this.btnVolverPaso2.UseVisualStyleBackColor = false;
            this.btnVolverPaso2.Click += new System.EventHandler(this.btnVolverPaso2_Click);
            // 
            // btnConfirmarReserva
            // 
            this.btnConfirmarReserva.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarReserva.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmarReserva.Location = new System.Drawing.Point(516, 235);
            this.btnConfirmarReserva.Name = "btnConfirmarReserva";
            this.btnConfirmarReserva.Size = new System.Drawing.Size(107, 40);
            this.btnConfirmarReserva.TabIndex = 328;
            this.btnConfirmarReserva.Text = "Confirmar Reserva!";
            this.btnConfirmarReserva.UseVisualStyleBackColor = false;
            this.btnConfirmarReserva.Click += new System.EventHandler(this.btnConfirmarReserva_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.DarkBlue;
            this.label35.Location = new System.Drawing.Point(249, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(166, 16);
            this.label35.TabIndex = 309;
            this.label35.Text = "Paso 3 - Confirmar Estadia";
            // 
            // VentanaGenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 677);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentanaGenerarReserva";
            this.Text = "Generar Reserva - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaGenerarReserva_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.Label lblErroHabitacionesHotel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnConfirmarPrecio;
        private System.Windows.Forms.Label lblNumeroPrecioFinal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxRegimenEstadiaObligatorio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPrecioHab;
        private System.Windows.Forms.Label lblTipoRegimen;
        private System.Windows.Forms.Label lblCantHabi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblrecargahotel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblErrorPaso2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVolverPaso2;
        private System.Windows.Forms.Button btnConfirmarReserva;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnClienteExistente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblcodreserva;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblpreciodiahab;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblcantidaddias;
        private System.Windows.Forms.Label label24;
    }
}