using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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

        public static bool ventanaCamposEstanCompletos(Control ventana, ErrorProvider errorProvider)
        {
            bool camposTodosCompletos = true;
            foreach (Control objeto in ventana.Controls)
            {
                if(objeto is TextBox)
                {
                    TextBox textBox = (TextBox)objeto;
                    if (textBox.ShortcutsEnabled && string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        camposTodosCompletos = false;
                        errorProvider.SetError(textBox, "El campo no puede estar vacio");
                    }
                }
                if(objeto is ListBox)
                {
                    ListBox listBox = (ListBox)objeto;
                    if (listBox.Items.Count == 0)
                    {
                        camposTodosCompletos = false;
                        errorProvider.SetError(listBox, "Debe seleccionar al menos una opcion");
                    }
                }
            }
            if(!camposTodosCompletos)
                SystemSounds.Beep.Play();
            return camposTodosCompletos;
        }
         
        public static void ventanaInformarErrorDatabase(Exception excepcion)
        {
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemSounds.Hand.Play();
        }

        public static bool ventanaInformarExito(string mensaje)
        {
            MessageBox.Show("AVISO: " + mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            SystemSounds.Exclamation.Play();
            return true;
        }

        public static bool ventanaInformarError(string mensaje)
        {
            MessageBox.Show("ERROR: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemSounds.Hand.Play();
            return false;
        }

        //-------------------------------------- Metodos para Elementos -------------------------------------

        public static void comboBoxCargar(ComboBox comboBox, List<string> listaDatos)
        {
            comboBox.Items.Clear();
            foreach (string dato in listaDatos)
                comboBox.Items.Add(dato);
            if(comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        public static void listBoxCargar(ListBox listBox, List<string> listaDatos)
        {
            foreach (string dato in listaDatos)
                listBox.Items.Add(dato);
            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }

        public static void listBoxLimpiar(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        public static void dataGridViewCargar(DataGridView dataGridView, DataTable tablaDatos)
        {
            dataGridView.DataSource = tablaDatos;
        }

        public static void dataGridViewAgregarBoton(DataGridView dataGridView, string textoBoton)
        {
            DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
            botonModificar.HeaderText = "Seleccionar";
            botonModificar.Text = textoBoton;
            botonModificar.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(botonModificar);
        }

        public static void dataGridViewAgregarBotonModificar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "            Modificar          ");
        }

        public static void dataGridViewAgregarBotonEliminar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "            Eliminar            ");
        }

        public static void botonAgregarComboBoxListBox(ComboBox comboBox, ListBox listBox)
        {
            if (comboBox.SelectedItem != null)
            {
                listBox.Items.Add(comboBox.SelectedItem);
                listBox.SelectedIndex = 0;
                comboBox.Items.Remove(comboBox.SelectedItem);
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
                else
                    comboBox.ResetText();
            }
        }

        public static void botonQuitarComboBoxListBox(ComboBox comboBox, ListBox listBox)
        {
            if (listBox.SelectedItem != null)
            {
                comboBox.Items.Add(listBox.SelectedItem);
                comboBox.Sorted = true;
                listBox.Items.Remove(listBox.SelectedItem);
                comboBox.SelectedIndex = 0;
                if (listBox.Items.Count > 0)
                    listBox.SelectedIndex = 0;
            }
        }

        public static void textBoxConfigurarParaNumeros(KeyPressEventArgs evento) 
        {
            if (textBoxNumerosCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        public static void textBoxConfigurarParaLetras(KeyPressEventArgs evento)
        {
            if (textBoxLetrasCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        public static void textBoxConfigurarParaCuenta(KeyPressEventArgs evento)
        {
            if (textBoxEmailCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        public static bool textBoxNumerosCaracterValido(char caracter)
        {
            return Char.IsDigit(caracter) || Char.IsControl(caracter);
        }

        public static bool textBoxLetrasCaracterValido(char caracter)
        {
            return Char.IsLetter(caracter) || Char.IsControl(caracter) || Char.IsSeparator(caracter);
        }

        public static bool textBoxEmailCaracterValido(char caracter)
        {
            return Char.IsLetter(caracter) || Char.IsDigit(caracter) || Char.IsControl(caracter) || caracter == '-' || caracter == '_' || caracter == '.';
        }
    }
}
