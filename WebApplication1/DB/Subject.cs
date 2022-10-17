using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DB
{
    public class Subject
    {
        [Required(ErrorMessage = "Id is needed")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject name needed")]
        public string Name { get; set; }
    }
}
