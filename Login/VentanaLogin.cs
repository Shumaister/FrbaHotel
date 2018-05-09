using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class VentanaLogin : VentanaBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
            lblErrorLogueo.Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrorLogueo.Visible = false;

           if(!CampoValidar(this, errorProvider1))
           {
               LogueoDTO logueo = DB.Autenticar(txbUser.Text, txbPass.Text);

               if (logueo.Exito)
               {
                   this.Hide();
                   new VentanaSeleccionRol().Show();
               }
               else
               {
                   txbUser.Text = "";
                   txbPass.Text = "";
                   lblErrorLogueo.Visible = true;
               }

           }
  
        }

        public static Boolean CampoValidar(Control objeto, ErrorProvider errorProvider)
        {
            Boolean flagError = false;

            foreach (Control item in objeto.Controls)
            {

                if (item is ErrorTxtBox)
                {
                    ErrorTxtBox campo = (ErrorTxtBox)item;

                    if (campo.Validar)
                    {
                        if (string.IsNullOrEmpty(campo.Text.Trim()))
                        {
                            errorProvider.SetError(campo, "El campo no puede estar vacio");
                            flagError = true;
                        }
                        else
                        {
                            errorProvider.SetError(campo, "");
                        }
                    }
                }

            }
            return flagError;
        }

        private void txbUser_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txbPass_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        /*
        
        private void MostrarRolSegun(bool buleano)
        {
            lblRol.Visible = buleano;
            cbxRoles.Visible = buleano;
            btnIngresar.Visible = buleano;
        }

         
        private void btnIngresoUsuario_Click(object sender, EventArgs e)
        {
            lblErrorLogueo.Visible = false;
            
            LogueoDTO logueo = DB.Autenticar(txbUser.Text, txbPass.Text);

            if (logueo.Exito)
            {
                txbUser.Enabled = false;
                txbPass.Enabled = false;
                btnIngresoUsuario.Enabled = false;
                MostrarRolSegun(true);
                cbxRoles.DataSource = logueo.Roles;
            }
            else
            {
                txbUser.Text = "";
                txbPass.Text = "";
                lblErrorLogueo.Visible = true;
                lblErrorLogueo.Text = logueo.MensajeError;
            }
        }

         */


    }
}
