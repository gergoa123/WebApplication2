using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DB
{
    public class Student
    {
        [Required(ErrorMessage = "Id is needed")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nume{ get; set; }

        [MaxLength(100)]
        public string Prenume { get; set; }

        [Range(18, 100)]
        public int Varsta { get; set; }

        [Required(ErrorMessage = "Address is needed")]
        public Adresa Adresa { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
