namespace FrbaHotel.Login
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.btnIngresoUsuario = new System.Windows.Forms.Button();
            this.lblErrorLogueo = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblErrorRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contrasenia";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(165, 33);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(100, 20);
            this.txbUser.TabIndex = 2;
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(165, 84);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(100, 20);
            this.txbPass.TabIndex = 3;
            this.txbPass.UseSystemPasswordChar = true;
            // 
            // btnIngresoUsuario
            // 
            this.btnIngresoUsuario.Location = new System.Drawing.Point(176, 150);
            this.btnIngresoUsuario.Name = "btnIngresoUsuario";
            this.btnIngresoUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnIngresoUsuario.TabIndex = 4;
            this.btnIngresoUsuario.Text = "Login";
            this.btnIngresoUsuario.UseVisualStyleBackColor = true;
            this.btnIngresoUsuario.Click += new System.EventHandler(this.btnIngresoUsuario_Click);
            // 
            // lblErrorLogueo
            // 
            this.lblErrorLogueo.AutoSize = true;
            this.lblErrorLogueo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLogueo.Location = new System.Drawing.Point(34, 121);
            this.lblErrorLogueo.Name = "lblErrorLogueo";
            this.lblErrorLogueo.Size = new System.Drawing.Size(257, 13);
            this.lblErrorLogueo.TabIndex = 5;
            this.lblErrorLogueo.Text = "Error al loguearse. Usuario o Contrasenia incorrectos.";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(66, 214);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 6;
            this.lblRol.Text = "Rol";
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(165, 211);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(100, 21);
            this.cbxRoles.TabIndex = 7;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(120, 282);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 8;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            // 
            // lblErrorRol
            // 
            this.lblErrorRol.AutoSize = true;
            this.lblErrorRol.ForeColor = System.Drawing.Color.Red;
            this.lblErrorRol.Location = new System.Drawing.Point(34, 250);
            this.lblErrorRol.Name = "lblErrorRol";
            this.lblErrorRol.Size = new System.Drawing.Size(236, 13);
            this.lblErrorRol.TabIndex = 9;
            this.lblErrorRol.Text = "Rol inhabilitado. Contactese con el administrador";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 352);
            this.Controls.Add(this.lblErrorRol);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.cbxRoles);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblErrorLogueo);
            this.Controls.Add(this.btnIngresoUsuario);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Button btnIngresoUsuario;
        private System.Windows.Forms.Label lblErrorLogueo;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblErrorRol;
    }
}