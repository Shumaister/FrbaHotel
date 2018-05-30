namespace FrbaHotel.AbmUsuario
{
    partial class VentanaUsuarios
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagAgregar = new System.Windows.Forms.TabPage();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.btnLimpiarUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarFecha = new System.Windows.Forms.Button();
            this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxDireccion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxTelefono = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.tbxApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuitarHotel = new System.Windows.Forms.Button();
            this.btnAgregarHotel = new System.Windows.Forms.Button();
            this.lbxHoteles = new System.Windows.Forms.ListBox();
            this.lbxRoles = new System.Windows.Forms.ListBox();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxContrasena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pagModificar = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvModificarUsuarios = new System.Windows.Forms.DataGridView();
            this.pagEliminar = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvEliminarUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pagAgregar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pagModificar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarUsuarios)).BeginInit();
            this.pagEliminar.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(645, 531);
            this.logo.Size = new System.Drawing.Size(16, 19);
            this.logo.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pagAgregar);
            this.tabControl.Controls.Add(this.pagModificar);
            this.tabControl.Controls.Add(this.pagEliminar);
            this.tabControl.Location = new System.Drawing.Point(25, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(614, 579);
            this.tabControl.TabIndex = 1;
            // 
            // pagAgregar
            // 
            this.pagAgregar.Controls.Add(this.btnGuardarUsuario);
            this.pagAgregar.Controls.Add(this.btnLimpiarUsuario);
            this.pagAgregar.Controls.Add(this.groupBox2);
            this.pagAgregar.Controls.Add(this.groupBox1);
            this.pagAgregar.Location = new System.Drawing.Point(4, 22);
            this.pagAgregar.Name = "pagAgregar";
            this.pagAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.pagAgregar.Size = new System.Drawing.Size(606, 553);
            this.pagAgregar.TabIndex = 0;
            this.pagAgregar.Text = "Agregar";
            this.pagAgregar.UseVisualStyleBackColor = true;
            this.pagAgregar.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.Location = new System.Drawing.Point(362, 506);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarUsuario.TabIndex = 49;
            this.btnGuardarUsuario.Text = "Guardar";
            this.btnGuardarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarUsuario
            // 
            this.btnLimpiarUsuario.Location = new System.Drawing.Point(243, 506);
            this.btnLimpiarUsuario.Name = "btnLimpiarUsuario";
            this.btnLimpiarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarUsuario.TabIndex = 48;
            this.btnLimpiarUsuario.Text = "Limpiar";
            this.btnLimpiarUsuario.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSeleccionarFecha);
            this.groupBox2.Controls.Add(this.cbxTipoDocumento);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.tbxFechaNacimiento);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.tbxDireccion);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbxTelefono);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbxDocumento);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbxNombre);
            this.groupBox2.Controls.Add(this.tbxApellido);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbxEmail);
            this.groupBox2.Location = new System.Drawing.Point(308, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 276);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos personales";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnSeleccionarFecha
            // 
            this.btnSeleccionarFecha.Location = new System.Drawing.Point(21, 236);
            this.btnSeleccionarFecha.Name = "btnSeleccionarFecha";
            this.btnSeleccionarFecha.Size = new System.Drawing.Size(94, 23);
            this.btnSeleccionarFecha.TabIndex = 75;
            this.btnSeleccionarFecha.Text = "Seleccionar";
            this.btnSeleccionarFecha.UseVisualStyleBackColor = true;
            // 
            // cbxTipoDocumento
            // 
            this.cbxTipoDocumento.FormattingEnabled = true;
            this.cbxTipoDocumento.Location = new System.Drawing.Point(23, 98);
            this.cbxTipoDocumento.Name = "cbxTipoDocumento";
            this.cbxTipoDocumento.Size = new System.Drawing.Size(98, 21);
            this.cbxTipoDocumento.TabIndex = 74;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(109, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 22);
            this.label19.TabIndex = 70;
            this.label19.Text = "*";
            // 
            // tbxFechaNacimiento
            // 
            this.tbxFechaNacimiento.Location = new System.Drawing.Point(23, 203);
            this.tbxFechaNacimiento.Name = "tbxFechaNacimiento";
            this.tbxFechaNacimiento.Size = new System.Drawing.Size(100, 20);
            this.tbxFechaNacimiento.TabIndex = 69;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 182);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 68;
            this.label20.Text = "Fecha Nacimiento";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(193, 177);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 22);
            this.label21.TabIndex = 67;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(145, 179);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 65;
            this.label22.Text = "Direccion";
            // 
            // tbxDireccion
            // 
            this.tbxDireccion.Location = new System.Drawing.Point(148, 203);
            this.tbxDireccion.Name = "tbxDireccion";
            this.tbxDireccion.Size = new System.Drawing.Size(100, 20);
            this.tbxDireccion.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(193, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 22);
            this.label15.TabIndex = 64;
            this.label15.Text = "*";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(148, 151);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(100, 20);
            this.tbxTelefono.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(145, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Telefono";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(50, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 22);
            this.label17.TabIndex = 61;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 59;
            this.label18.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(225, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 22);
            this.label13.TabIndex = 58;
            this.label13.Text = "*";
            // 
            // tbxDocumento
            // 
            this.tbxDocumento.Location = new System.Drawing.Point(148, 98);
            this.tbxDocumento.Name = "tbxDocumento";
            this.tbxDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbxDocumento.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "N° Documento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(187, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 22);
            this.label11.TabIndex = 55;
            this.label11.Text = "*";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(21, 43);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(100, 20);
            this.tbxNombre.TabIndex = 48;
            // 
            // tbxApellido
            // 
            this.tbxApellido.Location = new System.Drawing.Point(148, 43);
            this.tbxApellido.Name = "tbxApellido";
            this.tbxApellido.Size = new System.Drawing.Size(100, 20);
            this.tbxApellido.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Nombre";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(60, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 49;
            this.label7.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(103, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 22);
            this.label9.TabIndex = 52;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Tipo Documento";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(21, 151);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(100, 20);
            this.tbxEmail.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuitarHotel);
            this.groupBox1.Controls.Add(this.btnAgregarHotel);
            this.groupBox1.Controls.Add(this.lbxHoteles);
            this.groupBox1.Controls.Add(this.lbxRoles);
            this.groupBox1.Controls.Add(this.cbxRoles);
            this.groupBox1.Controls.Add(this.btnQuitarRol);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAgregarRol);
            this.groupBox1.Controls.Add(this.cbxHoteles);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxContrasena);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 472);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del usuario";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnQuitarHotel
            // 
            this.btnQuitarHotel.Location = new System.Drawing.Point(162, 341);
            this.btnQuitarHotel.Name = "btnQuitarHotel";
            this.btnQuitarHotel.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarHotel.TabIndex = 77;
            this.btnQuitarHotel.Text = "Quitar";
            this.btnQuitarHotel.UseVisualStyleBackColor = true;
            // 
            // btnAgregarHotel
            // 
            this.btnAgregarHotel.Location = new System.Drawing.Point(162, 313);
            this.btnAgregarHotel.Name = "btnAgregarHotel";
            this.btnAgregarHotel.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarHotel.TabIndex = 76;
            this.btnAgregarHotel.Text = "Agregar";
            this.btnAgregarHotel.UseVisualStyleBackColor = true;
            // 
            // lbxHoteles
            // 
            this.lbxHoteles.FormattingEnabled = true;
            this.lbxHoteles.Location = new System.Drawing.Point(21, 357);
            this.lbxHoteles.Name = "lbxHoteles";
            this.lbxHoteles.Size = new System.Drawing.Size(120, 95);
            this.lbxHoteles.TabIndex = 75;
            // 
            // lbxRoles
            // 
            this.lbxRoles.FormattingEnabled = true;
            this.lbxRoles.Location = new System.Drawing.Point(21, 190);
            this.lbxRoles.Name = "lbxRoles";
            this.lbxRoles.Size = new System.Drawing.Size(120, 95);
            this.lbxRoles.TabIndex = 74;
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(21, 152);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(120, 21);
            this.cbxRoles.TabIndex = 44;
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.Location = new System.Drawing.Point(162, 180);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarRol.TabIndex = 53;
            this.btnQuitarRol.Text = "Quitar";
            this.btnQuitarRol.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(50, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 43;
            this.label5.Text = "*";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(162, 152);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarRol.TabIndex = 52;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(21, 320);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(120, 21);
            this.cbxHoteles.TabIndex = 73;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(58, 297);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 22);
            this.label23.TabIndex = 72;
            this.label23.Text = "*";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Roles";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(18, 297);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 71;
            this.label24.Text = "Hoteles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(81, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "*";
            // 
            // tbxContrasena
            // 
            this.tbxContrasena.Location = new System.Drawing.Point(21, 97);
            this.tbxContrasena.Name = "tbxContrasena";
            this.tbxContrasena.Size = new System.Drawing.Size(100, 20);
            this.tbxContrasena.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(60, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 38;
            this.label4.Text = "*";
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.Location = new System.Drawing.Point(21, 44);
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(100, 20);
            this.tbxUsuario.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Usuario";
            // 
            // pagModificar
            // 
            this.pagModificar.Controls.Add(this.groupBox3);
            this.pagModificar.Location = new System.Drawing.Point(4, 22);
            this.pagModificar.Name = "pagModificar";
            this.pagModificar.Padding = new System.Windows.Forms.Padding(3);
            this.pagModificar.Size = new System.Drawing.Size(606, 553);
            this.pagModificar.TabIndex = 1;
            this.pagModificar.Text = "Modificar";
            this.pagModificar.UseVisualStyleBackColor = true;
            this.pagModificar.Click += new System.EventHandler(this.pagModificar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvModificarUsuarios);
            this.groupBox3.Location = new System.Drawing.Point(11, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 519);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Usuarios";
            // 
            // dgvModificarUsuarios
            // 
            this.dgvModificarUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModificarUsuarios.Location = new System.Drawing.Point(9, 28);
            this.dgvModificarUsuarios.Name = "dgvModificarUsuarios";
            this.dgvModificarUsuarios.Size = new System.Drawing.Size(565, 471);
            this.dgvModificarUsuarios.TabIndex = 0;
            // 
            // pagEliminar
            // 
            this.pagEliminar.Controls.Add(this.groupBox4);
            this.pagEliminar.Location = new System.Drawing.Point(4, 22);
            this.pagEliminar.Name = "pagEliminar";
            this.pagEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.pagEliminar.Size = new System.Drawing.Size(606, 553);
            this.pagEliminar.TabIndex = 2;
            this.pagEliminar.Text = "Eliminar";
            this.pagEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvEliminarUsuarios);
            this.groupBox4.Location = new System.Drawing.Point(11, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(584, 519);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Usuarios";
            // 
            // dgvEliminarUsuarios
            // 
            this.dgvEliminarUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEliminarUsuarios.Location = new System.Drawing.Point(9, 28);
            this.dgvEliminarUsuarios.Name = "dgvEliminarUsuarios";
            this.dgvEliminarUsuarios.Size = new System.Drawing.Size(565, 471);
            this.dgvEliminarUsuarios.TabIndex = 0;
            // 
            // VentanaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 638);
            this.Controls.Add(this.tabControl);
            this.Name = "VentanaUsuarios";
            this.Text = "Usuarios - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaUsuarios_Load);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pagAgregar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pagModificar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarUsuarios)).EndInit();
            this.pagEliminar.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagAgregar;
        private System.Windows.Forms.TabPage pagModificar;
        private System.Windows.Forms.TabPage pagEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxTelefono;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxDocumento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.TextBox tbxApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxContrasena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxFechaNacimiento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbxDireccion;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.Button btnLimpiarUsuario;
        private System.Windows.Forms.ComboBox cbxTipoDocumento;
        private System.Windows.Forms.Button btnSeleccionarFecha;
        private System.Windows.Forms.Button btnQuitarHotel;
        private System.Windows.Forms.Button btnAgregarHotel;
        private System.Windows.Forms.ListBox lbxHoteles;
        private System.Windows.Forms.ListBox lbxRoles;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvModificarUsuarios;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvEliminarUsuarios;
    }
}