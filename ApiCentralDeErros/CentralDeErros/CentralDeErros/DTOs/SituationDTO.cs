using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class SituationDTO
    {
        public int SituationId { get; set; }

        [Required]
        public string SituationName { get; set; }
    }
}