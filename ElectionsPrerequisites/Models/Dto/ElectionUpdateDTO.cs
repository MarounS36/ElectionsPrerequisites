using System.ComponentModel.DataAnnotations;

namespace ElectionsPrerequisites.Models.Dto
{
    public class ElectionUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ElectionName { get; set; }
    }
}
