using ProyectoCatedra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public class RolPersonalDAL
    {
        public void AddRolPersonal(string tipoRol, string descripcion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO rolPersonal (Tipo_rol, Descripcion) VALUES (@TipoRol, @Descripcion)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoRol", tipoRol);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllRolPersonal()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM rolPersonal";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void UpdateRolPersonal(int id, string tipoRol, string descripcion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE rolPersonal SET Tipo_rol = @TipoRol, Descripcion = @Descripcion WHERE Id_rolPersonal = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@TipoRol", tipoRol);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRolPersonal(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "DELETE FROM rolPersonal WHERE Id_rolPersonal = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

