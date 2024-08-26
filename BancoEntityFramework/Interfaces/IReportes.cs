using BancoCodigo.Models;

namespace BancoCodigo.Services
{
    /// <summary>
    /// Interfaz para el servicio de generacion de reportes de estado de cuenta.
    /// Define los metodos necesarios para la generacion de reportes.
    /// </summary>
    public interface IReportes
    {
        /// <summary>
        /// Genera un reporte de estado de cuenta para un cliente en un rango de fechas especifico.
        /// </summary>
        /// <param name="rangoFechas">Rango de fechas en formato inicio_fin.</param>
        /// <param name="clienteId">Identificador unico del cliente.</param>
        /// <returns>Reporte de estado de cuenta en formato JSON.</returns>
        ReporteEstadoCuenta GenerarReporte(string rangoFechas, int clienteId);
    }
}
