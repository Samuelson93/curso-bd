using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class MarcasController : ApiController
    {
        // GET: api/Marcas
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaMarcas = Db.GetMarcas();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch 
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaMarcas.Count;
            resultado.dataMarcas =  listaMarcas;
            return resultado;
        }

        // GET: api/Marcas/5
        public RespuestaAPI Get(long id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaMarcas = Db.GetMarcasPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaMarcas.Count;
            resultado.dataMarcas = listaMarcas;
            return resultado;
        }

        // POST: api/Marcas
        [HttpPost]
        public IHttpActionResult Post([FromBody] Marca marca)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta()) 
                    {
                    filasAfectadas = Db.AgregarMarca(marca);
                    }
                respuesta.totalElementos = filasAfectadas;

                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "error al agregar la marca";

            }

            return Ok(respuesta);
        }       

        // PUT: api/Marcas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Marcas/5
        public void Delete(int id)
        {
        }
    }
}
