using BancoCodigo.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BancoCodigo.Controllers
{
    /// <summary>
    /// Clase estática que extiende la funcionalidad de los controladores en ASP.NET Core.
    /// Proporciona un método de extensión para manejar de forma centralizada las respuestas HTTP, incluyendo el manejo de excepciones.
    /// </summary>
    public static class ExtensionController
    {
        /// <summary>
        /// Maneja la ejecucion de una funcion que retorna un IActionResult, capturando cualquier excepcion no controlada
        /// y devolviendo una respuesta HTTP con un codigo de error del servidor.
        /// </summary>
        /// <param name="controller">Instancia del controlador desde el cual se llama al método.</param>
        /// <param name="funcion">Función que contiene la logica para procesar la solicitud y generar un IActionResult.</param>
        /// <returns>El resultado de la funcion si no hay errores, o un error 500 con un mensaje descriptivo en caso de excepcion.</returns>
        public static IActionResult HandleResponse(this ControllerBase controller, Func<IActionResult> funcion)
        {
            try
            {
                return funcion();
            }
            catch (Exception ex)
            {
                return controller.StatusCode(Constantes.CODIGO_ERROR_SERVIDOR, $"{Constantes.ERROR_INTERNO_SERVIDOR} {ex.Message}");
            }
        }
    }
}
