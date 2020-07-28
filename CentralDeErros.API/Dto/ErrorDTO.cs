using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.API.Dto
{
    public class ErrorDTO
    {
        public int ErrorId { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
