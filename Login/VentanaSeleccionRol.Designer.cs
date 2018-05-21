namespace FrbaHotel.Login
{
    partial class VentanaSeleccionRol
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
            this.btnIngresarRol = new System.Windows.Forms.Button();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.btnIngresarHotel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(69, 12);
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
            // btnIngresarRol
            // 
            this.btnIngresarRol.Location = new System.Drawing.Point(215, 213);
            this.btnIngresarRol.Name = "btnIngresarRol";
            this.btnIngresarRol.Size = new System.Drawing.Size(40, 23);
            this.btnIngresarRol.TabIndex = 12;
            this.btnIngresarRol.Text = "Ok";
            this.btnIngresarRol.UseVisualStyleBackColor = true;
            this.btnIngresarRol.Click += new System.EventHandler(this.btnIngresarRol_Click);
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(25, 215);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(184, 21);
            this.cbxRoles.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(22, 189);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(142, 13);
            this.lblRol.TabIndex = 10;
            this.lblRol.Text = "Por favor,  seleccione un rol.";
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(25, 282);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(184, 21);
            this.cbxHoteles.TabIndex = 15;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(22, 256);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(151, 13);
            this.lblHotel.TabIndex = 14;
            this.lblHotel.Text = "Por favor,  seleccione un hotel";
            // 
            // btnIngresarHotel
            // 
            this.btnIngresarHotel.Location = new System.Drawing.Point(215, 282);
            this.btnIngresarHotel.Name = "btnIngresarHotel";
            this.btnIngresarHotel.Size = new System.Drawing.Size(40, 23);
            this.btnIngresarHotel.TabIndex = 16;
            this.btnIngresarHotel.Text = "Ok";
            this.btnIngresarHotel.UseVisualStyleBackColor = true;
            this.btnIngresarHotel.Click += new System.EventHandler(this.btnIngresarHotel_Click);
            // 
            // VentanaSeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(300, 378);
            this.Controls.Add(this.btnIngresarHotel);
            this.Controls.Add(this.cbxHoteles);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.lblErrorRol);
            this.Controls.Add(this.btnIngresarRol);
            this.Controls.Add(this.cbxRoles);
            this.Controls.Add(this.lblRol);
            this.Name = "VentanaSeleccionRol";
            this.Text = "SeleccionRol";
            this.Load += new System.EventHandler(this.SeleccionRol_Load);
            this.Controls.SetChildIndex(this.lblRol, 0);
            this.Controls.SetChildIndex(this.cbxRoles, 0);
            this.Controls.SetChildIndex(this.btnIngresarRol, 0);
            this.Controls.SetChildIndex(this.lblErrorRol, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.lblHotel, 0);
            this.Controls.SetChildIndex(this.cbxHoteles, 0);
            this.Controls.SetChildIndex(this.btnIngresarHotel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErrorRol;
        private System.Windows.Forms.Button btnIngresarRol;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Button btnIngresarHotel;
    }
}