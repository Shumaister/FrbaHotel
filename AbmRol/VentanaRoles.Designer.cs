﻿namespace FrbaHotel.AbmRol
{
    partial class VentanaRoles
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAgregar = new System.Windows.Forms.TabPage();
            this.tbxNombreRol = new System.Windows.Forms.TextBox();
            this.btnAgregarFuncionalidad = new System.Windows.Forms.Button();
            this.lbxFuncionalidades = new System.Windows.Forms.ListBox();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.rbtRolDesactivado = new System.Windows.Forms.RadioButton();
            this.rbtRolActivado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabModificar = new System.Windows.Forms.TabPage();
            this.cbxModificar = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarRol1 = new System.Windows.Forms.Label();
            this.bntModificar = new System.Windows.Forms.Button();
            this.tabEliminar = new System.Windows.Forms.TabPage();
            this.cbxEliminar = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarRol2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnQuitarRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAgregar.SuspendLayout();
            this.tabModificar.SuspendLayout();
            this.tabEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(441, 324);
            this.logo.Size = new System.Drawing.Size(46, 34);
            this.logo.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAgregar);
            this.tabControl1.Controls.Add(this.tabModificar);
            this.tabControl1.Controls.Add(this.tabEliminar);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 419);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAgregar
            // 
            this.tabAgregar.Controls.Add(this.btnQuitarRol);
            this.tabAgregar.Controls.Add(this.tbxNombreRol);
            this.tabAgregar.Controls.Add(this.btnAgregarFuncionalidad);
            this.tabAgregar.Controls.Add(this.lbxFuncionalidades);
            this.tabAgregar.Controls.Add(this.btnGuardarRol);
            this.tabAgregar.Controls.Add(this.btnLimpiarRol);
            this.tabAgregar.Controls.Add(this.label3);
            this.tabAgregar.Controls.Add(this.label2);
            this.tabAgregar.Controls.Add(this.cbxFuncionalidades);
            this.tabAgregar.Controls.Add(this.rbtRolDesactivado);
            this.tabAgregar.Controls.Add(this.rbtRolActivado);
            this.tabAgregar.Controls.Add(this.label1);
            this.tabAgregar.Location = new System.Drawing.Point(4, 22);
            this.tabAgregar.Name = "tabAgregar";
            this.tabAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgregar.Size = new System.Drawing.Size(271, 393);
            this.tabAgregar.TabIndex = 0;
            this.tabAgregar.Text = " Agregar";
            this.tabAgregar.UseVisualStyleBackColor = true;
            // 
            // tbxNombreRol
            // 
            this.tbxNombreRol.Location = new System.Drawing.Point(33, 49);
            this.tbxNombreRol.Name = "tbxNombreRol";
            this.tbxNombreRol.Size = new System.Drawing.Size(100, 20);
            this.tbxNombreRol.TabIndex = 11;
            this.tbxNombreRol.TextChanged += new System.EventHandler(this.tbxNombreRol_TextChanged);
            // 
            // btnAgregarFuncionalidad
            // 
            this.btnAgregarFuncionalidad.Location = new System.Drawing.Point(176, 107);
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
            this.lbxFuncionalidades.Location = new System.Drawing.Point(33, 155);
            this.lbxFuncionalidades.Name = "lbxFuncionalidades";
            this.lbxFuncionalidades.Size = new System.Drawing.Size(120, 95);
            this.lbxFuncionalidades.TabIndex = 9;
            this.lbxFuncionalidades.DataSourceChanged += new System.EventHandler(this.lbxFuncionalidades_DataSourceChanged);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(160, 345);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRol.TabIndex = 8;
            this.btnGuardarRol.Text = "Guardar";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.Location = new System.Drawing.Point(33, 345);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarRol.TabIndex = 7;
            this.btnLimpiarRol.Text = "Limpiar";
            this.btnLimpiarRol.UseVisualStyleBackColor = true;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btnLimpiarRol_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionalidades";
            // 
            // cbxFuncionalidades
            // 
            this.cbxFuncionalidades.FormattingEnabled = true;
            this.cbxFuncionalidades.Location = new System.Drawing.Point(33, 109);
            this.cbxFuncionalidades.Name = "cbxFuncionalidades";
            this.cbxFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbxFuncionalidades.TabIndex = 4;
            // 
            // rbtRolDesactivado
            // 
            this.rbtRolDesactivado.AutoSize = true;
            this.rbtRolDesactivado.Location = new System.Drawing.Point(141, 301);
            this.rbtRolDesactivado.Name = "rbtRolDesactivado";
            this.rbtRolDesactivado.Size = new System.Drawing.Size(85, 17);
            this.rbtRolDesactivado.TabIndex = 3;
            this.rbtRolDesactivado.TabStop = true;
            this.rbtRolDesactivado.Text = "Desactivado";
            this.rbtRolDesactivado.UseVisualStyleBackColor = true;
            // 
            // rbtRolActivado
            // 
            this.rbtRolActivado.AutoSize = true;
            this.rbtRolActivado.Location = new System.Drawing.Point(33, 301);
            this.rbtRolActivado.Name = "rbtRolActivado";
            this.rbtRolActivado.Size = new System.Drawing.Size(67, 17);
            this.rbtRolActivado.TabIndex = 2;
            this.rbtRolActivado.TabStop = true;
            this.rbtRolActivado.Text = "Activado";
            this.rbtRolActivado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // tabModificar
            // 
            this.tabModificar.Controls.Add(this.cbxModificar);
            this.tabModificar.Controls.Add(this.lblSeleccionarRol1);
            this.tabModificar.Controls.Add(this.bntModificar);
            this.tabModificar.Location = new System.Drawing.Point(4, 22);
            this.tabModificar.Name = "tabModificar";
            this.tabModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificar.Size = new System.Drawing.Size(271, 393);
            this.tabModificar.TabIndex = 1;
            this.tabModificar.Text = "Modificar";
            this.tabModificar.UseVisualStyleBackColor = true;
            this.tabModificar.Click += new System.EventHandler(this.tabModificar_Click);
            // 
            // cbxModificar
            // 
            this.cbxModificar.FormattingEnabled = true;
            this.cbxModificar.Location = new System.Drawing.Point(30, 60);
            this.cbxModificar.Name = "cbxModificar";
            this.cbxModificar.Size = new System.Drawing.Size(121, 21);
            this.cbxModificar.TabIndex = 6;
            // 
            // lblSeleccionarRol1
            // 
            this.lblSeleccionarRol1.AutoSize = true;
            this.lblSeleccionarRol1.Location = new System.Drawing.Point(27, 22);
            this.lblSeleccionarRol1.Name = "lblSeleccionarRol1";
            this.lblSeleccionarRol1.Size = new System.Drawing.Size(89, 13);
            this.lblSeleccionarRol1.TabIndex = 2;
            this.lblSeleccionarRol1.Text = "Seleccione un rol";
            // 
            // bntModificar
            // 
            this.bntModificar.Location = new System.Drawing.Point(30, 116);
            this.bntModificar.Name = "bntModificar";
            this.bntModificar.Size = new System.Drawing.Size(75, 23);
            this.bntModificar.TabIndex = 1;
            this.bntModificar.Text = "Modificar";
            this.bntModificar.UseVisualStyleBackColor = true;
            this.bntModificar.Click += new System.EventHandler(this.bntModificar_Click);
            // 
            // tabEliminar
            // 
            this.tabEliminar.Controls.Add(this.cbxEliminar);
            this.tabEliminar.Controls.Add(this.lblSeleccionarRol2);
            this.tabEliminar.Controls.Add(this.btnEliminar);
            this.tabEliminar.Location = new System.Drawing.Point(4, 22);
            this.tabEliminar.Name = "tabEliminar";
            this.tabEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEliminar.Size = new System.Drawing.Size(271, 393);
            this.tabEliminar.TabIndex = 2;
            this.tabEliminar.Text = "Eliminar";
            this.tabEliminar.UseVisualStyleBackColor = true;
            // 
            // cbxEliminar
            // 
            this.cbxEliminar.FormattingEnabled = true;
            this.cbxEliminar.Location = new System.Drawing.Point(31, 63);
            this.cbxEliminar.Name = "cbxEliminar";
            this.cbxEliminar.Size = new System.Drawing.Size(121, 21);
            this.cbxEliminar.TabIndex = 9;
            // 
            // lblSeleccionarRol2
            // 
            this.lblSeleccionarRol2.AutoSize = true;
            this.lblSeleccionarRol2.Location = new System.Drawing.Point(28, 25);
            this.lblSeleccionarRol2.Name = "lblSeleccionarRol2";
            this.lblSeleccionarRol2.Size = new System.Drawing.Size(89, 13);
            this.lblSeleccionarRol2.TabIndex = 8;
            this.lblSeleccionarRol2.Text = "Seleccione un rol";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(31, 114);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.Location = new System.Drawing.Point(176, 136);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarRol.TabIndex = 12;
            this.btnQuitarRol.Text = "Quitar";
            this.btnQuitarRol.UseVisualStyleBackColor = true;
            this.btnQuitarRol.Click += new System.EventHandler(this.btnQuitarRol_Click);
            // 
            // VentanaRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 447);
            this.Controls.Add(this.tabControl1);
            this.Name = "VentanaRoles";
            this.Text = "Roles - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRoles_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAgregar.ResumeLayout(false);
            this.tabAgregar.PerformLayout();
            this.tabModificar.ResumeLayout(false);
            this.tabModificar.PerformLayout();
            this.tabEliminar.ResumeLayout(false);
            this.tabEliminar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAgregar;
        private System.Windows.Forms.TabPage tabModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtRolDesactivado;
        private System.Windows.Forms.RadioButton rbtRolActivado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabEliminar;
        private System.Windows.Forms.Label lblSeleccionarRol1;
        private System.Windows.Forms.Button bntModificar;
        private System.Windows.Forms.ComboBox cbxFuncionalidades;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.ComboBox cbxModificar;
        private System.Windows.Forms.ComboBox cbxEliminar;
        private System.Windows.Forms.Label lblSeleccionarRol2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregarFuncionalidad;
        private System.Windows.Forms.ListBox lbxFuncionalidades;
        private System.Windows.Forms.TextBox tbxNombreRol;
        private System.Windows.Forms.Button btnQuitarRol;
    }
}