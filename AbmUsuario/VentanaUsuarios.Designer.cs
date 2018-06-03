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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagAgregar = new System.Windows.Forms.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tbxDepartamento = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tbxPiso = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.lblNumeroCalle = new System.Windows.Forms.Label();
            this.tbxNumeroCalle = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tbxCalle = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbxCiudad = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
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
            this.btnSeleccionarFecha = new System.Windows.Forms.Button();
            this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxPais = new System.Windows.Forms.TextBox();
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
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.btnLimpiarUsuario = new System.Windows.Forms.Button();
            this.pagModificar = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvModificarUsuarios = new System.Windows.Forms.DataGridView();
            this.pagEliminar = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEliminarUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pagAgregar.SuspendLayout();
            this.pagModificar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarUsuarios)).BeginInit();
            this.pagEliminar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(848, 552);
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
            this.tabControl.Size = new System.Drawing.Size(821, 601);
            this.tabControl.TabIndex = 1;
            // 
            // pagAgregar
            // 
            this.pagAgregar.Controls.Add(this.label37);
            this.pagAgregar.Controls.Add(this.label36);
            this.pagAgregar.Controls.Add(this.label34);
            this.pagAgregar.Controls.Add(this.label32);
            this.pagAgregar.Controls.Add(this.label33);
            this.pagAgregar.Controls.Add(this.tbxDepartamento);
            this.pagAgregar.Controls.Add(this.label35);
            this.pagAgregar.Controls.Add(this.tbxPiso);
            this.pagAgregar.Controls.Add(this.label28);
            this.pagAgregar.Controls.Add(this.lblNumeroCalle);
            this.pagAgregar.Controls.Add(this.tbxNumeroCalle);
            this.pagAgregar.Controls.Add(this.label30);
            this.pagAgregar.Controls.Add(this.label31);
            this.pagAgregar.Controls.Add(this.tbxCalle);
            this.pagAgregar.Controls.Add(this.label26);
            this.pagAgregar.Controls.Add(this.label27);
            this.pagAgregar.Controls.Add(this.tbxCiudad);
            this.pagAgregar.Controls.Add(this.label25);
            this.pagAgregar.Controls.Add(this.btnQuitarHotel);
            this.pagAgregar.Controls.Add(this.btnAgregarHotel);
            this.pagAgregar.Controls.Add(this.lbxHoteles);
            this.pagAgregar.Controls.Add(this.lbxRoles);
            this.pagAgregar.Controls.Add(this.cbxRoles);
            this.pagAgregar.Controls.Add(this.btnQuitarRol);
            this.pagAgregar.Controls.Add(this.label5);
            this.pagAgregar.Controls.Add(this.btnAgregarRol);
            this.pagAgregar.Controls.Add(this.cbxHoteles);
            this.pagAgregar.Controls.Add(this.label23);
            this.pagAgregar.Controls.Add(this.label6);
            this.pagAgregar.Controls.Add(this.label24);
            this.pagAgregar.Controls.Add(this.label2);
            this.pagAgregar.Controls.Add(this.tbxContrasena);
            this.pagAgregar.Controls.Add(this.label3);
            this.pagAgregar.Controls.Add(this.label4);
            this.pagAgregar.Controls.Add(this.tbxUsuario);
            this.pagAgregar.Controls.Add(this.label1);
            this.pagAgregar.Controls.Add(this.btnSeleccionarFecha);
            this.pagAgregar.Controls.Add(this.cbxTipoDocumento);
            this.pagAgregar.Controls.Add(this.label19);
            this.pagAgregar.Controls.Add(this.tbxFechaNacimiento);
            this.pagAgregar.Controls.Add(this.label20);
            this.pagAgregar.Controls.Add(this.label21);
            this.pagAgregar.Controls.Add(this.label22);
            this.pagAgregar.Controls.Add(this.tbxPais);
            this.pagAgregar.Controls.Add(this.label15);
            this.pagAgregar.Controls.Add(this.tbxTelefono);
            this.pagAgregar.Controls.Add(this.label16);
            this.pagAgregar.Controls.Add(this.label17);
            this.pagAgregar.Controls.Add(this.label18);
            this.pagAgregar.Controls.Add(this.label13);
            this.pagAgregar.Controls.Add(this.tbxDocumento);
            this.pagAgregar.Controls.Add(this.label14);
            this.pagAgregar.Controls.Add(this.label11);
            this.pagAgregar.Controls.Add(this.tbxNombre);
            this.pagAgregar.Controls.Add(this.tbxApellido);
            this.pagAgregar.Controls.Add(this.label8);
            this.pagAgregar.Controls.Add(this.label12);
            this.pagAgregar.Controls.Add(this.label7);
            this.pagAgregar.Controls.Add(this.label9);
            this.pagAgregar.Controls.Add(this.label10);
            this.pagAgregar.Controls.Add(this.tbxEmail);
            this.pagAgregar.Controls.Add(this.btnGuardarUsuario);
            this.pagAgregar.Controls.Add(this.btnLimpiarUsuario);
            this.pagAgregar.Location = new System.Drawing.Point(4, 22);
            this.pagAgregar.Name = "pagAgregar";
            this.pagAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.pagAgregar.Size = new System.Drawing.Size(813, 575);
            this.pagAgregar.TabIndex = 0;
            this.pagAgregar.Text = "Agregar";
            this.pagAgregar.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.DarkBlue;
            this.label37.Location = new System.Drawing.Point(31, 17);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(50, 16);
            this.label37.TabIndex = 137;
            this.label37.Text = "Cuenta";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.DarkBlue;
            this.label36.Location = new System.Drawing.Point(470, 433);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(61, 16);
            this.label36.TabIndex = 136;
            this.label36.Text = "Contacto";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.DarkBlue;
            this.label34.Location = new System.Drawing.Point(468, 225);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 16);
            this.label34.TabIndex = 135;
            this.label34.Text = "Domicilio";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(468, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(115, 16);
            this.label32.TabIndex = 134;
            this.label32.Text = "Datos personales";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(658, 374);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 13);
            this.label33.TabIndex = 132;
            this.label33.Text = "Departamento";
            // 
            // tbxDepartamento
            // 
            this.tbxDepartamento.Location = new System.Drawing.Point(661, 398);
            this.tbxDepartamento.MaxLength = 1;
            this.tbxDepartamento.Name = "tbxDepartamento";
            this.tbxDepartamento.ShortcutsEnabled = false;
            this.tbxDepartamento.Size = new System.Drawing.Size(100, 20);
            this.tbxDepartamento.TabIndex = 133;
            this.tbxDepartamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDepartamento_KeyPress);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(468, 374);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(27, 13);
            this.label35.TabIndex = 129;
            this.label35.Text = "Piso";
            // 
            // tbxPiso
            // 
            this.tbxPiso.Location = new System.Drawing.Point(471, 398);
            this.tbxPiso.Name = "tbxPiso";
            this.tbxPiso.ShortcutsEnabled = false;
            this.tbxPiso.Size = new System.Drawing.Size(100, 20);
            this.tbxPiso.TabIndex = 130;
            this.tbxPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPiso_KeyPress);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(695, 313);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 22);
            this.label28.TabIndex = 128;
            this.label28.Text = "*";
            // 
            // lblNumeroCalle
            // 
            this.lblNumeroCalle.AutoSize = true;
            this.lblNumeroCalle.Location = new System.Drawing.Point(658, 314);
            this.lblNumeroCalle.Name = "lblNumeroCalle";
            this.lblNumeroCalle.Size = new System.Drawing.Size(34, 13);
            this.lblNumeroCalle.TabIndex = 126;
            this.lblNumeroCalle.Text = "Altura";
            // 
            // tbxNumeroCalle
            // 
            this.tbxNumeroCalle.Location = new System.Drawing.Point(661, 338);
            this.tbxNumeroCalle.Name = "tbxNumeroCalle";
            this.tbxNumeroCalle.Size = new System.Drawing.Size(100, 20);
            this.tbxNumeroCalle.TabIndex = 127;
            this.tbxNumeroCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumeroCalle_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(498, 313);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 22);
            this.label30.TabIndex = 125;
            this.label30.Text = "*";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(468, 314);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 13);
            this.label31.TabIndex = 123;
            this.label31.Text = "Calle";
            // 
            // tbxCalle
            // 
            this.tbxCalle.Location = new System.Drawing.Point(471, 338);
            this.tbxCalle.Name = "tbxCalle";
            this.tbxCalle.Size = new System.Drawing.Size(100, 20);
            this.tbxCalle.TabIndex = 124;
            this.tbxCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCalle_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(697, 248);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 22);
            this.label26.TabIndex = 122;
            this.label26.Text = "*";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(658, 250);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 120;
            this.label27.Text = "Ciudad";
            // 
            // tbxCiudad
            // 
            this.tbxCiudad.Location = new System.Drawing.Point(661, 274);
            this.tbxCiudad.Name = "tbxCiudad";
            this.tbxCiudad.Size = new System.Drawing.Size(100, 20);
            this.tbxCiudad.TabIndex = 121;
            this.tbxCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCiudad_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(585, 482);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 119;
            this.label25.Text = "@gmail.com";
            // 
            // btnQuitarHotel
            // 
            this.btnQuitarHotel.Location = new System.Drawing.Point(335, 368);
            this.btnQuitarHotel.Name = "btnQuitarHotel";
            this.btnQuitarHotel.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarHotel.TabIndex = 118;
            this.btnQuitarHotel.Text = "Quitar";
            this.btnQuitarHotel.UseVisualStyleBackColor = true;
            this.btnQuitarHotel.Click += new System.EventHandler(this.btnQuitarHotel_Click);
            // 
            // btnAgregarHotel
            // 
            this.btnAgregarHotel.Location = new System.Drawing.Point(335, 340);
            this.btnAgregarHotel.Name = "btnAgregarHotel";
            this.btnAgregarHotel.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarHotel.TabIndex = 117;
            this.btnAgregarHotel.Text = "Agregar";
            this.btnAgregarHotel.UseVisualStyleBackColor = true;
            this.btnAgregarHotel.Click += new System.EventHandler(this.btnAgregarHotel_Click);
            // 
            // lbxHoteles
            // 
            this.lbxHoteles.FormattingEnabled = true;
            this.lbxHoteles.Location = new System.Drawing.Point(34, 379);
            this.lbxHoteles.Name = "lbxHoteles";
            this.lbxHoteles.Size = new System.Drawing.Size(282, 95);
            this.lbxHoteles.TabIndex = 116;
            // 
            // lbxRoles
            // 
            this.lbxRoles.FormattingEnabled = true;
            this.lbxRoles.Location = new System.Drawing.Point(34, 212);
            this.lbxRoles.Name = "lbxRoles";
            this.lbxRoles.Size = new System.Drawing.Size(120, 95);
            this.lbxRoles.TabIndex = 115;
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(34, 174);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(120, 21);
            this.cbxRoles.TabIndex = 109;
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.Location = new System.Drawing.Point(171, 200);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarRol.TabIndex = 111;
            this.btnQuitarRol.Text = "Quitar";
            this.btnQuitarRol.UseVisualStyleBackColor = true;
            this.btnQuitarRol.Click += new System.EventHandler(this.btnQuitarRol_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(63, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 108;
            this.label5.Text = "*";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(171, 172);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarRol.TabIndex = 110;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(34, 342);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(282, 21);
            this.cbxHoteles.TabIndex = 114;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(71, 319);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 22);
            this.label23.TabIndex = 113;
            this.label23.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "Roles";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(31, 319);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 112;
            this.label24.Text = "Hoteles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(94, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 22);
            this.label2.TabIndex = 106;
            this.label2.Text = "*";
            // 
            // tbxContrasena
            // 
            this.tbxContrasena.Location = new System.Drawing.Point(34, 119);
            this.tbxContrasena.Name = "tbxContrasena";
            this.tbxContrasena.Size = new System.Drawing.Size(100, 20);
            this.tbxContrasena.TabIndex = 105;
            this.tbxContrasena.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(73, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 103;
            this.label4.Text = "*";
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.Location = new System.Drawing.Point(34, 66);
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(100, 20);
            this.tbxUsuario.TabIndex = 102;
            this.tbxUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsuario_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Usuario";
            // 
            // btnSeleccionarFecha
            // 
            this.btnSeleccionarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFecha.Location = new System.Drawing.Point(596, 190);
            this.btnSeleccionarFecha.Name = "btnSeleccionarFecha";
            this.btnSeleccionarFecha.Size = new System.Drawing.Size(36, 23);
            this.btnSeleccionarFecha.TabIndex = 100;
            this.btnSeleccionarFecha.Text = "...";
            this.btnSeleccionarFecha.UseVisualStyleBackColor = true;
            // 
            // cbxTipoDocumento
            // 
            this.cbxTipoDocumento.FormattingEnabled = true;
            this.cbxTipoDocumento.Location = new System.Drawing.Point(471, 130);
            this.cbxTipoDocumento.Name = "cbxTipoDocumento";
            this.cbxTipoDocumento.Size = new System.Drawing.Size(100, 21);
            this.cbxTipoDocumento.TabIndex = 99;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(560, 165);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 22);
            this.label19.TabIndex = 98;
            this.label19.Text = "*";
            // 
            // tbxFechaNacimiento
            // 
            this.tbxFechaNacimiento.Location = new System.Drawing.Point(473, 190);
            this.tbxFechaNacimiento.Name = "tbxFechaNacimiento";
            this.tbxFechaNacimiento.Size = new System.Drawing.Size(100, 20);
            this.tbxFechaNacimiento.TabIndex = 97;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(470, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 96;
            this.label20.Text = "Fecha Nacimiento";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(495, 251);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 22);
            this.label21.TabIndex = 95;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(468, 250);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 13);
            this.label22.TabIndex = 93;
            this.label22.Text = "Pais";
            // 
            // tbxPais
            // 
            this.tbxPais.Location = new System.Drawing.Point(471, 274);
            this.tbxPais.Name = "tbxPais";
            this.tbxPais.Size = new System.Drawing.Size(100, 20);
            this.tbxPais.TabIndex = 94;
            this.tbxPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPais_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(712, 457);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 22);
            this.label15.TabIndex = 92;
            this.label15.Text = "*";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(661, 479);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(100, 20);
            this.tbxTelefono.TabIndex = 91;
            this.tbxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxTelefono_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(664, 460);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 90;
            this.label16.Text = "Telefono";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(502, 457);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 22);
            this.label17.TabIndex = 89;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(470, 458);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 88;
            this.label18.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(738, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 22);
            this.label13.TabIndex = 87;
            this.label13.Text = "*";
            // 
            // tbxDocumento
            // 
            this.tbxDocumento.Location = new System.Drawing.Point(661, 131);
            this.tbxDocumento.Name = "tbxDocumento";
            this.tbxDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbxDocumento.TabIndex = 86;
            this.tbxDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxDocumento_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(658, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 85;
            this.label14.Text = "N° Documento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(700, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 22);
            this.label11.TabIndex = 84;
            this.label11.Text = "*";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(471, 67);
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(100, 20);
            this.tbxNombre.TabIndex = 77;
            this.tbxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNombre_KeyPress);
            // 
            // tbxApellido
            // 
            this.tbxApellido.Location = new System.Drawing.Point(661, 66);
            this.tbxApellido.Name = "tbxApellido";
            this.tbxApellido.Size = new System.Drawing.Size(100, 20);
            this.tbxApellido.TabIndex = 83;
            this.tbxApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxApellido_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(468, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Nombre";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(658, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(510, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 78;
            this.label7.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(553, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 22);
            this.label9.TabIndex = 81;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(468, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Tipo Documento";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(471, 479);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(99, 20);
            this.tbxEmail.TabIndex = 80;
            this.tbxEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEmail_KeyPress);
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.Location = new System.Drawing.Point(437, 541);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarUsuario.TabIndex = 49;
            this.btnGuardarUsuario.Text = "Guardar";
            this.btnGuardarUsuario.UseVisualStyleBackColor = true;
            this.btnGuardarUsuario.Click += new System.EventHandler(this.btnGuardarUsuario_Click);
            // 
            // btnLimpiarUsuario
            // 
            this.btnLimpiarUsuario.Location = new System.Drawing.Point(318, 541);
            this.btnLimpiarUsuario.Name = "btnLimpiarUsuario";
            this.btnLimpiarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarUsuario.TabIndex = 48;
            this.btnLimpiarUsuario.Text = "Limpiar";
            this.btnLimpiarUsuario.UseVisualStyleBackColor = true;
            this.btnLimpiarUsuario.Click += new System.EventHandler(this.btnLimpiarUsuario_Click);
            // 
            // pagModificar
            // 
            this.pagModificar.Controls.Add(this.groupBox3);
            this.pagModificar.Location = new System.Drawing.Point(4, 22);
            this.pagModificar.Name = "pagModificar";
            this.pagModificar.Padding = new System.Windows.Forms.Padding(3);
            this.pagModificar.Size = new System.Drawing.Size(813, 575);
            this.pagModificar.TabIndex = 1;
            this.pagModificar.Text = "Modificar";
            this.pagModificar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvModificarUsuarios);
            this.groupBox3.Location = new System.Drawing.Point(15, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 519);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Usuarios";
            // 
            // dgvModificarUsuarios
            // 
            this.dgvModificarUsuarios.AllowUserToAddRows = false;
            this.dgvModificarUsuarios.AllowUserToDeleteRows = false;
            this.dgvModificarUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvModificarUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarUsuarios.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgvModificarUsuarios.Location = new System.Drawing.Point(17, 30);
            this.dgvModificarUsuarios.Name = "dgvModificarUsuarios";
            this.dgvModificarUsuarios.RowHeadersVisible = false;
            this.dgvModificarUsuarios.Size = new System.Drawing.Size(745, 471);
            this.dgvModificarUsuarios.TabIndex = 0;
            this.dgvModificarUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModificarUsuarios_CellContentClick);
            // 
            // pagEliminar
            // 
            this.pagEliminar.Controls.Add(this.groupBox1);
            this.pagEliminar.Location = new System.Drawing.Point(4, 22);
            this.pagEliminar.Name = "pagEliminar";
            this.pagEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.pagEliminar.Size = new System.Drawing.Size(813, 575);
            this.pagEliminar.TabIndex = 2;
            this.pagEliminar.Text = "Eliminar";
            this.pagEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEliminarUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(15, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 519);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuarios";
            // 
            // dgvEliminarUsuarios
            // 
            this.dgvEliminarUsuarios.AllowUserToAddRows = false;
            this.dgvEliminarUsuarios.AllowUserToDeleteRows = false;
            this.dgvEliminarUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgvEliminarUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarUsuarios.DefaultCellStyle = dataGridViewCellStyle40;
            this.dgvEliminarUsuarios.Location = new System.Drawing.Point(17, 30);
            this.dgvEliminarUsuarios.Name = "dgvEliminarUsuarios";
            this.dgvEliminarUsuarios.RowHeadersVisible = false;
            this.dgvEliminarUsuarios.Size = new System.Drawing.Size(745, 471);
            this.dgvEliminarUsuarios.TabIndex = 0;
            // 
            // VentanaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 644);
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
            this.pagAgregar.PerformLayout();
            this.pagModificar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarUsuarios)).EndInit();
            this.pagEliminar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagAgregar;
        private System.Windows.Forms.TabPage pagModificar;
        private System.Windows.Forms.TabPage pagEliminar;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.Button btnLimpiarUsuario;
        private System.Windows.Forms.Button btnQuitarHotel;
        private System.Windows.Forms.Button btnAgregarHotel;
        private System.Windows.Forms.ListBox lbxHoteles;
        private System.Windows.Forms.ListBox lbxRoles;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Button btnQuitarRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxContrasena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionarFecha;
        private System.Windows.Forms.ComboBox cbxTipoDocumento;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxFechaNacimiento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbxPais;
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
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbxCiudad;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbxDepartamento;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbxPiso;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblNumeroCalle;
        private System.Windows.Forms.TextBox tbxNumeroCalle;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbxCalle;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvModificarUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEliminarUsuarios;
    }
}