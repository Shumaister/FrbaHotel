using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Menus
{
    public partial class MenuPrincipalUsuarios : Form
    {
        Usuario Usuario { get; set; }
        public MenuPrincipalUsuarios(Usuario usu)
        {
            this.Usuario = usu; 
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
