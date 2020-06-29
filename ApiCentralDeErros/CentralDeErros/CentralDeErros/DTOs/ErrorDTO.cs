using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.Api.DTOs
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