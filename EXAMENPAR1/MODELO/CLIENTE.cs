using MySql.Data.MySqlClient;

public class Cliente
{
    public int Id { get; set; }
    public int Id_banco { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public string Direccion { get; set; }
    public string Correo { get; set; }
    public string Celular { get; set; }
    public string Estado { get; set; }

    public void CrearCliente(MySqlConnection connection)
    {
        try
        {
            ServicioCliente servicioCliente = new ServicioCliente();
            if (!servicioCliente.ValidarCliente(this))
                return;

            string query = "INSERT INTO Cliente (id_banco, nombre, apellido, documento, direccion, correo, celular, estado) " +
                           "VALUES (@id_banco, @Nombre, @Apellido, @Documento, @Direccion, @Correo, @Celular, @Estado)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_banco", Id_banco);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Apellido", Apellido);
            command.Parameters.AddWithValue("@Documento", Documento);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Celular", Celular);
            command.Parameters.AddWithValue("@Estado", Estado);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Cliente creado exitosamente.");
            else
                Console.WriteLine("Error al crear el cliente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear el cliente: " + ex.Message);
        }
    }

    public void LeerCliente(MySqlConnection connection, int id)
    {
        try
        {
            string query = "SELECT * FROM Cliente WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Id = reader.GetInt32("id");
                    Id_banco = reader.GetInt32("id_banco");
                    Nombre = reader.GetString("nombre");
                    Apellido = reader.GetString("apellido");
                    Documento = reader.GetString("documento");
                    Direccion = reader.GetString("direccion");
                    Correo = reader.GetString("correo");
                    Celular = reader.GetString("celular");
                    Estado = reader.GetString("estado");

                    Console.WriteLine($"Cliente encontrado: {Nombre} {Apellido}");
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el cliente: " + ex.Message);
        }
    }

    public void ActualizarCliente(MySqlConnection connection)
    {
        try
        {
            string query = "UPDATE Cliente SET id_banco = @id_banco, nombre = @Nombre, apellido = @Apellido, documento = @Documento, " +
                           "direccion = @Direccion, correo = @Correo, celular = @Celular, estado = @Estado " +
                           "WHERE id = @Id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_banco", Id_banco);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Apellido", Apellido);
            command.Parameters.AddWithValue("@Documento", Documento);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Celular", Celular);
            command.Parameters.AddWithValue("@Estado", Estado);
            command.Parameters.AddWithValue("@Id", Id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Cliente actualizado exitosamente.");
            else
                Console.WriteLine("Error al actualizar el cliente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al actualizar el cliente: " + ex.Message);
        }
    }

    public void EliminarCliente(MySqlConnection connection)
    {
        try
        {
            string query = "DELETE FROM Cliente WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Cliente eliminado exitosamente.");
            else
                Console.WriteLine("Error al eliminar el cliente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar el cliente: " + ex.Message);

        }
    }
    static void ListarClientes(MySqlConnection connection)
    {
        string query = "SELECT * FROM clientes";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Nombre: {reader["nombre"]}, Dirección: {reader["direccion"]}");
        }

        reader.Close();
    }

    static void BuscarClientePorId(MySqlConnection connection, int idCliente)
    {
        string query = $"SELECT * FROM clientes WHERE id = {idCliente}";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Nombre: {reader["nombre"]}, Dirección: {reader["direccion"]}");
        }
        else
        {
            Console.WriteLine("No se encontró ningún cliente con ese ID.");
        }

        reader.Close();
    }

    static void IngresarNuevoCliente(MySqlConnection connection)
    {
        Console.Write("Ingrese el nombre del nuevo cliente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la dirección del nuevo cliente: ");
        string direccion = Console.ReadLine();

        string query = $"INSERT INTO clientes (nombre, direccion) VALUES ('{nombre}', '{direccion}')";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();

        Console.WriteLine("Cliente ingresado exitosamente.");




    }

