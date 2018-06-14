namespace FrbaHotel.AbmRol
{
    partial class VentanaRol
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
            this.tabRoles = new System.Windows.Forms.TabControl();
            this.tabAgregar = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitarFuncionalidad = new System.Windows.Forms.Button();
            this.tbxNombreRol = new System.Windows.Forms.TextBox();
            this.btnAgregarFuncionalidad = new System.Windows.Forms.Button();
            this.lbxFuncionalidades = new System.Windows.Forms.ListBox();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabModificar = new System.Windows.Forms.TabPage();
            this.dgvModificarRoles = new System.Windows.Forms.DataGridView();
            this.lblSeleccionarRol1 = new System.Windows.Forms.Label();
            this.tabEliminar = new System.Windows.Forms.TabPage();
            this.dgvEliminarRoles = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabRoles.SuspendLayout();
            this.tabAgregar.SuspendLayout();
            this.tabModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarRoles)).BeginInit();
            this.tabEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(468, 409);
            this.logo.Size = new System.Drawing.Size(46, 34);
            this.logo.Visible = false;
            // 
            // tabRoles
            // 
            this.tabRoles.Controls.Add(this.tabAgregar);
            this.tabRoles.Controls.Add(this.tabModificar);
            this.tabRoles.Controls.Add(this.tabEliminar);
            this.tabRoles.Location = new System.Drawing.Point(12, 12);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.SelectedIndex = 0;
            this.tabRoles.Size = new System.Drawing.Size(374, 381);
            this.tabRoles.TabIndex = 1;
            // 
            // tabAgregar
            // 
            this.tabAgregar.Controls.Add(this.label32);
            this.tabAgregar.Controls.Add(this.label5);
            this.tabAgregar.Controls.Add(this.label4);
            this.tabAgregar.Controls.Add(this.btnQuitarFuncionalidad);
            this.tabAgregar.Controls.Add(this.tbxNombreRol);
            this.tabAgregar.Controls.Add(this.btnAgregarFuncionalidad);
            this.tabAgregar.Controls.Add(this.lbxFuncionalidades);
            this.tabAgregar.Controls.Add(this.btnGuardarRol);
            this.tabAgregar.Controls.Add(this.btnLimpiarRol);
            this.tabAgregar.Controls.Add(this.label2);
            this.tabAgregar.Controls.Add(this.cbxFuncionalidades);
            this.tabAgregar.Controls.Add(this.label1);
            this.tabAgregar.Location = new System.Drawing.Point(4, 22);
            this.tabAgregar.Name = "tabAgregar";
            this.tabAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgregar.Size = new System.Drawing.Size(366, 355);
            this.tabAgregar.TabIndex = 0;
            this.tabAgregar.Text = " Agregar";
            this.tabAgregar.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(84, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(90, 16);
            this.label32.TabIndex = 263;
            this.label32.Text = "Datos del Rol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(167, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 27;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(126, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "*";
            // 
            // btnQuitarFuncionalidad
            // 
            this.btnQuitarFuncionalidad.Location = new System.Drawing.Point(230, 148);
            this.btnQuitarFuncionalidad.Name = "btnQuitarFuncionalidad";
            this.btnQuitarFuncionalidad.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarFuncionalidad.TabIndex = 12;
            this.btnQuitarFuncionalidad.Text = "Quitar";
            this.btnQuitarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnQuitarFuncionalidad.Click += new System.EventHandler(this.btnQuitarFuncionalidad_Click);
            // 
            // tbxNombreRol
            // 
            this.tbxNombreRol.Location = new System.Drawing.Point(87, 61);
            this.tbxNombreRol.Name = "tbxNombreRol";
            this.tbxNombreRol.Size = new System.Drawing.Size(100, 20);
            this.tbxNombreRol.TabIndex = 11;
            this.tbxNombreRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNombreRol_KeyPress);
            // 
            // btnAgregarFuncionalidad
            // 
            this.btnAgregarFuncionalidad.Location = new System.Drawing.Point(230, 119);
            this.btnAgregarFuncionalidad.Name = "btnAgregarFuncionalidad";
            this.btnAgregarFuncionalidad.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarFuncionalidad.TabIndex = 10;
            this.btnAgregarFuncionalidad.Text = "Agregar";
            this.btnAgregarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnAgregarFuncionalidad.Click += new System.EventHandler(this.btnAgregarFuncionalidad_Click);
            // 
            // lbxFuncionalidades
            // 
            this.lbxFuncionalidades.FormattingEnabled = true;
            this.lbxFuncionalidades.Location = new System.Drawing.Point(87, 167);
            this.lbxFuncionalidades.Name = "lbxFuncionalidades";
            this.lbxFuncionalidades.Size = new System.Drawing.Size(120, 95);
            this.lbxFuncionalidades.TabIndex = 9;
            this.lbxFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.lbxFuncionalidades_SelectedIndexChanged);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(196, 302);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRol.TabIndex = 8;
            this.btnGuardarRol.Text = "Guardar";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.Location = new System.Drawing.Point(72, 302);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarRol.TabIndex = 7;
            this.btnLimpiarRol.Text = "Limpiar";
            this.btnLimpiarRol.UseVisualStyleBackColor = true;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btnLimpiarRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionalidades";
            // 
            // cbxFuncionalidades
            // 
            this.cbxFuncionalidades.FormattingEnabled = true;
            this.cbxFuncionalidades.Location = new System.Drawing.Point(87, 121);
            this.cbxFuncionalidades.Name = "cbxFuncionalidades";
            this.cbxFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbxFuncionalidades.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // tabModificar
            // 
            this.tabModificar.Controls.Add(this.dgvModificarRoles);
            this.tabModificar.Controls.Add(this.lblSeleccionarRol1);
            this.tabModificar.Location = new System.Drawing.Point(4, 22);
            this.tabModificar.Name = "tabModificar";
            this.tabModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificar.Size = new System.Drawing.Size(366, 355);
            this.tabModificar.TabIndex = 1;
            this.tabModificar.Text = "Modificar";
            this.tabModificar.UseVisualStyleBackColor = true;
            // 
            // dgvModificarRoles
            // 
            this.dgvModificarRoles.AllowUserToAddRows = false;
            this.dgvModificarRoles.AllowUserToDeleteRows = false;
            this.dgvModificarRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModificarRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModificarRoles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModificarRoles.Location = new System.Drawing.Point(19, 31);
            this.dgvModificarRoles.Name = "dgvModificarRoles";
            this.dgvModificarRoles.ReadOnly = true;
            this.dgvModificarRoles.RowHeadersVisible = false;
            this.dgvModificarRoles.Size = new System.Drawing.Size(329, 308);
            this.dgvModificarRoles.TabIndex = 10;
            this.dgvModificarRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModificarRoles_CellContentClick);
            // 
            // lblSeleccionarRol1
            // 
            this.lblSeleccionarRol1.AutoSize = true;
            this.lblSeleccionarRol1.Location = new System.Drawing.Point(17, 11);
            this.lblSeleccionarRol1.Name = "lblSeleccionarRol1";
            this.lblSeleccionarRol1.Size = new System.Drawing.Size(34, 13);
            this.lblSeleccionarRol1.TabIndex = 2;
            this.lblSeleccionarRol1.Text = "Roles";
            // 
            // tabEliminar
            // 
            this.tabEliminar.Controls.Add(this.dgvEliminarRoles);
            this.tabEliminar.Controls.Add(this.label7);
            this.tabEliminar.Location = new System.Drawing.Point(4, 22);
            this.tabEliminar.Name = "tabEliminar";
            this.tabEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEliminar.Size = new System.Drawing.Size(366, 355);
            this.tabEliminar.TabIndex = 2;
            this.tabEliminar.Text = "Eliminar";
            this.tabEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvEliminarRoles
            // 
            this.dgvEliminarRoles.AllowUserToAddRows = false;
            this.dgvEliminarRoles.AllowUserToDeleteRows = false;
            this.dgvEliminarRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEliminarRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEliminarRoles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEliminarRoles.Location = new System.Drawing.Point(19, 31);
            this.dgvEliminarRoles.Name = "dgvEliminarRoles";
            this.dgvEliminarRoles.ReadOnly = true;
            this.dgvEliminarRoles.RowHeadersVisible = false;
            this.dgvEliminarRoles.Size = new System.Drawing.Size(329, 308);
            this.dgvEliminarRoles.TabIndex = 11;
            this.dgvEliminarRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEliminarRoles_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Roles";
            // 
            // VentanaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 415);
            this.Controls.Add(this.tabRoles);
            this.Name = "VentanaRol";
            this.Text = "Roles - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRoles_Load);
            this.Controls.SetChildIndex(this.tabRoles, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabRoles.ResumeLayout(false);
            this.tabAgregar.ResumeLayout(false);
            this.tabAgregar.PerformLayout();
            this.tabModificar.ResumeLayout(false);
            this.tabModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarRoles)).EndInit();
            this.tabEliminar.ResumeLayout(false);
            this.tabEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRoles;
        private System.Windows.Forms.TabPage tabAgregar;
        private System.Windows.Forms.TabPage tabModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabEliminar;
        private System.Windows.Forms.Label lblSeleccionarRol1;
        private System.Windows.Forms.ComboBox cbxFuncionalidades;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.Button btnAgregarFuncionalidad;
        private System.Windows.Forms.ListBox lbxFuncionalidades;
        private System.Windows.Forms.TextBox tbxNombreRol;
        private System.Windows.Forms.Button btnQuitarFuncionalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvModificarRoles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView dgvEliminarRoles;
    }
}