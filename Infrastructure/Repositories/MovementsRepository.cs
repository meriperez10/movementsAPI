using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class MovementsRepository : IMovementsRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<MovementsRepository> logger;


        public MovementsRepository(AppDbContext context, ILogger<MovementsRepository> logger)
        {
            this.context = context;
            this.logger = logger;

        }



        /// <summary>
        /// Obtiene una lista paginada de movimientos, aplicando filtros opcionales por rango de fechas y categoría.
        /// </summary>
        /// <param name="startDate"> Fecha inicial del rango de búsqueda (opcional </param>
        /// <param name="endDate"> Fecha final del rango de búsqueda (opcional) </param>
        /// <param name="category"> Categoría del movimiento para filtrar resultados (opcional) </param>
        /// <param name="page"> Número de página </param>
        /// <param name="pageSize"> Cantidad de elementos por página </param>
        /// <returns>Lista de MovementsDTO que cumplen con los filtros aplicados. Devuelve lista vacía si no hay resultados </returns>
        public async Task<IEnumerable<MovementsDTO>?> GetMovementsAsync( DateTime? startDate, DateTime? endDate, string? category, int page, int pageSize)
       {

            try
            {

                var movements = context.Movements.AsQueryable();

                if (movements != null && movements.Any())
                {
                    logger.LogInformation("Se obtienen todos los movimientos. Total: {TotalMovements}", movements.Count());

                    if (startDate.HasValue)
                    {
                        movements = movements.Where(m => m.OperationDate >= startDate.Value);
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por fecha de inicio.");
                    }

                    if (endDate.HasValue)
                    {
                        movements = movements.Where(m => m.OperationDate <= endDate.Value);
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por fecha final.");
                    }

                    if (!string.IsNullOrWhiteSpace(category))
                    {
                        movements = movements.Where(m => m.Category.ToLower().Contains(category.ToLower()));
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por categoria.");
                    }

                    if (!movements.Any())
                    {
                        logger.LogWarning("No hay movimientos para: StartDate:{StartDate}, EndDate:{EndDate}, Category:{Category}", startDate, endDate, category);
                    }

                    return await movements.OrderByDescending(m => m.OperationDate)
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .Select(m => new MovementsDTO
                                      {
                                          OperationDate = m.OperationDate,
                                          ValueDate = m.ValueDate,
                                          Amount = m.Amount,
                                          Description = m.Description,
                                          Category = m.Category
                                      })
                                      .ToListAsync();
                }
                else {
                    logger.LogWarning("No hay movimientos en la base de datos.");
                    return Enumerable.Empty<MovementsDTO>();
                }
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "Error GetMovementsAsync. StartDate:{StartDate},EndDate:{EndDate},Category:{Category},Page:{Page},PageSize:{PageSize}", startDate, endDate, category, page, pageSize);
                return null;
            }
       }


        /// <summary>
        /// Obtiene un resumen de los movimientos, aplicando filtros opcionales por rango de fechas y categoría
        /// </summary>
        /// <param name="startDate"> Fecha inicial del rango de búsqueda </param>
        /// <param name="endDate"> Fecha final del rango de búsqueda </param>
        /// <param name="category"> Categoría de los movimientos para filtrar (opcional) </param>
        /// <returns> Un MovementsSummaryDTO con la informacion de los movimientos encontrados. Devuelve un resumen con totales en cero si no hay movimientos.</returns>
        public async Task<MovementsSummaryDTO?> GetSummaryAsync(DateTime? startDate, DateTime? endDate, string? category)
        {

            try { 
               
                var movements = context.Movements.AsQueryable();

                if (movements != null && movements.Any())
                {
                    logger.LogInformation("Se obtienen todos los movimientos.Total: {TotalMovements}", movements.Count());


                    if (startDate.HasValue)
                    {
                        movements = movements.Where(m => m.OperationDate >= startDate.Value);
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por fecha de inicio.");
                    }

                    if (endDate.HasValue)
                    {
                        movements = movements.Where(m => m.OperationDate <= endDate.Value);
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por fecha final.");
                    }

                    if (!string.IsNullOrWhiteSpace(category))
                    {
                        movements = movements.Where(m => m.Category.ToLower().Contains(category.ToLower()));
                        logger.LogInformation("Se obtienen todos los movimientos filtrados por categoria.");
                    }

                    var movementsSummary = await movements.ToListAsync();

                    if (!movementsSummary.Any())
                    {
                        logger.LogWarning("No hay movimientos para el resumen: StartDate:{StartDate}, EndDate:{EndDate}, Category:{Category}", startDate, endDate, category);
                        return null;
                    }
                    else
                    {
                        return new MovementsSummaryDTO
                        {
                            TotalMovements = movementsSummary.Count,
                            TotalIncome = movementsSummary.Where(m => m.Amount > 0).Sum(m => m.Amount),
                            TotalExpenses = movementsSummary.Where(m => m.Amount < 0).Sum(m => m.Amount)
                        };
                    }

                }
                else {
                    logger.LogWarning("No hay movimientos en la base de datos.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error GetSummaryAsync. StartDate:{StartDate},EndDate:{EndDate},Category:{Category}", startDate, endDate, category);
                return null;
            }
        }

    }
}
