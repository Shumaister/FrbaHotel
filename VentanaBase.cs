using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class VentanaBase : Form
    {

        protected string ProgramTitle { get; set; }

        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        public static bool camposEstanCompletos(Control ventana, ErrorProvider errorProvider)
        {
            bool flagControl = true;
            foreach (Control objeto in ventana.Controls)
            {
                if(objeto is TextBox)
                {
                    TextBox textBox = (TextBox)objeto;
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        flagControl = false;
                        errorProvider.SetError(textBox, "El campo no puede estar vacio");
                    }
                    else
                        errorProvider.SetError(textBox, "");
                }
                if(objeto is ListBox)
                {
                    ListBox listBox = (ListBox)objeto;
                    if (listBox.Items.Count == 0)
                    {
                        flagControl = false;
                        errorProvider.SetError(listBox, "Debe seleccionar al menos una opcion");
                    }
                    else
                        errorProvider.SetError(listBox, "");
                }
            }
            return flagControl;
        }

        public static void informarExito() 
        {
            MessageBox.Show("La operacion se ha realizado con exito", "Aviso");
        }

        public static void informarError(string mensaje)
        {
            MessageBox.Show("ERROR: " + mensaje, "Aviso");
        }

        public static void cargarComboBox(ComboBox comboBox, List<string> listaValores)
        {
            foreach (string valor in listaValores)
                comboBox.Items.Add(valor);
        }
    }
}
