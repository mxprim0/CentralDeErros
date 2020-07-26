﻿using System.ComponentModel.DataAnnotations;


namespace CentralDeErros.API.Dto
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserId { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Code { get; set; }
    }
}

