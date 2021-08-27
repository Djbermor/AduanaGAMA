If  Object_id(N'DBO.GestionEmpleado','P') IS NOT NULL 
Begin 
 Drop Procedure [DBO].GestionEmpleado;
End;
Go

CREATE PROCEDURE GestionEmpleado
@Activar VARCHAR(20),
@nombre NVARCHAR(100) = null,
@apellido NVARCHAR(100) = null,
@direccion NVARCHAR(100)  = null,
@telefono NVARCHAR(100)  = null,
@salario money  = null,
@departamento int  = null,
@rol INT  = null,
@fecha datetime  = null,
@sexo NVARCHAR(100)  = null,
@codigo NVARCHAR(100)  = null,
@id INT  = null
AS 
IF @Activar = 'Insertar'
BEGIN
	INSERT INTO  Empleado (Nombre,Apellido,Direccion,Telefono,Salario,IdDepartamento,Rol,FechaIngreso,Sexo,CodigoCompania)
	VALUES (@nombre, @apellido, @direccion, @telefono, @salario, @departamento, @rol, @fecha, @sexo, @codigo)

	--retorna el id de la ultima insercion
	select SCOPE_IDENTITY() as Id
	return
END

IF @Activar = 'Actualizar'
BEGIN
	UPDATE Empleado 
		SET Nombre=@nombre,Apellido=@apellido,Direccion=@direccion,Telefono=@telefono,Salario=@salario,IdDepartamento=@departamento,Rol=@rol,FechaIngreso=@fecha,Sexo=@sexo,CodigoCompania=@codigo 
	WHERE Id=@id

	select @id as Id
	return
END

IF @Activar = 'Consultar'
BEGIN
	if IsNull(@id, 0) = 0 
	begin
		SELECT Empleado.Id, Empleado.Nombre, Apellido, Direccion, Telefono, Convert(int, Salario) as Salario, IdDepartamento, Rol, 
			Convert(varchar, FechaIngreso, 23) as FechaIngreso, Sexo, CodigoCompania, 
			Departamento.Nombre as NombreDepartamento, Rol.nombre as NombreRol
		FROM Empleado
			inner join Rol on Rol.Id = Empleado.Rol
			inner join Departamento on Departamento.Id = Empleado.IdDepartamento
			where  Rol >=2
	end
	else
	begin
		SELECT Empleado.Id, Empleado.Nombre, Apellido, Direccion, Telefono, Convert(int, Salario) as Salario, IdDepartamento, Rol, 
			Convert(varchar, FechaIngreso, 23) as FechaIngreso, Sexo, CodigoCompania, 
			Departamento.Nombre as NombreDepartamento, Rol.nombre as NombreRol
		FROM Empleado
			inner join Rol on Rol.Id = Empleado.Rol
			inner join Departamento on Departamento.Id = Empleado.IdDepartamento
		where Empleado.Id = @id
	end

	return
END

IF @Activar = 'Eliminar'
BEGIN
	DELETE FROM Empleado WHERE Id=@id
	return
END

-------------------------------------
-- ROLES
-------------------------------------
IF @Activar = 'CRoles'
BEGIN
	select '0' as Id, 'Rol*' as  Nombre
	union
	SELECT Id, nombre as Nombre from Rol

	return
END

-------------------------------------
-- Departamento
-------------------------------------
IF @Activar = 'CDepa'
BEGIN
	select '0' as Id, 'Departamento*' as  Nombre
	union
	SELECT Id, nombre as Nombre from Departamento

	return
END

-------------------------------------
-- Query Deprtamento
-------------------------------------
IF @Activar = 'CDeparta'
BEGIN
	if IsNull(@id, 0) = 0 
	begin
		SELECT Id, nombre as Nombre
		FROM Departamento
	end
	else
	begin
		SELECT Id, nombre as Nombre
		FROM Departamento
		where Departamento.Id = @id
	end

	return
END

IF @Activar = 'ADeparta'
BEGIN
	UPDATE Departamento 
		SET Nombre=@nombre
	WHERE Id=@id

	select @id as Id
	return
END

IF @Activar = 'IDeparta'
BEGIN
	INSERT INTO  Departamento(Nombre)
	VALUES (@nombre)

	--retorna el id de la ultima insercion
	select SCOPE_IDENTITY() as Id
	return
END

IF @Activar = 'EDeparta'
BEGIN
	DELETE FROM Departamento WHERE Id=@id
	return
END

-------------------------------------
-- Query Jefe
-------------------------------------
IF @Activar = 'CJefe'
BEGIN
	if IsNull(@id, 0) = 0 
	begin
		SELECT Empleado.Id, Empleado.Nombre, Apellido, Direccion, Telefono, Convert(int, Salario) as Salario, IdDepartamento, Rol, 
			Convert(varchar, FechaIngreso, 23) as FechaIngreso, Sexo, CodigoCompania, 
			Departamento.Nombre as NombreDepartamento, Rol.nombre as NombreRol
		FROM Empleado
			inner join Rol on Rol.Id = Empleado.Rol
			inner join Departamento on Departamento.Id = Empleado.IdDepartamento
			where  Rol = 1
	end
	else
	begin
	-- Esta linea de codigo no tiene ningun uso, pero se deja por si deseo usar mas adelante
		SELECT Empleado.Id, Empleado.Nombre, Apellido, Direccion, Telefono, Convert(int, Salario) as Salario, IdDepartamento, Rol, 
			Convert(varchar, FechaIngreso, 23) as FechaIngreso, Sexo, CodigoCompania, 
			Departamento.Nombre as NombreDepartamento, Rol.nombre as NombreRol
		FROM Empleado
			inner join Rol on Rol.Id = Empleado.Rol
			inner join Departamento on Departamento.Id = Empleado.IdDepartamento
		where Empleado.Id = @id and Rol = 1
	end

	return
END

-------------------------------------
-- Query Rol
-------------------------------------
IF @Activar = 'CRol'
BEGIN
	if IsNull(@id, 0) = 0 
	begin
		SELECT Id, nombre as Nombre
		FROM Rol
	end
	else
	begin
		SELECT Id, nombre as Nombre
		FROM Rol
		where Rol.Id = @id
	end

	return
END

IF @Activar = 'ARol'
BEGIN
	UPDATE Rol 
		SET Nombre=@nombre
	WHERE Id=@id

	select @id as Id
	return
	BEGIN
	UPDATE Rol 
		SET Nombre=@nombre
	WHERE Id=@id

	select @id as Id
	return
END
END

IF @Activar = 'IRol'
BEGIN
	INSERT INTO  Rol(Nombre)
	VALUES (@nombre)

	--retorna el id de la ultima insercion
	select SCOPE_IDENTITY() as Id
	return
END

IF @Activar = 'ERol'
BEGIN
	DELETE FROM Rol WHERE Id=@id
	return
END

IF @Activar = 'CSexo'
BEGIN
	select 'Sexo*' as Nombre
	union
	select 'M'
	union
	select 'F'
	order by Nombre desc

	return
END
GO
