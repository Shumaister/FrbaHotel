namespace FrbaHotel.Login
{
    partial class SeleccionRol
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
            this.lblErrorRol = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblErrorRol
            // 
            this.lblErrorRol.AutoSize = true;
            this.lblErrorRol.ForeColor = System.Drawing.Color.Red;
            this.lblErrorRol.Location = new System.Drawing.Point(42, 166);
            this.lblErrorRol.Name = "lblErrorRol";
            this.lblErrorRol.Size = new System.Drawing.Size(239, 13);
            this.lblErrorRol.TabIndex = 13;
            this.lblErrorRol.Text = "Rol inhabilitado. Contactese con el administrador.";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(112, 248);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 12;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(63, 215);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(184, 21);
            this.cbxRoles.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(83, 189);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(142, 13);
            this.lblRol.TabIndex = 10;
            this.lblRol.Text = "Por favor,  seleccione un rol.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.pictureBox1.Location = new System.Drawing.Point(45, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // SeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 298);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblErrorRol);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.cbxRoles);
            this.Controls.Add(this.lblRol);
            this.Name = "SeleccionRol";
            this.Text = "SeleccionRol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SeleccionRol_FormClosed);
            this.Load += new System.EventHandler(this.SeleccionRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErrorRol;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}