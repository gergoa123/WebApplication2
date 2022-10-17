using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DB
{
    public class Adresa
    {
        [Required(ErrorMessage = "Id is needed")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Oras { get; set; }

        [MaxLength(100)]
        public string Strada { get; set; }

        [MaxLength(100)]
        public string Numar { get; set; }
    }
}
