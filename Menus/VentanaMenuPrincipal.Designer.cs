namespace FrbaHotel.Menus
{
    partial class VentanaMenuPrincipal
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
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.regimenesEstadiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoteleriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regimenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadiasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCambiarContrasenia = new System.Windows.Forms.ToolStripMenuItem();
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
            this.administracionToolStripMenuItem,
            this.hoteleriaToolStripMenuItem,
            this.configuracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRoles,
            this.menuUsuarios,
            this.funcionalidadesToolStripMenuItem,
            this.habitacionesToolStripMenuItem1,
            this.regimenesEstadiaToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // menuRoles
            // 
            this.menuRoles.Name = "menuRoles";
            this.menuRoles.Size = new System.Drawing.Size(143, 22);
            this.menuRoles.Text = "Roles";
            this.menuRoles.Click += new System.EventHandler(this.menuRoles_Click);
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(143, 22);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // funcionalidadesToolStripMenuItem
            // 
            this.funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            this.funcionalidadesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.funcionalidadesToolStripMenuItem.Text = "Hoteles";
            // 
            // habitacionesToolStripMenuItem1
            // 
            this.habitacionesToolStripMenuItem1.Name = "habitacionesToolStripMenuItem1";
            this.habitacionesToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.habitacionesToolStripMenuItem1.Text = "Habitaciones";
            // 
            // regimenesEstadiaToolStripMenuItem
            // 
            this.regimenesEstadiaToolStripMenuItem.Name = "regimenesEstadiaToolStripMenuItem";
            this.regimenesEstadiaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.regimenesEstadiaToolStripMenuItem.Text = "Regimenes";
            // 
            // hoteleriaToolStripMenuItem
            // 
            this.hoteleriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotelesToolStripMenuItem,
            this.habitacionesToolStripMenuItem,
            this.regimenesToolStripMenuItem,
            this.estadiasToolStripMenuItem1,
            this.facturasToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.hoteleriaToolStripMenuItem.Name = "hoteleriaToolStripMenuItem";
            this.hoteleriaToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.hoteleriaToolStripMenuItem.Text = "Recepcion";
            // 
            // hotelesToolStripMenuItem
            // 
            this.hotelesToolStripMenuItem.Name = "hotelesToolStripMenuItem";
            this.hotelesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.hotelesToolStripMenuItem.Text = "Clientes";
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.habitacionesToolStripMenuItem.Text = "Reservas";
            // 
            // regimenesToolStripMenuItem
            // 
            this.regimenesToolStripMenuItem.Name = "regimenesToolStripMenuItem";
            this.regimenesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.regimenesToolStripMenuItem.Text = "Estadias";
            // 
            // estadiasToolStripMenuItem1
            // 
            this.estadiasToolStripMenuItem1.Name = "estadiasToolStripMenuItem1";
            this.estadiasToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.estadiasToolStripMenuItem1.Text = "Consumibles";
            // 
            // facturasToolStripMenuItem
            // 
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.facturasToolStripMenuItem.Text = "Facturas";
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCambiarContrasenia});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // menuCambiarContrasenia
            // 
            this.menuCambiarContrasenia.Name = "menuCambiarContrasenia";
            this.menuCambiarContrasenia.Size = new System.Drawing.Size(167, 22);
            this.menuCambiarContrasenia.Text = "Ajustes de cuenta";
            this.menuCambiarContrasenia.Click += new System.EventHandler(this.menuCambiarContrasenia_Click);
            // 
            // VentanaMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FrbaHotel.Properties.Resources.Logo_TP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1038, 796);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "VentanaMenuPrincipal";
            this.Text = "Menu Principal - FRBA Hotel ©";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaMenuPrincipal_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem funcionalidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoteleriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regimenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem regimenesEstadiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadiasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuCambiarContrasenia;
    }
}