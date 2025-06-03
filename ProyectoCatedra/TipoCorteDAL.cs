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
    public class TipoCorteDAL
    {
        public void AddTipoCorte(string tipoCorte, string descripcion, decimal precio)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO tipoCorte (Tipo_corte, Descripcion, Precio) VALUES (@TipoCorte, @Descripcion, @Precio)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoCorte", tipoCorte);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllTipoCorte()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT Id_corte, Tipo_corte, Descripcion, Precio FROM tipoCorte";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void UpdateTipoCorte(int id, string tipoCorte, string descripcion, decimal precio)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE tipoCorte SET Tipo_corte = @TipoCorte, Descripcion = @Descripcion, Precio = @Precio WHERE Id_corte = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@TipoCorte", tipoCorte);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTipoCorte(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "DELETE FROM tipoCorte WHERE Id_corte = @Id";
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

