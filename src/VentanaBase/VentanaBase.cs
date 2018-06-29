using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FrbaHotel
{
    public partial class VentanaBase : Form
    {
        #region Atributos

        protected string ProgramTitle { get; set; }

        #endregion

        #region Constructores

        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        #endregion

        #region Ventana

        public static bool ventanaCamposEstanCompletos(Control ventana, ErrorProvider errorProvider)
        {
            bool camposTodosCompletos = true;
            foreach (Control objeto in ventana.Controls)
            {
                if(objeto is TextBox)
                {
                    TextBox textBox = (TextBox)objeto;
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        camposTodosCompletos = false;
                        errorProvider.SetError(textBox, "El campo no puede estar vacio");
                    }
                    if (!textBox.ShortcutsEnabled)
                    {
                        Regex expresionParaEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        if (!expresionParaEmail.IsMatch(textBox.Text))
                        {
                            camposTodosCompletos = false;
                            errorProvider.SetError(textBox, "El formato de E-mail es invalido");
                        }
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
            SystemSounds.Hand.Play();
            MessageBox.Show("ERROR EN LA BASE DE DATOS:\n" + excepcion.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);          
        }

        public static void ventanaInformarExito(string mensaje)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("AVISO: " + mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);          
        }

        public static void ventanaInformarError(string mensaje)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("ERROR: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
        }

        #endregion

        #region ComboBox

        public static void comboBoxCargar(ComboBox comboBox, List<string> listaDatos)
        {
            comboBox.Items.Clear();
            foreach (string dato in listaDatos)
                comboBox.Items.Add(dato);
            if(comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        #endregion

        #region ListBox

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

        public List<string> listBoxExtraerItemsEnLista(ListBox listBox)
        {
            List<string> lista = new List<string>();
            foreach (string item in listBox.Items)
                lista.Add(item);
            return lista;
        }

        #endregion

        #region DataGridView

        public static void dataGridViewCargar(DataGridView dataGridView, DataTable tablaDatos)
        {
            dataGridView.DataSource = tablaDatos;
        }

        public static void dataGridViewAgregarBoton(DataGridView dataGridView, string textoBoton)
        {
            DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
            botonModificar.HeaderText = "Accion";
            botonModificar.Text = textoBoton;
            botonModificar.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(botonModificar);
        }

        public static void dataGridViewAgregarBotonModificar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "         Modificar       ");
        }

        public static void dataGridViewAgregarBotonEliminar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "         Eliminar         ");
        }

        #endregion

        #region Button

        public static void buttonAgregarComboBoxListBox(ComboBox comboBox, ListBox listBox)
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

        public static void buttonQuitarComboBoxListBox(ComboBox comboBox, ListBox listBox)
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

        #endregion

        #region TextBox

        public static void textBoxConfigurarParaLetras(KeyPressEventArgs evento)
        {
            if (textBoxLetrasCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;
        }

        public static void textBoxConfigurarParaNumeros(KeyPressEventArgs evento) 
        {
            if (textBoxNumerosCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        public static void textBoxConfigurarParaLetrasYNumeros(KeyPressEventArgs evento)
        {
            if (textBoxLetrasYNumerosCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;
        }

        public static void textBoxConfigurarParaCuenta(KeyPressEventArgs evento)
        {
            if (textBoxCuentaCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        public static bool textBoxLetrasCaracterValido(char caracter)
        {
            return Char.IsLetter(caracter) || Char.IsControl(caracter) || Char.IsSeparator(caracter);
        }

        public static bool textBoxNumerosCaracterValido(char caracter)
        {
            return Char.IsDigit(caracter) || Char.IsControl(caracter);
        }

        public static bool textBoxLetrasYNumerosCaracterValido(char caracter)
        {
            return Char.IsLetterOrDigit(caracter) || Char.IsControl(caracter) || Char.IsSeparator(caracter);
        }

        public static bool textBoxCuentaCaracterValido(char caracter)
        {
            return Char.IsLetter(caracter) || Char.IsDigit(caracter) || Char.IsControl(caracter) || caracter == '-' || caracter == '_' || caracter == '.';
        }

        #endregion

        #region RadioButton

        public string radioButtonEstado(RadioButton radioButtonHabilitar)
        {
            if (radioButtonHabilitar.Checked)
                return "1";
            else
                return "0";
        }

        #endregion
    }
}
