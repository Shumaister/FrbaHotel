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
        //-------------------------------------- Atributos -------------------------------------

        protected string ProgramTitle { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        //-------------------------------------- Metodos para Ventanas -------------------------------------

        public static bool ventanaCamposTodosCompletos(Control ventana, ErrorProvider errorProvider)
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

        public static void ventanaInformarExito()
        {
            MessageBox.Show("La operacion se ha realizado con exito", "Aviso");
        }

        public static void ventanaInformarError(string mensaje)
        {
            MessageBox.Show("ERROR: " + mensaje, "Aviso");
        }

        //-------------------------------------- Metodos para Elementos -------------------------------------

        public static void comboBoxCargar(ComboBox comboBox, List<string> listaValores)
        {
            foreach (string valor in listaValores)
                comboBox.Items.Add(valor);
        }

        public static void listBoxCargar(ListBox listBox, List<string> listaValores)
        {
            foreach (string valor in listaValores)
                listBox.Items.Add(valor);
        }

        public static void dataGridViewCargar(DataGridView dataGridView, DataTable tablaValores)
        {
            dataGridView.DataSource = tablaValores;
        }
    }
}
