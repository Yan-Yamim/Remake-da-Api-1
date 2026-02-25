using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Atividade")]
    public class Atividade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_atividade")]
        public long ativId { get; set; }

        [Column("nome_atividade")]
        public string nomeAtividade { get; set; }

        [Column("nota_atividade")]
        public float notaAtividade { get; set; }

        [Column("aluno_id")]
        public long alunoId { get; set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; } = new();

        [Column("ciclo_id")]
        public long cicloId { get; set; }

        [JsonIgnore]
        public Ciclo Ciclo { get; set; } = new();
    }
}