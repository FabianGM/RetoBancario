using BancoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Servicio que implementa la interfaz ICliente para manejar las operaciones CRUD relacionadas con los clientes.
    /// Proporciona la logica necesaria para obtener, crear, actualizar y eliminar clientes en la base de datos.
    /// </summary>
    public class SrvCliente : ICliente
    {
        private readonly BaseDeDatosBancoContext _contextService;

        /// <summary>
        /// Constructor para inyeccion de dependencias.
        /// </summary>
        /// <param name="service">Contexto de la base de datos inyectado.</param>
        public SrvCliente(BaseDeDatosBancoContext service)
        {
            _contextService = service;
        }

        /// <summary>
        /// GET: Obtiene la lista de todos los clientes.
        /// URL: api/BancoCliente/Clientes
        /// </summary>
        /// <returns>Lista con los datos de los clientes.</returns>
        public List<ClientesTable> ObtenerClientes()
        {
            List<ClientesTable> oCliente = new List<ClientesTable>();

            foreach (ClientesTable Cliente in _contextService.ClientesTable.ToList())
            {
                oCliente.Add(Cliente);
            }

            return oCliente;
        }

        /// <summary>
        /// GET: Obtiene un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente.</param>
        /// <returns>Datos del cliente especificado.</returns>
        public ClientesTable ObtenerClienteEspecifico(int id)
        {
            return _contextService.ClientesTable.Find(id);
        }

        /// <summary>
        /// POST: Crea un nuevo cliente.
        /// URL: api/BancoCliente/Clientes/Registros
        /// </summary>
        /// <param name="oclientesTable">Datos del cliente a crear.</param>
        public void CrearCliente(ClientesTable oclientesTable)
        {
            ClientesTable addClienteRegistro = new ClientesTable
            {
                Nombre = oclientesTable.Nombre,
                Direccion = oclientesTable.Direccion,
                Telefono = oclientesTable.Telefono,
                Clave = oclientesTable.Clave,
                Estado = oclientesTable.Estado
            };

            _contextService.ClientesTable.Add(addClienteRegistro);
            _contextService.SaveChanges();
        }

        /// <summary>
        /// PUT: Actualiza los datos de un cliente especifico.
        /// URL: api/BancoCliente/Clientes/Actualizar/Clientes/{id}
        /// </summary>
        /// <param name="oclientesTable">Datos actualizados del cliente.</param>
        /// <param name="id">Identificador unico del cliente.</param>
        public void ActualizarClienteEspecifico(ClientesTable oclientesTable, int id)
        {
            var addClienteRegistro = _contextService.ClientesTable.Find(id);
            addClienteRegistro.Nombre = oclientesTable.Nombre;
            addClienteRegistro.Direccion = oclientesTable.Direccion;
            addClienteRegistro.Telefono = oclientesTable.Telefono;
            addClienteRegistro.Clave = oclientesTable.Clave;
            addClienteRegistro.Estado = oclientesTable.Estado;

            _contextService.Entry(addClienteRegistro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contextService.SaveChanges();
        }

        /// <summary>
        /// DELETE: Elimina un cliente especifico por ID.
        /// URL: api/BancoCliente/Clientes/Eliminar/Clientes/{id}
        /// </summary>
        /// <param name="id">Identificador unico del cliente a eliminar.</param>
        public void BorrarClienteEspecifico(int id)
        {
            var oEliminar = _contextService.ClientesTable.Find(id);
            _contextService.Remove(oEliminar);
            _contextService.SaveChanges();
        }
    }
}
