using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Infra.Entidades
{
    public class LogsResponseDTO
    {
     
        public string Description { get; set; }

        public string Title { get; set; }

        public string Events { get; set; }

        public Boolean Archived { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }

        public string LevelName{ get; set; }

     
    }
}
