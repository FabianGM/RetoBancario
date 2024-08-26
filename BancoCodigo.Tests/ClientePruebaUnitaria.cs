using BancoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ClienteTests.PruebasUnitarias
{
    public class ClientePruebaUnitaria
    {
        // Contexto de la base de datos para pruebas
        private readonly BaseDeDatosBancoContext _context;

        // Configura el contexto en memoria para las pruebas
        public ClientePruebaUnitaria()
        {
            DbContextOptions<BaseDeDatosBancoContext> options = new DbContextOptionsBuilder<BaseDeDatosBancoContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new BaseDeDatosBancoContext(options);
        }

        // Verifica que un cliente se inserte correctamente en la base de datos
        [Fact]
        public void InsertaCliente_EnBaseDeDatos()
        {
            // Configura los datos del cliente
            ClientesTable cliente = new ClientesTable
            {
                ClienteId = 1,
                Nombre = "Jose Lema",
                Clave = "1234",
                Estado = 1
            };

            // Inserta el cliente en la base de datos y guarda cambios
            _context.ClientesTable.Add(cliente);
            _context.SaveChanges();

            ClientesTable clienteGuardado = _context.ClientesTable.Find(1);
            Assert.NotNull(clienteGuardado);
            Assert.Equal("Jose Lema", clienteGuardado.Nombre);
            Assert.Equal("1234", clienteGuardado.Clave);
            Assert.Equal(1, clienteGuardado.Estado);
        }
    }
}
