namespace BancoCodigo.Models
{
    /// <summary>
    /// Representa la entidad MovimientoFecha en la base de datos.
    /// Contiene los datos relacionados con los movimientos de cuenta, incluyendo fecha, cliente, tipo de movimiento y saldos.
    /// </summary>
    public partial class MovimientoFecha
    {
        /// <summary>
        /// Identificador unico del registro de movimiento por fecha.
        /// </summary>
        public int MovimientoFechaId { get; set; }

        /// <summary>
        /// Identificador unico del movimiento asociado.
        /// </summary>
        public int? MovimientosId { get; set; }

        /// <summary>
        /// Fecha en que se realizo el movimiento.
        /// </summary>
        public string Fecha { get; set; }

        /// <summary>
        /// Nombre del cliente asociado al movimiento.
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Numero de cuenta donde se realizo el movimiento.
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        /// Tipo de movimiento (por ejemplo, deposito, retiro).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Saldo inicial antes de realizar el movimiento.
        /// </summary>
        public decimal? SaldoInicial { get; set; }

        /// <summary>
        /// Estado del movimiento (aprobado, pendiente, etc.).
        /// </summary>
        public int? Estado { get; set; }

        /// <summary>
        /// Monto del movimiento realizado.
        /// </summary>
        public decimal? Movimiento { get; set; }

        /// <summary>
        /// Saldo disponible en la cuenta despues del movimiento.
        /// </summary>
        public decimal? SaldoDisponible { get; set; }

        /// <summary>
        /// Navegacion virtual hacia el movimiento asociado.
        /// Relacion muchos a uno con la entidad MovimientosTable.
        /// </summary>
        public virtual MovimientosTable Movimientos { get; set; }
    }
}
