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
    public partial class CRUSinCitas : Form
    {
		private HistorialCortesDAL historialCortesDAL = new HistorialCortesDAL();
		private string mode; // "Add" or "Edit"
		private int id; // Used in Edit mode
		public CRUSinCitas(string mode)
        {
			InitializeComponent();
			this.mode = mode;
			this.Text = "Agregar cita";
			LoadDropdowns();
			dateTimePickerFechaReservacion.ValueChanged += DateTimePicker_ValueChanged;
			comboBoxBarbero.SelectedIndexChanged += ComboBoxBarbero_SelectedIndexChanged;
			comboBoxTipoReservacion.SelectedValue = 1; ;
		}

        // Constructor for Edit mode
        public CRUSinCitas(string mode, int id, string nombreReservacion, DateTime fechaReservacion, TimeSpan horaReservacion, int idBarbero, int idTipoCorte, int idTipoReservacion, int idEstado)
        {
			InitializeComponent();
			this.mode = mode;
			this.id = id;
			this.Text = "Editar cita";
			txtNombreReservacion.Text = nombreReservacion;
			dateTimePickerFechaReservacion.Value = fechaReservacion;
			timePickerHoraReservacion.Value = DateTime.Today + horaReservacion;
			LoadDropdowns();
			comboBoxBarbero.SelectedValue = idBarbero;
			comboBoxTipoCorte.SelectedValue = idTipoCorte;
			comboBoxTipoReservacion.SelectedValue = 1;
			comboBoxEstado.SelectedValue = idEstado;

		}

		private void LoadDropdowns()
		{
			try
			{
				comboBoxBarbero.DataSource = historialCortesDAL.GetAllPersonal();
				comboBoxBarbero.DisplayMember = "NombrePersonal";
				comboBoxBarbero.ValueMember = "Id_personal";

				
				var tipoCorteData = historialCortesDAL.GetAllTipoCorte();
				foreach (DataRow row in tipoCorteData.Rows)
				{
					row["Tipo_corte"] = $"{row["Tipo_corte"]} (${row["Precio"]})";
				}
				comboBoxTipoCorte.DataSource = tipoCorteData;
				comboBoxTipoCorte.DisplayMember = "Tipo_corte";
				comboBoxTipoCorte.ValueMember = "Id_corte";

				comboBoxTipoReservacion.DataSource = historialCortesDAL.GetAllTipoReservacion();
				comboBoxTipoReservacion.DisplayMember = "Tipo_reservacion";
				comboBoxTipoReservacion.ValueMember = "Id_tipoReservacion";

				comboBoxEstado.DataSource = historialCortesDAL.GetAllEstadoReservaciones();
				comboBoxEstado.DisplayMember = "Estado";
				comboBoxEstado.ValueMember = "Id_estado";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar lista: " + ex.Message);
			}
		}

		private void DateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			if (mode == "Add" && comboBoxBarbero.SelectedValue != null)
			{
				SuggestAvailableTime();
			}
		}

		private void ComboBoxBarbero_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (mode == "Add" && dateTimePickerFechaReservacion.Value != null)
			{
				SuggestAvailableTime();
			}
		}

		private void SuggestAvailableTime()
		{
			if (comboBoxBarbero.SelectedValue != null)
			{
				int idBarbero = Convert.ToInt32(comboBoxBarbero.SelectedValue);
				DateTime selectedDate = dateTimePickerFechaReservacion.Value.Date;
				try
				{
					TimeSpan suggestedTime = historialCortesDAL.SuggestNextAvailableTime(selectedDate, idBarbero);
					timePickerHoraReservacion.Value = selectedDate + suggestedTime;
					MessageBox.Show($"Tiempo sugerido: {suggestedTime:hh\\:mm} on {selectedDate:yyyy-MM-dd}.");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Espacio no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					timePickerHoraReservacion.Value = selectedDate + new TimeSpan(9, 0, 0); 
				}
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
        {
			try
			{
				string nombreReservacion = txtNombreReservacion.Text;
				DateTime fechaReservacion = dateTimePickerFechaReservacion.Value;
				TimeSpan horaReservacion = timePickerHoraReservacion.Value.TimeOfDay;
				int idBarbero = Convert.ToInt32(comboBoxBarbero.SelectedValue);
				int idTipoCorte = Convert.ToInt32(comboBoxTipoCorte.SelectedValue);
				int idTipoReservacion = 1;
				int idEstado = Convert.ToInt32(comboBoxEstado.SelectedValue);

				if (string.IsNullOrWhiteSpace(nombreReservacion))
				{
					MessageBox.Show("Por favor, agrega nombre de reservación.");
					return;
				}

				if (mode == "Add")
				{
					if (!historialCortesDAL.IsStaffAvailable(fechaReservacion, horaReservacion, idBarbero))
					{
						MessageBox.Show($"El barbero selecionado no esta disponible a las {horaReservacion:hh\\:mm} en {fechaReservacion:yyyy-MM-dd}. Por favor, selecciona diferente barbero o tiempo.");
						return;
					}

					historialCortesDAL.AddHistorialCorte(nombreReservacion, fechaReservacion, horaReservacion, idBarbero, idTipoCorte, idTipoReservacion, idEstado);
					MessageBox.Show("Se agrego exitosamente!");
				}
				else if (mode == "Edit")
				{
					historialCortesDAL.UpdateHistorialCorte(id, nombreReservacion, fechaReservacion, horaReservacion, idBarbero, idTipoCorte, idTipoReservacion, idEstado);
					MessageBox.Show("Se ha actualizado exitosamente!");
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error {(mode == "Agregar" ? "Agregando" : "Actualizando")} cita: " + ex.Message);
			}
		}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

