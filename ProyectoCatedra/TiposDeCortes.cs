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

                if (dataGridViewTipoCorte.Columns["Id_corte"] != null)
                    dataGridViewTipoCorte.Columns["Id_corte"].Visible = false;

                if (dataGridViewTipoCorte.Columns["Precio"] != null)
                {
                    dataGridViewTipoCorte.Columns["Precio"].DefaultCellStyle.Format = "C2"; 
                    dataGridViewTipoCorte.Columns["Precio"].HeaderText = "Precio";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información: " + ex.Message);
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
                    $"Estas seguro de querer eliminar este corte'{tipoCorte}'?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        tipoCorteDAL.DeleteTipoCorte(id);
                        MessageBox.Show("Tipo de corte eliminado!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el tipo corte: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona el registro a eliminar.");
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
                MessageBox.Show("Por favor, selecciona el registro a modificar.");
            }

        }
    }

}

