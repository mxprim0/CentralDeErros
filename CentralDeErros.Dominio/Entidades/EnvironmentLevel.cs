﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Entidades
{
    [Table("ENVIRONMENT")]
    public class EnvironmentLevel
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnvironmentId { get; set; }

        [Column("ENVIRONMENT")]
        [StringLength(30)]
        [Required]
        public string EnvironmentName { get; set; }

        public ICollection<Error> Errors { get; set; }
    }
}