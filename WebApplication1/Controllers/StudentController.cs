using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("Get-All-Students")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Student>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllStudents()
        {
            List<Student> students = DataAcessLayer.Instance.GetStudents();

            if (students.Count <= 0)
            {
                return NotFound();
            } else
            {
                return Ok(DataAcessLayer.Instance.GetStudents());
            }
        }

        [HttpGet("Get-Student-ById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudentById([FromQuery][Required] int studentId)
        {
            Student student = DataAcessLayer.Instance.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DataAcessLayer.Instance.GetStudentById(studentId));
            }
        }

        [HttpPost("Create-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateStudent([FromBody][Required] Student stud)
        {
            var res = DataAcessLayer.Instance.CreateStudent(stud);

            if (res == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpDelete("Delete-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudent([FromQuery][Required] int studentId)
        {
            string res = DataAcessLayer.Instance.DeleteStudent(studentId);
            if (res == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("Change-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudent([FromBody][Required] Student stud)
        {
        string res = DataAcessLayer.Instance.ChangeStudent(stud);
        if (res == "")
            {
                return Ok();
            }
        else
            {
                return BadRequest(res);
            }
        
        
        }
        
        [HttpPut("Change-Student-Address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudentAddress([FromQuery][Required] int studentId, [FromBody][Required] Adresa adresa)
        {
           var res = DataAcessLayer.Instance.ChangeStudentAddress(studentId, adresa);
            if (res == 1)
            {
                return Ok();
                
            }
            else if (res == 2)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete-Student-Plus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudentPlus([FromQuery][Required] int studentId)
        {
            var res = DataAcessLayer.Instance.DeleteStudentPlus(studentId);
            if (res == 1)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("Create-Subject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateSubject([FromBody][Required] Subject subject)
        {
            var res = DataAcessLayer.Instance.CreateSubject(subject);

            if(res == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPatch("AddMark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult AddMark([Required] int studentId, [FromBody][Required] Mark mark)
        {
            var res = DataAcessLayer.Instance.AddMark(studentId, mark);

            if (res == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
