using AppClima.Models;
using AppClima.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppClima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string ciudad, string pais)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ClimaContext db = new ClimaContext())
                {
                    var parameters = new[] {
                        new SqlParameter() {
                            ParameterName = "@Ciudad",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ciudad
                        } ,
                        new SqlParameter() {
                            ParameterName = "@Pais",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pais
                        }
                    };
                    var lstHistoricos = db.Historicos.FromSqlRaw("EXECUTE spGetHistorico @Ciudad, @Pais", parameters).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lstHistoricos;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                throw;
            }

            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(Historico oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ClimaContext db = new ClimaContext())
                {
                    Historico oHistorico = new Historico();
                    oHistorico.PaisNombre = oModel.PaisNombre;
                    oHistorico.CiudadNombre = oModel.CiudadNombre;
                    oHistorico.Clima = oModel.Clima;
                    oHistorico.SensacionTermica = oModel.SensacionTermica;
                    db.Historicos.Add(oHistorico);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
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
