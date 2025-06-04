using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProyectoCatedra
{
    public partial class registroPersonal : Form
    {
        private PersonalDAL personalDAL = new PersonalDAL();

        // Nodo y ABB para personal
        private class PersonalNode
        {
            public int Id;
            public string Nombre;
            public string Direccion;
            public DateTime FechaNacimiento;
            public string Rol;
            public PersonalNode Izq, Der;
            public PersonalNode(int id, string nombre, string direccion, DateTime fechaNacimiento, string rol)
            {
                Id = id;
                Nombre = nombre;
                Direccion = direccion;
                FechaNacimiento = fechaNacimiento;
                Rol = rol;
            }
        }
        private class PersonalABB
        {
            public PersonalNode Raiz;
            public void Insertar(PersonalNode nodo)
            {
                Raiz = InsertarRec(Raiz, nodo);
            }
            private PersonalNode InsertarRec(PersonalNode actual, PersonalNode nodo)
            {
                if (actual == null) return nodo;
                int cmp = string.Compare(nodo.Nombre, actual.Nombre, StringComparison.OrdinalIgnoreCase);
                if (cmp < 0) actual.Izq = InsertarRec(actual.Izq, nodo);
                else actual.Der = InsertarRec(actual.Der, nodo);
                return actual;
            }
            public List<PersonalNode> BuscarPorNombre(string nombre)
            {
                var lista = new List<PersonalNode>();
                BuscarRec(Raiz, nombre.ToLower(), lista);
                return lista;
            }
            private void BuscarRec(PersonalNode actual, string nombre, List<PersonalNode> lista)
            {
                if (actual == null) return;
                if (actual.Nombre.ToLower().Contains(nombre)) lista.Add(actual);
                BuscarRec(actual.Izq, nombre, lista);
                BuscarRec(actual.Der, nombre, lista);
            }
            public void Limpiar() { Raiz = null; }
        }
        private PersonalABB abbPersonal = new PersonalABB();

        public registroPersonal()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dt = personalDAL.GetAllPersonal();
                dataGridViewPersonal.DataSource = dt;
                // Actualizar ABB
                abbPersonal.Limpiar();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    abbPersonal.Insertar(new PersonalNode(
                        Convert.ToInt32(row["Id_personal"]),
                        row["NombrePersonal"].ToString(),
                        row["DireccionPersonal"].ToString(),
                        Convert.ToDateTime(row["FechaNacimiento"]),
                        row["Rol"].ToString()
                    ));
                }
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
                // Buscar en ABB
                var resultados = abbPersonal.BuscarPorNombre(textoBusqueda);
                if (resultados.Count > 0)
                {
                    var dt = new System.Data.DataTable();
                    dt.Columns.Add("Id_personal", typeof(int));
                    dt.Columns.Add("NombrePersonal", typeof(string));
                    dt.Columns.Add("DireccionPersonal", typeof(string));
                    dt.Columns.Add("FechaNacimiento", typeof(DateTime));
                    dt.Columns.Add("Rol", typeof(string));
                    foreach (var p in resultados)
                    {
                        dt.Rows.Add(p.Id, p.Nombre, p.Direccion, p.FechaNacimiento, p.Rol);
                    }
                    dataGridViewPersonal.DataSource = dt;
                }
                else
                {
                    // Si no hay resultados en ABB, recargar de la base de datos
                    dataGridViewPersonal.DataSource = personalDAL.BuscarPersonalPorNombre(textoBusqueda);
                    LoadData(); // Para mantener el ABB actualizado si hubo cambios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void dataGridViewPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
