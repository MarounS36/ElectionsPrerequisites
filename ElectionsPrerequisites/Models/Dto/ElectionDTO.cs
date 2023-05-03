using System.ComponentModel.DataAnnotations;

namespace ElectionsPrerequisites.Models.Dto
{
    public class ElectionDTO
    {
        public int Id { get; set; }
        [Required]
        public string ElectionName { get; set; }
    }
}
