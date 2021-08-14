CREATE DATABASE GestionEmpleado
GO
USE GestionEmpleado
GO
CREATE TABLE Departamento(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Nombre NVARCHAR (100) NOT NULL
)
GO
CREATE TABLE Rol(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Nombre NVARCHAR (100) NOT NULL
)
GO
CREATE TABLE Empleado(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Nombre NVARCHAR (100) NOT NULL,
	Apellido NVARCHAR (100) NOT NULL,
	Direccion NVARCHAR (100) NOT NULL, 
	Telefono NVARCHAR (100) NOT NULL,
	Salario MONEY NOT NULL, 
	IdDepartamento INT NOT NULL,
	Rol int NOT NULL,
	FechaIngreso DATETIME NOT NULL, 
	Sexo NVARCHAR (50) NOT NULL, 
	CodigoCompania NVARCHAR (100) NOT NULL,
	FOREIGN KEY (IdDepartamento) REFERENCES Departamento(Id),
	FOREIGN KEY (Rol) REFERENCES Rol(Id)
)
GO
INSERT INTO Rol(Nombre)VALUES('Jefe')
GO
INSERT INTO Rol(Nombre)VALUES('Empleado')
GO
INSERT INTO Departamento(Nombre)VALUES('Recursos Humanos')
GO
INSERT INTO Departamento(Nombre)VALUES('Sistemas')
GO
INSERT INTO Departamento(Nombre)VALUES('Logistica')
GO
INSERT INTO Departamento(Nombre)VALUES('Operador')
GO
UPDATE Rol SET Nombre = 'Operador' WHERE Id=2
GO
UPDATE Departamento SET Nombre = 'Produccion' WHERE Id=4
GO
SELECT * FROM Rol
GO
SELECT * FROM Departamento
GO 
--CREATE PROCEDURE GestionEmpleado
--@Activar NVARCHAR(20),
--@nombre NVARCHAR(100),
--@apellido NVARCHAR(100),
--@direcion NVARCHAR(100),
--@telefono NVARCHAR(100),
--@salario money,
--@departamento int,
--@rol INT,
--@fecha datetime,
--@sexo NVARCHAR(100),
--@codigo NVARCHAR(100),
--@id INT
--AS 
--IF @Activar = 'Insertar'
--BEGIN
--	INSERT INTO  Empleado (Nombre,Apellido,Dirección,Teléfono,Salario,IdDepartamento,Rol,FechaIngreso,Sexo,CódigoCompanía)
--	VALUES (@nombre, @apellido, @direcion, @telefono, @salario, @departamento, @rol, @fecha, @sexo, @codigo)

--	--retorna el id de la ultima insercion
--	select SCOPE_IDENTITY() as Id
--END

--IF @Activar = 'Actualizar'
--BEGIN
--	UPDATE Empleado 
--		SET Nombre=@nombre,Apellido=@apellido,Dirección=@direcion,Teléfono=@telefono,Salario=@salario,IdDepartamento=@departamento,Rol=@rol,FechaIngreso=@fecha,Sexo=@sexo,CódigoCompanía=@codigo 
--	WHERE Id=@id

--	select @id as Id
--END

--IF @Activar = 'Consultar'
--BEGIN
--	SELECT Id, Nombre, Apellido, Dirección, Salario, IdDepartamento, Rol, FechaIngreso, Sexo, CódigoCompanía 
--	FROM Empleado
--END

--IF @Activar = 'Eliminar'
--BEGIN
--	DELETE FROM Empleado WHERE Id=@id
--END
--GO


