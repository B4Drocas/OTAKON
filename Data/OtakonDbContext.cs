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
        public DbSet<Manga> Mangas { get; set; }

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
            // Hash gerado de: admin123
            var adminPasswordHash = "$2a$11$zI.u/TjSvtvu0K7eH8XQweeV1xbGQKmJfJRfLSzxQADXBjfF.bQJm";
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
