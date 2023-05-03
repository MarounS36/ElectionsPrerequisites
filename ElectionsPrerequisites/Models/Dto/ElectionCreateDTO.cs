using System.ComponentModel.DataAnnotations;

namespace ElectionsPrerequisites.Models.Dto
{
    public class ElectionCreateDTO
    {
        [Required]
        public string ElectionName { get; set; }
    }
}
