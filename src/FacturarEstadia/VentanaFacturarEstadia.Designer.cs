namespace FrbaHotel.FacturarEstadia
{
    partial class VentanaFacturarEstadia
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
            this.CodReservaL = new System.Windows.Forms.Label();
            this.CodReserva = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataConsumibles = new System.Windows.Forms.DataGridView();
            this.SubTotal = new System.Windows.Forms.Label();
            this.sub = new System.Windows.Forms.Label();
            this.RegimenPrecio = new System.Windows.Forms.Label();
            this.DiasRegimen = new System.Windows.Forms.Label();
            this.Regimen = new System.Windows.Forms.Label();
            this.allInclusivePrecio = new System.Windows.Forms.Label();
            this.allinclusivecant = new System.Windows.Forms.Label();
            this.allInclusive = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subRegimenPrecio = new System.Windows.Forms.Label();
            this.subRegimen = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.TotalNumero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.diasUtilizados = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConsumibles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(797, 12);
            this.logo.Size = new System.Drawing.Size(72, 55);
            // 
            // CodReservaL
            // 
            this.CodReservaL.AutoSize = true;
            this.CodReservaL.Location = new System.Drawing.Point(12, 50);
            this.CodReservaL.Name = "CodReservaL";
            this.CodReservaL.Size = new System.Drawing.Size(104, 13);
            this.CodReservaL.TabIndex = 1;
            this.CodReservaL.Text = "Codigo de Reserva :";
            // 
            // CodReserva
            // 
            this.CodReserva.Location = new System.Drawing.Point(140, 47);
            this.CodReserva.MaxLength = 18;
            this.CodReserva.Name = "CodReserva";
            this.CodReserva.Size = new System.Drawing.Size(125, 20);
            this.CodReserva.TabIndex = 2;
            this.CodReserva.TextChanged += new System.EventHandler(this.CodReserva_TextChanged);
            this.CodReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodReserva_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataConsumibles);
            this.groupBox1.Controls.Add(this.SubTotal);
            this.groupBox1.Controls.Add(this.sub);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 374);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Factura";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataConsumibles
            // 
            this.dataConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConsumibles.Location = new System.Drawing.Point(9, 16);
            this.dataConsumibles.Name = "dataConsumibles";
            this.dataConsumibles.ReadOnly = true;
            this.dataConsumibles.RowHeadersVisible = false;
            this.dataConsumibles.Size = new System.Drawing.Size(403, 337);
            this.dataConsumibles.TabIndex = 19;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSize = true;
            this.SubTotal.Location = new System.Drawing.Point(305, 246);
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.Size = new System.Drawing.Size(0, 13);
            this.SubTotal.TabIndex = 6;
            // 
            // sub
            // 
            this.sub.AutoSize = true;
            this.sub.Location = new System.Drawing.Point(228, 356);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(46, 13);
            this.sub.TabIndex = 5;
            this.sub.Text = "Subtotal";
            this.sub.Click += new System.EventHandler(this.sub_Click);
            // 
            // RegimenPrecio
            // 
            this.RegimenPrecio.AutoSize = true;
            this.RegimenPrecio.Location = new System.Drawing.Point(265, 47);
            this.RegimenPrecio.Name = "RegimenPrecio";
            this.RegimenPrecio.Size = new System.Drawing.Size(37, 13);
            this.RegimenPrecio.TabIndex = 23;
            this.RegimenPrecio.Text = "Precio";
            // 
            // DiasRegimen
            // 
            this.DiasRegimen.AutoSize = true;
            this.DiasRegimen.Location = new System.Drawing.Point(173, 47);
            this.DiasRegimen.Name = "DiasRegimen";
            this.DiasRegimen.Size = new System.Drawing.Size(86, 13);
            this.DiasRegimen.TabIndex = 22;
            this.DiasRegimen.Text = "Cantidad de dias";
            // 
            // Regimen
            // 
            this.Regimen.AutoSize = true;
            this.Regimen.Location = new System.Drawing.Point(9, 47);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(49, 13);
            this.Regimen.TabIndex = 5;
            this.Regimen.Text = "Regimen";
            // 
            // allInclusivePrecio
            // 
            this.allInclusivePrecio.AutoSize = true;
            this.allInclusivePrecio.Location = new System.Drawing.Point(268, 86);
            this.allInclusivePrecio.Name = "allInclusivePrecio";
            this.allInclusivePrecio.Size = new System.Drawing.Size(0, 13);
            this.allInclusivePrecio.TabIndex = 21;
            // 
            // allinclusivecant
            // 
            this.allinclusivecant.AutoSize = true;
            this.allinclusivecant.Location = new System.Drawing.Point(178, 86);
            this.allinclusivecant.Name = "allinclusivecant";
            this.allinclusivecant.Size = new System.Drawing.Size(0, 13);
            this.allinclusivecant.TabIndex = 20;
            // 
            // allInclusive
            // 
            this.allInclusive.AutoSize = true;
            this.allInclusive.Location = new System.Drawing.Point(9, 74);
            this.allInclusive.Name = "allInclusive";
            this.allInclusive.Size = new System.Drawing.Size(0, 13);
            this.allInclusive.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.subRegimenPrecio);
            this.groupBox2.Controls.Add(this.subRegimen);
            this.groupBox2.Controls.Add(this.RegimenPrecio);
            this.groupBox2.Controls.Add(this.Regimen);
            this.groupBox2.Controls.Add(this.DiasRegimen);
            this.groupBox2.Controls.Add(this.allInclusive);
            this.groupBox2.Controls.Add(this.allinclusivecant);
            this.groupBox2.Controls.Add(this.allInclusivePrecio);
            this.groupBox2.Location = new System.Drawing.Point(449, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 220);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regimen y Habitación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "CantidadHuespedes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Huespedes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Porcentual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tipo Habitacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Cantidad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // subRegimenPrecio
            // 
            this.subRegimenPrecio.AutoSize = true;
            this.subRegimenPrecio.Location = new System.Drawing.Point(302, 168);
            this.subRegimenPrecio.Name = "subRegimenPrecio";
            this.subRegimenPrecio.Size = new System.Drawing.Size(0, 13);
            this.subRegimenPrecio.TabIndex = 24;
            // 
            // subRegimen
            // 
            this.subRegimen.AutoSize = true;
            this.subRegimen.Location = new System.Drawing.Point(222, 189);
            this.subRegimen.Name = "subRegimen";
            this.subRegimen.Size = new System.Drawing.Size(46, 13);
            this.subRegimen.TabIndex = 19;
            this.subRegimen.Text = "Subtotal";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(461, 416);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(46, 18);
            this.Total.TabIndex = 25;
            this.Total.Text = "Total";
            // 
            // TotalNumero
            // 
            this.TotalNumero.AutoSize = true;
            this.TotalNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalNumero.Location = new System.Drawing.Point(600, 416);
            this.TotalNumero.Name = "TotalNumero";
            this.TotalNumero.Size = new System.Drawing.Size(68, 18);
            this.TotalNumero.TabIndex = 26;
            this.TotalNumero.Text = "Numero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Metodo de Pago";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tarjeta",
            "Efectivo"});
            this.comboBox1.Location = new System.Drawing.Point(557, 346);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(772, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 40);
            this.button2.TabIndex = 29;
            this.button2.Text = "Pagar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Días Utilizados";
            // 
            // diasUtilizados
            // 
            this.diasUtilizados.AutoSize = true;
            this.diasUtilizados.Location = new System.Drawing.Point(122, 76);
            this.diasUtilizados.Name = "diasUtilizados";
            this.diasUtilizados.Size = new System.Drawing.Size(0, 13);
            this.diasUtilizados.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(554, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 18);
            this.label9.TabIndex = 32;
            this.label9.Text = "U$S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(12, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 311;
            this.label10.Text = "Facturar Reserva";
            // 
            // VentanaFacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(881, 483);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.diasUtilizados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalNumero);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CodReserva);
            this.Controls.Add(this.CodReservaL);
            this.Name = "VentanaFacturarEstadia";
            this.Text = "Facturas - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaFacturarEstadia_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.CodReservaL, 0);
            this.Controls.SetChildIndex(this.CodReserva, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.Total, 0);
            this.Controls.SetChildIndex(this.TotalNumero, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.diasUtilizados, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConsumibles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CodReservaL;
        private System.Windows.Forms.TextBox CodReserva;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label sub;
        private System.Windows.Forms.Label SubTotal;
        private System.Windows.Forms.Label allInclusivePrecio;
        private System.Windows.Forms.Label allinclusivecant;
        private System.Windows.Forms.Label allInclusive;
        private System.Windows.Forms.Label RegimenPrecio;
        private System.Windows.Forms.Label DiasRegimen;
        private System.Windows.Forms.Label Regimen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label subRegimen;
        private System.Windows.Forms.Label subRegimenPrecio;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label TotalNumero;
        private System.Windows.Forms.DataGridView dataConsumibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label diasUtilizados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}