using System.ComponentModel.DataAnnotations;

namespace ApiXamarin.Models
{
    public class Work
    {
        [Key]
        public int WorkID { get; set; }
        [Required ]
        public string  Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }

    }
}