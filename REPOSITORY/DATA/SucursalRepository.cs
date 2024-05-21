using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace EXAMENPAR1.REPOSITORY.DATA
{
    public class SucursalRepository
    {
        private readonly string _connectionString;

        public SucursalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Sucursal> GetAllSucursales()
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return db.Query<Sucursal>("SELECT * FROM Sucursal");
            }
        }

        public Sucursal GetSucursalById(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Sucursal>("SELECT * FROM Sucursal WHERE id = @Id", new { Id = id });
            }
        }

        public void AddSucursal(Sucursal sucursal)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Sucursal (Descripcion, Direccion, Telefono, Whatsapp, Mail, Estado) 
                                VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
                db.Execute(query, sucursal);
            }
        }

        public void UpdateSucursal(Sucursal sucursal)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Sucursal SET Descripcion = @Descripcion, Direccion = @Direccion, Telefono = @Telefono, 
                                Whatsapp = @Whatsapp, Mail = @Mail, Estado = @Estado WHERE Id = @Id";
                db.Execute(query, sucursal);
            }
        }

        public void DeleteSucursal(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Sucursal WHERE Id = @Id";
                db.Execute(query, new { Id = id });
            }
        }
    }
}
