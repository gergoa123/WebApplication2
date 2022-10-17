using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DB
{
    public class Mark
    {
        [Required(ErrorMessage = "Id is needed")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mark is needed")]
        [Range(1, 10)]
        public int Nota { get; set; }

        [Required(ErrorMessage = "Date is needed")]       
        public DateTime Date { get; set;}

        [Required(ErrorMessage = "Subject is needed")]
        public Subject Subject { get; set;}
    }
}
