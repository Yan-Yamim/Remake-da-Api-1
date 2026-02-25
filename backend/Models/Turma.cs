using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("turma_id")]
        public long turmaId { get; set; }

        [Required]
        [Column("nome_turma")]
        public string nomeTurma { get; set; }

        [Column("qtd_aluno")]
        public int qtdAlunos { get; set; }

        [Column("qtd_ciclos")]
        public int qtdCiclos { get; set; }

        [Required]
        [Column("media_turma")]
        [NotMapped]
        public int mediaTurma { get; set; }

        [JsonIgnore]
        public List<Aluno> Alunos { get; set; } = new();

        [JsonIgnore]
        public List<Ciclo> Ciclos { get; set; } = new();

    }
}