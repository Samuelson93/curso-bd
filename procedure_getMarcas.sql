-- PROCEDIMIENTO PARA LISTAR LAS MARCAS
CREATE PROCEDURE GetMarcas
AS
BEGIN
    SELECT id, denominacion FROM Marcas
END