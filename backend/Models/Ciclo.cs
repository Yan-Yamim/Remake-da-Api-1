using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Ciclo")]
    public class Ciclo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_ciclo")]
        public long idCiclo { get; set; }

        [Column("nome_ciclo")]
        public string nomeCiclo { get; set; }

        [Required]
        [Column("data_inicio")]
        public DateOnly dataInicio { get; set; }

        [Column("data_fim")]
        public DateOnly dataFim { get; set; }

        [Column("peso_nota")]
        public float pesoNota { get; set; }

        [Column("turma_id")]
        public long turmaId { get; set; }

        [JsonIgnore]
        public Turma Turma { get; set; } = new();

        [JsonIgnore]
        public List<Atividade> Atividades { get; set; } = new();
    }
}