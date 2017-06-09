CREATE PROCEDURE AgregarTipoCombustible
	@denominacion nvarchar(50)
AS
	
BEGIN
	INSERT INTO TiposCombustible(denominacion) VALUES(@denominacion) 
END

--Procedimiento Para eliminar una marca.

CREATE PROCEDURE EliminarMarca
	@id bigint
AS
BEGIN
	DELETE FROM Marcas WHERE id =@id
END

--Procedimiento para actualizar los datos de una marca
CREATE PROCEDURE ActualizarMarca
	@denominacion nvarchar(50)
	,@id bigint
AS
BEGIN
	UPDATE Marcas SET
		denominacion = @denominacion
	WHERE id = @id
END