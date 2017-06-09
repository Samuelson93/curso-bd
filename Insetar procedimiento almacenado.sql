--PROCEDIMIENTO PARA INSERTAR UNA NUEVA MARCA
CREATE PROCEDURE AgregarMarca
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT INTO Marcas(denominacion) VALUES (@denominacion)
END

