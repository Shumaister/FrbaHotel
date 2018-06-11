namespace FrbaHotel.Login
{
    partial class VentanaSeleccionRolHotel
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
            this.btnIngresarRol = new System.Windows.Forms.Button();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(106, 12);
            // 
            // btnIngresarRol
            // 
            this.btnIngresarRol.Location = new System.Drawing.Point(138, 322);
            this.btnIngresarRol.Name = "btnIngresarRol";
            this.btnIngresarRol.Size = new System.Drawing.Size(91, 23);
            this.btnIngresarRol.TabIndex = 12;
            this.btnIngresarRol.Text = "Ingresar";
            this.btnIngresarRol.UseVisualStyleBackColor = true;
            this.btnIngresarRol.Click += new System.EventHandler(this.btnIngresarRol_Click);
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(28, 208);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(322, 21);
            this.cbxRoles.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(118, 176);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(142, 13);
            this.lblRol.TabIndex = 10;
            this.lblRol.Text = "Por favor,  seleccione un rol.";
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(28, 277);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(322, 21);
            this.cbxHoteles.TabIndex = 15;
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(116, 248);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(154, 13);
            this.lblHotel.TabIndex = 14;
            this.lblHotel.Text = "Por favor,  seleccione un hotel.";
            // 
            // VentanaSeleccionRolHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(382, 361);
            this.Controls.Add(this.cbxHoteles);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.btnIngresarRol);
            this.Controls.Add(this.cbxRoles);
            this.Controls.Add(this.lblRol);
            this.Name = "VentanaSeleccionRolHotel";
            this.Text = "Seleccion - FRBA Hotel ©";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaSeleccionRol_FormClosed);
            this.Load += new System.EventHandler(this.VentanaSeleccionRolHotel_Load);
            this.Controls.SetChildIndex(this.lblRol, 0);
            this.Controls.SetChildIndex(this.cbxRoles, 0);
            this.Controls.SetChildIndex(this.btnIngresarRol, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.lblHotel, 0);
            this.Controls.SetChildIndex(this.cbxHoteles, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarRol;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.Label lblHotel;
    }
}