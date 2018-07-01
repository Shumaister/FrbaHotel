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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregarConsumible = new System.Windows.Forms.Button();
            this.btnGuardarConsumibles = new System.Windows.Forms.Button();
            this.btnLimpiarConsumibles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxConsumibles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvConsumibles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(19, 292);
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
            this.label5.Location = new System.Drawing.Point(132, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 274;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(202, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 273;
            this.label4.Text = "*";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(158, 70);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(75, 20);
            this.tbxCantidad.TabIndex = 271;
            // 
            // btnAgregarConsumible
            // 
            this.btnAgregarConsumible.Location = new System.Drawing.Point(257, 67);
            this.btnAgregarConsumible.Name = "btnAgregarConsumible";
            this.btnAgregarConsumible.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarConsumible.TabIndex = 270;
            this.btnAgregarConsumible.Text = "Agregar";
            this.btnAgregarConsumible.UseVisualStyleBackColor = true;
            this.btnAgregarConsumible.Click += new System.EventHandler(this.btnAgregarConsumible_Click);
            // 
            // btnGuardarConsumibles
            // 
            this.btnGuardarConsumibles.Location = new System.Drawing.Point(210, 311);
            this.btnGuardarConsumibles.Name = "btnGuardarConsumibles";
            this.btnGuardarConsumibles.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarConsumibles.TabIndex = 268;
            this.btnGuardarConsumibles.Text = "Guardar";
            this.btnGuardarConsumibles.UseVisualStyleBackColor = true;
            this.btnGuardarConsumibles.Click += new System.EventHandler(this.btnGuardarConsumibles_Click);
            // 
            // btnLimpiarConsumibles
            // 
            this.btnLimpiarConsumibles.Location = new System.Drawing.Point(90, 311);
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
            this.cbxConsumibles.FormattingEnabled = true;
            this.cbxConsumibles.Location = new System.Drawing.Point(19, 70);
            this.cbxConsumibles.Name = "cbxConsumibles";
            this.cbxConsumibles.Size = new System.Drawing.Size(121, 21);
            this.cbxConsumibles.TabIndex = 265;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 276;
            this.label3.Text = "Consumibles a registrar";
            // 
            // dgvConsumibles
            // 
            this.dgvConsumibles.AllowUserToAddRows = false;
            this.dgvConsumibles.AllowUserToDeleteRows = false;
            this.dgvConsumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsumibles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConsumibles.Location = new System.Drawing.Point(18, 132);
            this.dgvConsumibles.Name = "dgvConsumibles";
            this.dgvConsumibles.ReadOnly = true;
            this.dgvConsumibles.RowHeadersVisible = false;
            this.dgvConsumibles.Size = new System.Drawing.Size(324, 162);
            this.dgvConsumibles.TabIndex = 277;
            // 
            // VentanaRegistrarConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 350);
            this.Controls.Add(this.dgvConsumibles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dgvConsumibles, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Button btnAgregarConsumible;
        private System.Windows.Forms.Button btnGuardarConsumibles;
        private System.Windows.Forms.Button btnLimpiarConsumibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxConsumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvConsumibles;
    }
}