using Microsoft.EntityFrameworkCore;
using OTAKode.Models;

namespace OTAKode.Data
{
    public class OtakonDbContext : DbContext
    {
        public OtakonDbContext(DbContextOptions<OtakonDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações da tabela User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Criar usuário admin padrão
            // Senha: admin123 (pré-hashada com BCrypt)
            var adminPasswordHash = "$2a$11$Dv3aeNe5N5kJnVVy4Kqum.Lq2W0g7EJ8B2nH6mR6kJ7wNL7vGGh0i";
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@otakon.com",
                    FullName = "Administrador",
                    PasswordHash = adminPasswordHash,
                    IsAdmin = true,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                }
            );
        }
    }
}
