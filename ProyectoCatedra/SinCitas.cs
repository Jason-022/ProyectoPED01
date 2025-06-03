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
                MessageBox.Show("Error loading data: " + ex.Message);
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
                MessageBox.Show("Please select a record to modify.");
            }
        }

        private void btnEliminarCita_Click(object sender, EventArgs e)
        {
            if (dataGridViewSinCitas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewSinCitas.SelectedRows[0].Cells["Id_historial"].Value);
                string nombreReservacion = dataGridViewSinCitas.SelectedRows[0].Cells["nombreReservacion"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the reservation '{nombreReservacion}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        historialCortesDAL.DeleteHistorialCorte(id);
                        MessageBox.Show("Reservation deleted successfully!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting reservation: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }


    }
}
