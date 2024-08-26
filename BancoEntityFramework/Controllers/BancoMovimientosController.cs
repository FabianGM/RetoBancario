using BancoCodigo.Models;
using BancoCodigo.Models.Constants;
using BancoCodigo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoCodigo.Controllers
{
    /// <summary>
    /// Controlador API que maneja las operaciones CRUD relacionadas con los movimientos bancarios.
    /// Proporciona endpoints para obtener, crear, actualizar y eliminar movimientos en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BancoMovimientosController : ControllerBase
    {
        private readonly IMovimientos sMovimientos;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="servicioMovimientos">Servicio de movimientos inyectado.</param>
        public BancoMovimientosController(IMovimientos movimientos)
        {
            sMovimientos = movimientos;
        }

        /// <summary>
        /// GET: Obtiene la lista de todos los movimientos.
        /// URL: api/BancoMovimientos/Movimientos
        /// </summary>
        /// <returns>IEnumerable con los datos de los movimientos.</returns>
        [HttpGet("Movimientos")]
        public IActionResult ObtenerMovimientos()
        {
            return this.HandleResponse(() =>
            {
                var movimientos = sMovimientos.ObtenerMovimientos();
                return Ok(movimientos);
            });
        }

        /// <summary>
        /// GET: Obtiene un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento.</param>
        /// <returns>Datos del movimiento especificado.</returns>
        [HttpGet("Movimientos/{id}")]
        public IActionResult ObtenerMovimientoEspecifico(int id)
        {
            return this.HandleResponse(() =>
            {
                var movimiento = sMovimientos.ObtenerMovimientoEspecifico(id);
                if (movimiento == null)
                {
                    return NotFound(Constantes.MOVIMIENTO_NO_ENCONTRADO);
                }
                return Ok(movimiento);
            });
        }

        /// <summary>
        /// GET: Obtiene la lista de movimientos por fechas.
        /// URL: api/BancoMovimientos/MovimientosFechas
        /// </summary>
        /// <returns>Lista de movimientos por fecha.</returns>
        [HttpGet("MovimientosFechas")]
        public IActionResult ObtenerMovimientosPorFechas()
        {
            return this.HandleResponse(() =>
            {
                var movimientosPorFechas = sMovimientos.ObtenerMovimientosPorFechas();
                return Ok(movimientosPorFechas);
            });
        }

        /// <summary>
        /// GET: Obtiene la lista de movimientos para un cliente en una fecha especifica.
        /// URL: api/BancoMovimientos/MovimientosFechas/{fechas}/Clientes/{cliente}
        /// </summary>
        /// <param name="fechas">Fecha especifica.</param>
        /// <param name="cliente">Cliente especifico.</param>
        /// <returns>Lista de movimientos por fecha para un cliente especifico.</returns>
        [HttpGet("MovimientosFechas/{fechas}/Clientes/{cliente}")]
        public IActionResult ObtenerMovimientosPorFechaCliente(string fechas, string cliente)
        {
            return this.HandleResponse(() =>
            {
                var movimientos = sMovimientos.ObtenerMovimientosPorFechaCliente(fechas, cliente);
                return Ok(movimientos);
            });
        }

        /// <summary>
        /// POST: Crea un nuevo movimiento.
        /// URL: api/BancoMovimientos/Movimientos/Nuevos/Movimientos
        /// </summary>
        /// <param name="oMovimiento">Datos del movimiento a crear.</param>
        [HttpPost("Movimientos/Nuevos/Movimientos")]
        public IActionResult CrearMovimiento([FromBody] MovimientosTable oMovimiento)
        {
            return this.HandleResponse(() =>
            {
                sMovimientos.CrearMovimiento(oMovimiento);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }

        /// <summary>
        /// PUT: Actualiza los datos de un movimiento especifico.
        /// URL: api/BancoMovimientos/Movimientos/Editar/Movimientos/{id}
        /// </summary>
        /// <param name="oMovimiento">Datos actualizados del movimiento.</param>
        /// <param name="id">Identificador unico del movimiento.</param>
        [HttpPut("Movimientos/Editar/Movimientos/{id}")]
        public IActionResult ActualizarMovimientoEspecifico([FromBody] MovimientosTable oMovimiento, int id)
        {
            return this.HandleResponse(() =>
            {
                var resultado = sMovimientos.ActualizarMovimientoEspecifico(oMovimiento, id);
                return Ok(resultado);
            });
        }

        /// <summary>
        /// DELETE: Elimina un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/Eliminar/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento a eliminar.</param>
        [HttpDelete("Movimientos/Eliminar/Movimientos/{id}")]
        public IActionResult BorrarMovimientoEspecifico(int id)
        {
            return this.HandleResponse(() =>
            {
                sMovimientos.BorrarMovimientoEspecifico(id);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }
    }
}
