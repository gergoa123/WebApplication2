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
            DataAccessLayer DAO = new();
            List<Student> students = DAO.GetStudents();

            if (students.Count <= 0)
            {
                return NotFound(students);
            } else
            {
                return Ok(students);
            }
        }

        [HttpGet("Get-Student-ById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudentById([FromQuery][Required] int studentId)
        {
            DataAccessLayer DAO = new();
            Student student = DAO.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound(new Student());
            }
            else
            {
                return Ok(DAO.GetStudentById(studentId));
            }
        }

        [HttpPost("Create-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateStudent([FromBody][Required] Student stud)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.CreateStudent(stud);
                return Ok("Student created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("Delete-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudent([FromQuery][Required] int studentId)
        {
            DataAccessLayer DAO = new();
            try { 
                DAO.DeleteStudent(studentId);
                return Ok("Deleted student");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("Change-Student")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudent([FromBody][Required] Student stud)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.ChangeStudent(stud);
                return Ok("Changed student");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        [HttpPut("Change-Student-Address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudentAddress([FromQuery][Required] int studentId, [FromBody][Required] Adresa adresa)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.ChangeStudentAddress(studentId, adresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("Delete-Student-Plus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudentPlus([FromQuery][Required] int studentId)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.DeleteStudentPlus(studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Create-Subject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateSubject([FromBody][Required] Subject subject)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.CreateSubject(subject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPatch("Add-Mark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult AddMark([Required] int studentId, [FromBody][Required] Mark mark)
        {
            DataAccessLayer DAO = new();
            try
            {
                DAO.AddMark(studentId, mark);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("Get-All-Marks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Mark>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetMarks()
        {
            DataAccessLayer DAO = new();
            List<Mark> marks = DAO.GetMarks();

            if (marks.Count <= 0)
            {
                return NotFound(marks);
            }
            else
            {
                return Ok(marks);
            }
        }
    }
}
