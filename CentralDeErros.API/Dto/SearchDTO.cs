using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.API.Dto
{
    public class SearchDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Type { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
     
    }
}
