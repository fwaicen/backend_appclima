using AppClima.Models;
using AppClima.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppClima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ClimaContext db = new ClimaContext())
                {
                    var lstCiudades = db.Ciudades.FromSqlRaw("EXECUTE spGetCiudades").ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lstCiudades;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                throw;
            }

            return Ok(oRespuesta);
        }
    }
}
