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
        public VentanaBase()
        {
            InitializeComponent();
            ProgramTitle = "Frba Hotel";
        }

        private void VentanaBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected string ProgramTitle { get; set; }
    }
}
