using MySql.Data.MySqlClient;
using System;

namespace EXAMENPAR1
{
    public class Factura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIva5 { get; set; }
        public decimal TotalIva10 { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }

        public void CrearFactura(MySqlConnection connection)
        {
            try
            {
                string query = "INSERT INTO Factura (id_Cliente, Nro_Factura, fecha_hora, total, total_iva_5, total_iva_10, total_letras, sucursal) VALUES (@IdCliente, @NroFactura, @FechaHora, @Total, @TotalIva5, @TotalIva10, @TotalLetras, @Sucursal)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", IdCliente);
                command.Parameters.AddWithValue("@NroFactura", NroFactura);
                command.Parameters.AddWithValue("@FechaHora", FechaHora);
                command.Parameters.AddWithValue("@Total", Total);
                command.Parameters.AddWithValue("@TotalIva5", TotalIva5);
                command.Parameters.AddWithValue("@TotalIva10", TotalIva10);
                command.Parameters.AddWithValue("@TotalLetras", TotalLetras);
                command.Parameters.AddWithValue("@Sucursal", Sucursal);
                command.ExecuteNonQuery();
                Console.WriteLine("Factura creada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear factura: " + ex.Message);
            }
        }

        public void LeerFactura(MySqlConnection connection, int id)
        {
            try
            {
                string query = "SELECT * FROM Factura WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32("id");
                        IdCliente = reader.GetInt32("id_Cliente");
                        NroFactura = reader.GetString("Nro_Factura");
                        FechaHora = reader.GetDateTime("fecha_hora");
                        Total = reader.GetDecimal("total");
                        TotalIva5 = reader.GetDecimal("total_iva_5");
                        TotalIva10 = reader.GetDecimal("total_iva_10");
                        TotalLetras = reader.GetString("total_letras");
                        Sucursal = reader.GetString("sucursal");

                        Console.WriteLine($"Factura encontrada: ID: {Id}, Nro. Factura: {NroFactura}, Fecha: {FechaHora}, Total: {Total}");
                    }
                    else
                    {
                        Console.WriteLine("Factura no encontrada.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer factura: " + ex.Message);
            }
        }

        public void ActualizarFactura(MySqlConnection connection)
        {
            try
            {
                string query = "UPDATE Factura SET id_Cliente = @IdCliente, Nro_Factura = @NroFactura, fecha_hora = @FechaHora, total = @Total, total_iva_5 = @TotalIva5, total_iva_10 = @TotalIva10, total_letras = @TotalLetras, sucursal = @Sucursal WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@IdCliente", IdCliente);
                command.Parameters.AddWithValue("@NroFactura", NroFactura);
                command.Parameters.AddWithValue("@FechaHora", FechaHora);
                command.Parameters.AddWithValue("@Total", Total);
                command.Parameters.AddWithValue("@TotalIva5", TotalIva5);
                command.Parameters.AddWithValue("@TotalIva10", TotalIva10);
                command.Parameters.AddWithValue("@TotalLetras", TotalLetras);
                command.Parameters.AddWithValue("@Sucursal", Sucursal);
                command.ExecuteNonQuery();
                Console.WriteLine("Factura actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar factura: " + ex.Message);
            }
        }

        public void EliminarFactura(MySqlConnection connection)
        {
            try
            {
                string query = "DELETE FROM Factura WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                Console.WriteLine("Factura eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar factura: " + ex.Message);
            }
        }
    }
}
