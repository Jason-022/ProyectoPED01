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
    public class EstadoReservacionesDAL
    {
        public void AddEstadoReservacion(string estado, string descripcion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO estadoReservaciones (Estado, Descripcion) VALUES (@Estado, @Descripcion)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllEstadoReservaciones()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT * FROM estadoReservaciones";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void UpdateEstadoReservacion(int id, string estado, string descripcion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE estadoReservaciones SET Estado = @Estado, Descripcion = @Descripcion WHERE Id_estado = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEstadoReservacion(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "DELETE FROM estadoReservaciones WHERE Id_estado = @Id";
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

