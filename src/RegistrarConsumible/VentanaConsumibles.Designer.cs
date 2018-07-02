namespace FrbaHotel.RegistrarConsumible
{
    partial class VentanaConsumibles
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
            this.lblHotel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxReserva = new System.Windows.Forms.TextBox();
            this.cbxHabitacion = new System.Windows.Forms.ComboBox();
            this.btnRegistrarConsumibles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(394, 233);
            this.logo.Size = new System.Drawing.Size(22, 20);
            this.logo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de reserva";
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(56, 90);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(73, 13);
            this.lblHotel.TabIndex = 3;
            this.lblHotel.Text = "Estadia_Hotel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hotel :";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(73, 117);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(90, 13);
            this.lblRegimen.TabIndex = 7;
            this.lblRegimen.Text = "Estadia_Regimen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Regimen :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Habitacion";
            // 
            // tbxReserva
            // 
            this.tbxReserva.Location = new System.Drawing.Point(15, 59);
            this.tbxReserva.MaxLength = 17;
            this.tbxReserva.Name = "tbxReserva";
            this.tbxReserva.Size = new System.Drawing.Size(111, 20);
            this.tbxReserva.TabIndex = 11;
            this.tbxReserva.TextChanged += new System.EventHandler(this.tbxReserva_TextChanged);
            this.tbxReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReserva_KeyPress);
            // 
            // cbxHabitacion
            // 
            this.cbxHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHabitacion.FormattingEnabled = true;
            this.cbxHabitacion.Location = new System.Drawing.Point(15, 168);
            this.cbxHabitacion.Name = "cbxHabitacion";
            this.cbxHabitacion.Size = new System.Drawing.Size(111, 21);
            this.cbxHabitacion.TabIndex = 12;
            // 
            // btnRegistrarConsumibles
            // 
            this.btnRegistrarConsumibles.Location = new System.Drawing.Point(84, 212);
            this.btnRegistrarConsumibles.Name = "btnRegistrarConsumibles";
            this.btnRegistrarConsumibles.Size = new System.Drawing.Size(129, 23);
            this.btnRegistrarConsumibles.TabIndex = 15;
            this.btnRegistrarConsumibles.Text = "Registrar consumibles";
            this.btnRegistrarConsumibles.UseVisualStyleBackColor = true;
            this.btnRegistrarConsumibles.Click += new System.EventHandler(this.btnRegistrarConsumibles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(69, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 22);
            this.label2.TabIndex = 274;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(107, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 22);
            this.label3.TabIndex = 275;
            this.label3.Text = "*";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(12, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(54, 16);
            this.label32.TabIndex = 276;
            this.label32.Text = "Estadia";
            // 
            // VentanaConsumibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 252);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistrarConsumibles);
            this.Controls.Add(this.cbxHabitacion);
            this.Controls.Add(this.tbxReserva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblRegimen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "VentanaConsumibles";
            this.Text = "Consumibles - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRegistrarConsumible_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblHotel, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblRegimen, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.tbxReserva, 0);
            this.Controls.SetChildIndex(this.cbxHabitacion, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.btnRegistrarConsumibles, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxReserva;
        private System.Windows.Forms.ComboBox cbxHabitacion;
        private System.Windows.Forms.Button btnRegistrarConsumibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label32;
    }
}