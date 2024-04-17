using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace EXAMENPAR1.REPOSITORY.DATA.CONFIGURACIONESDB
{
    // Clase de conexión a la base de datos
    public class ConexionDB
    {
        private string connectionString;

        public ConexionDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Método para establecer la conexión
        public MySqlConnection EstablecerConexion()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexión establecida con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
            }
            return connection;
        }

        // Método para cerrar la conexión
        public void CerrarConexion(MySqlConnection connection)
        {
            try
            {
                connection.Close();
                Console.WriteLine("Conexión cerrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}