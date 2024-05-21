using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;
using System.Text.RegularExpressions;
using EXAMENPAR1;

public class ServicioSucursal
{
    // Método para validar los datos de la sucursal
    public bool ValidarSucursal(Sucursal sucursal)
    {
        if (string.IsNullOrWhiteSpace(sucursal.Descripcion) || sucursal.Descripcion.Length < 3)
        {
            Console.WriteLine("La descripción de la sucursal es obligatoria y debe tener al menos 3 caracteres.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(sucursal.Direccion) || sucursal.Direccion.Length < 10)
        {
            Console.WriteLine("La dirección de la sucursal es obligatoria y debe tener al menos 10 caracteres de longitud.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(sucursal.Telefono) || sucursal.Telefono.Length < 3)
        {
            Console.WriteLine("El número de teléfono de la sucursal es obligatorio y debe tener al menos 3 caracteres.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(sucursal.Whatsapp) || sucursal.Whatsapp.Length < 10)
        {
            Console.WriteLine("El número de WhatsApp de la sucursal es obligatorio y debe tener al menos 10 caracteres de longitud.");
            return false;
        }

        if (!Regex.IsMatch(sucursal.Mail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            Console.WriteLine("El correo electrónico de la sucursal no es válido.");
            return false;
        }

        return true;
    }

    // Método para verificar si una sucursal existe en la base de datos según su ID
    public bool SucursalExiste(MySqlConnection connection, int idSucursal)
    {
        try
        {
            string query = "SELECT COUNT(*) FROM Sucursal WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", idSucursal);

            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al verificar la existencia de la sucursal: " + ex.Message);
            return false;
        }
    }
}
