CREATE PROCEDURE AgregarTipoCombustible
	@denominacion nvarchar(50)
AS
	
BEGIN
	INSERT INTO TiposCombustible(denominacion) VALUES(@denominacion) 
END