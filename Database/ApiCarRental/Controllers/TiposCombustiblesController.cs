using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCarRental.Controllers
{
    public class TiposCombustiblesController : ApiController
    {
        // GET: api/TiposCombustibles
        public RespuestaAPI Get()
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            List<TipoCombustible> data = new List<TipoCombustible>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    data = Db.GetTiposCombustibles();
                   
                }
                respuesta.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se produjo un error";
            }

            respuesta.totalElementos = data.Count;
            respuesta.dataTiposCombustible = data;
            return respuesta;
        }










        // GET: api/TiposCombustibles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TiposCombustibles
        [HttpPost]
        public IHttpActionResult Post([FromBody]TipoCombustible tipoCombustible)
        {
            RespuestaAPI respuesta = new RespuestaAPI();
            respuesta.error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarTipoCombustible(tipoCombustible);
                }
                respuesta.totalElementos = filasAfectadas;

                Db.Desconectar();
            }
            catch 
            {
                respuesta.totalElementos = 0;
                respuesta.error = "error al agregar el tipo combustible";

            }

            return Ok(respuesta);
        }

        // PUT: api/TiposCombustibles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TiposCombustibles/5
        public void Delete(int id)
        {
        }
    }
}