using MySqlConnector;
using System;
using System.Text.RegularExpressions;

public class ServicioCliente
{
    // Método para validar los datos del cliente
    public bool ValidarCliente(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre) || cliente.Nombre.Length < 3)
        {
            Console.WriteLine("El nombre del cliente es obligatorio y debe tener al menos 3 caracteres.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(cliente.Apellido) || cliente.Apellido.Length < 3)
        {
            Console.WriteLine("El apellido del cliente es obligatorio y debe tener al menos 3 caracteres.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(cliente.Documento) || cliente.Documento.Length < 3)
        {
            Console.WriteLine("El documento del cliente es obligatorio y debe tener al menos 3 caracteres.");
            return false;
        }

        if (!Regex.IsMatch(cliente.Celular, @"^\d{10}$"))
        {
            Console.WriteLine("El número de celular del cliente debe ser numérico y tener una longitud de 10 dígitos.");
            return false;
        }

        return true;
    }

    // Método para verificar si un cliente existe en la base de datos según su ID
    public bool ClienteExiste(MySqlConnection connection, int idCliente)
    {
        try
        {
            string query = "SELECT COUNT(*) FROM Cliente WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", idCliente);

            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al verificar la existencia del cliente: " + ex.Message);
            return false;
        }
    }
}
