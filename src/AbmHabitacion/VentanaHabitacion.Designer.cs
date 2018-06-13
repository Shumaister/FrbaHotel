namespace FrbaHotel.AbmHabitacion
{
    partial class VentanaHabitacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagAgregar = new System.Windows.Forms.TabPage();
            this.cbxTipoHabitaciones = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.cbxFrentes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxNumero = new System.Windows.Forms.TextBox();
            this.tbxPiso = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarGuardar = new System.Windows.Forms.Button();
            this.btnAgregarLimpiar = new System.Windows.Forms.Button();
            this.pagModificar = new System.Windows.Forms.TabPage();
            this.cbxModificarFiltroTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarLimpiar = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.btnModificarFiltrar = new System.Windows.Forms.Button();
            this.tbxModificarFiltroNumero = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvModificarHabitacion = new System.Windows.Forms.DataGridView();
            this.pagEliminar = new System.Windows.Forms.TabPage();
            this.cbxEliminarFiltroTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarLimpiar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnEliminarFiltrar = new System.Windows.Forms.Button();
            this.tbxElminarFiltroNumero = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgwEliminarHabitacion = new System.Windows.Forms.DataGridView();
            this.lblHotel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pagAgregar.SuspendLayout();
            this.pagModificar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarHabitacion)).BeginInit();
            this.pagEliminar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEliminarHabitacion)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(409, 384);
            this.logo.Size = new System.Drawing.Size(28, 30);
            this.logo.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pagAgregar);
            this.tabControl.Controls.Add(this.pagModificar);
            this.tabControl.Controls.Add(this.pagEliminar);
            this.tabControl.Location = new System.Drawing.Point(22, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(385, 433);
            this.tabControl.TabIndex = 5;
            // 
            // pagAgregar
            // 
            this.pagAgregar.Controls.Add(this.lblHotel);
            this.pagAgregar.Controls.Add(this.cbxTipoHabitaciones);
            this.pagAgregar.Controls.Add(this.label5);
            this.pagAgregar.Controls.Add(this.label6);
            this.pagAgregar.Controls.Add(this.tbxDescripcion);
            this.pagAgregar.Controls.Add(this.cbxFrentes);
            this.pagAgregar.Controls.Add(this.label9);
            this.pagAgregar.Controls.Add(this.label10);
            this.pagAgregar.Controls.Add(this.label32);
            this.pagAgregar.Controls.Add(this.label19);
            this.pagAgregar.Controls.Add(this.label20);
            this.pagAgregar.Controls.Add(this.label11);
            this.pagAgregar.Controls.Add(this.tbxNumero);
            this.pagAgregar.Controls.Add(this.tbxPiso);
            this.pagAgregar.Controls.Add(this.label8);
            this.pagAgregar.Controls.Add(this.label12);
            this.pagAgregar.Controls.Add(this.label7);
            this.pagAgregar.Controls.Add(this.btnAgregarGuardar);
            this.pagAgregar.Controls.Add(this.btnAgregarLimpiar);
            this.pagAgregar.Location = new System.Drawing.Point(4, 22);
            this.pagAgregar.Name = "pagAgregar";
            this.pagAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.pagAgregar.Size = new System.Drawing.Size(377, 407);
            this.pagAgregar.TabIndex = 0;
            this.pagAgregar.Text = "Agregar";
            this.pagAgregar.UseVisualStyleBackColor = true;
            // 
            // cbxTipoHabitaciones
            // 
            this.cbxTipoHabitaciones.FormattingEnabled = true;
            this.cbxTipoHabitaciones.Location = new System.Drawing.Point(161, 92);
            this.cbxTipoHabitaciones.Name = "cbxTipoHabitaciones";
            this.cbxTipoHabitaciones.Size = new System.Drawing.Size(147, 21);
            this.cbxTipoHabitaciones.TabIndex = 297;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(256, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 296;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 295;
            this.label6.Text = "Tipo de habitacion";
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Location = new System.Drawing.Point(29, 217);
            this.tbxDescripcion.Multiline = true;
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(306, 138);
            this.tbxDescripcion.TabIndex = 294;
            // 
            // cbxFrentes
            // 
            this.cbxFrentes.FormattingEnabled = true;
            this.cbxFrentes.Location = new System.Drawing.Point(161, 153);
            this.cbxFrentes.Name = "cbxFrentes";
            this.cbxFrentes.Size = new System.Drawing.Size(147, 21);
            this.cbxFrentes.TabIndex = 289;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(194, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 22);
            this.label9.TabIndex = 288;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 287;
            this.label10.Text = "Frente";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(26, 14);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(142, 16);
            this.label32.TabIndex = 284;
            this.label32.Text = "Datos de la habitacion";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(89, 187);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 22);
            this.label19.TabIndex = 281;
            this.label19.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 187);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 279;
            this.label20.Text = "Descripcion";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(53, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 22);
            this.label11.TabIndex = 275;
            this.label11.Text = "*";
            // 
            // tbxNumero
            // 
            this.tbxNumero.Location = new System.Drawing.Point(29, 92);
            this.tbxNumero.Name = "tbxNumero";
            this.tbxNumero.Size = new System.Drawing.Size(100, 20);
            this.tbxNumero.TabIndex = 269;
            this.tbxNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumero_KeyPress);
            // 
            // tbxPiso
            // 
            this.tbxPiso.Location = new System.Drawing.Point(29, 153);
            this.tbxPiso.Name = "tbxPiso";
            this.tbxPiso.Size = new System.Drawing.Size(100, 20);
            this.tbxPiso.TabIndex = 274;
            this.tbxPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPiso_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 268;
            this.label8.Text = "Numero";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 273;
            this.label12.Text = "Piso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(68, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 270;
            this.label7.Text = "*";
            // 
            // btnAgregarGuardar
            // 
            this.btnAgregarGuardar.Location = new System.Drawing.Point(211, 373);
            this.btnAgregarGuardar.Name = "btnAgregarGuardar";
            this.btnAgregarGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarGuardar.TabIndex = 204;
            this.btnAgregarGuardar.Text = "Guardar";
            this.btnAgregarGuardar.UseVisualStyleBackColor = true;
            this.btnAgregarGuardar.Click += new System.EventHandler(this.btnAgregarGuardar_Click);
            // 
            // btnAgregarLimpiar
            // 
            this.btnAgregarLimpiar.Location = new System.Drawing.Point(73, 373);
            this.btnAgregarLimpiar.Name = "btnAgregarLimpiar";
            this.btnAgregarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarLimpiar.TabIndex = 203;
            this.btnAgregarLimpiar.Text = "Limpiar";
            this.btnAgregarLimpiar.UseVisualStyleBackColor = true;
            this.btnAgregarLimpiar.Click += new System.EventHandler(this.btnAgregarLimpiar_Click);
            // 
            // pagModificar
            // 
            this.pagModificar.Controls.Add(this.cbxModificarFiltroTipo);
            this.pagModificar.Controls.Add(this.label4);
            this.pagModificar.Controls.Add(this.label1);
            this.pagModificar.Controls.Add(this.btnModificarLimpiar);
            this.pagModificar.Controls.Add(this.label37);
            this.pagModificar.Controls.Add(this.btnModificarFiltrar);
            this.pagModificar.Controls.Add(this.tbxModificarFiltroNumero);
            this.pagModificar.Controls.Add(this.groupBox3);
            this.pagModificar.Location = new System.Drawing.Point(4, 22);
            this.pagModificar.Name = "pagModificar";
            this.pagModificar.Padding = new System.Windows.Forms.Padding(3);
            this.pagModificar.Size = new System.Drawing.Size(377, 407);
            this.pagModificar.TabIndex = 1;
            this.pagModificar.Text = "Modificar";
            this.pagModificar.UseVisualStyleBackColor = true;
            // 
            // cbxModificarFiltroTipo
            // 
            this.cbxModificarFiltroTipo.FormattingEnabled = true;
            this.cbxModificarFiltroTipo.Location = new System.Drawing.Point(226, 47);
            this.cbxModificarFiltroTipo.Name = "cbxModificarFiltroTipo";
            this.cbxModificarFiltroTipo.Size = new System.Drawing.Size(127, 21);
            this.cbxModificarFiltroTipo.TabIndex = 303;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 301;
            this.label4.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 268;
            this.label1.Text = "Nombre";
            // 
            // btnModificarLimpiar
            // 
            this.btnModificarLimpiar.Location = new System.Drawing.Point(23, 92);
            this.btnModificarLimpiar.Name = "btnModificarLimpiar";
            this.btnModificarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnModificarLimpiar.TabIndex = 267;
            this.btnModificarLimpiar.Text = "Limpiar";
            this.btnModificarLimpiar.UseVisualStyleBackColor = true;
            this.btnModificarLimpiar.Click += new System.EventHandler(this.btnModificarLimpiar_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.DarkBlue;
            this.label37.Location = new System.Drawing.Point(20, 11);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(127, 16);
            this.label37.TabIndex = 266;
            this.label37.Text = "Filtros de busqueda";
            // 
            // btnModificarFiltrar
            // 
            this.btnModificarFiltrar.Location = new System.Drawing.Point(278, 94);
            this.btnModificarFiltrar.Name = "btnModificarFiltrar";
            this.btnModificarFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnModificarFiltrar.TabIndex = 8;
            this.btnModificarFiltrar.Text = "Filtrar";
            this.btnModificarFiltrar.UseVisualStyleBackColor = true;
            this.btnModificarFiltrar.Click += new System.EventHandler(this.btnModificarFiltrar_Click);
            // 
            // tbxModificarFiltroNumero
            // 
            this.tbxModificarFiltroNumero.Location = new System.Drawing.Point(70, 48);
            this.tbxModificarFiltroNumero.Name = "tbxModificarFiltroNumero";
            this.tbxModificarFiltroNumero.Size = new System.Drawing.Size(100, 20);
            this.tbxModificarFiltroNumero.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvModificarHabitacion);
            this.groupBox3.Location = new System.Drawing.Point(5, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 274);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Habitaciones";
            // 
            // dgvModificarHabitacion
            // 
            this.dgvModificarHabitacion.AllowUserToAddRows = false;
            this.dgvModificarHabitacion.AllowUserToDeleteRows = false;
            this.dgvModificarHabitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarHabitacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvModificarHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarHabitacion.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvModificarHabitacion.Location = new System.Drawing.Point(16, 29);
            this.dgvModificarHabitacion.Name = "dgvModificarHabitacion";
            this.dgvModificarHabitacion.RowHeadersVisible = false;
            this.dgvModificarHabitacion.Size = new System.Drawing.Size(332, 226);
            this.dgvModificarHabitacion.TabIndex = 0;
            // 
            // pagEliminar
            // 
            this.pagEliminar.Controls.Add(this.cbxEliminarFiltroTipo);
            this.pagEliminar.Controls.Add(this.label2);
            this.pagEliminar.Controls.Add(this.label3);
            this.pagEliminar.Controls.Add(this.btnEliminarLimpiar);
            this.pagEliminar.Controls.Add(this.label16);
            this.pagEliminar.Controls.Add(this.btnEliminarFiltrar);
            this.pagEliminar.Controls.Add(this.tbxElminarFiltroNumero);
            this.pagEliminar.Controls.Add(this.groupBox1);
            this.pagEliminar.Location = new System.Drawing.Point(4, 22);
            this.pagEliminar.Name = "pagEliminar";
            this.pagEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.pagEliminar.Size = new System.Drawing.Size(377, 407);
            this.pagEliminar.TabIndex = 2;
            this.pagEliminar.Text = "Eliminar";
            this.pagEliminar.UseVisualStyleBackColor = true;
            // 
            // cbxEliminarFiltroTipo
            // 
            this.cbxEliminarFiltroTipo.FormattingEnabled = true;
            this.cbxEliminarFiltroTipo.Location = new System.Drawing.Point(226, 47);
            this.cbxEliminarFiltroTipo.Name = "cbxEliminarFiltroTipo";
            this.cbxEliminarFiltroTipo.Size = new System.Drawing.Size(127, 21);
            this.cbxEliminarFiltroTipo.TabIndex = 311;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 309;
            this.label3.Text = "Nombre";
            // 
            // btnEliminarLimpiar
            // 
            this.btnEliminarLimpiar.Location = new System.Drawing.Point(23, 92);
            this.btnEliminarLimpiar.Name = "btnEliminarLimpiar";
            this.btnEliminarLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarLimpiar.TabIndex = 308;
            this.btnEliminarLimpiar.Text = "Limpiar";
            this.btnEliminarLimpiar.UseVisualStyleBackColor = true;
            this.btnEliminarLimpiar.Click += new System.EventHandler(this.btnEliminarLimpiar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkBlue;
            this.label16.Location = new System.Drawing.Point(20, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 16);
            this.label16.TabIndex = 307;
            this.label16.Text = "Filtros de busqueda";
            // 
            // btnEliminarFiltrar
            // 
            this.btnEliminarFiltrar.Location = new System.Drawing.Point(278, 94);
            this.btnEliminarFiltrar.Name = "btnEliminarFiltrar";
            this.btnEliminarFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFiltrar.TabIndex = 306;
            this.btnEliminarFiltrar.Text = "Filtrar";
            this.btnEliminarFiltrar.UseVisualStyleBackColor = true;
            this.btnEliminarFiltrar.Click += new System.EventHandler(this.btnEliminarFiltrar_Click);
            // 
            // tbxElminarFiltroNumero
            // 
            this.tbxElminarFiltroNumero.Location = new System.Drawing.Point(70, 48);
            this.tbxElminarFiltroNumero.Name = "tbxElminarFiltroNumero";
            this.tbxElminarFiltroNumero.Size = new System.Drawing.Size(100, 20);
            this.tbxElminarFiltroNumero.TabIndex = 305;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgwEliminarHabitacion);
            this.groupBox1.Location = new System.Drawing.Point(5, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 274);
            this.groupBox1.TabIndex = 304;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitaciones";
            // 
            // dgwEliminarHabitacion
            // 
            this.dgwEliminarHabitacion.AllowUserToAddRows = false;
            this.dgwEliminarHabitacion.AllowUserToDeleteRows = false;
            this.dgwEliminarHabitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwEliminarHabitacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgwEliminarHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwEliminarHabitacion.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgwEliminarHabitacion.Location = new System.Drawing.Point(16, 29);
            this.dgwEliminarHabitacion.Name = "dgwEliminarHabitacion";
            this.dgwEliminarHabitacion.RowHeadersVisible = false;
            this.dgwEliminarHabitacion.Size = new System.Drawing.Size(332, 226);
            this.dgwEliminarHabitacion.TabIndex = 0;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(26, 41);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(78, 13);
            this.lblHotel.TabIndex = 317;
            this.lblHotel.Text = "Hotel direccion";
            // 
            // VentanaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 466);
            this.Controls.Add(this.tabControl);
            this.Name = "VentanaHabitacion";
            this.Text = "Habitaciones - FRBA Hotel ©";
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pagAgregar.ResumeLayout(false);
            this.pagAgregar.PerformLayout();
            this.pagModificar.ResumeLayout(false);
            this.pagModificar.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarHabitacion)).EndInit();
            this.pagEliminar.ResumeLayout(false);
            this.pagEliminar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEliminarHabitacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagAgregar;
        private System.Windows.Forms.ComboBox cbxFrentes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxNumero;
        private System.Windows.Forms.TextBox tbxPiso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarGuardar;
        private System.Windows.Forms.Button btnAgregarLimpiar;
        private System.Windows.Forms.TabPage pagModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificarLimpiar;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnModificarFiltrar;
        private System.Windows.Forms.TextBox tbxModificarFiltroNumero;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvModificarHabitacion;
        private System.Windows.Forms.TabPage pagEliminar;
        private System.Windows.Forms.ComboBox cbxTipoHabitaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.ComboBox cbxModificarFiltroTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxEliminarFiltroTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarLimpiar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnEliminarFiltrar;
        private System.Windows.Forms.TextBox tbxElminarFiltroNumero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgwEliminarHabitacion;
        private System.Windows.Forms.Label lblHotel;
    }
}