using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class VentanaUsuarios : VentanaBase
    {
        //-------------------------------------- Constructores -------------------------------------

        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        //-------------------------------------- Metodos para Eventos -------------------------------------

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            VentanaBase.dataGridViewCargar(dgvModificarUsuarios, Database.usuarioObtenerTodos());
            DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
            botonModificar.HeaderText = "Seleccionar";
            botonModificar.Text = "Modificar";
            dgvModificarUsuarios.Columns.Add(botonModificar);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pagModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
