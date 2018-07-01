namespace FrbaHotel.RegistrarEstadia
{
    partial class VentanaRegistrarIngreso
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
            this.btnQuitarCliente = new System.Windows.Forms.Button();
            this.lbxHuespedes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarIngreso = new System.Windows.Forms.Button();
            this.btnAgregarClienteNuevo = new System.Windows.Forms.Button();
            this.btnAgregarClienteExistente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.lblClienteDocumento = new System.Windows.Forms.Label();
            this.lblClienteEmail = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblClienteApellido = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(628, 505);
            this.logo.Size = new System.Drawing.Size(24, 23);
            this.logo.Visible = false;
            // 
            // btnQuitarCliente
            // 
            this.btnQuitarCliente.Location = new System.Drawing.Point(347, 275);
            this.btnQuitarCliente.Name = "btnQuitarCliente";
            this.btnQuitarCliente.Size = new System.Drawing.Size(142, 23);
            this.btnQuitarCliente.TabIndex = 276;
            this.btnQuitarCliente.Text = "Quitar";
            this.btnQuitarCliente.UseVisualStyleBackColor = true;
            this.btnQuitarCliente.Click += new System.EventHandler(this.btnQuitarCliente_Click);
            // 
            // lbxHuespedes
            // 
            this.lbxHuespedes.FormattingEnabled = true;
            this.lbxHuespedes.Location = new System.Drawing.Point(12, 217);
            this.lbxHuespedes.Name = "lbxHuespedes";
            this.lbxHuespedes.Size = new System.Drawing.Size(311, 95);
            this.lbxHuespedes.TabIndex = 274;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 273;
            this.label2.Text = "Huespedes registrados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(9, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 293;
            this.label1.Text = "Acompañantes del cliente";
            // 
            // btnGuardarIngreso
            // 
            this.btnGuardarIngreso.Location = new System.Drawing.Point(239, 338);
            this.btnGuardarIngreso.Name = "btnGuardarIngreso";
            this.btnGuardarIngreso.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarIngreso.TabIndex = 295;
            this.btnGuardarIngreso.Text = "Guardar";
            this.btnGuardarIngreso.UseVisualStyleBackColor = true;
            this.btnGuardarIngreso.Click += new System.EventHandler(this.btnGuardarIngreso_Click);
            // 
            // btnAgregarClienteNuevo
            // 
            this.btnAgregarClienteNuevo.Location = new System.Drawing.Point(347, 217);
            this.btnAgregarClienteNuevo.Name = "btnAgregarClienteNuevo";
            this.btnAgregarClienteNuevo.Size = new System.Drawing.Size(142, 23);
            this.btnAgregarClienteNuevo.TabIndex = 296;
            this.btnAgregarClienteNuevo.Text = "Agregar nuevo cliente";
            this.btnAgregarClienteNuevo.UseVisualStyleBackColor = true;
            this.btnAgregarClienteNuevo.Click += new System.EventHandler(this.btnAgregarClienteNuevo_Click);
            // 
            // btnAgregarClienteExistente
            // 
            this.btnAgregarClienteExistente.Location = new System.Drawing.Point(347, 246);
            this.btnAgregarClienteExistente.Name = "btnAgregarClienteExistente";
            this.btnAgregarClienteExistente.Size = new System.Drawing.Size(142, 23);
            this.btnAgregarClienteExistente.TabIndex = 297;
            this.btnAgregarClienteExistente.Text = "Agregar cliente existente";
            this.btnAgregarClienteExistente.UseVisualStyleBackColor = true;
            this.btnAgregarClienteExistente.Click += new System.EventHandler(this.btnAgregarClienteExistente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 300;
            this.label3.Text = "Datos del cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 298;
            this.label6.Text = "Nombre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 301;
            this.label4.Text = "Documento: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 302;
            this.label7.Text = "Email: ";
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.AutoSize = true;
            this.lblClienteNombre.Location = new System.Drawing.Point(120, 40);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(77, 13);
            this.lblClienteNombre.TabIndex = 303;
            this.lblClienteNombre.Text = "Cliente nombre";
            // 
            // lblClienteDocumento
            // 
            this.lblClienteDocumento.AutoSize = true;
            this.lblClienteDocumento.Location = new System.Drawing.Point(120, 108);
            this.lblClienteDocumento.Name = "lblClienteDocumento";
            this.lblClienteDocumento.Size = new System.Drawing.Size(95, 13);
            this.lblClienteDocumento.TabIndex = 304;
            this.lblClienteDocumento.Text = "Cliente documento";
            // 
            // lblClienteEmail
            // 
            this.lblClienteEmail.AutoSize = true;
            this.lblClienteEmail.Location = new System.Drawing.Point(120, 131);
            this.lblClienteEmail.Name = "lblClienteEmail";
            this.lblClienteEmail.Size = new System.Drawing.Size(66, 13);
            this.lblClienteEmail.TabIndex = 305;
            this.lblClienteEmail.Text = "Cliente email";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(9, 64);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 306;
            this.lblApellido.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 307;
            this.label5.Text = "Tipo documento:";
            // 
            // lblClienteApellido
            // 
            this.lblClienteApellido.AutoSize = true;
            this.lblClienteApellido.Location = new System.Drawing.Point(120, 64);
            this.lblClienteApellido.Name = "lblClienteApellido";
            this.lblClienteApellido.Size = new System.Drawing.Size(78, 13);
            this.lblClienteApellido.TabIndex = 308;
            this.lblClienteApellido.Text = "Cliente apellido";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(120, 87);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(115, 13);
            this.lblTipoDocumento.TabIndex = 309;
            this.lblTipoDocumento.Text = "Cliente tipo documento";
            // 
            // VentanaRegistrarIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 378);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.lblClienteApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblClienteEmail);
            this.Controls.Add(this.lblClienteDocumento);
            this.Controls.Add(this.lblClienteNombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAgregarClienteExistente);
            this.Controls.Add(this.btnAgregarClienteNuevo);
            this.Controls.Add(this.btnGuardarIngreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitarCliente);
            this.Controls.Add(this.lbxHuespedes);
            this.Controls.Add(this.label2);
            this.Name = "VentanaRegistrarIngreso";
            this.Text = "Registrar ingreso - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRegistrarIngreso_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbxHuespedes, 0);
            this.Controls.SetChildIndex(this.btnQuitarCliente, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnGuardarIngreso, 0);
            this.Controls.SetChildIndex(this.btnAgregarClienteNuevo, 0);
            this.Controls.SetChildIndex(this.btnAgregarClienteExistente, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblClienteNombre, 0);
            this.Controls.SetChildIndex(this.lblClienteDocumento, 0);
            this.Controls.SetChildIndex(this.lblClienteEmail, 0);
            this.Controls.SetChildIndex(this.lblApellido, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblClienteApellido, 0);
            this.Controls.SetChildIndex(this.lblTipoDocumento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitarCliente;
        private System.Windows.Forms.ListBox lbxHuespedes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarIngreso;
        private System.Windows.Forms.Button btnAgregarClienteNuevo;
        private System.Windows.Forms.Button btnAgregarClienteExistente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label lblClienteDocumento;
        private System.Windows.Forms.Label lblClienteEmail;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblClienteApellido;
        private System.Windows.Forms.Label lblTipoDocumento;
    }
}