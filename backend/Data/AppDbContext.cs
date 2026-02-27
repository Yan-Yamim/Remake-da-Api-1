using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ciclo>()
                .HasOne(c => c.Turma)
                .WithMany(t => t.Ciclos)
                .HasForeignKey(c => c.turmaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Atividade>()
                .HasOne(a => a.Ciclo)
                .WithMany(c => c.Atividades)
                .HasForeignKey(a => a.cicloId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Atividade>()
                .HasOne(a => a.Aluno)
                .WithMany(al => al.Atividades)
                .HasForeignKey(a => a.alunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}