using BancoCodigo.Models;
using System.Collections.Generic;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Interfaz que define las operaciones CRUD relacionadas con los clientes.
    /// Proporciona los metodos necesarios para obtener, crear, actualizar y eliminar clientes en el sistema.
    /// </summary>
    public interface ICliente
    {
        /// <summary>
        /// GET: Obtiene la lista de todos los clientes.
        /// URL: api/BancoCliente/Clientes
        /// </summary>
        /// <returns>Lista con los datos de los clientes.</returns>
        List<ClientesTable> ObtenerClientes();

        /// <summary>
        /// GET: Obtiene un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente.</param>
        /// <returns>Datos del cliente especificado.</returns>
        ClientesTable ObtenerClienteEspecifico(int id);

        /// <summary>
        /// POST: Crea un nuevo cliente.
        /// URL: api/BancoCliente/Clientes/Registros
        /// </summary>
        /// <param name="oclientesTable">Datos del cliente a crear.</param>
        void CrearCliente(ClientesTable oclientesTable);

        /// <summary>
        /// PUT: Actualiza los datos de un cliente especifico.
        /// URL: api/BancoCliente/Clientes/Actualizar/Clientes/{id}
        /// </summary>
        /// <param name="oclientesTable">Datos actualizados del cliente.</param>
        /// <param name="id">Identificador unico del cliente.</param>
        void ActualizarClienteEspecifico(ClientesTable oclientesTable, int id);

        /// <summary>
        /// DELETE: Elimina un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/Eliminar/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente a eliminar.</param>
        void BorrarClienteEspecifico(int id);
    }
}
