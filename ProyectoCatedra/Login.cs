using ProyectoCatedra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class Login : Form
    {

        private string usuario;
        private string contra;

        public Login()
        {
            InitializeComponent();
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contra = txtPass.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contra))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (ValidateUser(usuario, contra))
                {
                    MessageBox.Show("Inicio de sesión exitoso. Bienvenido, Administrador!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Inicio mainForm = new Inicio();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario, contraseña incorrectos o no tiene permisos de Administrador.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string usuario, string password)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                
                string query = @"
                SELECT COUNT(*) 
                FROM cuentausuario cu 
                JOIN personal p ON cu.id_personal = p.Id_personal 
                JOIN rolPersonal rp ON p.Id_rol = rp.Id_rolPersonal 
                WHERE cu.usuario = @Usuario 
                AND cu.password = @Password 
                AND rp.Id_rolPersonal = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


    }
}