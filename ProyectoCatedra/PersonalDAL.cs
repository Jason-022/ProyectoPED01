using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoCatedra
{
    public class PersonalDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrothersBarberClubConnection"].ConnectionString;

        public void AddPersonal(string nombrePersonal, string direccionPersonal, DateTime fechaNacimiento, string rol)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Primero insertar el rol si no existe
                        int idRol;
                        using (SqlCommand cmd = new SqlCommand("SELECT Id_rolPersonal FROM rolPersonal WHERE Tipo_rol = @Tipo_rol", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Tipo_rol", rol);
                            object result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                // El rol no existe, lo insertamos
                                using (SqlCommand insertCmd = new SqlCommand("INSERT INTO rolPersonal (Tipo_rol, Descripcion) VALUES (@Tipo_rol, @Descripcion); SELECT SCOPE_IDENTITY();", connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@Tipo_rol", rol);
                                    insertCmd.Parameters.AddWithValue("@Descripcion", "Rol de " + rol);
                                    idRol = Convert.ToInt32(insertCmd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                idRol = Convert.ToInt32(result);
                            }
                        }

                        // Luego insertar el personal
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO personal (NombrePersonal, DireccionPersonal, FechaNacimiento, Id_rol) VALUES (@NombrePersonal, @DireccionPersonal, @FechaNacimiento, @Id_rol)", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NombrePersonal", nombrePersonal);
                            cmd.Parameters.AddWithValue("@DireccionPersonal", direccionPersonal);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            cmd.Parameters.AddWithValue("@Id_rol", idRol);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetAllPersonal()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT p.Id_personal, p.NombrePersonal, p.DireccionPersonal, p.FechaNacimiento, r.Tipo_rol as Rol
                    FROM personal p
                    INNER JOIN rolPersonal r ON p.Id_rol = r.Id_rolPersonal", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void UpdatePersonal(int id, string nombrePersonal, string direccionPersonal, DateTime fechaNacimiento, string rol)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Primero obtener o insertar el rol
                        int idRol;
                        using (SqlCommand cmd = new SqlCommand("SELECT Id_rolPersonal FROM rolPersonal WHERE Tipo_rol = @Tipo_rol", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Tipo_rol", rol);
                            object result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                // El rol no existe, lo insertamos
                                using (SqlCommand insertCmd = new SqlCommand("INSERT INTO rolPersonal (Tipo_rol, Descripcion) VALUES (@Tipo_rol, @Descripcion); SELECT SCOPE_IDENTITY();", connection, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@Tipo_rol", rol);
                                    insertCmd.Parameters.AddWithValue("@Descripcion", "Rol de " + rol);
                                    idRol = Convert.ToInt32(insertCmd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                idRol = Convert.ToInt32(result);
                            }
                        }

                        // Luego actualizar el personal
                        using (SqlCommand cmd = new SqlCommand("UPDATE personal SET NombrePersonal = @NombrePersonal, DireccionPersonal = @DireccionPersonal, FechaNacimiento = @FechaNacimiento, Id_rol = @Id_rol WHERE Id_personal = @Id_personal", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id_personal", id);
                            cmd.Parameters.AddWithValue("@NombrePersonal", nombrePersonal);
                            cmd.Parameters.AddWithValue("@DireccionPersonal", direccionPersonal);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            cmd.Parameters.AddWithValue("@Id_rol", idRol);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void DeletePersonal(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM personal WHERE Id_personal = @Id_personal", connection))
                {
                    cmd.Parameters.AddWithValue("@Id_personal", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable BuscarPersonalPorNombre(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT p.Id_personal, p.NombrePersonal, p.DireccionPersonal, p.FechaNacimiento, r.Tipo_rol as Rol
                    FROM personal p
                    INNER JOIN rolPersonal r ON p.Id_rol = r.Id_rolPersonal
                    WHERE p.NombrePersonal LIKE @NombrePersonal", connection))
                {
                    cmd.Parameters.AddWithValue("@NombrePersonal", "%" + nombre + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}


