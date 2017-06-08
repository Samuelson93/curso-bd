--CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_NPLAZAS
AS
BEGIN
	
	SELECT 
	  Marcas.denominacion as denominacionMarca
	, Coches.nPlazas
	, Coches.id, Coches.matricula, coches.idMarca
	
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
	GROUP BY
	Marcas.denominacion 
	, Coches.nPlazas
	, Coches.id, Coches.matricula, coches.idMarca
	ORDER BY Coches.nPlazas
	
END