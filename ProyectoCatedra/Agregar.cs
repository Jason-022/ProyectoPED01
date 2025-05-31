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
    public partial class Agregar : Form
    {
        private readonly ModoAgregar _modo;
        private TipoCorteDAL tipoCorteDAL = new TipoCorteDAL();

        public Agregar(ModoAgregar modo)
        {
           
            InitializeComponent();
            _modo = modo;
            ConfigurarFormulario();
        }

        public enum ModoAgregar
        {
            Cita,
            Personal
        }

        private void ConfigurarFormulario()
        {
            // Oculta todos los paneles
            panelCita.Visible = false;
            panelPersonal.Visible = false;

            // Activa sólo el panel para el modo actual
            switch (_modo)
            {
                case ModoAgregar.Cita:
                    this.Text = "Agregar Cita";
                    panelCita.Visible = true;
                    panelCita.BringToFront();
                    btnAceptar.Text = "Guardar Cita";
                    break;

                case ModoAgregar.Personal:
                    this.Text = "Registrar Personal";
                    panelPersonal.Visible = true;
                    panelPersonal.BringToFront();
                    btnAceptar.Text = "Agregar Personal";
                    break;

                
            }

            btnAceptar.Visible = true;
        }



        private void ClearFields()
        {
            
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}


