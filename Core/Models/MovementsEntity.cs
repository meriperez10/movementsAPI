using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MovementsEntity
    {
        public Guid Id { get; set; }                            // Identificador único
        public DateTime OperationDate { get; set; }             // Fecha en la que se realizó la operación 
        public DateTime ValueDate { get; set; }                 // Fecha de valor del movimiento  
        public decimal Amount { get; set; }                     // Valor del movimiento (positivo = entrada, negativo = salida)
        public string Description { get; set; } = string.Empty; // Descripción textual del movimiento
        public string Category { get; set; } = string.Empty;    // Categoría del movimiento (por ejemplo: salario, servicios públicos, alquiler...)

    }
}
