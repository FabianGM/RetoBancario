using System.Collections.Generic;

namespace BancoCodigo.Models
{
    /// <summary>
    /// Representa la entidad Movimientos en la base de datos.
    /// Contiene los datos relacionados con los movimientos de cuenta, como el tipo de movimiento, saldo inicial, estado y fecha.
    /// </summary>
    public partial class MovimientosTable
    {
        /// <summary>
        /// Constructor que inicializa la coleccion de registros de movimientos por fecha asociados.
        /// </summary>
        public MovimientosTable()
        {
            MovimientoFecha = new HashSet<MovimientoFecha>();
        }

        /// <summary>
        /// Identificador unico del movimiento.
        /// </summary>
        public int MovimientosId { get; set; }

        /// <summary>
        /// Identificador unico de la cuenta asociada al movimiento.
        /// </summary>
        public int? CuentaId { get; set; }

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
        public int? Movimiento { get; set; }

        /// <summary>
        /// Fecha en que se realizo el movimiento.
        /// </summary>
        public string Fecha { get; set; }

        /// <summary>
        /// Navegacion virtual hacia la cuenta asociada al movimiento.
        /// Relacion muchos a uno con la entidad CuentaTable.
        /// </summary>
        public virtual CuentaTable Cuenta { get; set; }

        /// <summary>
        /// Coleccion de registros de movimientos por fecha asociados al movimiento.
        /// Relacion uno a muchos entre MovimientosTable y MovimientoFecha.
        /// </summary>
        public virtual ICollection<MovimientoFecha> MovimientoFecha { get; set; }
    }
}
