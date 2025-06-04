using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public partial class RegistroUsuarioAdmin : Form
    {
        private HistorialCortesDAL historialCortesDAL = new HistorialCortesDAL();
        public RegistroUsuarioAdmin()
        {
            
            InitializeComponent();
            LoadPersonnelComboBox();
        }

        private void LoadPersonnelComboBox()
        {
            try
            {
                // Get all personnel and filter out those with existing accounts
                string query = @"
                    SELECT p.Id_personal, p.NombrePersonal 
                    FROM personal p 
                    LEFT JOIN cuentausuario cu ON p.Id_personal = cu.id_personal 
                    WHERE cu.id_personal IS NULL 
                    AND p.Id_rol = 1"; // Only Administracion role (Id_rol = 1)
                using (SqlConnection conn = ConnectionHelper.GetConnection())
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        comboBoxPersonal.DataSource = dt;
                        comboBoxPersonal.DisplayMember = "NombrePersonal";
                        comboBoxPersonal.ValueMember = "Id_personal";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading personnel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string password = txtPass.Text.Trim();
                int idPersonal = Convert.ToInt32(comboBoxPersonal.SelectedValue);

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedPassword = HashPassword(password);

                using (SqlConnection conn = ConnectionHelper.GetConnection())
                {
                    string query = "INSERT INTO cuentausuario (usuario, password, id_personal) VALUES (@Usuario, @Password, @IdPersonal)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@IdPersonal", idPersonal);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadPersonnelComboBox(); // Refresh to exclude the newly added user
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtUsuario.Clear();
            txtPass.Clear();
            comboBoxPersonal.SelectedIndex = -1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
