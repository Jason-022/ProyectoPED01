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
    public partial class Inventarios : Form
    {
        public Inventarios()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Administracion rAdmin = new Administracion();
            rAdmin.Show();
            this.Hide();
        }
    }
}
