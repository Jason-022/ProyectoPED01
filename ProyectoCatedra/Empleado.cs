using System;

namespace ProyectoCatedra
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Rol { get; set; }

        public Empleado(int id, string nombre, string direccion, DateTime fechaNacimiento, string rol)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Rol = rol;
        }
    }
} 