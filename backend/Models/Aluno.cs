using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models 
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("aluno_id")]
        public long alunoId { get; set; }

        [Required]
        [Column("nome_aluno")]
        public string nomeAluno { get; set; }

        [Column("sobrenome")]
        public string sobrenome { get; set; }

        [Column("idade")]
        public int idade { get; set; }

        [Required]
        [Column("ra")]
        public int ra { get; set; }

        [Required]
        [Column("email")]
        public string email { get; set; }

        [Column("nota_final")]
        [NotMapped]
        public float notaFinal { get; set; }

        [JsonIgnore]
        public List<Ciclo> Ciclos { get; set; } = new();

        [JsonIgnore]
        public List<Turma> Turmas { get; set; } = new();

        [JsonIgnore]
        public List<Atividade> Atividades { get; set; } = new();
    }
}