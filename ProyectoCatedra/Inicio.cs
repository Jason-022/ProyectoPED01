using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Administracion rdAdmin = new Administracion();
            rdAdmin.Show();
            this.Hide();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            Citas rCitas = new Citas();
            rCitas.Show();
            this.Hide();
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            SinCitas rSinCitas = new SinCitas();
            rSinCitas.Show();
            this.Hide();
        }
    }
}
