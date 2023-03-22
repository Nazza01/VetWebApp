using System.ComponentModel.DataAnnotations;

namespace VetWebApp.Models
{
    public class AnimalDataModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^([\d]|[1-9][\d])$", ErrorMessage = "Please enter a valid age.")]
        public string? Breed { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}
