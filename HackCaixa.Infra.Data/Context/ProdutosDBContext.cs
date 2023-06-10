using HackCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackCaixa.Infra.Data.Context
{
    public partial class ProdutosDBContext : DbContext
    {
        public virtual DbSet<Produto> Produtos { get; set; }

        public ProdutosDBContext()
        {
        }

        public ProdutosDBContext(DbContextOptions<ProdutosDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=dbhackathon.database.windows.net,1433;Database=hack;User Id=hack;Password=Password23;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CoProduto);

                entity.ToTable("PRODUTO");

                entity.Property(e => e.CoProduto)
                    .ValueGeneratedNever()
                    .HasColumnName("CO_PRODUTO");

                entity.Property(e => e.NoProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NO_PRODUTO");

                entity.Property(e => e.NuMaximoMeses).HasColumnName("NU_MAXIMO_MESES");

                entity.Property(e => e.NuMinimoMeses).HasColumnName("NU_MINIMO_MESES");

                entity.Property(e => e.PcTaxaJuros)
                    .HasColumnType("numeric(10, 9)")
                    .HasColumnName("PC_TAXA_JUROS");

                entity.Property(e => e.VrMaximo)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VR_MAXIMO");

                entity.Property(e => e.VrMinimo)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VR_MINIMO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
