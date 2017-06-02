--CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
	--SELECT  count(*) FROM Coches
	--SELECT *  FROM Coches
	--INSERT INTO Coches (matricula, idMarca, idTiposCombustible,
	--			color, cilindrada, nPlazas, fechaMatriculacion)
	--SELECT  matricula, idMarca, idTiposCombustible, color,
	--		cilindrada, nPlazas, fechaMatriculacion  
	--FROM Coches	

	SELECT 
	  Marcas.denominacion as denominacionMarca
	, TiposCombustible.denominacion as denominacionTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, coches.cilindrada, coches.idMarca, coches.idTiposCombustible  
	
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on Coches.idTiposCombustible = TiposCombustible.id
	GROUP BY
	Marcas.denominacion 
	, TiposCombustible.denominacion 
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, coches.cilindrada, coches.idMarca, coches.idTiposCombustible 
	ORDER BY Marcas.denominacion 
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END