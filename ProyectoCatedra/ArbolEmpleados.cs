using System;
using System.Collections.Generic;

namespace ProyectoCatedra
{
    public class NodoEmpleado
    {
        public Empleado Empleado { get; set; }
        public NodoEmpleado Izquierdo { get; set; }
        public NodoEmpleado Derecho { get; set; }

        public NodoEmpleado(Empleado empleado)
        {
            Empleado = empleado;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolEmpleados
    {
        private NodoEmpleado raiz;

        public ArbolEmpleados()
        {
            raiz = null;
        }

        public void Insertar(Empleado empleado)
        {
            raiz = InsertarRecursivo(raiz, empleado);
        }

        private NodoEmpleado InsertarRecursivo(NodoEmpleado nodo, Empleado empleado)
        {
            if (nodo == null)
            {
                return new NodoEmpleado(empleado);
            }

            if (empleado.Nombre.CompareTo(nodo.Empleado.Nombre) < 0)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, empleado);
            }
            else if (empleado.Nombre.CompareTo(nodo.Empleado.Nombre) > 0)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, empleado);
            }

            return nodo;
        }

        public Empleado Buscar(string nombre)
        {
            return BuscarRecursivo(raiz, nombre);
        }

        private Empleado BuscarRecursivo(NodoEmpleado nodo, string nombre)
        {
            if (nodo == null || nodo.Empleado.Nombre == nombre)
            {
                return nodo?.Empleado;
            }

            if (nombre.CompareTo(nodo.Empleado.Nombre) < 0)
            {
                return BuscarRecursivo(nodo.Izquierdo, nombre);
            }

            return BuscarRecursivo(nodo.Derecho, nombre);
        }

        public List<Empleado> ObtenerTodos()
        {
            List<Empleado> empleados = new List<Empleado>();
            ObtenerTodosRecursivo(raiz, empleados);
            return empleados;
        }

        private void ObtenerTodosRecursivo(NodoEmpleado nodo, List<Empleado> empleados)
        {
            if (nodo != null)
            {
                ObtenerTodosRecursivo(nodo.Izquierdo, empleados);
                empleados.Add(nodo.Empleado);
                ObtenerTodosRecursivo(nodo.Derecho, empleados);
            }
        }

        public void Eliminar(int id)
        {
            raiz = EliminarRecursivo(raiz, id);
        }

        private NodoEmpleado EliminarRecursivo(NodoEmpleado nodo, int id)
        {
            if (nodo == null)
            {
                return null;
            }

            if (id < nodo.Empleado.Id)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, id);
            }
            else if (id > nodo.Empleado.Id)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, id);
            }
            else
            {
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                NodoEmpleado sucesor = EncontrarMinimo(nodo.Derecho);
                nodo.Empleado = sucesor.Empleado;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Empleado.Id);
            }

            return nodo;
        }

        private NodoEmpleado EncontrarMinimo(NodoEmpleado nodo)
        {
            NodoEmpleado actual = nodo;
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }
            return actual;
        }
    }
} 