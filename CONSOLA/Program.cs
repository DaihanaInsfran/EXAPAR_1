using EXAMENPAR1.REPOSITORY.DATA.CONFIGURACIONESDB;
using MySql.Data.MySqlClient;
using System;

namespace EXAMENPAR1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;port=3306;database=Basede_datos;user=root;password=1234;";
            ConexionDB conexionDB = new ConexionDB(connectionString);
            MySqlConnection connection = conexionDB.EstablecerConexion();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Listar clientes");
                Console.WriteLine("2. Buscar cliente por ID");
                Console.WriteLine("3. Ingresar nuevo cliente");
                Console.WriteLine("4. Actualizar cliente");
                Console.WriteLine("5. Eliminar cliente");
                Console.WriteLine("6. Listar facturas");
                Console.WriteLine("7. Buscar factura por ID de cliente");
                Console.WriteLine("8. Ingresar nueva factura");
                Console.WriteLine("9. Actualizar factura");
                Console.WriteLine("10. Eliminar factura");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese la opción deseada: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarClientes(connection);
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del cliente a buscar: ");
                        int idClienteBuscar = Convert.ToInt32(Console.ReadLine());
                        BuscarClientePorId(connection, idClienteBuscar);
                        break;
                    case "3":
                        IngresarNuevoCliente(connection);
                        break;
                    case "4":
                        ActualizarCliente(connection);
                        break;
                    case "5":
                        EliminarCliente(connection);
                        break;
                    case "6":
                        ListarFacturas(connection);
                        break;
                    case "7":
                        Console.Write("Ingrese el ID del cliente para buscar sus facturas: ");
                        int idClienteFacturas = Convert.ToInt32(Console.ReadLine());
                        ListarFacturasPorCliente(connection, idClienteFacturas);
                        break;
                    case "8":
                        IngresarNuevaFactura(connection);
                        break;
                    case "9":
                        ActualizarFactura(connection);
                        break;
                    case "10":
                        EliminarFactura(connection);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                        break;
                }
            }

            conexionDB.CerrarConexion(connection);
        }

        static void ListarClientes(MySqlConnection connection)
        {
            try
            {
                // Consultar todos los clientes
                string query = "SELECT * FROM Cliente";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Listado de Clientes:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")}, Apellido: {reader.GetString("apellido")}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar clientes: " + ex.Message);
            }
        }

        static void BuscarClientePorId(MySqlConnection connection, int idCliente)
        {
            try
            {
                string query = "SELECT * FROM Cliente WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", idCliente);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Cliente encontrado - ID: {reader.GetInt32("id")}, Nombre: {reader.GetString("nombre")}, Apellido: {reader.GetString("apellido")}");
                    }
                    else
                    {
                        Console.WriteLine("Cliente no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar cliente: " + ex.Message);
            }
        }

        static void IngresarNuevoCliente(MySqlConnection connection)
        {
            Cliente cliente = new Cliente();
            Console.Write("Ingrese el nombre del cliente: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del cliente: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Ingrese el documento del cliente: ");
            cliente.Documento = Console.ReadLine();
            Console.Write("Ingrese la dirección del cliente: ");
            cliente.Direccion = Console.ReadLine();
            Console.Write("Ingrese el correo del cliente: ");
            cliente.Correo = Console.ReadLine();
            Console.Write("Ingrese el celular del cliente: ");
            cliente.Celular = Console.ReadLine();
            cliente.Estado = "Activo"; // Por defecto

            cliente.CrearCliente(connection);
        }

        static void ActualizarCliente(MySqlConnection connection)
        {
            Cliente cliente = new Cliente();
            Console.Write("Ingrese el ID del cliente a actualizar: ");
            cliente.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nombre del cliente: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del cliente: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Ingrese el documento del cliente: ");
            cliente.Documento = Console.ReadLine();
            Console.Write("Ingrese la dirección del cliente: ");
            cliente.Direccion = Console.ReadLine();
            Console.Write("Ingrese el correo del cliente: ");
            cliente.Correo = Console.ReadLine();
            Console.Write("Ingrese el celular del cliente: ");
            cliente.Celular = Console.ReadLine();
            Console.Write("Ingrese el estado del cliente (Activo/Inactivo): ");
            cliente.Estado = Console.ReadLine();

            cliente.ActualizarCliente(connection);
        }

        static void EliminarCliente(MySqlConnection connection)
        {
            Cliente cliente = new Cliente();
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            cliente.Id = Convert.ToInt32(Console.ReadLine());

            cliente.EliminarCliente(connection);
        }

        static void ListarFacturas(MySqlConnection connection)
        {
            try
            {
                // Consultar todas las facturas
                string query = "SELECT * FROM Factura";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Listado de Facturas:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32("id")}, Nro. Factura: {reader.GetString("Nro_Factura")}, Fecha: {reader.GetDateTime("fecha_hora")}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar facturas: " + ex.Message);
            }
        }

        static void ListarFacturasPorCliente(MySqlConnection connection, int idCliente)
        {
            try
            {
                // Consultar las facturas del cliente específico
                string query = "SELECT * FROM Factura WHERE id_Cliente = @IdCliente";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", idCliente);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine($"Listado de Facturas del Cliente ID: {idCliente}:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32("id")}, Nro. Factura: {reader.GetString("Nro_Factura")}, Fecha: {reader.GetDateTime("fecha_hora")}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar facturas por cliente: " + ex.Message);
            }
        }

        static void IngresarNuevaFactura(MySqlConnection connection)
        {
            Factura factura = new Factura();
            Console.Write("Ingrese el ID del cliente asociado a la factura: ");
            factura.IdCliente = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el número de factura (formato XXX-XXX-XXX): ");
            factura.NroFactura = Console.ReadLine();
            Console.Write("Ingrese la fecha y hora de la factura (formato YYYY-MM-DD HH:MM:SS): ");
            factura.FechaHora = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese el total de la factura: ");
            factura.Total = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total del impuesto al 5%: ");
            factura.TotalIva5 = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total del impuesto al 10%: ");
            factura.TotalIva10 = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total en letras de la factura: ");
            factura.TotalLetras = Console.ReadLine();
            Console.Write("Ingrese la sucursal: ");
            factura.Sucursal = Console.ReadLine();

            factura.CrearFactura(connection);
        }

        static void ActualizarFactura(MySqlConnection connection)
        {
            Factura factura = new Factura();
            Console.Write("Ingrese el ID de la factura a actualizar: ");
            factura.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el ID del cliente asociado a la factura: ");
            factura.IdCliente = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el número de factura (formato XXX-XXX-XXX): ");
            factura.NroFactura = Console.ReadLine();
            Console.Write("Ingrese la fecha y hora de la factura (formato YYYY-MM-DD HH:MM:SS): ");
            factura.FechaHora = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese el total de la factura: ");
            factura.Total = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total del impuesto al 5%: ");
            factura.TotalIva5 = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total del impuesto al 10%: ");
            factura.TotalIva10 = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese el total en letras de la factura: ");
            factura.TotalLetras = Console.ReadLine();
            Console.Write("Ingrese la sucursal: ");
            factura.Sucursal = Console.ReadLine();

            factura.ActualizarFactura(connection);
        }

        static void EliminarFactura(MySqlConnection connection)
        {
            Factura factura = new Factura();
            Console.Write("Ingrese el ID de la factura a eliminar: ");
            factura.Id = Convert.ToInt32(Console.ReadLine());

            factura.EliminarFactura(connection);
        }
    }
}
