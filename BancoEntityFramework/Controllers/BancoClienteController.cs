using BancoCodigo.Models;
using BancoCodigo.Models.Constants;
using BancoCodigo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoCodigo.Controllers
{
    /// <summary>
    /// Controlador API que maneja las operaciones CRUD relacionadas con los clientes.
    /// Proporciona endpoints para obtener, crear, actualizar y eliminar clientes en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BancoClienteController : ControllerBase
    {
        private readonly ICliente sCliente;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="cliente">Servicio de cliente inyectado.</param>
        public BancoClienteController(ICliente cliente)
        {
            sCliente = cliente;
        }

        /// <summary>
        /// GET: Obtiene la lista de todos los clientes.
        /// URL: api/BancoCliente/Clientes
        /// </summary>
        /// <returns>IEnumerable con los datos de los clientes.</returns>
        [HttpGet("Clientes")]
        public IActionResult ObtenerClientes()
        {
            return this.HandleResponse(() =>
            {
                var clientes = sCliente.ObtenerClientes();
                return Ok(clientes);
            });
        }

        /// <summary>
        /// GET: Obtiene un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente.</param>
        /// <returns>Datos del cliente especificado.</returns>
        [HttpGet("Clientes/{id}")]
        public IActionResult ObtenerClientesEspecifico(int id)
        {
            return this.HandleResponse(() =>
            {
                var cliente = sCliente.ObtenerClienteEspecifico(id);

                if (cliente == null)
                {
                    return NotFound(Constantes.CLIENTE_NO_ENCONTRADO);
                }

                return Ok(cliente);
            });
        }

        /// <summary>
        /// POST: Crea un nuevo cliente.
        /// URL: api/BancoCliente/Clientes/Registros
        /// </summary>
        /// <param name="oclientesTable">Datos del cliente a crear.</param>
        /// <returns>Resultado de la operacion.</returns>
        [HttpPost("Clientes/Registros")]
        public IActionResult CrearCliente([FromBody] ClientesTable oclientesTable)
        {
            return this.HandleResponse(() =>
            {
                if (string.IsNullOrEmpty(oclientesTable.Nombre) || string.IsNullOrEmpty(oclientesTable.Clave))
                {
                    return BadRequest(Constantes.NOMBRES_Y_CLAVES_VACIOS);
                }

                sCliente.CrearCliente(oclientesTable);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }

        /// <summary>
        /// PUT: Actualiza los datos de un cliente especifico.
        /// URL: api/BancoCliente/Clientes/Actualizar/Clientes/{id}
        /// </summary>
        /// <param name="oclientesTable">Datos actualizados del cliente.</param>
        /// <param name="id">Identificador unico del cliente.</param>
        /// <returns>Resultado de la operacion.</returns>
        [HttpPut("Clientes/Actualizar/Clientes/{id}")]
        public IActionResult ActualizarClienteEspecifico([FromBody] ClientesTable oclientesTable, int id)
        {
            return this.HandleResponse(() =>
            {
                var clienteExistente = sCliente.ObtenerClienteEspecifico(id);

                if (clienteExistente == null)
                {
                    return NotFound(Constantes.CLIENTE_NO_ENCONTRADO);
                }

                sCliente.ActualizarClienteEspecifico(oclientesTable, id);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }

        /// <summary>
        /// DELETE: Elimina un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/Eliminar/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente a eliminar.</param>
        /// <returns>Resultado de la operacion.</returns>
        [HttpDelete("Clientes/Eliminar/Clientes/{id}")]
        public IActionResult BorrarClienteEspecifico(int id)
        {
            return this.HandleResponse(() =>
            {
                var clienteExistente = sCliente.ObtenerClienteEspecifico(id);

                if (clienteExistente == null)
                {
                    return NotFound(Constantes.CLIENTE_NO_ENCONTRADO);
                }

                sCliente.BorrarClienteEspecifico(id);
                return Ok(Constantes.SOLICITUD_EXITOSA);
            });
        }
    }
}
