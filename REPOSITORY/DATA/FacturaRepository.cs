using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace EXAMENPAR1.REPOSITORY.DATA
{
    public class FacturaRepository
    {
        private readonly string _connectionString;

        public FacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return db.Query<Factura>("SELECT * FROM Factura");
            }
        }

        public Factura GetFacturaById(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Factura>("SELECT * FROM Factura WHERE id = @Id", new { Id = id });
            }
        }

        public void AddFactura(Factura factura)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Factura (IdCliente, NroFactura, FechaHora, Total, TotalIva5, TotalIva10, TotalLetras, Sucursal) 
                                VALUES (@IdCliente, @NroFactura, @FechaHora, @Total, @TotalIva5, @TotalIva10, @TotalLetras, @Sucursal)";
                db.Execute(query, factura);
            }
        }

        public void UpdateFactura(Factura factura)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Factura SET IdCliente = @IdCliente, NroFactura = @NroFactura, FechaHora = @FechaHora, 
                                Total = @Total, TotalIva5 = @TotalIva5, TotalIva10 = @TotalIva10, TotalLetras = @TotalLetras, Sucursal = @Sucursal 
                                WHERE Id = @Id";
                db.Execute(query, factura);
            }
        }

        public void DeleteFactura(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Factura WHERE Id = @Id";
                db.Execute(query, new { Id = id });
            }
        }
    }
}
