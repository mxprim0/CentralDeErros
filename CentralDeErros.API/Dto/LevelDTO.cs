using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.API.Dto
{
    public class LevelDTO
    {

        [Required]
        public int LevelId { get; set; }

        [Required]
        public string LevelName { get; set; }

        
    }
}
