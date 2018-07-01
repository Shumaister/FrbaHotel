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
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConsumibles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(649, -3);
            this.logo.Size = new System.Drawing.Size(10, 19);
            // 
            // CodReservaL
            // 
            this.CodReservaL.AutoSize = true;
            this.CodReservaL.Location = new System.Drawing.Point(12, 19);
            this.CodReservaL.Name = "CodReservaL";
            this.CodReservaL.Size = new System.Drawing.Size(104, 13);
            this.CodReservaL.TabIndex = 1;
            this.CodReservaL.Text = "Codigo de Reserva :";
            // 
            // CodReserva
            // 
            this.CodReserva.Location = new System.Drawing.Point(122, 16);
            this.CodReserva.MaxLength = 13;
            this.CodReserva.Name = "CodReserva";
            this.CodReserva.Size = new System.Drawing.Size(100, 20);
            this.CodReserva.TabIndex = 2;
            this.CodReserva.TextChanged += new System.EventHandler(this.CodReserva_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataConsumibles);
            this.groupBox1.Controls.Add(this.SubTotal);
            this.groupBox1.Controls.Add(this.sub);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 262);
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
            this.dataConsumibles.Size = new System.Drawing.Size(403, 227);
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
            this.sub.Location = new System.Drawing.Point(225, 246);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(46, 13);
            this.sub.TabIndex = 5;
            this.sub.Text = "Subtotal";
            this.sub.Click += new System.EventHandler(this.sub_Click);
            // 
            // RegimenPrecio
            // 
            this.RegimenPrecio.AutoSize = true;
            this.RegimenPrecio.Location = new System.Drawing.Point(265, 34);
            this.RegimenPrecio.Name = "RegimenPrecio";
            this.RegimenPrecio.Size = new System.Drawing.Size(37, 13);
            this.RegimenPrecio.TabIndex = 23;
            this.RegimenPrecio.Text = "Precio";
            // 
            // DiasRegimen
            // 
            this.DiasRegimen.AutoSize = true;
            this.DiasRegimen.Location = new System.Drawing.Point(173, 34);
            this.DiasRegimen.Name = "DiasRegimen";
            this.DiasRegimen.Size = new System.Drawing.Size(86, 13);
            this.DiasRegimen.TabIndex = 22;
            this.DiasRegimen.Text = "Cantidad de dias";
            // 
            // Regimen
            // 
            this.Regimen.AutoSize = true;
            this.Regimen.Location = new System.Drawing.Point(9, 34);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(49, 13);
            this.Regimen.TabIndex = 5;
            this.Regimen.Text = "Regimen";
            // 
            // allInclusivePrecio
            // 
            this.allInclusivePrecio.AutoSize = true;
            this.allInclusivePrecio.Location = new System.Drawing.Point(268, 73);
            this.allInclusivePrecio.Name = "allInclusivePrecio";
            this.allInclusivePrecio.Size = new System.Drawing.Size(0, 13);
            this.allInclusivePrecio.TabIndex = 21;
            // 
            // allinclusivecant
            // 
            this.allinclusivecant.AutoSize = true;
            this.allinclusivecant.Location = new System.Drawing.Point(178, 73);
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
            this.button1.Location = new System.Drawing.Point(268, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(15, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 202);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regimen y Habitación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Cantidad";
            // 
            // subRegimenPrecio
            // 
            this.subRegimenPrecio.AutoSize = true;
            this.subRegimenPrecio.Location = new System.Drawing.Point(302, 148);
            this.subRegimenPrecio.Name = "subRegimenPrecio";
            this.subRegimenPrecio.Size = new System.Drawing.Size(0, 13);
            this.subRegimenPrecio.TabIndex = 24;
            // 
            // subRegimen
            // 
            this.subRegimen.AutoSize = true;
            this.subRegimen.Location = new System.Drawing.Point(222, 148);
            this.subRegimen.Name = "subRegimen";
            this.subRegimen.Size = new System.Drawing.Size(46, 13);
            this.subRegimen.TabIndex = 19;
            this.subRegimen.Text = "Subtotal";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(24, 634);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(31, 13);
            this.Total.TabIndex = 25;
            this.Total.Text = "Total";
            // 
            // TotalNumero
            // 
            this.TotalNumero.AutoSize = true;
            this.TotalNumero.Location = new System.Drawing.Point(75, 634);
            this.TotalNumero.Name = "TotalNumero";
            this.TotalNumero.Size = new System.Drawing.Size(44, 13);
            this.TotalNumero.TabIndex = 26;
            this.TotalNumero.Text = "Numero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 634);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Metodo de Pago";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tarjeta",
            "Efectivo"});
            this.comboBox1.Location = new System.Drawing.Point(286, 631);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 631);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Pagar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Días Utilizados";
            // 
            // diasUtilizados
            // 
            this.diasUtilizados.AutoSize = true;
            this.diasUtilizados.Location = new System.Drawing.Point(122, 61);
            this.diasUtilizados.Name = "diasUtilizados";
            this.diasUtilizados.Size = new System.Drawing.Size(0, 13);
            this.diasUtilizados.TabIndex = 31;
            // 
            // VentanaFacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 679);
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
            this.Text = "VentanaFacturarEstadia";
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
    }
}