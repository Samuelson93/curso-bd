--CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
	SELECT  count(*) FROM Coches
	SELECT *  FROM Coches
	INSERT INTO Coches (matricula, idMarca, idTiposCombustible,
				color, cilindrada, nPlazas, fechaMatriculacion)
	SELECT  matricula, idMarca, idTiposCombustible, color,
			cilindrada, nPlazas, fechaMatriculacion  
	FROM Coches	

	SELECT * FROM Coches
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END