using System.Collections.Generic;

namespace BancoCodigo.Models
{
    /// <summary>
    /// Representa la entidad Clientes en la base de datos.
    /// Contiene los datos relacionados con un cliente, como su nombre, direccion, telefono y clave.
    /// </summary>
    public partial class ClientesTable
    {
        /// <summary>
        /// Constructor que inicializa la coleccion de cuentas asociadas al cliente.
        /// </summary>
        public ClientesTable()
        {
            CuentaTable = new HashSet<CuentaTable>();
        }

        /// <summary>
        /// Identificador unico del cliente.
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Direccion del cliente.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Numero de telefono del cliente.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Clave de acceso del cliente.
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Estado del cliente (activo/inactivo).
        /// </summary>
        public int? Estado { get; set; }

        /// <summary>
        /// Coleccion de cuentas asociadas al cliente.
        /// Relacion uno a muchos entre ClientesTable y CuentaTable.
        /// </summary>
        public virtual ICollection<CuentaTable> CuentaTable { get; set; }
    }
}
