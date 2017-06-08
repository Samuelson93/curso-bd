CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA_ID]
    @id bigint
AS
BEGIN
SELECT 
      Marcas.denominacion as denominacionMarca
    , TiposCombustible.denominacion as denominacionTipoCombustible
    , Coches.idMarca
    , Coches.idTiposCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustible on Coches.idTiposCombustible = TiposCombustible.id
WHERE Coches.id = @id
GROUP BY 
      Marcas.denominacion
    , TiposCombustible.denominacion
    , Coches.idMarca
    , Coches.idTiposCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion
END