using AppClima.Models;
using AppClima.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppClima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(string ciudad, string pais)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                ApiHelper.InitializeClient();
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
                var url = new Uri(configuration.GetConnectionString("ApiWeather"));

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url + "&q=" + ciudad))
                {
                    if (response.IsSuccessStatusCode) 
                    {
                        var oModel = JsonConvert.DeserializeObject<Weather>(await response.Content.ReadAsStringAsync());
                        using (ClimaContext db = new ClimaContext())
                        {
                            Historico historico = new Historico();
                            historico.CiudadNombre = ciudad;
                            historico.PaisNombre = pais;
                            historico.Clima = oModel.main.temp;
                            historico.SensacionTermica = oModel.main.feels_like;
                            historico.Icon = oModel.weather[0].icon;
                            oRespuesta.Data = JsonConvert.SerializeObject(historico);
                            db.Historicos.Add(historico);
                            db.SaveChanges();
                        }
                        oRespuesta.Exito = 1;
                    }
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
