using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace EXAMENPAR1.REPOSITORY.DATA.CONFIGURACIONESDB
{
    public class ClienteRepository
    {
        private readonly IDbConnection _connection;

        public ClienteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            string query = "SELECT * FROM Cliente";
            return _connection.Query<Cliente>(query);
        }

        public Cliente GetClienteById(int id)
        {
            string query = "SELECT * FROM Cliente WHERE Id = @Id";
            return _connection.QueryFirstOrDefault<Cliente>(query, new { Id = id });
        }

        public void AddCliente(Cliente cliente)
        {
            string query = @"INSERT INTO Cliente (Id_banco, Nombre, Apellido, Documento, Direccion, Correo, Celular, Estado) 
                             VALUES (@Id_banco, @Nombre, @Apellido, @Documento, @Direccion, @Correo, @Celular, @Estado)";
            _connection.Execute(query, cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            string query = @"UPDATE Cliente SET Id_banco = @Id_banco, Nombre = @Nombre, Apellido = @Apellido, 
                             Documento = @Documento, Direccion = @Direccion, Correo = @Correo, Celular = @Celular, Estado = @Estado 
                             WHERE Id = @Id";
            _connection.Execute(query, cliente);
        }

        public void DeleteCliente(int id)
        {
            string query = "DELETE FROM Cliente WHERE Id = @Id";
            _connection.Execute(query, new { Id = id });
        }
    }
}
