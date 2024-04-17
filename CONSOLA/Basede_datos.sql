CREATE DATABASE Basede_datos;
USE Basede_datos;
	
DROP DATABASE Basede_datos;
CREATE TABLE Cliente (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_banco INT ,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    documento VARCHAR(15),
    direccion VARCHAR(100),
    correo VARCHAR(100),
    celular VARCHAR(15),
    estado VARCHAR(10)
);

INSERT INTO Cliente (id_banco, nombre, apellido, documento, direccion, correo, celular, estado)
VALUES 
(1, 'Juan', 'Pérez', '123456789', 'Calle 123', 'juan@example.com', '123456789', 'Activo'),
(2, 'María', 'González', '987654321', 'Avenida 456', 'maria@example.com', '987654321', 'Inactivo'),
(3, 'Carlos', 'López', '456789123', 'Plaza Principal', 'carlos@example.com', '456789123', 'Activo'),
(4, 'Ana', 'Martínez', '789123456', 'Calle Principal', 'ana@example.com', '789123456', 'Inactivo'),
(5, 'Luis', 'Rodríguez', '321654987', 'Avenida Central', 'luis@example.com', '321654987', 'Activo');


CREATE TABLE Factura (
	id INT AUTO_INCREMENT PRIMARY KEY,
    id_Cliente INT ,
	Nro_Factura VARCHAR(100) ,
	fecha_hora DATETIME ,
	total DECIMAL(15, 2)  ,
	total_iva5 DECIMAL(15, 2) ,
	total_iva10 DECIMAL(15, 2) ,
    total_letras VARCHAR(100) ,
    sucursal VARCHAR(50) 
	
);

INSERT INTO Factura (id_Cliente, Nro_Factura, fecha_hora, total, total_iva5, total_iva10, total_letras, sucursal)
VALUES
(1, '001', '2024-04-16 10:00:00', 100.00, 5.00, 10.00, 'Cien dólares con 00/100', 'Sucursal A'),
(2,'002', '2024-04-16 11:00:00', 150.00, 7.50, 15.00, 'Ciento cincuenta dólares con 00/100', 'Sucursal B'),
(3, '003', '2024-04-16 12:00:00', 200.00, 10.00, 20.00, 'Doscientos dólares con 00/100', 'Sucursal C'),
(4, '004', '2024-04-16 13:00:00', 75.00, 3.75, 7.50, 'Setenta y cinco dólares con 00/100', 'Sucursal A'),
(5, '005', '2024-04-16 14:00:00', 120.00, 6.00, 12.00, 'Ciento veinte dólares con 00/100', 'Sucursal B');