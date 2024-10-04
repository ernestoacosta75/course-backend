using Films.Core.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Films.Core.Domain.Entities
{
    public class Actor
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; } = string.Empty;

        // Navigation properties
        public List<FilmsActors> FilmsActors { get; set; } = [];
    }
}
