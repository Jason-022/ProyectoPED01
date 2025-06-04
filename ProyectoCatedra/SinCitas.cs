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
    public partial class SinCitas : Form
    {
        private HistorialCortesDAL historialCortesDAL = new HistorialCortesDAL();
        public SinCitas()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewSinCitas.DataSource = historialCortesDAL.GetAllHistorialCortes();

                // Hide ID columns
                if (dataGridViewSinCitas.Columns["Id_barbero"] != null)
                    dataGridViewSinCitas.Columns["Id_barbero"].Visible = false;
                if (dataGridViewSinCitas.Columns["Id_tipoCorte"] != null)
                    dataGridViewSinCitas.Columns["Id_tipoCorte"].Visible = false;
                if (dataGridViewSinCitas.Columns["Id_tipoReservacion"] != null)
                    dataGridViewSinCitas.Columns["Id_tipoReservacion"].Visible = false;
                if (dataGridViewSinCitas.Columns["Id_estadoReservacion"] != null)
                    dataGridViewSinCitas.Columns["Id_estadoReservacion"].Visible = false;

                // Format the Precio column as currency
                if (dataGridViewSinCitas.Columns["Precio"] != null)
                {
                    dataGridViewSinCitas.Columns["Precio"].DefaultCellStyle.Format = "C2"; // Currency format
                    dataGridViewSinCitas.Columns["Precio"].HeaderText = "Precio";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Inicio rI = new Inicio();
            rI.Show();
            this.Hide();
        }

        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            CRUSinCitas AddSinCitas = new CRUSinCitas("Add");
            if (AddSinCitas.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnModificarCita_Click(object sender, EventArgs e)
        {
            if (dataGridViewSinCitas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_historial"].Value);
                string nombreReservacion = dataGridViewSinCitas.SelectedRows[0].Cells["nombreReservacion"].Value.ToString();
                DateTime fechaReservacion = Convert.ToDateTime(dataGridViewSinCitas.SelectedRows[0].Cells["fechaReservacion"].Value);
                TimeSpan horaReservacion = TimeSpan.Parse(dataGridViewSinCitas.SelectedRows[0].Cells["horaReervacion"].Value.ToString());
                int idBarbero = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_barbero"].Value);
                int idTipoCorte = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_tipoCorte"].Value);
                int idTipoReservacion = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_tipoReservacion"].Value);
                int idEstado = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_estadoReservacion"].Value);

                CRUSinCitas UpdateSinCitas = new CRUSinCitas("Edit", id, nombreReservacion, fechaReservacion, horaReservacion, idBarbero, idTipoCorte, idTipoReservacion, idEstado);
                if (UpdateSinCitas.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un registro a modificar.");
            }
        }

        private void btnEliminarCita_Click(object sender, EventArgs e)
        {
            if (dataGridViewSinCitas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_historial"].Value);
                string nombreReservacion = dataGridViewSinCitas.SelectedRows[0].Cells["nombreReservacion"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"¿Estás seguro que quieres eliminar la reservación? '{nombreReservacion}'?",
                    "Realizar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        historialCortesDAL.DeleteHistorialCorte(id);
                        MessageBox.Show("Reservación eliminzada exitosamente!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la reservación: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona el registro a eliminar.");
            }
        }
        private string busqueda;
        private void btnBuscarCita_Click(object sender, EventArgs e)
        {
            busqueda = txtBusquedaData.Text;
            try
            {
                if (string.IsNullOrEmpty(busqueda))
                {
                    // If search is empty, reload all data
                    LoadData();
                    MessageBox.Show("Mostrando todos los registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Perform the search
                    DataTable searchResults = historialCortesDAL.SearchHistorialCortesByNombre(busqueda);
                    dataGridViewSinCitas.DataSource = searchResults;

                    // Reapply formatting after search
                    if (dataGridViewSinCitas.Columns["Id_barbero"] != null)
                        dataGridViewSinCitas.Columns["Id_barbero"].Visible = false;
                    if (dataGridViewSinCitas.Columns["Id_tipoCorte"] != null)
                        dataGridViewSinCitas.Columns["Id_tipoCorte"].Visible = false;
                    if (dataGridViewSinCitas.Columns["Id_tipoReservacion"] != null)
                        dataGridViewSinCitas.Columns["Id_tipoReservacion"].Visible = false;
                    if (dataGridViewSinCitas.Columns["Id_estadoReservacion"] != null)
                        dataGridViewSinCitas.Columns["Id_estadoReservacion"].Visible = false;

                    if (dataGridViewSinCitas.Columns["Precio"] != null)
                    {
                        dataGridViewSinCitas.Columns["Precio"].DefaultCellStyle.Format = "C2";
                        dataGridViewSinCitas.Columns["Precio"].HeaderText = "Precio";
                    }

                    if (searchResults.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros con ese nombre de reservación.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar registros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
