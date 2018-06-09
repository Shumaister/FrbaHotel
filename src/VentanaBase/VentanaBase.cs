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

        /*
         ¨SIEMPRE QUE CREEN UNA VENTANA O FORMULARIO COMO QUIERAN DECIRLE
         * HEREDENLA DE ESTA CLASE ES DECIR
         * 
         * public class MiVentana : VentanaBase SIEMPREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
         * SINO VAN A PASAR COSAS MALAS (MENTIRA SOLO NO SE CAMBIA EL COLORCITO Y NO LES APARECE EL LOGUITO)
         *
         */
        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        //-------------------------------------- Metodos para Ventanas -------------------------------------

        /*PARA VER QUE LOS CAMPOS NO ESTEN VACIOS SIEMPRE PONERLO DENTRO DE LA FUNCION botoncito_Click
         * O SEA SIEMPRE QUE HAGAN UN CLICK DONDE SE GUARDE O MODIFIQUE ALGO
         * Ejemplo
         * 
         * private static void miBoton_Click()
         * {
         *      if(ventanaCamposEstanCompletos(this, controladorError))
         *      {
         *          ACA PONEN QUE GUARDE O MODIFIQUE ALG
         *          la variable 'controladorError' lo tienen todas las ventanas asi que solo llamenla y listo
         *      }
         * }

        */
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

        /*
         * PARA CUANDO QUIERAN AVISAR QUE LA ACCION X FUE EXITOSA Y SALE CON SONIDITO
        */
        public static void ventanaInformarExito()
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("La operacion se ha realizado con exito", "Aviso");
        }

        /*
         * PARA CUANDO QUIERAN AVISAR QUE LA ACCION X FALLO Y SALE CON SONIDITO DE ERROR
        */
        public static void ventanaInformarError(string mensaje)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("ERROR: " + mensaje, "Aviso");
        }

        //-------------------------------------- Metodos para Elementos -------------------------------------

        /* NECESITAS LLENAR UN COMBO BOX Y NO SABES COMO? ACA ESTA LA SOLUCION
         * Ejemplo : Quiero un combo box que me muestre todos los roles existentes
         * 
         * SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles")
         * List<string> lista = consultaObtenerLista(consulta);
         * ComboBox miComboBox;
         * comboBoxCargar(miComboBox, lista)
         * 
         * CON ESAS 4 LINEAS YA TENES EL COMBO BOX LLENO PAPU Y SELECCIONADO EN EL PRIMER ITEM
         * PARA EL SEGUNDO PARAMETRO SIEMPRE HAY USAR UN 'consultaObtenerLista' CON SU CONSULTA
         * CREADA PREVIAMENTE CON 'consultaCrear'
         */

        public static void comboBoxCargar(ComboBox comboBox, List<string> listaDatos)
        {
            comboBox.Items.Clear();
            foreach (string dato in listaDatos)
                comboBox.Items.Add(dato);
            if(comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

          /* NECESITAS LLENAR UN LIST BOX AHORA? ACA VA A OTRA FUNCION MAGICA
           * 
         * Ejemplo : Quiero un listBox que me muestre todos los roles existentes
         * 
         * SqlCommand consulta = consultaCrear("SELECT Rol_Nombre FROM RIP.Roles")
         * List<string> lista = consultaObtenerLista(consulta);
         * ListBox miListBox;
         * listBoxCargar(miListBox, lista);
         * 
         * ES LO MISMO QUE LA ANTERIOR, SOLO CAMBIA LA CLASE BASICAMENTE
         * PARA EL SEGUNDO PARAMETRO SIEMPRE HAY USAR UN 'consultaObtenerLista' CON SU CONSULTA
         * CREADA PREVIAMENTE CON 'consultaCrear'
         */

        public static void listBoxCargar(ListBox listBox, List<string> listaDatos)
        {
            foreach (string dato in listaDatos)
                listBox.Items.Add(dato);
            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }

        //POR SI QUERES QUE LOS DATOS DESAPAREZACAN MAGICAMENTE EXISTE SOLO PARA SER
        //MAS EXPRESIVO COMO ME ENSEÑO FRANQUITO

        public static void listBoxLimpiar(ListBox listBox)
        {
            listBox.Items.Clear();
        }


         /* AHORA NECESITO LLENAR UNA TABLA O DATAGRIDVIEW COMO QUIERAN DECIRLE
          * 
         * Ejemplo : Quiero un dataGridView (o tabla) que me muestre todos los roles existentes
         * 
         * SqlCommand consulta = consultaCrear("SELECT * FROM RIP.Roles")
         * DataTable datosParaMiTabla = consultaObtenerTabla(consulta);
         * DataGridView miTabla;
         * dataGridViewCargar(miTabla, datosParaMiTabla);
         * 
         * Y LISTO YA TIENEN SU TABLA CARGADA CON LINDOS DATOS
         * 
         */

        public static void dataGridViewCargar(DataGridView dataGridView, DataTable tablaDatos)
        {
            dataGridView.DataSource = tablaDatos;
        }

        /*POR QUE SI NECESITAN QUE APAREZCA UN BOTON ELMINAR O MODIFICAR DENTRO DE LA TABLA
         * POR EJEMPLO ESTO LO UTIILZO CUANDO APARECE LA VENTANA DEL ABM USUARIOS
         * 
         * private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            dataGridViewCargar(dgvModificarUsuarios, Database.usuarioObtenerTodos());
            dataGridViewCargar(dgvEliminarUsuarios, Database.usuarioObtenerTodos());
            ------------dataGridViewAgregarBotonModificar(dgvModificarUsuarios);-------------
            ------------dataGridViewAgregarBotonEliminar(dgvEliminarUsuarios);------------
            comboBoxCargar(cbxRoles, Database.rolObtenerTodosLista());
            comboBoxCargar(cbxHoteles, Database.hotelObtenerTodosLista());
            comboBoxCargar(cbxTipoDocumento, Database.tipoDocumentoObtenerTodos());
        }
         * SIMPLEMENTE LLAMANDOLAS SE CREAN LOS BOTONES, PREVIAMENTE TIENEN QUE HABER CREADO EL DATAGRIDVIEW O TABLA OBVIAMENTE
         * 
        */
        public static void dataGridViewAgregarBoton(DataGridView dataGridView, string textoBoton)
        {
            DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
            botonModificar.HeaderText = "Seleccionar";
            botonModificar.Text = textoBoton;
            botonModificar.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(botonModificar);
        }

        //SOLO PARA SER EXPRESIVO

        public static void dataGridViewAgregarBotonModificar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "            Modificar          ");
        }

        public static void dataGridViewAgregarBotonEliminar(DataGridView dataGridView)
        {
            VentanaBase.dataGridViewAgregarBoton(dataGridView, "            Eliminar            ");
        }

        /*ESTAS DOS FUNCIONES MISTICAS ES PARA CUANDO NECESITES COMBINAR
         * UN COMBO BOX DONDE AL SELECCIONAR UN ITEM SE TE GUARDE EN EL LIST BOX
         * 
         * ES DECIR PARA ESTAS DOS FUNCIONES SIEMPRE VA A TENER QUE HABER
         * 
         * UN COMBO BOX
         * UN LIST BOX
         * UN BOTON PARA AGREGAR
         * UN BOTON PARA QUITAR
         * 
         * CUANDO HAGAN CLICK EN AGREGAR EL ELEMETNO SELECCIONADO EN EL COMBO BOX SE GUARDA EN EL LIST BOX
         * CUANDO HAGAN CLICK EN QUITAR EL ELEMNTO SELECCIONADO EN EL LIST BOX VUELVE AL COMBO BOX
         * 
         * LAS FUCIONES SIEMPRE PONERLAS EN EL EVENTO 'Click' DE UN BOTON
         * ES DECIR CUANDO APRETAN EL BOTON
         * 
         * nombreDelBoton_Click(object sender, KeyPressEventArgs e)
         * {
         *      botonAgregarComboBoxListBox(miComboBox, miListBox);
         *     
         * }
         * 
         * CON ESO SERIA SUFICIENTE       
         PD: SI YA SE QUE SE DICEN "METODOS" PERO A MI ME GUSTA DECIR MAS FUNCIONES
        */

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


        //LO MISMO QUE ANTES PERO ESTA VEZ CON QUITAR
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

        //POR SI NECESITAS UN TEXT BOX SOLO PARA NUMEROS 
        //SIEMPRE UTILIZARLO DENTRO DEL METODO PARA EL EVENTO KEY PRESS
        // ES DECIR SI VEN UN METODO TIPO
        // nombreDelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //PONEN ESTO DENTRO DE ESE METODO SIEMPRE
        public static void textBoxConfigurarParaNumeros(KeyPressEventArgs evento) 
        {
            if (textBoxNumerosCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        //IDEM QUE LO ANTERIOR PERO PARA LETRAS
        public static void textBoxConfigurarParaLetras(KeyPressEventArgs evento)
        {
            if (textBoxLetrasCaracterValido(evento.KeyChar))
                evento.Handled = false;
            else
                evento.Handled = true;   
        }

        //LOS DEMAS SON LO MISMO PERO CASOS MAS ESPECIFICO, CREO QUE NI LAS VAN A TOCAR ES MAS PARA ABM'S
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
