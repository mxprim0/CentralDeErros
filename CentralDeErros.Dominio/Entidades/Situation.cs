using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Entidades
{
    [Table("SITUATION")]
    public class Situation
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int SituationId { get; set; }

        [Column("SITUATION")]
        [StringLength(30)]
        [Required]
        public string SituationName { get; set; }
        public ICollection<Logs> ErrorOccurrences { get; set; }
    }
}