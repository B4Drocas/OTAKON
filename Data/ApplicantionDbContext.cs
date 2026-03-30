using Microsoft.EntityFrameworkCore;
using OTAKON.Models;

namespace OTAKON.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 🔹 Construtor obrigatório
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 🔹 DbSet representa a tabela Produtos no banco
        public DbSet<Produto> Produtos { get; set; }

        // 🔹 Configurações adicionais (opcional mas recomendado)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.IDProduto);

                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.Autor)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Editora)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Categoria)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(p => p.Preco)
                      .HasColumnType("decimal(10,2)");

                entity.Property(p => p.Imagem)
                      .HasMaxLength(300);

                entity.Property(p => p.Descricao)
                      .HasMaxLength(2000);

                entity.Property(p => p.Quantidade)
                      .IsRequired();
            });
        }
    }
}
