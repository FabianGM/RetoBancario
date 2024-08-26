using BancoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Servicio que implementa la interfaz ICuentas para manejar las operaciones CRUD relacionadas con las cuentas bancarias.
    /// Proporciona la logica necesaria para obtener, crear, actualizar y eliminar cuentas en la base de datos.
    /// </summary>
    public class SrvCuentas : ICuentas
    {
        private readonly BaseDeDatosBancoContext _contextService;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="contextService">Contexto de la base de datos inyectado.</param>
        public SrvCuentas(BaseDeDatosBancoContext contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// GET: Obtiene la lista de todas las cuentas.
        /// URL: api/BancoCuentas/Cuentas
        /// </summary>
        /// <returns>Lista con los datos de las cuentas.</returns>
        public List<CuentaTable> ObtenerCuentas()
        {
            return _contextService.CuentaTable.ToList();
        }

        /// <summary>
        /// GET: Obtiene una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta.</param>
        /// <returns>Datos de la cuenta especificada.</returns>
        public CuentaTable ObtenerCuentaEspecifica(int id)
        {
            return _contextService.CuentaTable.Find(id);
        }

        /// <summary>
        /// POST: Crea una nueva cuenta.
        /// URL: api/BancoCuentas/Cuentas/Nuevas/Cuentas
        /// </summary>
        /// <param name="ocuentaTable">Datos de la cuenta a crear.</param>
        public void CrearCuenta(CuentaTable ocuentaTable)
        {
            var nuevaCuenta = new CuentaTable
            {
                ClienteId = ocuentaTable.ClienteId,
                NumeroCuenta = ocuentaTable.NumeroCuenta,
                TipoCuenta = ocuentaTable.TipoCuenta,
                SaldoInicial = ocuentaTable.SaldoInicial,
                Estado = ocuentaTable.Estado,
                Cliente = ocuentaTable.Cliente
            };

            _contextService.CuentaTable.Add(nuevaCuenta);
            _contextService.SaveChanges();
        }

        /// <summary>
        /// PUT: Actualiza los datos de una cuenta especifica.
        /// URL: api/BancoCuentas/Cuentas/Editar/Cuentas/{id}
        /// </summary>
        /// <param name="ocuentaTable">Datos actualizados de la cuenta.</param>
        /// <param name="id">Identificador unico de la cuenta.</param>
        public void ActualizarCuentaEspecifica(CuentaTable ocuentaTable, int id)
        {
            var cuentaExistente = _contextService.CuentaTable.Find(id);

            if (cuentaExistente != null)
            {
                cuentaExistente.ClienteId = ocuentaTable.ClienteId;
                cuentaExistente.NumeroCuenta = ocuentaTable.NumeroCuenta;
                cuentaExistente.TipoCuenta = ocuentaTable.TipoCuenta;
                cuentaExistente.SaldoInicial = ocuentaTable.SaldoInicial;
                cuentaExistente.Estado = ocuentaTable.Estado;
                cuentaExistente.Cliente = ocuentaTable.Cliente;

                _contextService.Entry(cuentaExistente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _contextService.SaveChanges();
            }
        }

        /// <summary>
        /// DELETE: Elimina una cuenta especifica por ID.
        /// URL: api/BancoCuentas/Cuentas/Eliminar/Cuentas/{id}
        /// </summary>
        /// <param name="id">Identificador unico de la cuenta a eliminar.</param>
        public void BorrarCuentaEspecifica(int id)
        {
            var cuentaAEliminar = _contextService.CuentaTable.Find(id);
            if (cuentaAEliminar != null)
            {
                _contextService.Remove(cuentaAEliminar);
                _contextService.SaveChanges();
            }
        }
    }
}
