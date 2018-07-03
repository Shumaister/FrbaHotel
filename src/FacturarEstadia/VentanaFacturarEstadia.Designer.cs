namespace FrbaHotel.FacturarEstadia
{
    partial class VentanaFacturarEstadia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CodReservaL = new System.Windows.Forms.Label();
            this.tbxReserva = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvConsumibles = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMontoEstadiaDiasNoUtilizados = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMontoEstadiaDiasUtilizados = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDiasNoUtilizados = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblDiasUtilizados = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDescuentoRegimen = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.lblMontoTotalEstadia = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblMontoTotalConsumibles = new System.Windows.Forms.Label();
            this.lblCantidadHuespedes = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPrecioRegimen = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblPrecioHabitacion = new System.Windows.Forms.Label();
            this.lblMontoEstadiaDia = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblRecargaEstrellas = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblHotel = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFormasPagos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(755, 41);
            this.logo.Size = new System.Drawing.Size(21, 19);
            // 
            // CodReservaL
            // 
            this.CodReservaL.AutoSize = true;
            this.CodReservaL.Location = new System.Drawing.Point(24, 23);
            this.CodReservaL.Name = "CodReservaL";
            this.CodReservaL.Size = new System.Drawing.Size(101, 13);
            this.CodReservaL.TabIndex = 1;
            this.CodReservaL.Text = "Codigo de Reserva ";
            // 
            // tbxReserva
            // 
            this.tbxReserva.Location = new System.Drawing.Point(27, 50);
            this.tbxReserva.MaxLength = 18;
            this.tbxReserva.Name = "tbxReserva";
            this.tbxReserva.Size = new System.Drawing.Size(125, 20);
            this.tbxReserva.TabIndex = 2;
            this.tbxReserva.TextChanged += new System.EventHandler(this.tbxReserva_TextChanged);
            this.tbxReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReserva_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvConsumibles);
            this.groupBox1.Location = new System.Drawing.Point(18, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 230);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos consumidos";
            // 
            // dgvConsumibles
            // 
            this.dgvConsumibles.AllowUserToAddRows = false;
            this.dgvConsumibles.AllowUserToDeleteRows = false;
            this.dgvConsumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumibles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsumibles.Location = new System.Drawing.Point(18, 30);
            this.dgvConsumibles.Name = "dgvConsumibles";
            this.dgvConsumibles.ReadOnly = true;
            this.dgvConsumibles.RowHeadersVisible = false;
            this.dgvConsumibles.Size = new System.Drawing.Size(410, 182);
            this.dgvConsumibles.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(180, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.tbxBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Días utilizados:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 208);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 13);
            this.label23.TabIndex = 374;
            this.label23.Text = "Días no utilizados:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 13);
            this.label25.TabIndex = 375;
            this.label25.Text = "Hotel:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 52);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 13);
            this.label28.TabIndex = 376;
            this.label28.Text = "Regimen:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblMontoEstadiaDiasNoUtilizados);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblMontoEstadiaDiasUtilizados);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblDiasNoUtilizados);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblDiasUtilizados);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lblDescuentoRegimen);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lblMontoTotal);
            this.groupBox3.Controls.Add(this.lblMontoTotalEstadia);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblMontoTotalConsumibles);
            this.groupBox3.Controls.Add(this.lblCantidadHuespedes);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblPrecioRegimen);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.lblPrecioHabitacion);
            this.groupBox3.Controls.Add(this.lblMontoEstadiaDia);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.lblRecargaEstrellas);
            this.groupBox3.Location = new System.Drawing.Point(488, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 422);
            this.groupBox3.TabIndex = 377;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalles de Factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 346);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 400;
            this.label2.Text = "-";
            // 
            // lblMontoEstadiaDiasNoUtilizados
            // 
            this.lblMontoEstadiaDiasNoUtilizados.AutoSize = true;
            this.lblMontoEstadiaDiasNoUtilizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoEstadiaDiasNoUtilizados.Location = new System.Drawing.Point(265, 255);
            this.lblMontoEstadiaDiasNoUtilizados.Name = "lblMontoEstadiaDiasNoUtilizados";
            this.lblMontoEstadiaDiasNoUtilizados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontoEstadiaDiasNoUtilizados.Size = new System.Drawing.Size(11, 13);
            this.lblMontoEstadiaDiasNoUtilizados.TabIndex = 405;
            this.lblMontoEstadiaDiasNoUtilizados.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 13);
            this.label6.TabIndex = 404;
            this.label6.Text = "Monto estadia por dias no utilizados";
            // 
            // lblMontoEstadiaDiasUtilizados
            // 
            this.lblMontoEstadiaDiasUtilizados.AutoSize = true;
            this.lblMontoEstadiaDiasUtilizados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoEstadiaDiasUtilizados.Location = new System.Drawing.Point(265, 231);
            this.lblMontoEstadiaDiasUtilizados.Name = "lblMontoEstadiaDiasUtilizados";
            this.lblMontoEstadiaDiasUtilizados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontoEstadiaDiasUtilizados.Size = new System.Drawing.Size(11, 13);
            this.lblMontoEstadiaDiasUtilizados.TabIndex = 403;
            this.lblMontoEstadiaDiasUtilizados.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 402;
            this.label3.Text = "Monto estadia por dias utilizados";
            // 
            // lblDiasNoUtilizados
            // 
            this.lblDiasNoUtilizados.AutoSize = true;
            this.lblDiasNoUtilizados.Location = new System.Drawing.Point(265, 208);
            this.lblDiasNoUtilizados.Name = "lblDiasNoUtilizados";
            this.lblDiasNoUtilizados.Size = new System.Drawing.Size(10, 13);
            this.lblDiasNoUtilizados.TabIndex = 386;
            this.lblDiasNoUtilizados.Text = "-";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 369);
            this.label21.Name = "label21";
            this.label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label21.Size = new System.Drawing.Size(313, 13);
            this.label21.TabIndex = 401;
            this.label21.Text = "---------------------------------------------------------------------------------" +
    "---------------------";
            // 
            // lblDiasUtilizados
            // 
            this.lblDiasUtilizados.AutoSize = true;
            this.lblDiasUtilizados.Location = new System.Drawing.Point(265, 186);
            this.lblDiasUtilizados.Name = "lblDiasUtilizados";
            this.lblDiasUtilizados.Size = new System.Drawing.Size(10, 13);
            this.lblDiasUtilizados.TabIndex = 385;
            this.lblDiasUtilizados.Text = "-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(152, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 16);
            this.label22.TabIndex = 388;
            this.label22.Text = "RESUMEN";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 145);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label15.Size = new System.Drawing.Size(313, 13);
            this.label15.TabIndex = 400;
            this.label15.Text = "---------------------------------------------------------------------------------" +
    "---------------------";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(24, 389);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 16);
            this.label16.TabIndex = 378;
            this.label16.Text = "MONTO TOTAL";
            // 
            // lblDescuentoRegimen
            // 
            this.lblDescuentoRegimen.AutoSize = true;
            this.lblDescuentoRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoRegimen.Location = new System.Drawing.Point(267, 346);
            this.lblDescuentoRegimen.Name = "lblDescuentoRegimen";
            this.lblDescuentoRegimen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescuentoRegimen.Size = new System.Drawing.Size(11, 13);
            this.lblDescuentoRegimen.TabIndex = 399;
            this.lblDescuentoRegimen.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 379;
            this.label17.Text = "Precio regimen";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 347);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 398;
            this.label14.Text = "Descuento por Regimen";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(265, 389);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(13, 16);
            this.lblMontoTotal.TabIndex = 380;
            this.lblMontoTotal.Text = "-";
            // 
            // lblMontoTotalEstadia
            // 
            this.lblMontoTotalEstadia.AutoSize = true;
            this.lblMontoTotalEstadia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalEstadia.Location = new System.Drawing.Point(265, 298);
            this.lblMontoTotalEstadia.Name = "lblMontoTotalEstadia";
            this.lblMontoTotalEstadia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontoTotalEstadia.Size = new System.Drawing.Size(11, 13);
            this.lblMontoTotalEstadia.TabIndex = 397;
            this.lblMontoTotalEstadia.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 13);
            this.label18.TabIndex = 381;
            this.label18.Text = "Cantidad de huespedes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 396;
            this.label10.Text = "Monto total estadia";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 13);
            this.label19.TabIndex = 382;
            this.label19.Text = "Precio habitacion";
            // 
            // lblMontoTotalConsumibles
            // 
            this.lblMontoTotalConsumibles.AutoSize = true;
            this.lblMontoTotalConsumibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalConsumibles.Location = new System.Drawing.Point(265, 322);
            this.lblMontoTotalConsumibles.Name = "lblMontoTotalConsumibles";
            this.lblMontoTotalConsumibles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontoTotalConsumibles.Size = new System.Drawing.Size(11, 13);
            this.lblMontoTotalConsumibles.TabIndex = 395;
            this.lblMontoTotalConsumibles.Text = "-";
            // 
            // lblCantidadHuespedes
            // 
            this.lblCantidadHuespedes.AutoSize = true;
            this.lblCantidadHuespedes.Location = new System.Drawing.Point(265, 82);
            this.lblCantidadHuespedes.Name = "lblCantidadHuespedes";
            this.lblCantidadHuespedes.Size = new System.Drawing.Size(10, 13);
            this.lblCantidadHuespedes.TabIndex = 383;
            this.lblCantidadHuespedes.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 13);
            this.label12.TabIndex = 394;
            this.label12.Text = "Monto total consumibles";
            // 
            // lblPrecioRegimen
            // 
            this.lblPrecioRegimen.AutoSize = true;
            this.lblPrecioRegimen.Location = new System.Drawing.Point(265, 128);
            this.lblPrecioRegimen.Name = "lblPrecioRegimen";
            this.lblPrecioRegimen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrecioRegimen.Size = new System.Drawing.Size(10, 13);
            this.lblPrecioRegimen.TabIndex = 384;
            this.lblPrecioRegimen.Text = "-";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 276);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label27.Size = new System.Drawing.Size(313, 13);
            this.label27.TabIndex = 393;
            this.label27.Text = "---------------------------------------------------------------------------------" +
    "---------------------";
            // 
            // lblPrecioHabitacion
            // 
            this.lblPrecioHabitacion.AutoSize = true;
            this.lblPrecioHabitacion.Location = new System.Drawing.Point(265, 58);
            this.lblPrecioHabitacion.Name = "lblPrecioHabitacion";
            this.lblPrecioHabitacion.Size = new System.Drawing.Size(10, 13);
            this.lblPrecioHabitacion.TabIndex = 385;
            this.lblPrecioHabitacion.Text = "-";
            // 
            // lblMontoEstadiaDia
            // 
            this.lblMontoEstadiaDia.AutoSize = true;
            this.lblMontoEstadiaDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoEstadiaDia.Location = new System.Drawing.Point(265, 164);
            this.lblMontoEstadiaDia.Name = "lblMontoEstadiaDia";
            this.lblMontoEstadiaDia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontoEstadiaDia.Size = new System.Drawing.Size(11, 13);
            this.lblMontoEstadiaDia.TabIndex = 392;
            this.lblMontoEstadiaDia.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 105);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(115, 13);
            this.label20.TabIndex = 386;
            this.label20.Text = "Recarga estrellas hotel";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(24, 164);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(109, 13);
            this.label26.TabIndex = 391;
            this.label26.Text = "Monto estadia por dia";
            // 
            // lblRecargaEstrellas
            // 
            this.lblRecargaEstrellas.AutoSize = true;
            this.lblRecargaEstrellas.Location = new System.Drawing.Point(265, 105);
            this.lblRecargaEstrellas.Name = "lblRecargaEstrellas";
            this.lblRecargaEstrellas.Size = new System.Drawing.Size(10, 13);
            this.lblRecargaEstrellas.TabIndex = 387;
            this.lblRecargaEstrellas.Text = "-";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRegimen);
            this.groupBox2.Controls.Add(this.lblHotel);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Location = new System.Drawing.Point(18, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 85);
            this.groupBox2.TabIndex = 378;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Estadia";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(69, 52);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(10, 13);
            this.lblRegimen.TabIndex = 384;
            this.lblRegimen.Text = "-";
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(52, 26);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(10, 13);
            this.lblHotel.TabIndex = 383;
            this.lblHotel.Text = "-";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(264, 463);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 27);
            this.btnPagar.TabIndex = 383;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 384;
            this.label1.Text = "Forma de Pago";
            // 
            // cbxFormasPagos
            // 
            this.cbxFormasPagos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormasPagos.FormattingEnabled = true;
            this.cbxFormasPagos.Items.AddRange(new object[] {
            "Tarjeta",
            "Efectivo"});
            this.cbxFormasPagos.Location = new System.Drawing.Point(90, 469);
            this.cbxFormasPagos.Name = "cbxFormasPagos";
            this.cbxFormasPagos.Size = new System.Drawing.Size(131, 21);
            this.cbxFormasPagos.TabIndex = 385;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(121, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 22);
            this.label8.TabIndex = 389;
            this.label8.Text = "*";
            // 
            // VentanaFacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 541);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFormasPagos);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxReserva);
            this.Controls.Add(this.CodReservaL);
            this.Name = "VentanaFacturarEstadia";
            this.Text = "Facturas - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaFacturarEstadia_Load);
            this.Controls.SetChildIndex(this.CodReservaL, 0);
            this.Controls.SetChildIndex(this.tbxReserva, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnPagar, 0);
            this.Controls.SetChildIndex(this.cbxFormasPagos, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CodReservaL;
        private System.Windows.Forms.TextBox tbxReserva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDescuentoRegimen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblMontoTotalEstadia;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblMontoTotalConsumibles;
        private System.Windows.Forms.Label lblCantidadHuespedes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblPrecioRegimen;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblPrecioHabitacion;
        private System.Windows.Forms.Label lblMontoEstadiaDia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblRecargaEstrellas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFormasPagos;
        private System.Windows.Forms.Label lblDiasNoUtilizados;
        private System.Windows.Forms.Label lblDiasUtilizados;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Label lblMontoEstadiaDiasNoUtilizados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMontoEstadiaDiasUtilizados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvConsumibles;
    }
}