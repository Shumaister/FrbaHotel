using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Clases;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class VentanaRegistrarConsumibles : VentanaBase
    {
        public Consumido consumido { get; set; }

        public VentanaRegistrarConsumibles(Consumido consumido)
        {
            InitializeComponent();
            this.consumido = consumido;
        }

        private void btnLimpiarConsumibles_Click(object sender, EventArgs e)
        {
            tbxCantidad.Clear();
            comboBoxCargar(cbxConsumibles, Database.consumibleObtenerTodosEnLista());
            listBoxLimpiar(lbxConsumibles);
        }

        private void btnGuardarConsumibles_Click(object sender, EventArgs e)
        {
            if (lbxConsumibles.Items.Count == 0)
            {
                ventanaInformarError("Debe registrar al menos un consumible");
                return;
            }
            foreach (string dato in lbxConsumibles.Items)
            {
                string[] datos = dato.Split('-');
                consumido.consumible = datos[0];
                consumido.cantidad = datos[1];
                Database.consumidoAgregar(consumido);
            }
            ventanaInformarExito("Los consumibles fueron registrados con exito");
            this.Hide();
        }

        private void VentanaRegistrarConsumibles_Load(object sender, EventArgs e)
        {
            comboBoxCargar(cbxConsumibles, Database.consumibleObtenerTodosEnLista());
        }

        private void btnQuitarConsumible_Click(object sender, EventArgs e)
        {
            if (lbxConsumibles.SelectedItem != null)
            {
                string consumible = lbxConsumibles.SelectedItem.ToString();
                string[] datos = consumible.Split('-');
                cbxConsumibles.Items.Add(datos[0]);
                cbxConsumibles.Sorted = true;
                lbxConsumibles.Items.Remove(lbxConsumibles.SelectedItem);
                cbxConsumibles.SelectedIndex = 0;
                if (lbxConsumibles.Items.Count > 0)
                    lbxConsumibles.SelectedIndex = 0;
            }
        }

        private void btnAgregarConsumible_Click(object sender, EventArgs e)
        {
            if (cbxConsumibles.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(tbxCantidad.Text))
                    ventanaInformarError("Debe asignar una cantidad al consumible");
                else
                {
                    lbxConsumibles.Items.Add(cbxConsumibles.SelectedItem + "-" + tbxCantidad.Text);
                    lbxConsumibles.SelectedIndex = 0;
                    cbxConsumibles.Items.Remove(cbxConsumibles.SelectedItem);
                    if (cbxConsumibles.Items.Count > 0)
                        cbxConsumibles.SelectedIndex = 0;
                    else
                        cbxConsumibles.ResetText();
                }

            }
        }
    }
}
