using BancoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace ClienteTests.PruebasUnitarias
{
    public class IntegracionTests
    {
        // Configuracion del contexto de base de datos en memoria
        private readonly BaseDeDatosBancoContext _context;

        // Configura el contexto en memoria para las pruebas
        public IntegracionTests()
        {
            DbContextOptions<BaseDeDatosBancoContext> options = new DbContextOptionsBuilder<BaseDeDatosBancoContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new BaseDeDatosBancoContext(options);
        }

        [Fact]
        public void InsertaClienteYRecuperaCuentas_Integracion()
        {
            // Arrange: Preparacion de datos de prueba para buscar cuenta del cliente
            ClientesTable cliente = new ClientesTable
            {
                ClienteId = 1111111,
                Nombre = "Jose Lema",
                Clave = "1234",
                Estado = 1
            };
            _context.ClientesTable.Add(cliente);
            _context.SaveChanges();

            CuentaTable cuenta = new CuentaTable
            {
                CuentaId = 1111111,
                ClienteId = 1111111,
                NumeroCuenta = "1234567890",
                TipoCuenta = "Ahorro",
                SaldoInicial = 1000,
                Estado = 1
            };
            _context.CuentaTable.Add(cuenta);
            _context.SaveChanges();

            // Act: Ejecucion de la funcionalidad a probar para buscar cuenta del cliente
            ClientesTable clienteRecuperado = _context.ClientesTable
                .Include(c => c.CuentaTable)
                .FirstOrDefault(c => c.ClienteId == 1111111);

            // Assert: Verificacion de los resultados obtenidos que comprueba la cuenta del cliente
            Assert.NotNull(clienteRecuperado);
            Assert.Single(clienteRecuperado.CuentaTable);
            Assert.Equal("1234567890", clienteRecuperado.CuentaTable.First().NumeroCuenta);
        }
    }
}
