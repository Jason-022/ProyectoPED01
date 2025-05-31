using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ProyectoCatedra
{

        public static class ConnectionHelper
        {
            public static SqlConnection GetConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BrothersBarberClubConnection"].ConnectionString;
                return new SqlConnection(connectionString);
            }
        }

}




/*

SqlConnection cnx;

public Conexion()
{
    try
    {
        cnx = new SqlConnection("Data Source=PC-DEVICE;Initial Catalog=brothers_barber_club_db;User ID=sa;Password=P4ssw0rd");
        cnx.Open();
        MessageBox.Show("Conexion correcta","Listo",MessageBoxButtons.OK);
    }
    catch (Exception e) {
        MessageBox.Show("ERROR: "+e.Message,"Error inesperado", MessageBoxButtons.OK);

    }
}

*/




