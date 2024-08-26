using BancoCodigo.Models;
using System.Collections.Generic;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Interfaz que define las operaciones CRUD relacionadas con los movimientos bancarios.
    /// Proporciona los metodos necesarios para obtener, crear, actualizar y eliminar movimientos.
    /// </summary>
    public interface IMovimientos
    {
        /// <summary>
        /// GET: Obtiene la lista de todos los movimientos.
        /// URL: api/BancoMovimientos/Movimientos
        /// </summary>
        /// <returns>Lista con los datos de los movimientos.</returns>
        List<MovimientosTable> ObtenerMovimientos();

        /// <summary>
        /// GET: Obtiene un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento.</param>
        /// <returns>Datos del movimiento especificado.</returns>
        MovimientosTable ObtenerMovimientoEspecifico(int id);

        /// <summary>
        /// GET: Obtiene la lista de movimientos por fechas.
        /// URL: api/BancoMovimientos/MovimientosFechas
        /// </summary>
        /// <returns>Lista de movimientos por fecha.</returns>
        List<MovimientoFecha> ObtenerMovimientosPorFechas();

        /// <summary>
        /// GET: Obtiene la lista de movimientos para un cliente en una fecha especifica.
        /// URL: api/BancoMovimientos/MovimientosFechas/{fechas}/Clientes/{cliente}
        /// </summary>
        /// <param name="fechas">Fecha especifica.</param>
        /// <param name="cliente">Cliente especifico.</param>
        /// <returns>Lista de movimientos por fecha para un cliente especifico.</returns>
        List<MovimientoFecha> ObtenerMovimientosPorFechaCliente(string fechas, string cliente);

        /// <summary>
        /// POST: Crea un nuevo movimiento.
        /// URL: api/BancoMovimientos/Movimientos/Nuevos/Movimientos
        /// </summary>
        /// <param name="oMovimiento">Datos del movimiento a crear.</param>
        void CrearMovimiento(MovimientosTable oMovimiento);

        /// <summary>
        /// PUT: Actualiza los datos de un movimiento especifico.
        /// URL: api/BancoMovimientos/Movimientos/Editar/Movimientos/{id}
        /// </summary>
        /// <param name="oMovimiento">Datos actualizados del movimiento.</param>
        /// <param name="id">Identificador unico del movimiento.</param>
        string ActualizarMovimientoEspecifico(MovimientosTable oMovimiento, int id);

        /// <summary>
        /// DELETE: Elimina un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/Eliminar/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento a eliminar.</param>
        void BorrarMovimientoEspecifico(int id);
    }
}
