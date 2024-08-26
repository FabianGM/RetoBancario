using BancoCodigo.Models;
using System.Collections.Generic;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Interfaz que define las operaciones CRUD relacionadas con las cuentas bancarias.
    /// Proporciona los metodos necesarios para obtener, crear, actualizar y eliminar cuentas.
    /// </summary>
    public interface ICuentas
    {
        /// <summary>
        /// GET: Obtiene la lista de todas las cuentas.
        /// URL: api/BancoCuentas/Cuentas
        /// </summary>
        /// <returns>Lista con los datos de las cuentas.</returns>
        List<CuentaTable> ObtenerCuentas();

        /// <summary>
        /// GET: Obtiene una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta.</param>
        /// <returns>Datos de la cuenta especificada.</returns>
        CuentaTable ObtenerCuentaEspecifica(int id);

        /// <summary>
        /// POST: Crea una nueva cuenta.
        /// URL: api/BancoCuentas/Cuentas/Nuevas/Cuentas
        /// </summary>
        /// <param name="ocuentaTable">Datos de la cuenta a crear.</param>
        void CrearCuenta(CuentaTable ocuentaTable);

        /// <summary>
        /// PUT: Actualiza los datos de una cuenta especifica.
        /// URL: api/BancoCuentas/Cuentas/Editar/Cuentas/{id}
        /// </summary>
        /// <param name="ocuentaTable">Datos actualizados de la cuenta.</param>
        /// <param name="id">Identificador unico de la cuenta.</param>
        void ActualizarCuentaEspecifica(CuentaTable ocuentaTable, int id);

        /// <summary>
        /// DELETE: Elimina una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/Eliminar/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta a eliminar.</param>
        void BorrarCuentaEspecifica(int id);
    }
}
