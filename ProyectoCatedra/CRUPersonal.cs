using System;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class CRUPersonal : Form
    {
        private PersonalDAL personalDAL = new PersonalDAL();
        private string mode; 
        private int id; 

        public CRUPersonal(string mode)
        {
            try
            {
                InitializeComponent();
                this.mode = mode;
                this.Text = "Agregar Personal";
                dtpFechaNacimiento.MaxDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public CRUPersonal(string mode, int id, string nombrePersonal, string direccionPersonal, DateTime fechaNacimiento, string rol)
        {
            try
            {
                InitializeComponent();
                this.mode = mode;
                this.id = id;
                this.Text = "Editar Personal";
                txtNombrePersonal.Text = nombrePersonal;
                txtDireccionPersonal.Text = direccionPersonal;
                dtpFechaNacimiento.Value = fechaNacimiento;
                txtRol.Text = rol;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string nombrePersonal = txtNombrePersonal.Text.Trim();
                string direccionPersonal = txtDireccionPersonal.Text.Trim();
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string rol = txtRol.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombrePersonal))
                {
                    MessageBox.Show("Por favor ingrese el nombre del personal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombrePersonal.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(direccionPersonal))
                {
                    MessageBox.Show("Por favor ingrese la dirección del personal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccionPersonal.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Por favor ingrese el rol del personal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRol.Focus();
                    return;
                }

                if (mode == "Add")
                {
                    personalDAL.AddPersonal(nombrePersonal, direccionPersonal, fechaNacimiento, rol);
                    MessageBox.Show("Personal agregado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (mode == "Edit")
                {
                    personalDAL.UpdatePersonal(id, nombrePersonal, direccionPersonal, fechaNacimiento, rol);
                    MessageBox.Show("Personal actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {(mode == "Add" ? "agregando" : "actualizando")} personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 