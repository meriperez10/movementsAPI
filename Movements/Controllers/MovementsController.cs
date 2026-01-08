using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Core.DTOs;


namespace MovementsAPI.Controllers
{
    [ApiController] 
    [Route("api/movements")] 
    public class MovementsController : ControllerBase
    {
        private readonly IMovementsRepository movementsRepository;
        private readonly ILogger<MovementsController> logger;

        public MovementsController(IMovementsRepository movementsRepository, ILogger<MovementsController> logger)
        {
            this.movementsRepository = movementsRepository;
            this.logger = logger;
        }


        /// <summary>
        /// Obtiene una lista paginada de movimientos, con filtros opcionales por rango de fechas y categoría.
        /// </summary>
        /// <param name="startDate"> Fecha inicial del rango de búsqueda (opcional) </param>
        /// <param name="endDate"> Fecha final del rango de búsqueda (opcional) </param>
        /// <param name="category"> Categoría del movimiento para filtrar los resultados (opcional) </param>
        /// <param name="page"> Número de página para la paginación. Si no se especifica, se utiliza la página 1 por defecto. </param>
        /// <param name="pageSize"> Cantidad de elementos por página. Si no se especifica, el valor por defecto es 5. </param>
        /// <returns> Una lista de movimientos que cumplen con los filtros aplicados. </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementsDTO>>> GetAllMovements( DateTime? startDate, DateTime? endDate, string? category, int? page, int? pageSize)
        {
            try {

                if (startDate.HasValue && endDate.HasValue && startDate > endDate) //Formato de fechas a introducir en los filtros MM/dd/YYYY
                {
                    logger.LogWarning("Fechas inválidas: StartDate: {StartDate} >  EndDate: {EndDate}", startDate, endDate);
                    return BadRequest("La fecha inicial no puede ser mayor que la fecha final.");
                }
                
              
                // Valores por defecto si son null
                var currentPage = page ?? 1;
                var currentPageSize = pageSize ?? 5;

                if (currentPage < 1 || currentPageSize < 1)
                {
                    logger.LogWarning("Datos de paginación inválidos: Page: {Page} ,  PageSize: {PageSize}", page, pageSize);
                    return BadRequest("Los parámetros de paginación deben ser mayores que 0.");
                }         

                var movements = await movementsRepository.GetMovementsAsync(startDate, endDate, category, currentPage, currentPageSize);

                if (movements == null || !movements.Any())
                {
                    return BadRequest("No se encontraron movimientos con los filtros introducidos.");
                }

                return Ok(movements);
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error GetAllMovements. StartDate:{StartDate},EndDate:{EndDate},Category:{Category},Page:{Page},PageSize:{PageSize}", startDate, endDate, category, page, pageSize);
                return BadRequest("Error GetAllMovements");
            }
        }


        /// <summary>
        /// Obtiene un resumen de los movimientos, con filtros opcionales por rango de fechas y categoría.
        /// </summary>
        /// <param name="startDate"> Fecha inicial del rango de búsqueda (opcional) </param>
        /// <param name="endDate"> Fecha final del rango de búsqueda (opcional) </param>
        /// <param name="category"> Categoría del movimiento para filtrar el resumen (opcional) </param>
        /// <returns> El resumen de los movimientos que cumplen con los filtros aplicados. </returns>
        [HttpGet("summary")]
        public async Task<ActionResult<MovementsSummaryDTO>> GetSummary( DateTime? startDate, DateTime? endDate, string? category)           
        {

            try {

                if (startDate.HasValue && endDate.HasValue && startDate > endDate)
                {
                    logger.LogWarning("Fechas inválidas: StartDate: {StartDate} >  EndDate: {EndDate}", startDate, endDate);
                    return BadRequest("La fecha inicial no puede ser mayor que la fecha final.");
                }

                var summary = await movementsRepository.GetSummaryAsync(startDate,endDate,category);


                if (summary == null)
                {
                    return BadRequest("No se encontraron movimientos con los filtros introducidos.");
                }

                return Ok(summary);
            }
            catch (Exception ex)
            {               
                logger.LogError(ex, "Error GetSummary. StartDate: {StartDate}, EndDate: {EndDate}, Category: {Category}", startDate, endDate, category);
                return BadRequest("Error GetSummary");
            }
        }
    }
}
