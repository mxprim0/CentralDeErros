using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Entidades
{
    [Table ("LEVEL")]
    public class Level
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }

        [Column("LEVEL")]
        [StringLength(30)]
        [Required]
        public string LevelName { get; set; }
        public ICollection<Error> Errors { get; set; }
    }
}