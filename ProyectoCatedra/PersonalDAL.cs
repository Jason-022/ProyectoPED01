using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ProyectoCatedra
{
    public class PersonalDAL
    {
        private static ArbolEmpleados arbolEmpleados = new ArbolEmpleados();
        private static int ultimoId = 0;
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrothersBarberClubConnection"].ConnectionString;

        public PersonalDAL()
        {
            // Cargar datos de la base de datos al árbol al iniciar
            CargarDatosDeBD();
        }

        private void CargarDatosDeBD()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT p.Id_personal, p.NombrePersonal, p.DireccionPersonal, p.FechaNacimiento, r.Tipo_rol as Rol
                    FROM personal p
                    INNER JOIN rolPersonal r ON p.Id_rol = r.Id_rolPersonal", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado(
                                reader.GetInt32(0), // Id_personal
                                reader.GetString(1), // NombrePersonal
                                reader.GetString(2), // DireccionPersonal
                                reader.GetDateTime(3), // FechaNacimiento
                                reader.GetString(4) // Rol
                            );
                            arbolEmpleados.Insertar(empleado);
                            if (empleado.Id > ultimoId)
                            {
                                ultimoId = empleado.Id;
                            }
                        }
                    }
                }
            }
        }

        public void AddPersonal(string nombrePersonal, string direccionPersonal, DateTime fechaNacimiento, string rol)
        {
            int nuevoId;
            // Insertar en la base de datos
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

                        // Insertar el personal SIN especificar Id_personal
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO personal (NombrePersonal, DireccionPersonal, FechaNacimiento, Id_rol) VALUES (@NombrePersonal, @DireccionPersonal, @FechaNacimiento, @Id_rol); SELECT SCOPE_IDENTITY();", connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NombrePersonal", nombrePersonal);
                            cmd.Parameters.AddWithValue("@DireccionPersonal", direccionPersonal);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            cmd.Parameters.AddWithValue("@Id_rol", idRol);
                            object idObj = cmd.ExecuteScalar();
                            nuevoId = Convert.ToInt32(idObj);
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
            // Insertar en el árbol con el ID generado
            Empleado nuevoEmpleado = new Empleado(nuevoId, nombrePersonal, direccionPersonal, fechaNacimiento, rol);
            arbolEmpleados.Insertar(nuevoEmpleado);
        }

        public DataTable GetAllPersonal()
        {
            // Usar el árbol para obtener los datos
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_personal", typeof(int));
            dt.Columns.Add("NombrePersonal", typeof(string));
            dt.Columns.Add("DireccionPersonal", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(DateTime));
            dt.Columns.Add("Rol", typeof(string));

            List<Empleado> empleados = arbolEmpleados.ObtenerTodos();
            foreach (var empleado in empleados)
            {
                dt.Rows.Add(empleado.Id, empleado.Nombre, empleado.Direccion, empleado.FechaNacimiento, empleado.Rol);
            }

            return dt;
        }

        public void UpdatePersonal(int id, string nombrePersonal, string direccionPersonal, DateTime fechaNacimiento, string rol)
        {
            // Actualizar en el árbol
            arbolEmpleados.Eliminar(id);
            Empleado empleadoActualizado = new Empleado(id, nombrePersonal, direccionPersonal, fechaNacimiento, rol);
            arbolEmpleados.Insertar(empleadoActualizado);

            // Actualizar en la base de datos
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
            // Eliminar del árbol
            arbolEmpleados.Eliminar(id);

            // Eliminar de la base de datos
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
            // Usar el árbol para la búsqueda
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_personal", typeof(int));
            dt.Columns.Add("NombrePersonal", typeof(string));
            dt.Columns.Add("DireccionPersonal", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(DateTime));
            dt.Columns.Add("Rol", typeof(string));

            Empleado empleado = arbolEmpleados.Buscar(nombre);
            if (empleado != null)
            {
                dt.Rows.Add(empleado.Id, empleado.Nombre, empleado.Direccion, empleado.FechaNacimiento, empleado.Rol);
            }

            return dt;
        }
    }
}


