namespace FrbaHotel.AbmRegimen
{
    partial class VentanaRegimenes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabRoles = new System.Windows.Forms.TabControl();
            this.tabAgregar = new System.Windows.Forms.TabPage();
            this.tbxPrecioRegimen = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDescipcionRegimen = new System.Windows.Forms.TextBox();
            this.btnGuardarRegimen = new System.Windows.Forms.Button();
            this.btnLimpiarRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabModificar = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvModificarRegimenes = new System.Windows.Forms.DataGridView();
            this.tabEliminar = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEliminarRegimenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.tabRoles.SuspendLayout();
            this.tabAgregar.SuspendLayout();
            this.tabModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarRegimenes)).BeginInit();
            this.tabEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarRegimenes)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(352, 439);
            this.logo.Size = new System.Drawing.Size(22, 10);
            // 
            // tabRoles
            // 
            this.tabRoles.Controls.Add(this.tabAgregar);
            this.tabRoles.Controls.Add(this.tabModificar);
            this.tabRoles.Controls.Add(this.tabEliminar);
            this.tabRoles.Location = new System.Drawing.Point(12, 12);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.SelectedIndex = 0;
            this.tabRoles.Size = new System.Drawing.Size(481, 291);
            this.tabRoles.TabIndex = 2;
            // 
            // tabAgregar
            // 
            this.tabAgregar.Controls.Add(this.tbxPrecioRegimen);
            this.tabAgregar.Controls.Add(this.label32);
            this.tabAgregar.Controls.Add(this.label5);
            this.tabAgregar.Controls.Add(this.label4);
            this.tabAgregar.Controls.Add(this.tbxDescipcionRegimen);
            this.tabAgregar.Controls.Add(this.btnGuardarRegimen);
            this.tabAgregar.Controls.Add(this.btnLimpiarRol);
            this.tabAgregar.Controls.Add(this.label2);
            this.tabAgregar.Controls.Add(this.label1);
            this.tabAgregar.Location = new System.Drawing.Point(4, 22);
            this.tabAgregar.Name = "tabAgregar";
            this.tabAgregar.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgregar.Size = new System.Drawing.Size(473, 265);
            this.tabAgregar.TabIndex = 0;
            this.tabAgregar.Text = " Agregar";
            this.tabAgregar.UseVisualStyleBackColor = true;
            // 
            // tbxPrecioRegimen
            // 
            this.tbxPrecioRegimen.Location = new System.Drawing.Point(271, 127);
            this.tbxPrecioRegimen.Name = "tbxPrecioRegimen";
            this.tbxPrecioRegimen.Size = new System.Drawing.Size(121, 20);
            this.tbxPrecioRegimen.TabIndex = 264;
            this.tbxPrecioRegimen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumeroCalle_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(66, 36);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(78, 16);
            this.label32.TabIndex = 263;
            this.label32.Text = "Regimenes";
            this.label32.Click += new System.EventHandler(this.label32_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(302, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 27;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(127, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "*";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbxDescipcionRegimen
            // 
            this.tbxDescipcionRegimen.Location = new System.Drawing.Point(69, 127);
            this.tbxDescipcionRegimen.Name = "tbxDescipcionRegimen";
            this.tbxDescipcionRegimen.Size = new System.Drawing.Size(121, 20);
            this.tbxDescipcionRegimen.TabIndex = 11;
            // 
            // btnGuardarRegimen
            // 
            this.btnGuardarRegimen.Location = new System.Drawing.Point(317, 203);
            this.btnGuardarRegimen.Name = "btnGuardarRegimen";
            this.btnGuardarRegimen.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRegimen.TabIndex = 8;
            this.btnGuardarRegimen.Text = "Guardar";
            this.btnGuardarRegimen.UseVisualStyleBackColor = true;
            this.btnGuardarRegimen.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnLimpiarRol
            // 
            this.btnLimpiarRol.Location = new System.Drawing.Point(69, 203);
            this.btnLimpiarRol.Name = "btnLimpiarRol";
            this.btnLimpiarRol.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarRol.TabIndex = 7;
            this.btnLimpiarRol.Text = "Limpiar";
            this.btnLimpiarRol.UseVisualStyleBackColor = true;
            this.btnLimpiarRol.Click += new System.EventHandler(this.btnLimpiarRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // tabModificar
            // 
            this.tabModificar.Controls.Add(this.label3);
            this.tabModificar.Controls.Add(this.dgvModificarRegimenes);
            this.tabModificar.Location = new System.Drawing.Point(4, 22);
            this.tabModificar.Name = "tabModificar";
            this.tabModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificar.Size = new System.Drawing.Size(473, 265);
            this.tabModificar.TabIndex = 1;
            this.tabModificar.Text = "Modificar";
            this.tabModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 264;
            this.label3.Text = "Regimenes";
            // 
            // dgvModificarRegimenes
            // 
            this.dgvModificarRegimenes.AllowUserToAddRows = false;
            this.dgvModificarRegimenes.AllowUserToDeleteRows = false;
            this.dgvModificarRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModificarRegimenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModificarRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModificarRegimenes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModificarRegimenes.Location = new System.Drawing.Point(6, 34);
            this.dgvModificarRegimenes.Name = "dgvModificarRegimenes";
            this.dgvModificarRegimenes.ReadOnly = true;
            this.dgvModificarRegimenes.RowHeadersVisible = false;
            this.dgvModificarRegimenes.Size = new System.Drawing.Size(461, 228);
            this.dgvModificarRegimenes.TabIndex = 10;
            this.dgvModificarRegimenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModificarRegimenes_CellContentClick);
            // 
            // tabEliminar
            // 
            this.tabEliminar.Controls.Add(this.label6);
            this.tabEliminar.Controls.Add(this.dgvEliminarRegimenes);
            this.tabEliminar.Location = new System.Drawing.Point(4, 22);
            this.tabEliminar.Name = "tabEliminar";
            this.tabEliminar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEliminar.Size = new System.Drawing.Size(473, 265);
            this.tabEliminar.TabIndex = 2;
            this.tabEliminar.Text = "Eliminar";
            this.tabEliminar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 265;
            this.label6.Text = "Regimenes";
            // 
            // dgvEliminarRegimenes
            // 
            this.dgvEliminarRegimenes.AllowUserToAddRows = false;
            this.dgvEliminarRegimenes.AllowUserToDeleteRows = false;
            this.dgvEliminarRegimenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEliminarRegimenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEliminarRegimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEliminarRegimenes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEliminarRegimenes.Location = new System.Drawing.Point(6, 34);
            this.dgvEliminarRegimenes.Name = "dgvEliminarRegimenes";
            this.dgvEliminarRegimenes.ReadOnly = true;
            this.dgvEliminarRegimenes.RowHeadersVisible = false;
            this.dgvEliminarRegimenes.Size = new System.Drawing.Size(461, 228);
            this.dgvEliminarRegimenes.TabIndex = 11;
            this.dgvEliminarRegimenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEliminarRegimenes_CellContentClick);
            // 
            // VentanaRegimenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 311);
            this.Controls.Add(this.tabRoles);
            this.Name = "VentanaRegimenes";
            this.Text = "Regimenes - FRBA Hotel ©";
            this.Controls.SetChildIndex(this.tabRoles, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.tabRoles.ResumeLayout(false);
            this.tabAgregar.ResumeLayout(false);
            this.tabAgregar.PerformLayout();
            this.tabModificar.ResumeLayout(false);
            this.tabModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModificarRegimenes)).EndInit();
            this.tabEliminar.ResumeLayout(false);
            this.tabEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarRegimenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRoles;
        private System.Windows.Forms.TabPage tabAgregar;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDescipcionRegimen;
        private System.Windows.Forms.Button btnGuardarRegimen;
        private System.Windows.Forms.Button btnLimpiarRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvModificarRegimenes;
        private System.Windows.Forms.TabPage tabEliminar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEliminarRegimenes;
        private System.Windows.Forms.TextBox tbxPrecioRegimen;
    }
}