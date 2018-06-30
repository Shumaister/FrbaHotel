namespace FrbaHotel.RegistrarEstadia
{
    partial class VentanaRegistrarEstadia
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbxNumeroReserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblRegimenDescripcion = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblHotelNombre = new System.Windows.Forms.Label();
            this.lblHotel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = null;
            this.logo.Location = new System.Drawing.Point(322, 305);
            this.logo.Size = new System.Drawing.Size(21, 22);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(33, 17);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(132, 16);
            this.label32.TabIndex = 267;
            this.label32.Text = "Datos de la Reserva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(72, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 22);
            this.label4.TabIndex = 266;
            this.label4.Text = "*";
            // 
            // tbxNumeroReserva
            // 
            this.tbxNumeroReserva.Location = new System.Drawing.Point(36, 77);
            this.tbxNumeroReserva.Name = "tbxNumeroReserva";
            this.tbxNumeroReserva.Size = new System.Drawing.Size(129, 20);
            this.tbxNumeroReserva.TabIndex = 265;
            this.tbxNumeroReserva.TextChanged += new System.EventHandler(this.tbxNumeroReserva_TextChanged);
            this.tbxNumeroReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumeroReserva_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Codigo";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(54, 188);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(110, 23);
            this.btnCheckIn.TabIndex = 268;
            this.btnCheckIn.Text = "Registrar ingreso";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(203, 188);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(99, 23);
            this.btnCheckOut.TabIndex = 269;
            this.btnCheckOut.Text = "Registrar egreso";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblRegimenDescripcion
            // 
            this.lblRegimenDescripcion.AutoSize = true;
            this.lblRegimenDescripcion.Location = new System.Drawing.Point(88, 147);
            this.lblRegimenDescripcion.Name = "lblRegimenDescripcion";
            this.lblRegimenDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblRegimenDescripcion.TabIndex = 275;
            this.lblRegimenDescripcion.Text = "Descripcion";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(33, 147);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(55, 13);
            this.lblRegimen.TabIndex = 274;
            this.lblRegimen.Text = "Regimen :";
            // 
            // lblHotelNombre
            // 
            this.lblHotelNombre.AutoSize = true;
            this.lblHotelNombre.Location = new System.Drawing.Point(73, 119);
            this.lblHotelNombre.Name = "lblHotelNombre";
            this.lblHotelNombre.Size = new System.Drawing.Size(44, 13);
            this.lblHotelNombre.TabIndex = 271;
            this.lblHotelNombre.Text = "Nombre";
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(33, 119);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(38, 13);
            this.lblHotel.TabIndex = 270;
            this.lblHotel.Text = "Hotel :";
            // 
            // VentanaRegistrarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 233);
            this.Controls.Add(this.lblRegimenDescripcion);
            this.Controls.Add(this.lblRegimen);
            this.Controls.Add(this.lblHotelNombre);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxNumeroReserva);
            this.Controls.Add(this.label1);
            this.Name = "VentanaRegistrarEstadia";
            this.Text = "Registrar estadia - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.VentanaRegistrarEstadia_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxNumeroReserva, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.btnCheckIn, 0);
            this.Controls.SetChildIndex(this.btnCheckOut, 0);
            this.Controls.SetChildIndex(this.lblHotel, 0);
            this.Controls.SetChildIndex(this.lblHotelNombre, 0);
            this.Controls.SetChildIndex(this.lblRegimen, 0);
            this.Controls.SetChildIndex(this.lblRegimenDescripcion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxNumeroReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblRegimenDescripcion;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblHotelNombre;
        private System.Windows.Forms.Label lblHotel;
    }
}