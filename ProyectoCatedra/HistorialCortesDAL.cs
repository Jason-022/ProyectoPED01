using ProyectoCatedra;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        //Parte de sin cita
        public DataTable GetAllHistorialCortesSinCita()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                            FROM historialCortes h 
                            JOIN personal p ON h.Id_barbero = p.Id_personal 
                            JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                            JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                            JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado
                            WHERE r.Tipo_reservacion = 'Sin cita'";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SearchHistorialCortesByNombreSinCita(string nombreReservacion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                            FROM historialCortes h 
                            JOIN personal p ON h.Id_barbero = p.Id_personal 
                            JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                            JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                            JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado 
                            WHERE h.nombreReservacion LIKE @NombreReservacion
                            AND r.Tipo_reservacion = 'Sin cita'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreReservacion", "%" + nombreReservacion + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        //Parte de con Cita

        public DataTable GetAllHistorialCortesCitas()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                            FROM historialCortes h 
                            JOIN personal p ON h.Id_barbero = p.Id_personal 
                            JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                            JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                            JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado
                            WHERE r.Tipo_reservacion = 'Con cita'";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SearchHistorialCortesByNombreCitas(string nombreReservacion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                            FROM historialCortes h 
                            JOIN personal p ON h.Id_barbero = p.Id_personal 
                            JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                            JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                            JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado 
                            WHERE h.nombreReservacion LIKE @NombreReservacion
                            AND r.Tipo_reservacion = 'Con cita'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreReservacion", "%" + nombreReservacion + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetAllHistorialCortes()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                                FROM historialCortes h 
                                JOIN personal p ON h.Id_barbero = p.Id_personal 
                                JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado
                                WHERE r.Tipo_reservacion = 'Sin Cita'";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SearchHistorialCortesByNombre(string nombreReservacion)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT h.*, p.NombrePersonal, c.Tipo_corte, c.Precio, r.Tipo_reservacion, e.Estado 
                                FROM historialCortes h 
                                JOIN personal p ON h.Id_barbero = p.Id_personal 
                                JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado 
                                WHERE h.nombreReservacion LIKE @NombreReservacion
                                AND r.Tipo_reservacion = 'Sin Cita'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreReservacion", "%" + nombreReservacion + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
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
                string query = "SELECT Id_corte, Tipo_corte, Precio FROM tipoCorte";
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

        public bool IsStaffAvailable(DateTime fechaReservacion, TimeSpan horaReservacion, int idBarbero)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM historialCortes WHERE Id_barbero = @IdBarbero AND fechaReservacion = @Fecha AND horaReervacion = @Hora";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdBarbero", idBarbero);
                    cmd.Parameters.AddWithValue("@Fecha", fechaReservacion.Date);
                    cmd.Parameters.AddWithValue("@Hora", horaReservacion);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public TimeSpan SuggestNextAvailableTime(DateTime fechaReservacion, int idBarbero)
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT horaReervacion FROM historialCortes WHERE Id_barbero = @IdBarbero AND fechaReservacion = @Fecha ORDER BY horaReervacion";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdBarbero", idBarbero);
                    cmd.Parameters.AddWithValue("@Fecha", fechaReservacion.Date);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        TimeSpan currentTime = new TimeSpan(9, 0, 0); // Start at 9:00 AM
                        TimeSpan endTime = new TimeSpan(17, 0, 0);   // End at 5:00 PM
                        TimeSpan interval = new TimeSpan(1, 0, 0);    // 1-hour intervals

                        while (reader.Read())
                        {
                            TimeSpan bookedTime = (TimeSpan)reader["horaReervacion"];
                            if (bookedTime >= currentTime && bookedTime < endTime)
                            {
                                if (bookedTime > currentTime)
                                {
                                    return currentTime; // Return the current time if a gap is found
                                }
                                currentTime = bookedTime.Add(interval); // Move to the next hour
                            }
                        }

                        if (currentTime >= endTime)
                        {
                            throw new Exception("No available slots for this barber on the selected date.");
                        }

                        return currentTime;
                    }
                }
            }
        }

        public DataTable GetPersonnelByRole()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT r.Tipo_rol, COUNT(p.Id_personal) as TotalPersonnel 
                                FROM personal p 
                                JOIN rolPersonal r ON p.Id_rol = r.Id_rolPersonal 
                                GROUP BY r.Tipo_rol";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public int GetTotalAppointments()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM historialCortes";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public decimal GetTotalPriceOfCuts()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT SUM(c.Precio) 
                                FROM historialCortes h 
                                JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? (decimal)result : 0.00m;
                }
            }
        }

        public int GetTotalPersonnel()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM personal";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int GetTotalTipoCorte()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM tipoCorte";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int GetHistorialCortesSinCita()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT COUNT(*) 
                                FROM historialCortes h 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                WHERE r.Tipo_reservacion = 'Sin Cita'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int GetHistorialCortesConCita()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT COUNT(*) 
                                FROM historialCortes h 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                WHERE r.Tipo_reservacion = 'Con Cita'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public decimal GetTotalPriceOfCompletedCuts()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT SUM(c.Precio) 
                                FROM historialCortes h 
                                JOIN tipoCorte c ON h.Id_tipoCorte = c.Id_corte 
                                JOIN estadoReservaciones e ON h.Id_estadoReservacion = e.Id_estado 
                                WHERE e.Estado = 'Completado'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? (decimal)result : 0.00m;
                }
            }
        }

        public DataTable GetTipoReservacionCounts()
        {
            using (SqlConnection conn = ConnectionHelper.GetConnection())
            {
                string query = @"SELECT r.Tipo_reservacion, COUNT(*) as Total 
                                FROM historialCortes h 
                                JOIN tipoReservacion r ON h.Id_tipoReservacion = r.Id_tipoReservacion 
                                GROUP BY r.Tipo_reservacion";
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


