using BancoCodigo.Models;
using BancoCodigo.Models.Constants;
using System;
using System.Linq;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Implementacion del servicio de generacion de reportes de estado de cuenta.
    /// </summary>
    public class SrvReportes : IReportes
    {
        private readonly BaseDeDatosBancoContext _context;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="context">Contexto de la base de datos inyectado.</param>
        public SrvReportes(BaseDeDatosBancoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Genera un reporte de estado de cuenta para un cliente en un rango de fechas especifico.
        /// </summary>
        /// <param name="rangoFechas">Rango de fechas en formato inicio_fin.</param>
        /// <param name="clienteId">Identificador unico del cliente.</param>
        /// <returns>Reporte de estado de cuenta en formato JSON.</returns>
        public ReporteEstadoCuenta GenerarReporte(string rangoFechas, int clienteId)
        {
            var fechas = rangoFechas.Split('_');
            var fechaInicio = DateTime.ParseExact(fechas[0], Constantes.FORMATO_FECHA_INICIAL, null);
            var fechaFin = DateTime.ParseExact(fechas[1], Constantes.FORMATO_FECHA_INICIAL, null);

            var cuentas = _context.CuentaTable
                .Where(c => c.ClienteId == clienteId)
                .AsEnumerable()
                .Select(c => new CuentaReporte
                {
                    NumeroCuenta = c.NumeroCuenta,
                    SaldoInicial = c.SaldoInicial ?? 0,
                    Movimientos = _context.MovimientosTable
                        .Where(m => m.CuentaId == c.CuentaId)
                        .AsEnumerable()
                        .Where(m =>
                        {
                            DateTime fechaMovimiento;
                            bool esFechaValida = DateTime.TryParseExact(m.Fecha, Constantes.FORMATO_FECHA_INICIAL, null, System.Globalization.DateTimeStyles.None, out fechaMovimiento);
                            return esFechaValida && fechaMovimiento >= fechaInicio && fechaMovimiento <= fechaFin;
                        })
                        .Select(m => new MovimientoDetalle
                        {
                            Fecha = m.Fecha,
                            Tipo = m.Tipo,
                            Monto = m.Movimiento ?? 0,
                            SaldoInicial = m.SaldoInicial ?? 0,
                            Estado = m.Estado ?? 0
                        }).ToList()
                }).ToList();

            return new ReporteEstadoCuenta
            {
                ClienteId = clienteId,
                FechaInicio = fechaInicio.ToString("yyyy-MM-dd"),
                FechaFin = fechaFin.ToString("yyyy-MM-dd"),
                Cuentas = cuentas
            };
        }


    }
}
