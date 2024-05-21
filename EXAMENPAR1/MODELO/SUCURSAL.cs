using System;
using MySql.Data.MySqlClient;

namespace EXAMENPAR1
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Whatsapp { get; set; }
        public string Mail { get; set; }
        public string Estado { get; set; }

        public void CrearSucursal(MySqlConnection connection)
        {
            try
            {
                string query = "INSERT INTO Sucursal (Descripcion, direccion, telefono, whatsapp, mail, estado) VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@Direccion", Direccion);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Whatsapp", Whatsapp);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.ExecuteNonQuery();
                Console.WriteLine("Sucursal creada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear sucursal: " + ex.Message);
            }
        }

        public void LeerSucursal(MySqlConnection connection, int id)
        {
            try
            {
                string query = "SELECT * FROM Sucursal WHERE idSucursal = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", IdSucursal);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IdSucursal = reader.GetInt32("id");
                        Descripcion = reader.GetString("Descripcion");
                        Direccion = reader.GetString("direccion");
                        Telefono = reader.GetString("telefono");
                        Whatsapp = reader.GetString("whatsapp");
                        Mail = reader.GetString("mail");
                        Estado = reader.GetString("estado");

                        Console.WriteLine($"Sucursal encontrada: ID: {IdSucursal}, Descripcion: {Descripcion}, Direccion: {Direccion}, Telefono: {Telefono}");
                    }
                    else
                    {
                        Console.WriteLine("Sucursal no encontrada.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer sucursal: " + ex.Message);
            }
        }

        public void ActualizarSucursal(MySqlConnection connection)
        {
            try
            {
                string query = "UPDATE Sucursal SET Descripcion = @Descripcion, direccion = @Direccion, telefono = @Telefono, whatsapp = @Whatsapp, mail = @Mail, estado = @Estado WHERE idSucursal = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", IdSucursal);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@Direccion", Direccion);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Whatsapp", Whatsapp);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.ExecuteNonQuery();
                Console.WriteLine("Sucursal actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar sucursal: " + ex.Message);
            }
        }

        public void EliminarSucursal(MySqlConnection connection)
        {
            try
            {
                string query = "DELETE FROM Sucursal WHERE idSucursal = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", IdSucursal);
                command.ExecuteNonQuery();
                Console.WriteLine("Sucursal eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar sucursal: " + ex.Message);
            }
        }
    }
}