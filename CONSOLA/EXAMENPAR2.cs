using EXAMENPAR1.REPOSITORY.DATA;
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

            ClienteRepository clienteRepository = new ClienteRepository(connection);
            FacturaRepository facturaRepository = new FacturaRepository(connectionString);
            SucursalRepository sucursalRepository = new SucursalRepository(connectionString);

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
                        foreach (var cliente in clienteRepository.GetAllClientes())
                        {
                            Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}");
                        }
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del cliente a buscar: ");
                        int idClienteBuscar = Convert.ToInt32(Console.ReadLine());
                        var clienteEncontrado = clienteRepository.GetClienteById(idClienteBuscar);
                        if (clienteEncontrado != null)
                        {
                            Console.WriteLine($"Cliente encontrado - ID: {clienteEncontrado.Id}, Nombre: {clienteEncontrado.Nombre}, Apellido: {clienteEncontrado.Apellido}");
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;
                    case "3":
                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido del cliente: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Ingrese el ID del banco: ");
                        int idBanco = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el documento del cliente: ");
                        string documento = Console.ReadLine();
                        Console.Write("Ingrese la dirección del cliente: ");
                        string direccion = Console.ReadLine();
                        Console.Write("Ingrese el correo electrónico del cliente: ");
                        string correo = Console.ReadLine();
                        Console.Write("Ingrese el número de celular del cliente: ");
                        string celular = Console.ReadLine();
                        Console.Write("Ingrese el estado del cliente ('Activo' o 'Inactivo'): ");
                        string estadoCliente = Console.ReadLine();
                        Cliente nuevoCliente = new Cliente
                        {
                            Id_banco = idBanco,
                            Nombre = nombre,
                            Apellido = apellido,
                            Documento = documento,
                            Direccion = direccion,
                            Correo = correo,
                            Celular = celular,
                            Estado = estadoCliente // Asignamos el estado proporcionado por el usuario
                        };
                        clienteRepository.AddCliente(nuevoCliente);
                        break;

                    case "4":
                        Console.Write("Ingrese el ID del cliente a actualizar: ");
                        int idClienteActualizar = Convert.ToInt32(Console.ReadLine());
                        var clienteActualizar = clienteRepository.GetClienteById(idClienteActualizar);
                        if (clienteActualizar != null)
                        {
                            Console.Write("Ingrese el nuevo nombre del cliente: ");
                            string nuevoNombre = Console.ReadLine();
                            Console.Write("Ingrese el nuevo apellido del cliente: ");
                            string nuevoApellido = Console.ReadLine();
                            // Continuar con la actualización de otros campos si es necesario
                            clienteActualizar.Nombre = nuevoNombre;
                            clienteActualizar.Apellido = nuevoApellido;
                            clienteRepository.UpdateCliente(clienteActualizar);
                            Console.WriteLine("Cliente actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;
                    case "5":
                        Console.Write("Ingrese el ID del cliente a eliminar: ");
                        int idClienteEliminar = Convert.ToInt32(Console.ReadLine());
                        clienteRepository.DeleteCliente(idClienteEliminar);
                        Console.WriteLine("Cliente eliminado correctamente.");
                        break;
                    case "8":
                        Console.Write("Ingrese el ID del cliente para la nueva factura: ");
                        int idClienteFactura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el número de factura: ");
                        int nroFactura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el total de la factura: ");
                        decimal totalFactura = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Ingrese el total de IVA al 5%: ");
                        decimal totalIva5 = Convert.ToDecimal(Console.ReadLine());
                        // Agrega la entrada de datos para TotalIva10 y TotalLetras aquí si corresponde
                        decimal totalIva10 = 0; // Asigna un valor predeterminado si es necesario
                        string totalLetras = ""; // Asigna un valor predeterminado si es necesario
                                                 // Aquí deberías obtener el valor de idSucursal o pasarlo desde algún lugar
                         
                        Factura nuevaFactura = new Factura
                        {
                            IdCliente = idClienteFactura,
                            NroFactura = nroFactura,
                            FechaHora = DateTime.Now, // Puedes ajustar la fecha y hora según sea necesario
                            Total = totalFactura,
                            TotalIva5 = totalIva5,
                            TotalIva10 = totalIva10, // Ajusta este valor según corresponda
                            TotalLetras = totalLetras, // Ajusta este valor según corresponda
                            
                        };
                        facturaRepository.AddFactura(nuevaFactura);
                        Console.WriteLine("Factura ingresada correctamente.");
                        break;

                    case "9":
                        Console.Write("Ingrese el ID de la factura a actualizar: ");
                        int idFacturaActualizar = Convert.ToInt32(Console.ReadLine());
                        var facturaActualizar = facturaRepository.GetFacturaById(idFacturaActualizar);
                        if (facturaActualizar != null)
                        {
                            Console.Write("Ingrese el nuevo número de factura: ");
                            int nuevoNroFactura = Convert.ToInt32(Console.ReadLine());
                            // Continuar con la actualización de otros campos si es necesario
                            facturaActualizar.NroFactura = nuevoNroFactura;
                            facturaRepository.UpdateFactura(facturaActualizar);
                            Console.WriteLine("Factura actualizada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Factura no encontrada.");
                        }
                        break;
                    case "10":
                        Console.Write("Ingrese el ID de la factura a eliminar: ");
                        int idFacturaEliminar = Convert.ToInt32(Console.ReadLine());
                        facturaRepository.DeleteFactura(idFacturaEliminar);
                        Console.WriteLine("Factura eliminada correctamente.");
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
    }
}
