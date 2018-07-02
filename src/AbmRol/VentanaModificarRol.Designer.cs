namespace FrbaHotel.AbmRol
{
    partial class VentanaModificarRol
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
            this.btnQuitarFuncionalidad = new System.Windows.Forms.Button();
            this.tbxNombreRol = new System.Windows.Forms.TextBox();
            this.btnAgregarFuncionalidad = new System.Windows.Forms.Button();
            this.lbxFuncionalidades = new System.Windows.Forms.ListBox();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(210, 12);
            this.logo.Size = new System.Drawing.Size(27, 21);
            this.logo.Visible = false;
            // 
            // btnQuitarFuncionalidad
            // 
            this.btnQuitarFuncionalidad.Location = new System.Drawing.Point(191, 167);
            this.btnQuitarFuncionalidad.Name = "btnQuitarFuncionalidad";
            this.btnQuitarFuncionalidad.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarFuncionalidad.TabIndex = 24;
            this.btnQuitarFuncionalidad.Text = "Quitar";
            this.btnQuitarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnQuitarFuncionalidad.Click += new System.EventHandler(this.btnQuitarFuncionalidad_Click);
            // 
            // tbxNombreRol
            // 
            this.tbxNombreRol.Location = new System.Drawing.Point(30, 75);
            this.tbxNombreRol.MaxLength = 254;
            this.tbxNombreRol.Name = "tbxNombreRol";
            this.tbxNombreRol.Size = new System.Drawing.Size(120, 20);
            this.tbxNombreRol.TabIndex = 23;
            this.tbxNombreRol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNombreRol_KeyPress);
            // 
            // btnAgregarFuncionalidad
            // 
            this.btnAgregarFuncionalidad.Location = new System.Drawing.Point(191, 138);
            this.btnAgregarFuncionalidad.Name = "btnAgregarFuncionalidad";
            this.btnAgregarFuncionalidad.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarFuncionalidad.TabIndex = 22;
            this.btnAgregarFuncionalidad.Text = "Agregar";
            this.btnAgregarFuncionalidad.UseVisualStyleBackColor = true;
            this.btnAgregarFuncionalidad.Click += new System.EventHandler(this.btnAgregarFuncionalidad_Click);
            // 
            // lbxFuncionalidades
            // 
            this.lbxFuncionalidades.FormattingEnabled = true;
            this.lbxFuncionalidades.Location = new System.Drawing.Point(29, 186);
            this.lbxFuncionalidades.Name = "lbxFuncionalidades";
            this.lbxFuncionalidades.Size = new System.Drawing.Size(120, 95);
            this.lbxFuncionalidades.TabIndex = 21;
            this.lbxFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.lbxFuncionalidades_SelectedIndexChanged);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(191, 365);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRol.TabIndex = 20;
            this.btnGuardarRol.Text = "Guardar";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.Location = new System.Drawing.Point(29, 365);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarRol.TabIndex = 19;
            this.btnLimpiarRol.Text = "Limpiar";
            this.btnLimpiarRol.UseVisualStyleBackColor = true;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btnLimpiarRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Funcionalidades";
            // 
            // cbxFuncionalidades
            // 
            this.cbxFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFuncionalidades.FormattingEnabled = true;
            this.cbxFuncionalidades.Location = new System.Drawing.Point(29, 140);
            this.cbxFuncionalidades.Name = "cbxFuncionalidades";
            this.cbxFuncionalidades.Size = new System.Drawing.Size(121, 21);
            this.cbxFuncionalidades.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(67, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 25;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(109, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 26;
            this.label5.Text = "*";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(26, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(90, 16);
            this.label32.TabIndex = 264;
            this.label32.Text = "Datos del Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Estado";
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(75, 302);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(75, 23);
            this.btnHabilitar.TabIndex = 266;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // VentanaModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 409);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnQuitarFuncionalidad);
            this.Controls.Add(this.tbxNombreRol);
            this.Controls.Add(this.btnAgregarFuncionalidad);
            this.Controls.Add(this.lbxFuncionalidades);
            this.Controls.Add(this.btnGuardarRol);
            this.Controls.Add(this.btnLimpiarRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxFuncionalidades);
            this.Controls.Add(this.label1);
            this.Name = "VentanaModificarRol";
            this.Text = "Modificar Rol - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaModificarRol_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbxFuncionalidades, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnLimpiarRol, 0);
            this.Controls.SetChildIndex(this.btnGuardarRol, 0);
            this.Controls.SetChildIndex(this.lbxFuncionalidades, 0);
            this.Controls.SetChildIndex(this.btnAgregarFuncionalidad, 0);
            this.Controls.SetChildIndex(this.tbxNombreRol, 0);
            this.Controls.SetChildIndex(this.btnQuitarFuncionalidad, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.btnHabilitar, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitarFuncionalidad;
        private System.Windows.Forms.TextBox tbxNombreRol;
        private System.Windows.Forms.Button btnAgregarFuncionalidad;
        private System.Windows.Forms.ListBox lbxFuncionalidades;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFuncionalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHabilitar;
    }
}