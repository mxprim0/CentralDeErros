using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErros.Infra.Entidades
{
    [Table("ERROR_OCCURRENCE")]
    public class Logs
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ErrorOccurrenceId { get; set; }


        [Column("DESCRIPTION")]
        [StringLength(2000)]
        [Required]
        public string Description { get; set; }

        [Column("TITLE")]
        [StringLength(2000)]
        [Required]
        public string Title { get; set; }

        [Column("EVENTS")]
        [StringLength(2000)]
        [Required]
        public string Events { get; set; }

        [Column("ARCHIVED")]
        [Required]
        public Boolean Archived { get; set; }

        [Column("DATE_TIME")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("USERID"), Required]
        public int UserId { get; set; }

        [ForeignKey("USER_ID")]

        public Users User { get; set; }

        [Column("ERRORID"), Required]

        public int ErrorId { get; set; }

        [ForeignKey("ERROR_ID")]
        public Error Error { get; set; }

        [Column("LEVELID"), Required]
        public int LevelId { get; set; }

        [ForeignKey("LEVEL_ID")]
        public Level Level { get; set; }
        public object Situation { get; internal set; }
    }
}