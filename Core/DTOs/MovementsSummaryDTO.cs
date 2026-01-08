using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class MovementsSummaryDTO
    {
        public int TotalMovements { get; set; }         // Cantidad total de movimientos encontrados.
        public decimal TotalIncome { get; set; }        // Suma de los ingresos
        public decimal TotalExpenses { get; set; }      // Suma de los gastos
    }
}
