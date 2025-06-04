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
    public partial class CRUTipoCorte : Form
    {

        private TipoCorteDAL tipoCorteDAL = new TipoCorteDAL();
        private string mode; // "Add" or "Edit"
        private int id; // Used in Edit mode


        // Constructor for Add mode
        public CRUTipoCorte(string mode)
        {
            InitializeComponent();
            this.mode = mode;
            this.Text = "Tipo de corte";
        }

        // Constructor for Edit mode
        public CRUTipoCorte(string mode, int id, string tipoCorte, string descripcion)
        {
            InitializeComponent();
            this.mode = mode;
            this.id = id;
            this.Text = "Edit Type of Cut";
            txtTipoCorte.Text = tipoCorte;
            txtDespcripcionCorte.Text = descripcion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoCorte = txtTipoCorte.Text;
                string descripcion = txtDespcripcionCorte.Text;

                if (string.IsNullOrWhiteSpace(tipoCorte))
                {
                    MessageBox.Show("Please enter a type of cut.");
                    return;
                }

                if (mode == "Add")
                {
                    tipoCorteDAL.AddTipoCorte(tipoCorte, descripcion);
                    MessageBox.Show("Type of cut added successfully!");
                }
                else if (mode == "Edit")
                {
                    tipoCorteDAL.UpdateTipoCorte(id, tipoCorte, descripcion);
                    MessageBox.Show("Type of cut updated successfully!");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {(mode == "Add" ? "adding" : "updating")} type of cut: " + ex.Message);
            }
        }
    }
}

























