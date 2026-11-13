using Microsoft.EntityFrameworkCore;
using p2_full_stack_2026.Entities;

namespace p2_full_stack_2026.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        public DbSet<AutorEntity> Autor;
        public DbSet<EmprestimoEntity> Emprestimos;
        public DbSet<LivroEntity> Livros;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorEntity>().ToTable("autor");
            modelBuilder.Entity<EmprestimoEntity>().ToTable("emprestimo");
            modelBuilder.Entity<LivroEntity>().ToTable("livro");

            modelBuilder.Entity<AutorEntity>()
                .HasKey(autor => autor.Id);

            modelBuilder.Entity<EmprestimoEntity>()
                .HasKey(emprestimo => emprestimo.Id);

            modelBuilder.Entity<LivroEntity>()
                .HasKey(livro => livro.Id);

            modelBuilder.Entity<AutorEntity>()
                .HasMany<LivroEntity>(livro => livro.Livros)
                .WithOne(Livro => Livro.Autor)
                .HasForeignKey(livro => livro.AutorId);

            modelBuilder.Entity<LivroEntity>()
               .HasMany(livro => livro.Emprestimos)
               .WithOne(emprestimo => emprestimo.Livro)
               .HasForeignKey(emprestimo => emprestimo.LivroId);


            modelBuilder.Entity<AutorEntity>(autor =>
            {
                autor.Property(autor => autor.Nome).IsRequired().HasMaxLength(100);
                autor.Property(autor => autor.Nacionalidade).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<LivroEntity>(livro =>
            {
                livro.Property(livro => livro.Titulo).IsRequired().HasMaxLength(150);
                livro.HasIndex(livro => livro.ISBN).IsUnique();
                livro.Property(livro => livro.ISBN).IsRequired().HasMaxLength(13);
                livro.Property(livro => livro.AnoPublicacao).IsRequired();
            });

            modelBuilder.Entity<EmprestimoEntity>(emprestimo =>
            {
                emprestimo.Property(emprestimo => emprestimo.NomeLeitor).IsRequired().HasMaxLength(100);
                emprestimo.Property(emprestimo => emprestimo.DataEmprestimo).IsRequired();
            });
        }
    }
}
