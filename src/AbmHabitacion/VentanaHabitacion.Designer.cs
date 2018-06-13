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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagAgregar = new System.Windows.Forms.TabPage();
            this.rbtInterna = new System.Windows.Forms.RadioButton();
            this.rbtExterna = new System.Windows.Forms.RadioButton();
            this.lblHotel = new System.Windows.Forms.Label();
            this.cbxTipoHabitaciones = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvModificarHabitacion = new System.Windows.Forms.DataGridView();
            this.pagEliminar = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEliminarHabitacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pagAgregar.SuspendLayout();
            this.pagModificar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarHabitacion)).BeginInit();
            this.pagEliminar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarHabitacion)).BeginInit();
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
            this.pagAgregar.Controls.Add(this.rbtInterna);
            this.pagAgregar.Controls.Add(this.rbtExterna);
            this.pagAgregar.Controls.Add(this.lblHotel);
            this.pagAgregar.Controls.Add(this.cbxTipoHabitaciones);
            this.pagAgregar.Controls.Add(this.label5);
            this.pagAgregar.Controls.Add(this.label6);
            this.pagAgregar.Controls.Add(this.tbxDescripcion);
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
            // rbtInterna
            // 
            this.rbtInterna.AutoSize = true;
            this.rbtInterna.Location = new System.Drawing.Point(161, 156);
            this.rbtInterna.Name = "rbtInterna";
            this.rbtInterna.Size = new System.Drawing.Size(58, 17);
            this.rbtInterna.TabIndex = 319;
            this.rbtInterna.TabStop = true;
            this.rbtInterna.Text = "Interna";
            this.rbtInterna.UseVisualStyleBackColor = true;
            // 
            // rbtExterna
            // 
            this.rbtExterna.AutoSize = true;
            this.rbtExterna.Location = new System.Drawing.Point(247, 156);
            this.rbtExterna.Name = "rbtExterna";
            this.rbtExterna.Size = new System.Drawing.Size(61, 17);
            this.rbtExterna.TabIndex = 318;
            this.rbtExterna.TabStop = true;
            this.rbtExterna.Text = "Externa";
            this.rbtExterna.UseVisualStyleBackColor = true;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(189, 128);
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
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 287;
            this.label10.Text = "Vista";
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
            this.pagModificar.Controls.Add(this.groupBox3);
            this.pagModificar.Location = new System.Drawing.Point(4, 22);
            this.pagModificar.Name = "pagModificar";
            this.pagModificar.Padding = new System.Windows.Forms.Padding(3);
            this.pagModificar.Size = new System.Drawing.Size(377, 407);
            this.pagModificar.TabIndex = 1;
            this.pagModificar.Text = "Modificar";
            this.pagModificar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvModificarHabitacion);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 395);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Habitaciones";
            // 
            // dgvModificarHabitacion
            // 
            this.dgvModificarHabitacion.AllowUserToAddRows = false;
            this.dgvModificarHabitacion.AllowUserToDeleteRows = false;
            this.dgvModificarHabitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarHabitacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModificarHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarHabitacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModificarHabitacion.Location = new System.Drawing.Point(16, 29);
            this.dgvModificarHabitacion.Name = "dgvModificarHabitacion";
            this.dgvModificarHabitacion.RowHeadersVisible = false;
            this.dgvModificarHabitacion.Size = new System.Drawing.Size(332, 347);
            this.dgvModificarHabitacion.TabIndex = 0;
            this.dgvModificarHabitacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModificarHabitacion_CellContentClick);
            // 
            // pagEliminar
            // 
            this.pagEliminar.Controls.Add(this.groupBox1);
            this.pagEliminar.Location = new System.Drawing.Point(4, 22);
            this.pagEliminar.Name = "pagEliminar";
            this.pagEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.pagEliminar.Size = new System.Drawing.Size(377, 407);
            this.pagEliminar.TabIndex = 2;
            this.pagEliminar.Text = "Eliminar";
            this.pagEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEliminarHabitacion);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 395);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Habitaciones";
            // 
            // dgvEliminarHabitacion
            // 
            this.dgvEliminarHabitacion.AllowUserToAddRows = false;
            this.dgvEliminarHabitacion.AllowUserToDeleteRows = false;
            this.dgvEliminarHabitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarHabitacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEliminarHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarHabitacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEliminarHabitacion.Location = new System.Drawing.Point(16, 29);
            this.dgvEliminarHabitacion.Name = "dgvEliminarHabitacion";
            this.dgvEliminarHabitacion.RowHeadersVisible = false;
            this.dgvEliminarHabitacion.Size = new System.Drawing.Size(332, 347);
            this.dgvEliminarHabitacion.TabIndex = 0;
            this.dgvEliminarHabitacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEliminarHabitacion_CellContentClick);
            // 
            // VentanaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 466);
            this.Controls.Add(this.tabControl);
            this.Name = "VentanaHabitacion";
            this.Text = "Habitaciones - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaHabitacion_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pagAgregar.ResumeLayout(false);
            this.pagAgregar.PerformLayout();
            this.pagModificar.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarHabitacion)).EndInit();
            this.pagEliminar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarHabitacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagAgregar;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvModificarHabitacion;
        private System.Windows.Forms.TabPage pagEliminar;
        private System.Windows.Forms.ComboBox cbxTipoHabitaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.RadioButton rbtInterna;
        private System.Windows.Forms.RadioButton rbtExterna;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEliminarHabitacion;
    }
}