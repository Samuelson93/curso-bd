USE [carrental]
GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_POR_MARCA]    Script Date: 08/06/2017 17:20:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE [dbo].[GET_COCHE_POR_MARCA]
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
	, Coches.fechaMatriculacion, coches.cilindrada, coches.idMarca, coches.idTipoCombustible  
	
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
	GROUP BY
	Marcas.denominacion 
	, TiposCombustible.denominacion 
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, coches.cilindrada, coches.idMarca, coches.idTipoCombustible 
	ORDER BY Marcas.denominacion 
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END