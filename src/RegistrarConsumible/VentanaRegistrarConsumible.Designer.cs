namespace FrbaHotel.RegistrarConsumible
{
    partial class VentanaRegistrarConsumible
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
            this.TextHotel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextHabitacion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextRegimen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextEstadia = new System.Windows.Forms.TextBox();
            this.ConsumibleCombo = new System.Windows.Forms.ComboBox();
            this.TextCantidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(243, 137);
            this.logo.Size = new System.Drawing.Size(22, 20);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estadia ID :";
            // 
            // TextHotel
            // 
            this.TextHotel.AutoSize = true;
            this.TextHotel.Location = new System.Drawing.Point(78, 39);
            this.TextHotel.Name = "TextHotel";
            this.TextHotel.Size = new System.Drawing.Size(0, 13);
            this.TextHotel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hotel :";
            // 
            // TextHabitacion
            // 
            this.TextHabitacion.AutoSize = true;
            this.TextHabitacion.Location = new System.Drawing.Point(78, 73);
            this.TextHabitacion.Name = "TextHabitacion";
            this.TextHabitacion.Size = new System.Drawing.Size(0, 13);
            this.TextHabitacion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Habitacion : ";
            // 
            // TextRegimen
            // 
            this.TextRegimen.AutoSize = true;
            this.TextRegimen.Location = new System.Drawing.Point(78, 105);
            this.TextRegimen.Name = "TextRegimen";
            this.TextRegimen.Size = new System.Drawing.Size(0, 13);
            this.TextRegimen.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Regimen :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Consumible";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Cantidad";
            // 
            // TextEstadia
            // 
            this.TextEstadia.Location = new System.Drawing.Point(81, 9);
            this.TextEstadia.Name = "TextEstadia";
            this.TextEstadia.Size = new System.Drawing.Size(121, 20);
            this.TextEstadia.TabIndex = 11;
            this.TextEstadia.TextChanged += new System.EventHandler(this.TextEstadia_TextChanged_1);
            // 
            // ConsumibleCombo
            // 
            this.ConsumibleCombo.FormattingEnabled = true;
            this.ConsumibleCombo.Items.AddRange(new object[] {
            "Coca Cola",
            "Whisky",
            "Bonbones",
            "Agua Mineral"});
            this.ConsumibleCombo.Location = new System.Drawing.Point(81, 137);
            this.ConsumibleCombo.Name = "ConsumibleCombo";
            this.ConsumibleCombo.Size = new System.Drawing.Size(121, 21);
            this.ConsumibleCombo.TabIndex = 12;
            // 
            // TextCantidad
            // 
            this.TextCantidad.Location = new System.Drawing.Point(81, 173);
            this.TextCantidad.Name = "TextCantidad";
            this.TextCantidad.Size = new System.Drawing.Size(32, 20);
            this.TextCantidad.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VentanaRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextCantidad);
            this.Controls.Add(this.ConsumibleCombo);
            this.Controls.Add(this.TextEstadia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TextRegimen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TextHabitacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextHotel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "VentanaRegistrarConsumible";
            this.Text = "Registrar Consumibles";
            this.Load += new System.EventHandler(this.VentanaRegistrarConsumible_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.TextHotel, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.TextHabitacion, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.TextRegimen, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.TextEstadia, 0);
            this.Controls.SetChildIndex(this.ConsumibleCombo, 0);
            this.Controls.SetChildIndex(this.TextCantidad, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.logo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TextHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TextHabitacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TextRegimen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextEstadia;
        private System.Windows.Forms.ComboBox ConsumibleCombo;
        private System.Windows.Forms.TextBox TextCantidad;
        private System.Windows.Forms.Button button1;
    }
}