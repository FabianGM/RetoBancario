using System.Collections.Generic;

namespace BancoCodigo.Models
{
    /// <summary>
    /// Representa la entidad Cuenta en la base de datos.
    /// Contiene los datos relacionados con una cuenta bancaria, como su numero, tipo, saldo y cliente asociado.
    /// </summary>
    public partial class CuentaTable
    {
        /// <summary>
        /// Constructor que inicializa la coleccion de movimientos asociados a la cuenta.
        /// </summary>
        public CuentaTable()
        {
            MovimientosTable = new HashSet<MovimientosTable>();
        }

        /// <summary>
        /// Identificador unico de la cuenta.
        /// </summary>
        public int CuentaId { get; set; }

        /// <summary>
        /// Identificador unico del cliente asociado a la cuenta.
        /// </summary>
        public int? ClienteId { get; set; }

        /// <summary>
        /// Numero de cuenta bancaria.
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        /// Tipo de cuenta (por ejemplo, ahorro, corriente).
        /// </summary>
        public string TipoCuenta { get; set; }

        /// <summary>
        /// Saldo inicial de la cuenta.
        /// </summary>
        public decimal? SaldoInicial { get; set; }

        /// <summary>
        /// Estado de la cuenta (activa/inactiva).
        /// </summary>
        public int? Estado { get; set; }

        /// <summary>
        /// Nombre del cliente asociado a la cuenta.
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Navegacion virtual hacia el cliente asociado a la cuenta.
        /// Relacion muchos a uno con la entidad ClientesTable.
        /// </summary>
        public virtual ClientesTable ClienteNavigation { get; set; }

        /// <summary>
        /// Coleccion de movimientos asociados a la cuenta.
        /// Relacion uno a muchos entre CuentaTable y MovimientosTable.
        /// </summary>
        public virtual ICollection<MovimientosTable> MovimientosTable { get; set; }
    }
}
