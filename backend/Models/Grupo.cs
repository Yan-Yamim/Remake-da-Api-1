using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Grupo")]
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_grupo")]
        public long grupoId { get; set; }

        [Column("nome_grupo")]
        public string nomeGrupo { get; set; }

        [JsonIgnore]
        public List<Aluno> Alunos { get; set; }

    }
}