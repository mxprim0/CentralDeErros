using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CentralDeErros.Api.Entidades
{
    [Table ("USERS")]
    public class Users
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int UserId { get; set; }

        [Column("NAME")]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [Column("EMAIL")]
        [StringLength(200)]
        [Required]
        public string Email { get; set; }

        [Column("PASSWORD")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Column("TOKEN")]
        [MaxLength(400)]
        public string Token { get; set; }

        [Column("EXPIRATION")]
        [Required]
        public DateTime Expiration { get; set; }

        public ICollection<ErrorOccurrence> ErrorOccurrences { get; set; }
    }
}