using BancoCodigo.Models;
using BancoCodigo.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Servicio que implementa la interfaz IMovimientos para manejar las operaciones CRUD relacionadas con los movimientos bancarios.
    /// Proporciona la logica necesaria para obtener, crear, actualizar y eliminar movimientos en la base de datos.
    /// </summary>
    public class SrvMovimientos : IMovimientos
    {
        private readonly BaseDeDatosBancoContext _contextService;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="contextService">Contexto de la base de datos inyectado.</param>
        public SrvMovimientos(BaseDeDatosBancoContext contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// GET: Obtiene la lista de todos los movimientos.
        /// URL: api/BancoMovimientos/Movimientos
        /// </summary>
        /// <returns>Lista con los datos de los movimientos.</returns>
        public List<MovimientosTable> ObtenerMovimientos()
        {
            return _contextService.MovimientosTable.ToList();
        }

        /// <summary>
        /// GET: Obtiene un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento.</param>
        /// <returns>Datos del movimiento especificado.</returns>
        public MovimientosTable ObtenerMovimientoEspecifico(int id)
        {
            return _contextService.MovimientosTable.Find(id);
        }

        /// <summary>
        /// GET: Obtiene la lista de movimientos por fechas.
        /// URL: api/BancoMovimientos/MovimientosFechas
        /// </summary>
        /// <returns>Lista de movimientos por fecha.</returns>
        public List<MovimientoFecha> ObtenerMovimientosPorFechas()
        {
            return _contextService.MovimientoFecha.ToList();
        }

        /// <summary>
        /// GET: Obtiene la lista de movimientos para un cliente en una fecha especifica.
        /// URL: api/BancoMovimientos/MovimientosFechas/{fechas}/Clientes/{cliente}
        /// </summary>
        /// <param name="fechas">Fecha especifica.</param>
        /// <param name="cliente">Cliente especifico.</param>
        /// <returns>Lista de movimientos por fecha para un cliente especifico.</returns>
        public List<MovimientoFecha> ObtenerMovimientosPorFechaCliente(string fechas, string cliente)
        {
            return _contextService.MovimientoFecha
                                  .Where(m => m.Fecha == fechas && m.Cliente == cliente)
                                  .ToList();
        }

        /// <summary>
        /// POST: Crea un nuevo movimiento.
        /// URL: api/BancoMovimientos/Movimientos/Nuevos/Movimientos
        /// </summary>
        /// <param name="oMovimiento">Datos del movimiento a crear.</param>
        public void CrearMovimiento(MovimientosTable oMovimiento)
        {
            var nuevoMovimiento = new MovimientosTable
            {
                CuentaId = oMovimiento.CuentaId,
                NumeroCuenta = oMovimiento.NumeroCuenta,
                Tipo = oMovimiento.Tipo,
                SaldoInicial = oMovimiento.SaldoInicial,
                Estado = oMovimiento.Estado,
                Movimiento = oMovimiento.Movimiento,
                Fecha = DateTime.Now.ToString(Constantes.FORMATO_FECHA_INICIAL)
            };

            _contextService.MovimientosTable.Add(nuevoMovimiento);
            _contextService.SaveChanges();
        }

        /// <summary>
        /// PUT: Actualiza los datos de un movimiento especifico.
        /// URL: api/BancoMovimientos/Movimientos/Editar/Movimientos/{id}
        /// </summary>
        /// <param name="oMovimiento">Datos actualizados del movimiento.</param>
        /// <param name="id">Identificador unico del movimiento.</param>
        public string ActualizarMovimientoEspecifico(MovimientosTable oMovimiento, int id)
        {
            var movimientoExistente = _contextService.MovimientosTable.Find(id);
            if (movimientoExistente == null)
            {
                return Constantes.MOVIMIENTO_NO_ENCONTRADO;
            }

            var cuenta = _contextService.CuentaTable.Find(movimientoExistente.CuentaId);

            movimientoExistente.NumeroCuenta = oMovimiento.NumeroCuenta;
            movimientoExistente.Tipo = oMovimiento.Tipo;
            movimientoExistente.SaldoInicial = cuenta.SaldoInicial;
            movimientoExistente.Estado = oMovimiento.Estado;
            movimientoExistente.Movimiento = oMovimiento.Movimiento;

            var nuevoMovimientoFecha = new MovimientoFecha
            {
                MovimientosId = movimientoExistente.MovimientosId,
                Fecha = movimientoExistente.Fecha,
                Cliente = cuenta.Cliente,
                NumeroCuenta = cuenta.NumeroCuenta,
                Tipo = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                Movimiento = movimientoExistente.Movimiento,
                SaldoDisponible = cuenta.SaldoInicial + (movimientoExistente.Movimiento)
            };

            if (nuevoMovimientoFecha.SaldoDisponible < Constantes.VALOR_CERO)
            {
                return Constantes.SALDO_NO_DISPONIBLE;
            }
            else if (nuevoMovimientoFecha.Movimiento > Constantes.CUPO_DIARIO)
            {
                return Constantes.CUPO_DIARIO_EXCEDIDO;
            }
            else
            {
                _contextService.Entry(movimientoExistente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _contextService.MovimientoFecha.Add(nuevoMovimientoFecha);
                _contextService.SaveChanges();
            }

            return Constantes.SOLICITUD_EXITOSA;
        }

        /// <summary>
        /// DELETE: Elimina un movimiento especifico por ID.
        /// URL: api/BancoMovimientos/Movimientos/Eliminar/Movimientos/{id}
        /// </summary>
        /// <param name="id">Identificador unico del movimiento a eliminar.</param>
        public void BorrarMovimientoEspecifico(int id)
        {
            var movimientoAEliminar = _contextService.MovimientoFecha.Find(id);
            if (movimientoAEliminar != null)
            {
                _contextService.Remove(movimientoAEliminar);
                _contextService.SaveChanges();
            }
        }
    }
}
