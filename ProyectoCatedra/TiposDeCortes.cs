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

                // Hide ID column
                if (dataGridViewTipoCorte.Columns["Id_corte"] != null)
                    dataGridViewTipoCorte.Columns["Id_corte"].Visible = false;

                // Optional: Format the Precio column as currency
                if (dataGridViewTipoCorte.Columns["Precio"] != null)
                {
                    dataGridViewTipoCorte.Columns["Precio"].DefaultCellStyle.Format = "C2"; // Currency format
                    dataGridViewTipoCorte.Columns["Precio"].HeaderText = "Precio";
                }
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

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the type of cut '{tipoCorte}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        tipoCorteDAL.DeleteTipoCorte(id);
                        MessageBox.Show("Type of cut deleted successfully!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting type of cut: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }


        }


        private void btnAgregarCorte_Click(object sender, EventArgs e)
        {

            CRUTipoCorte form = new CRUTipoCorte("Add");
            if (form.ShowDialog() == DialogResult.OK)
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
                decimal precio = Convert.ToDecimal(dataGridViewTipoCorte.SelectedRows[0].Cells["Precio"].Value);

                CRUTipoCorte form = new CRUTipoCorte("Edit", id, tipoCorte, descripcion, precio);
                if (form.ShowDialog() == DialogResult.OK)
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

