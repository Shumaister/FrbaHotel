namespace FrbaHotel.RegistrarConsumible
{
    partial class VentanaRegistrarConsumibles
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
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregarConsumible = new System.Windows.Forms.Button();
            this.btnGuardarConsumibles = new System.Windows.Forms.Button();
            this.btnLimpiarConsumibles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxConsumibles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxConsumibles = new System.Windows.Forms.ListBox();
            this.btnQuitarConsumible = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(299, 252);
            this.logo.Size = new System.Drawing.Size(35, 31);
            this.logo.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(16, 13);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(86, 16);
            this.label32.TabIndex = 275;
            this.label32.Text = "Consumibles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(132, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 274;
            this.label5.Text = "*";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(162, 70);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.ShortcutsEnabled = false;
            this.tbxCantidad.Size = new System.Drawing.Size(75, 20);
            this.tbxCantidad.TabIndex = 271;
            // 
            // btnAgregarConsumible
            // 
            this.btnAgregarConsumible.Location = new System.Drawing.Point(259, 70);
            this.btnAgregarConsumible.Name = "btnAgregarConsumible";
            this.btnAgregarConsumible.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarConsumible.TabIndex = 270;
            this.btnAgregarConsumible.Text = "Agregar";
            this.btnAgregarConsumible.UseVisualStyleBackColor = true;
            this.btnAgregarConsumible.Click += new System.EventHandler(this.btnAgregarConsumible_Click);
            // 
            // btnGuardarConsumibles
            // 
            this.btnGuardarConsumibles.Location = new System.Drawing.Point(195, 260);
            this.btnGuardarConsumibles.Name = "btnGuardarConsumibles";
            this.btnGuardarConsumibles.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarConsumibles.TabIndex = 268;
            this.btnGuardarConsumibles.Text = "Guardar";
            this.btnGuardarConsumibles.UseVisualStyleBackColor = true;
            this.btnGuardarConsumibles.Click += new System.EventHandler(this.btnGuardarConsumibles_Click);
            // 
            // btnLimpiarConsumibles
            // 
            this.btnLimpiarConsumibles.Location = new System.Drawing.Point(75, 260);
            this.btnLimpiarConsumibles.Name = "btnLimpiarConsumibles";
            this.btnLimpiarConsumibles.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarConsumibles.TabIndex = 267;
            this.btnLimpiarConsumibles.Text = "Limpiar";
            this.btnLimpiarConsumibles.UseVisualStyleBackColor = true;
            this.btnLimpiarConsumibles.Click += new System.EventHandler(this.btnLimpiarConsumibles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 266;
            this.label2.Text = "Consumible";
            // 
            // cbxConsumibles
            // 
            this.cbxConsumibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsumibles.FormattingEnabled = true;
            this.cbxConsumibles.Location = new System.Drawing.Point(19, 70);
            this.cbxConsumibles.Name = "cbxConsumibles";
            this.cbxConsumibles.Size = new System.Drawing.Size(121, 21);
            this.cbxConsumibles.TabIndex = 265;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 276;
            this.label3.Text = "Consumibles a registrar";
            // 
            // lbxConsumibles
            // 
            this.lbxConsumibles.FormattingEnabled = true;
            this.lbxConsumibles.Location = new System.Drawing.Point(19, 138);
            this.lbxConsumibles.Name = "lbxConsumibles";
            this.lbxConsumibles.Size = new System.Drawing.Size(218, 95);
            this.lbxConsumibles.TabIndex = 277;
            // 
            // btnQuitarConsumible
            // 
            this.btnQuitarConsumible.Location = new System.Drawing.Point(259, 138);
            this.btnQuitarConsumible.Name = "btnQuitarConsumible";
            this.btnQuitarConsumible.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarConsumible.TabIndex = 278;
            this.btnQuitarConsumible.Text = "Quitar";
            this.btnQuitarConsumible.UseVisualStyleBackColor = true;
            this.btnQuitarConsumible.Click += new System.EventHandler(this.btnQuitarConsumible_Click);
            // 
            // VentanaRegistrarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 295);
            this.Controls.Add(this.btnQuitarConsumible);
            this.Controls.Add(this.lbxConsumibles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxCantidad);
            this.Controls.Add(this.btnAgregarConsumible);
            this.Controls.Add(this.btnGuardarConsumibles);
            this.Controls.Add(this.btnLimpiarConsumibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxConsumibles);
            this.Controls.Add(this.label1);
            this.Name = "VentanaRegistrarConsumibles";
            this.Text = "Registrar consumibles - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRegistrarConsumibles_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbxConsumibles, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnLimpiarConsumibles, 0);
            this.Controls.SetChildIndex(this.btnGuardarConsumibles, 0);
            this.Controls.SetChildIndex(this.btnAgregarConsumible, 0);
            this.Controls.SetChildIndex(this.tbxCantidad, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lbxConsumibles, 0);
            this.Controls.SetChildIndex(this.btnQuitarConsumible, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Button btnAgregarConsumible;
        private System.Windows.Forms.Button btnGuardarConsumibles;
        private System.Windows.Forms.Button btnLimpiarConsumibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxConsumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxConsumibles;
        private System.Windows.Forms.Button btnQuitarConsumible;
    }
}