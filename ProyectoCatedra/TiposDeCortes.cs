using ProyectoCatedra;
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
    public partial class TiposDeCortes : Form
    {

        private TipoCorteDAL tipoCorteDAL = new TipoCorteDAL();

        public TiposDeCortes()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                dataGridViewTipoCorte.DataSource = tipoCorteDAL.GetAllTipoCorte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Administracion rAdmin = new Administracion();
            rAdmin.Show();
            this.Hide();
        }

        private void dataGridViewTipoCorte_SelectionChanged(object sender, EventArgs e)
        {
           
        }



        private void btnEliminarPeinado_Click(object sender, EventArgs e)
        {
           if (dataGridViewTipoCorte.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewTipoCorte.SelectedRows[0].Cells["Id_corte"].Value);
                string tipoCorte = dataGridViewTipoCorte.SelectedRows[0].Cells["Tipo_corte"].Value.ToString();

                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    $"Esta seguro de eliminar el Tipo de corte '{tipoCorte}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        tipoCorteDAL.DeleteTipoCorte(id);
                        MessageBox.Show("El tipo de corte fue eliminado exitosamente!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecionar el tipo de corte que desea eliminar.");
            }

           
        }


        private void btnAgregarCorte_Click(object sender, EventArgs e)
        {

            // Open the form in Add mode
            CRUTipoCorte AddTipoCorte = new CRUTipoCorte("Add");
            if (AddTipoCorte.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }

        }

        private void btnModificarPeinado_Click(object sender, EventArgs e)
        {

            if (dataGridViewTipoCorte.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewTipoCorte.SelectedRows[0].Cells["Id_corte"].Value);
                string tipoCorte = dataGridViewTipoCorte.SelectedRows[0].Cells["Tipo_corte"].Value.ToString();
                string descripcion = dataGridViewTipoCorte.SelectedRows[0].Cells["Descripcion"].Value.ToString();

                // Open the form in Edit mode, passing the current record's data
                CRUTipoCorte EditTipoCorte = new CRUTipoCorte("Edit", id, tipoCorte, descripcion);
                if (EditTipoCorte.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to modify.");
            }

        }
    }

}

