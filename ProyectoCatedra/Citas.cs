using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoCatedra.Agregar;

namespace ProyectoCatedra
{
    public partial class Citas : Form
    {
        public Citas()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Inicio rI = new Inicio();
            rI.Show();
            this.Hide();
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            var form = new Agregar(ModoAgregar.Cita);
            form.ShowDialog();
        }
    }
}
