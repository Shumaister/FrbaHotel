using FrbaHotel.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRegimen
{
    public partial class VentanaRegimenes : VentanaBase
    {
        public VentanaRegimenes()
        {
            InitializeComponent();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(tabAgregar, controladorError))
            {
                Regimen regimen = CrearRegimen();
                if (Database.RegimenAgregadoConExito(regimen)) { 
                }
                    //ventanaActualizar();
            }
        }



        private Regimen CrearRegimen()
        {
            return new Regimen(this.tbxDescipcionRegimen.Text, this.tbxPrecioRegimen.Text);
        }



        private void tbxNumeroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxConfigurarParaNumeros(e);
            controladorError.Clear();
        }

        #region LosCreeSinQuererUps

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
