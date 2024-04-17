

using MySql.Data.MySqlClient;
using System;

public class Conexion
{
    private MySqlConnection connection;

    public Conexion(string connectionString)
    {
        connection = new MySqlConnection(connectionString);
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }
}