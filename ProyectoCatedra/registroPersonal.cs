using System;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class registroPersonal : Form
    {
        private PersonalDAL personalDAL = new PersonalDAL();

        public registroPersonal()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewPersonal.DataSource = personalDAL.GetAllPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Administracion rAdmin = new Administracion();
            rAdmin.Show();
            this.Hide();
        }

        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            CRUPersonal addPersonal = new CRUPersonal("Add");
            if (addPersonal.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnModificarPersonal_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonal.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewPersonal.SelectedRows[0].Cells["Id_personal"].Value);
                string nombrePersonal = dataGridViewPersonal.SelectedRows[0].Cells["NombrePersonal"].Value.ToString();
                string direccionPersonal = dataGridViewPersonal.SelectedRows[0].Cells["DireccionPersonal"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(dataGridViewPersonal.SelectedRows[0].Cells["FechaNacimiento"].Value);
                string rol = dataGridViewPersonal.SelectedRows[0].Cells["Rol"].Value.ToString();

                CRUPersonal editPersonal = new CRUPersonal("Edit", id, nombrePersonal, direccionPersonal, fechaNacimiento, rol);
                if (editPersonal.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro para modificar.");
            }
        }

        private void btnEliminarPersonal_Click(object sender, EventArgs e)
        {
            if (dataGridViewPersonal.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewPersonal.SelectedRows[0].Cells["Id_personal"].Value);
                string nombrePersonal = dataGridViewPersonal.SelectedRows[0].Cells["NombrePersonal"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de eliminar al personal '{nombrePersonal}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        personalDAL.DeletePersonal(id);
                        MessageBox.Show("Personal eliminado exitosamente!");
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
                MessageBox.Show("Por favor seleccione el personal que desea eliminar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                LoadData();
                return;
            }
            try
            {
                dataGridViewPersonal.DataSource = personalDAL.BuscarPersonalPorNombre(textoBusqueda);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }
    }
}
