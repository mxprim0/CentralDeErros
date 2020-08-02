using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.API.Dto
{
    public class LogsDTO
    {
     
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Events { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Boolean Archived { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime CreatedAt { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserName { get; set; }


        public int ErrorId { get; set; }


        public int LevelId { get; set; }

     
    }
}
