﻿namespace FrbaHotel.AbmRol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvModificarRoles = new System.Windows.Forms.DataGridView();
            this.tabEliminar = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEliminarRoles = new System.Windows.Forms.DataGridView();
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
            this.logo.Location = new System.Drawing.Point(422, 12);
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
            this.tabRoles.Size = new System.Drawing.Size(359, 425);
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
            this.tabAgregar.Size = new System.Drawing.Size(351, 399);
            this.tabAgregar.TabIndex = 0;
            this.tabAgregar.Text = " Agregar";
            this.tabAgregar.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(60, 25);
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
            this.label5.Location = new System.Drawing.Point(143, 127);
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
            this.label4.Location = new System.Drawing.Point(102, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "*";
            // 
            // btnQuitarFuncionalidad
            // 
            this.btnQuitarFuncionalidad.Location = new System.Drawing.Point(224, 155);
            this.btnQuitarFuncionalidad.Name = "btnQuitarFuncionalidad";
            this.btnQuitarFuncionalidad.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarFuncionalidad.TabIndex = 12;
            this.btnQuitarFuncionalidad.Text = "Quitar";
            this.btnQuitarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnQuitarFuncionalidad.Click += new System.EventHandler(this.btnQuitarFuncionalidad_Click);
            // 
            // tbxNombreRol
            // 
            this.tbxNombreRol.Location = new System.Drawing.Point(63, 93);
            this.tbxNombreRol.MaxLength = 254;
            this.tbxNombreRol.Name = "tbxNombreRol";
            this.tbxNombreRol.Size = new System.Drawing.Size(121, 20);
            this.tbxNombreRol.TabIndex = 11;
            this.tbxNombreRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNombreRol_KeyPress);
            // 
            // btnAgregarFuncionalidad
            // 
            this.btnAgregarFuncionalidad.Location = new System.Drawing.Point(224, 126);
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
            this.lbxFuncionalidades.Location = new System.Drawing.Point(63, 199);
            this.lbxFuncionalidades.Name = "lbxFuncionalidades";
            this.lbxFuncionalidades.Size = new System.Drawing.Size(120, 95);
            this.lbxFuncionalidades.TabIndex = 9;
            this.lbxFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.lbxFuncionalidades_SelectedIndexChanged);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(224, 347);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRol.TabIndex = 8;
            this.btnGuardarRol.Text = "Guardar";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.Location = new System.Drawing.Point(63, 347);
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
            this.label2.Location = new System.Drawing.Point(60, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionalidades";
            // 
            // cbxFuncionalidades
            // 
            this.cbxFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFuncionalidades.FormattingEnabled = true;
            this.cbxFuncionalidades.Location = new System.Drawing.Point(63, 153);
            this.cbxFuncionalidades.Name = "cbxFuncionalidades";
            this.cbxFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbxFuncionalidades.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // tabModificar
            // 
            this.tabModificar.Controls.Add(this.label3);
            this.tabModificar.Controls.Add(this.dgvModificarRoles);
            this.tabModificar.Location = new System.Drawing.Point(4, 22);
            this.tabModificar.Name = "tabModificar";
            this.tabModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificar.Size = new System.Drawing.Size(351, 399);
            this.tabModificar.TabIndex = 1;
            this.tabModificar.Text = "Modificar";
            this.tabModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 264;
            this.label3.Text = "Roles";
            // 
            // dgvModificarRoles
            // 
            this.dgvModificarRoles.AllowUserToAddRows = false;
            this.dgvModificarRoles.AllowUserToDeleteRows = false;
            this.dgvModificarRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvModificarRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModificarRoles.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvModificarRoles.Location = new System.Drawing.Point(6, 34);
            this.dgvModificarRoles.Name = "dgvModificarRoles";
            this.dgvModificarRoles.ReadOnly = true;
            this.dgvModificarRoles.RowHeadersVisible = false;
            this.dgvModificarRoles.Size = new System.Drawing.Size(339, 359);
            this.dgvModificarRoles.TabIndex = 10;
            this.dgvModificarRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModificarRoles_CellContentClick);
            // 
            // tabEliminar
            // 
            this.tabEliminar.Controls.Add(this.label6);
            this.tabEliminar.Controls.Add(this.dgvEliminarRoles);
            this.tabEliminar.Location = new System.Drawing.Point(4, 22);
            this.tabEliminar.Name = "tabEliminar";
            this.tabEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEliminar.Size = new System.Drawing.Size(351, 399);
            this.tabEliminar.TabIndex = 2;
            this.tabEliminar.Text = "Eliminar";
            this.tabEliminar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 265;
            this.label6.Text = "Roles";
            // 
            // dgvEliminarRoles
            // 
            this.dgvEliminarRoles.AllowUserToAddRows = false;
            this.dgvEliminarRoles.AllowUserToDeleteRows = false;
            this.dgvEliminarRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEliminarRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEliminarRoles.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEliminarRoles.Location = new System.Drawing.Point(6, 34);
            this.dgvEliminarRoles.Name = "dgvEliminarRoles";
            this.dgvEliminarRoles.ReadOnly = true;
            this.dgvEliminarRoles.RowHeadersVisible = false;
            this.dgvEliminarRoles.Size = new System.Drawing.Size(339, 359);
            this.dgvEliminarRoles.TabIndex = 11;
            this.dgvEliminarRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEliminarRoles_CellContentClick);
            // 
            // VentanaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 449);
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
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView dgvEliminarRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}