CREATE PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS
AS
BEGIN
	SELECT 
		 M.denominacion as Marca
		,C.matricula
		,C.nPlazas
	FROM Marcas M
		INNER JOIN Coches C ON M.id = C.idMarca
	GROUP BY 
		 M.denominacion
		,C.matricula
		,C.nPlazas
	ORDER BY nPlazas
END