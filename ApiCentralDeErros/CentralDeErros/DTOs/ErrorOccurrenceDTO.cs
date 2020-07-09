using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.Api.DTOs
{
    public class ErrorOccurrenceDTO
    {
        public int ErrorOccurrenceId { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ErrorId { get; set; }

        [Required]
        public int SituationId { get; set; }
    }
}