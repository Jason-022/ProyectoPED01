using ProyectoCatedra;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoCatedra
{
    public class HistorialCortesDAL
    {
        public void AddHistorialCorte(string nombreReservacion, DateTime fechaReservacion, TimeSpan horaReservacion, int idBarbero, int idTipoCorte, int idTipoReservacion, int idEstado)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "INSERT INTO historialCortes (nombreReservacion, fechaReservacion, horaReervacion, Id_barbero, Id_tipoCorte, Id_tipoReservacion, Id_estadoReservacion) VALUES (@Nombre, @Fecha, @Hora, @IdBarbero, @IdTipoCorte, @IdTipoReservacion, @IdEstado)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreReservacion);
                    cmd.Parameters.AddWithValue("@Fecha", fechaReservacion);
                    cmd.Parameters.AddWithValue("@Hora", horaReservacion);
                    cmd.Parameters.AddWithValue("@IdBarbero", idBarbero);
                    cmd.Parameters.AddWithValue("@IdTipoCorte", idTipoCorte);
                    cmd.Parameters.AddWithValue("@IdTipoReservacion", idTipoReservacion);
                    cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllHistorialCortes()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, r.Tipo_reservacion, e.Estado 
                                FROM historialCortes h 
                                JOIN personal p ON h.Id_barbero = p.Id_personal 
                                JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void UpdateHistorialCorte(int id, string nombreReservacion, DateTime fechaReservacion, TimeSpan horaReservacion, int idBarbero, int idTipoCorte, int idTipoReservacion, int idEstado)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "UPDATE historialCortes SET nombreReservacion = @Nombre, fechaReservacion = @Fecha, horaReervacion = @Hora, Id_barbero = @IdBarbero, Id_tipoCorte = @IdTipoCorte, Id_tipoReservacion = @IdTipoReservacion, Id_estadoReservacion = @IdEstado WHERE Id_historial = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombreReservacion);
                    cmd.Parameters.AddWithValue("@Fecha", fechaReservacion);
                    cmd.Parameters.AddWithValue("@Hora", horaReservacion);
                    cmd.Parameters.AddWithValue("@IdBarbero", idBarbero);
                    cmd.Parameters.AddWithValue("@IdTipoCorte", idTipoCorte);
                    cmd.Parameters.AddWithValue("@IdTipoReservacion", idTipoReservacion);
                    cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteHistorialCorte(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "DELETE FROM historialCortes WHERE Id_historial = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllPersonal()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT Id_personal, NombrePersonal FROM personal";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllTipoCorte()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT Id_corte, Tipo_corte FROM tipoCorte";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllTipoReservacion()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT Id_tipoReservacion, Tipo_reservacion FROM tipoReservacion";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllEstadoReservaciones()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT Id_estado, Estado FROM estadoReservaciones";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}


