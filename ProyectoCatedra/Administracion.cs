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
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            registroPersonal rePresonal = new registroPersonal();
            rePresonal.Show();
            this.Hide();
        }

        private void btnTiposCortes_Click(object sender, EventArgs e)
        {
            TiposDeCortes rTipoCorte = new TiposDeCortes();
            rTipoCorte.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventarios rInventarios = new Inventarios();
            rInventarios.Show();
            this.Hide();


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Inicio rI = new Inicio();
            rI.Show();
            this.Hide();
        }
    }
}
