namespace FrbaHotel.CancelarReserva
{
    partial class VentanaCancelarReserva
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.tbxMotivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblErrorIngresoReserva = new System.Windows.Forms.Label();
            this.btnIngresoNroReserva = new System.Windows.Forms.Button();
            this.tbxNumeroReserva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(352, 0);
            this.logo.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.btnCancelarReserva);
            this.groupBox1.Controls.Add(this.btnLimpiarCampos);
            this.groupBox1.Controls.Add(this.tbxMotivo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblErrorIngresoReserva);
            this.groupBox1.Controls.Add(this.btnIngresoNroReserva);
            this.groupBox1.Controls.Add(this.tbxNumeroReserva);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 498);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(142, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 22);
            this.label13.TabIndex = 348;
            this.label13.Text = "*";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(171, 194);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(35, 13);
            this.lblFecha.TabIndex = 347;
            this.lblFecha.Text = "--/--/--";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(171, 243);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(10, 13);
            this.lblUsuario.TabIndex = 346;
            this.lblUsuario.Text = "-";
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarReserva.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelarReserva.Location = new System.Drawing.Point(238, 443);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(112, 40);
            this.btnCancelarReserva.TabIndex = 345;
            this.btnCancelarReserva.Text = "Confirmar Cancelacion";
            this.btnCancelarReserva.UseVisualStyleBackColor = false;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Location = new System.Drawing.Point(25, 460);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(97, 23);
            this.btnLimpiarCampos.TabIndex = 344;
            this.btnLimpiarCampos.Text = "Limpiar";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // tbxMotivo
            // 
            this.tbxMotivo.Location = new System.Drawing.Point(174, 295);
            this.tbxMotivo.MaxLength = 250;
            this.tbxMotivo.Multiline = true;
            this.tbxMotivo.Name = "tbxMotivo";
            this.tbxMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMotivo.Size = new System.Drawing.Size(176, 117);
            this.tbxMotivo.TabIndex = 342;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 341;
            this.label5.Text = "Motivo:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 340;
            this.label4.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 339;
            this.label3.Text = "Fecha cancelacion:";
            // 
            // lblErrorIngresoReserva
            // 
            this.lblErrorIngresoReserva.AutoSize = true;
            this.lblErrorIngresoReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorIngresoReserva.ForeColor = System.Drawing.Color.Red;
            this.lblErrorIngresoReserva.Location = new System.Drawing.Point(13, 104);
            this.lblErrorIngresoReserva.Name = "lblErrorIngresoReserva";
            this.lblErrorIngresoReserva.Size = new System.Drawing.Size(38, 13);
            this.lblErrorIngresoReserva.TabIndex = 338;
            this.lblErrorIngresoReserva.Text = "Error ";
            this.lblErrorIngresoReserva.Visible = false;
            // 
            // btnIngresoNroReserva
            // 
            this.btnIngresoNroReserva.Location = new System.Drawing.Point(228, 125);
            this.btnIngresoNroReserva.Name = "btnIngresoNroReserva";
            this.btnIngresoNroReserva.Size = new System.Drawing.Size(122, 23);
            this.btnIngresoNroReserva.TabIndex = 313;
            this.btnIngresoNroReserva.Text = "Ingresar reserva";
            this.btnIngresoNroReserva.UseVisualStyleBackColor = true;
            this.btnIngresoNroReserva.Click += new System.EventHandler(this.btnIngresoNroReserva_Click);
            // 
            // tbxNumeroReserva
            // 
            this.tbxNumeroReserva.Location = new System.Drawing.Point(174, 65);
            this.tbxNumeroReserva.MaxLength = 18;
            this.tbxNumeroReserva.Name = "tbxNumeroReserva";
            this.tbxNumeroReserva.Size = new System.Drawing.Size(176, 20);
            this.tbxNumeroReserva.TabIndex = 312;
            this.tbxNumeroReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidadHuespedes_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Ingrese Nro de su reserva:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 310;
            this.label1.Text = "Cancelar Reserva";
            // 
            // VentanaCancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 522);
            this.Controls.Add(this.groupBox1);
            this.Name = "VentanaCancelarReserva";
            this.Text = "Cancelar Reserva - FRBA Hotel ©";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.logo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controladorError)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIngresoNroReserva;
        private System.Windows.Forms.TextBox tbxNumeroReserva;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.TextBox tbxMotivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblErrorIngresoReserva;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label13;
    }
}