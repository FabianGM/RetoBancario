using BancoCodigo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoCodigo.Controllers
{
    /// <summary>
    /// Controlador API que maneja la generacion de reportes de estado de cuenta.
    /// Proporciona un endpoint para generar un reporte de estado de cuenta por cliente y rango de fechas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BancoReportesController : ControllerBase
    {
        private readonly IReportes _reportesService;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="reportesService">Servicio de reportes inyectado.</param>
        public BancoReportesController(IReportes reportesService)
        {
            _reportesService = reportesService;
        }

        /// <summary>
        /// GET: Genera un reporte de estado de cuenta por cliente y rango de fechas.
        /// URL: BancoReportes/Reportes?fecha=inicio_fin&cliente=clienteId
        /// </summary>
        /// <param name="fecha">Rango de fechas en formato inicio_fin.</param>
        /// <param name="cliente">Identificador unico del cliente.</param>
        /// <returns>Reporte de estado de cuenta en formato JSON.</returns>
        [HttpGet("Reportes")]
        public IActionResult GenerarReporte([FromQuery] string fecha, [FromQuery] int cliente)
        {
            return this.HandleResponse(() =>
            {
                var resultado = _reportesService.GenerarReporte(fecha, cliente);
                return Ok(resultado);
            });
        }
    }
}
