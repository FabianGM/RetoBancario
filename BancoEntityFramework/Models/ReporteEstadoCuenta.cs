using System.Collections.Generic;

namespace BancoCodigo.Models
{
    /// <summary>
    /// Representa el reporte de estado de cuenta de un cliente.
    /// Contiene la informacion de las cuentas y sus respectivos movimientos en un rango de fechas.
    /// </summary>
    public class ReporteEstadoCuenta
    {
        /// <summary>
        /// Identificador unico del cliente.
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Fecha de inicio del rango solicitado.
        /// </summary>
        public string FechaInicio { get; set; }

        /// <summary>
        /// Fecha de fin del rango solicitado.
        /// </summary>
        public string FechaFin { get; set; }

        /// <summary>
        /// Lista de cuentas asociadas con sus respectivos detalles de movimientos.
        /// </summary>
        public List<CuentaReporte> Cuentas { get; set; }
    }

    /// <summary>
    /// Representa una cuenta en el reporte de estado de cuenta.
    /// Contiene la informacion del numero de cuenta, saldo y movimientos.
    /// </summary>
    public class CuentaReporte
    {
        /// <summary>
        /// Numero de cuenta.
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        /// Saldo inicial de la cuenta al inicio del rango solicitado.
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Lista de movimientos realizados en la cuenta dentro del rango de fechas.
        /// </summary>
        public List<MovimientoDetalle> Movimientos { get; set; }
    }

    /// <summary>
    /// Representa el detalle de un movimiento en una cuenta dentro del reporte de estado de cuenta.
    /// </summary>
    public class MovimientoDetalle
    {
        /// <summary>
        /// Fecha en que se realizo el movimiento.
        /// </summary>
        public string Fecha { get; set; }

        /// <summary>
        /// Tipo de movimiento (por ejemplo, deposito, retiro).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Monto del movimiento.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Saldo inicial antes de realizar el movimiento.
        /// </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary>
        /// Estado del movimiento (aprobado, pendiente, etc.).
        /// </summary>
        public int Estado { get; set; }
    }
}
