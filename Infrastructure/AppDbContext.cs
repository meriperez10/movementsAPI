using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<MovementsEntity> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovementsEntity>().HasData(
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 1),
                    ValueDate = new DateTime(2025, 10, 2),
                    Amount = 2500.00m,
                    Description = "1.Nómina Octubre",
                    Category = "Salario"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 5),
                    ValueDate = new DateTime(2025, 10, 5),
                    Amount = -800.00m,
                    Description = "2.Alquiler piso Octubre",
                    Category = "Alquiler"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 10),
                    ValueDate = new DateTime(2025, 10, 10),
                    Amount = -120.50m,
                    Description = "3.Factura Luz",
                    Category = "Servicios públicos"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 15),
                    ValueDate = new DateTime(2025, 10, 16),
                    Amount = -50.25m,
                    Description = "4.Compra Mercadona",
                    Category = "Alimentación"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 20),
                    ValueDate = new DateTime(2025, 10, 21),
                    Amount = -80.25m,
                    Description = "5.Factura Agua",
                    Category = "Servicios públicos"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 25),
                    ValueDate = new DateTime(2025, 10, 26),
                    Amount = -55.00m,
                    Description = "6.Factura Gas",
                    Category = "Servicios públicos"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 10, 30),
                    ValueDate = new DateTime(2025, 10, 30),
                    Amount = -25.00m,
                    Description = "7.Compra Carrefour",
                    Category = "Alimentación"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 11, 5),
                    ValueDate = new DateTime(2025, 11, 5),
                    Amount = 800.00m,
                    Description = "8.Nomina Noviembre",
                    Category = "Salario"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 11, 10),
                    ValueDate = new DateTime(2025, 11, 10),
                    Amount = -850.00m,
                    Description = "9.Alquiler piso Noviembre",
                    Category = "Alquiler"
                },
                new MovementsEntity
                {
                    Id = Guid.NewGuid(),
                    OperationDate = new DateTime(2025, 11, 15),
                    ValueDate = new DateTime(2025, 11, 16),
                    Amount = -80.00m,
                    Description = "10.Factura Agua",
                    Category = "Servicios públicos"
                });
         }
                


    }
}

