namespace FrbaHotel.Menus
{
    partial class VentanaMenuPrincipalClientes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.misReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(56, 65);
            this.logo.Size = new System.Drawing.Size(245, 196);
            this.logo.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.misReservasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // misReservasToolStripMenuItem
            // 
            this.misReservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaReservaToolStripMenuItem,
            this.modificarReservaToolStripMenuItem,
            this.cancelarReservaToolStripMenuItem});
            this.misReservasToolStripMenuItem.Name = "misReservasToolStripMenuItem";
            this.misReservasToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.misReservasToolStripMenuItem.Text = "Mis Reservas";
            // 
            // nuevaReservaToolStripMenuItem
            // 
            this.nuevaReservaToolStripMenuItem.Name = "nuevaReservaToolStripMenuItem";
            this.nuevaReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nuevaReservaToolStripMenuItem.Text = "Nueva Reserva";
            this.nuevaReservaToolStripMenuItem.Click += new System.EventHandler(this.nuevaReservaToolStripMenuItem_Click);
            // 
            // modificarReservaToolStripMenuItem
            // 
            this.modificarReservaToolStripMenuItem.Name = "modificarReservaToolStripMenuItem";
            this.modificarReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.modificarReservaToolStripMenuItem.Text = "Modificar Reserva";
            this.modificarReservaToolStripMenuItem.Click += new System.EventHandler(this.modificarReservaToolStripMenuItem_Click);
            // 
            // cancelarReservaToolStripMenuItem
            // 
            this.cancelarReservaToolStripMenuItem.Name = "cancelarReservaToolStripMenuItem";
            this.cancelarReservaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cancelarReservaToolStripMenuItem.Text = "Cancelar Reserva";
            this.cancelarReservaToolStripMenuItem.Click += new System.EventHandler(this.cancelarReservaToolStripMenuItem_Click);
            // 
            // VentanaMenuPrincipalClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(448, 436);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "VentanaMenuPrincipalClientes";
            this.Text = "Menu Principal - FRBA Hotel ©";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.VentanaMenuPrincipal_Load);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem misReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarReservaToolStripMenuItem;
    }
}