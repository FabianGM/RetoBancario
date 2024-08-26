using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    /// <summary>
    /// Contexto de base de datos para la aplicacion del Banco.
    /// Proporciona acceso a las tablas y la configuracion del modelo de base de datos.
    /// </summary>
    public partial class BaseDeDatosBancoContext : DbContext
    {
        /// <summary>
        /// Objeto de configuracion que proporciona acceso a los valores definidos en appsettings.json.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor sin parametros requerido por EF Core.
        /// </summary>
        public BaseDeDatosBancoContext()
        {
        }

        /// <summary>
        /// Constructor que permite pasar opciones al contexto, como la cadena de conexion.
        /// <summary>
        public BaseDeDatosBancoContext(DbContextOptions<BaseDeDatosBancoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Constructor que permite pasar opciones al contexto, como la cadena de conexion.
        /// Tambien inyecta la configuracion para leer valores de appsettings.json.
        /// </summary>
        /// <param name="options">Opciones de configuracion para el contexto de la base de datos.</param>
        /// <param name="configuration">Configuracion inyectada para acceder a appsettings.json.</param>
        public BaseDeDatosBancoContext(DbContextOptions<BaseDeDatosBancoContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Tabla que almacena los datos de los clientes.
        /// </summary>
        public virtual DbSet<ClientesTable> ClientesTable { get; set; }

        /// <summary>
        /// Tabla que almacena los datos de las cuentas.
        /// </summary>
        public virtual DbSet<CuentaTable> CuentaTable { get; set; }

        /// <summary>
        /// Tabla que almacena los datos de los movimientos por fecha.
        /// </summary>
        public virtual DbSet<MovimientoFecha> MovimientoFecha { get; set; }

        /// <summary>
        /// Tabla que almacena los datos de los movimientos.
        /// </summary>
        public virtual DbSet<MovimientosTable> MovimientosTable { get; set; }

        /// <summary>
        /// Configura las opciones del contexto si no estan configuradas.
        /// Establece la cadena de conexion a SQL Server si no se ha proporcionado ninguna.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones para configurar el contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BaseDeDatosBancoConnection"));
            }
        }

        /// <summary>
        /// Configura el modelo de entidades para la base de datos.
        /// Define las relaciones, claves y otras propiedades de las entidades.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo utilizado para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientesTable>(entity =>
            {
                // Define la clave primaria para la entidad ClientesTable.
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK_PersonaTable");

                // Configura las propiedades de la entidad ClientesTable.
                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CuentaTable>(entity =>
            {
                // Define la clave primaria para la entidad CuentaTable.
                entity.HasKey(e => e.CuentaId);

                // Configura las propiedades de la entidad CuentaTable.
                entity.Property(e => e.Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Define la relacion entre CuentaTable y ClientesTable.
                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CuentaTable)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_CuentaTable_ClientesTable1");
            });

            modelBuilder.Entity<MovimientoFecha>(entity =>
            {
                // Configura las propiedades de la entidad MovimientoFecha.
                entity.Property(e => e.Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Movimiento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoDisponible).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Define la relacion entre MovimientoFecha y MovimientosTable.
                entity.HasOne(d => d.Movimientos)
                    .WithMany(p => p.MovimientoFecha)
                    .HasForeignKey(d => d.MovimientosId)
                    .HasConstraintName("FK_MovimientoFecha_MovimientosTable");
            });

            modelBuilder.Entity<MovimientosTable>(entity =>
            {
                // Define la clave primaria para la entidad MovimientosTable.
                entity.HasKey(e => e.MovimientosId)
                    .HasName("PK_MovimientoTalbe");

                // Configura las propiedades de la entidad MovimientosTable.
                entity.Property(e => e.Fecha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Define la relacion entre MovimientosTable y CuentaTable.
                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.MovimientosTable)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("FK_MovimientosTable_CuentaTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// Metodo parcial para extender la configuracion del modelo si es necesario.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo utilizado para configurar las entidades.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
