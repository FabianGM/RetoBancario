using BancoCodigo.Models;
using BancoCodigo.Models.Constants;
using BancoCodigo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoCodigo.Controllers
{
    /// <summary>
    /// Controlador API que maneja las operaciones CRUD relacionadas con las cuentas bancarias.
    /// Proporciona endpoints para obtener, crear, actualizar y eliminar cuentas en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BancoCuentasController : ControllerBase
    {
        private readonly ICuentas sCuentas;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="sCuentas">Servicio de cuentas inyectado.</param>
        public BancoCuentasController(ICuentas cuentas)
        {
            sCuentas = cuentas;
        }

        /// <summary>
        /// GET: Obtiene la lista de todas las cuentas.
        /// URL: api/BancoCuentas/Cuentas
        /// </summary>
        /// <returns>IEnumerable con los datos de las cuentas.</returns>
        [HttpGet("Cuentas")]
        public IActionResult ObtenerCuentas()
        {
            return this.HandleResponse(() =>
            {
                var cuentas = sCuentas.ObtenerCuentas();
                return Ok(cuentas);
            });
        }

        /// <summary>
        /// GET: Obtiene una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta.</param>
        /// <returns>Datos de la cuenta especificada.</returns>
        [HttpGet("Cuentas/{id}")]
        public IActionResult ObtenerCuentaEspecifica(int id)
        {
            return this.HandleResponse(() =>
            {
                var cuenta = sCuentas.ObtenerCuentaEspecifica(id);
                if (cuenta == null)
                {
                    return NotFound(Constantes.CUENTA_NO_ENCONTRADA);
                }
                return Ok(cuenta);
            });
        }

        /// <summary>
        /// POST: Crea una nueva cuenta.
        /// URL: api/BancoCuentas/Cuentas/Nuevas/Cuentas
        /// </summary>
        /// <param name="ocuentaTable">Datos de la cuenta a crear.</param>
        [HttpPost("Cuentas/Nuevas/Cuentas")]
        public IActionResult CrearCuenta([FromBody] CuentaTable ocuentaTable)
        {
            return this.HandleResponse(() =>
            {
                sCuentas.CrearCuenta(ocuentaTable);
                return CreatedAtAction(nameof(ObtenerCuentaEspecifica), new { id = ocuentaTable.ClienteId }, ocuentaTable);
            });
        }

        /// <summary>
        /// PUT: Actualiza los datos de una cuenta especifica.
        /// URL: api/BancoCuentas/Cuentas/Editar/Cuentas/{id}
        /// </summary>
        /// <param name="ocuentaTable">Datos actualizados de la cuenta.</param>
        /// <param name="id">Identificador unico de la cuenta.</param>
        [HttpPut("Cuentas/Editar/Cuentas/{id}")]
        public IActionResult ActualizarCuentaEspecifica([FromBody] CuentaTable ocuentaTable, int id)
        {
            return this.HandleResponse(() =>
            {
                sCuentas.ActualizarCuentaEspecifica(ocuentaTable, id);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }

        /// <summary>
        /// DELETE: Elimina una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/Eliminar/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta a eliminar.</param>
        [HttpDelete("Cuentas/Eliminar/Cuentas/{id}")]
        public IActionResult BorrarCuentaEspecifica(int id)
        {
            return this.HandleResponse(() =>
            {
                sCuentas.BorrarCuentaEspecifica(id);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }
    }
}
