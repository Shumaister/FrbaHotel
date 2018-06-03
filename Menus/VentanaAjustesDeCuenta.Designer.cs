namespace FrbaHotel.Menus
{
    partial class VentanaAjustesDeCuenta
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
            this.btnGuardarContrasenia = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.tbxContrasenia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(235, 215);
            this.logo.Size = new System.Drawing.Size(47, 34);
            this.logo.Visible = false;
            // 
            // btnGuardarContrasenia
            // 
            this.btnGuardarContrasenia.Location = new System.Drawing.Point(114, 194);
            this.btnGuardarContrasenia.Name = "btnGuardarContrasenia";
            this.btnGuardarContrasenia.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarContrasenia.TabIndex = 1;
            this.btnGuardarContrasenia.Text = "Guardar";
            this.btnGuardarContrasenia.UseVisualStyleBackColor = true;
            this.btnGuardarContrasenia.Click += new System.EventHandler(this.btnGuardarContrasenia_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(95, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 16);
            this.label32.TabIndex = 266;
            this.label32.Text = "Datos de la cuenta";
            // 
            // tbxContrasenia
            // 
            this.tbxContrasenia.Location = new System.Drawing.Point(81, 149);
            this.tbxContrasenia.Name = "tbxContrasenia";
            this.tbxContrasenia.Size = new System.Drawing.Size(149, 20);
            this.tbxContrasenia.TabIndex = 264;
            this.tbxContrasenia.UseSystemPasswordChar = true;
            this.tbxContrasenia.TextChanged += new System.EventHandler(this.tbxContrasenia_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 263;
            this.label8.Text = "Nueva contraseña";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(177, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 22);
            this.label7.TabIndex = 265;
            this.label7.Text = "*";
            // 
            // tbxNombreUsuario
            // 
            this.tbxNombreUsuario.Enabled = false;
            this.tbxNombreUsuario.Location = new System.Drawing.Point(81, 76);
            this.tbxNombreUsuario.Name = "tbxNombreUsuario";
            this.tbxNombreUsuario.Size = new System.Drawing.Size(149, 20);
            this.tbxNombreUsuario.TabIndex = 268;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Usuario";
            // 
            // VentanaAjustesDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 261);
            this.Controls.Add(this.tbxNombreUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.tbxContrasenia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGuardarContrasenia);
            this.Name = "VentanaAjustesDeCuenta";
            this.Text = "Ajustes de Cuenta - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaAjustesDeCuenta_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.btnGuardarContrasenia, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.tbxContrasenia, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxNombreUsuario, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarContrasenia;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbxContrasenia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxNombreUsuario;
        private System.Windows.Forms.Label label1;
    }
}