using CodeFirstApproachDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirstApproachDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentController : ControllerBase
    {

        private readonly SchoolContext _context;

        public SchoolStudentController(SchoolContext context)
        {
            _context = context;
        }
        // GET: StudentController
       
        // GET: api/<SchoolStudentController>
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        // GET api/<SchoolStudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST api/<SchoolStudentController>
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student value)
        {

            await _context.Students.AddAsync(value);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = value.RollNo }, value);
        }

        // PUT api/<SchoolStudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Student value)
        {
            var findStud = await _context.Students.FindAsync(id);
            if (findStud != null)
            {
                findStud.StudName = value.StudName;
                findStud.City = value.City;
                findStud.BirthDate = value.BirthDate;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest();
            
            }
           
        }

        // DELETE api/<SchoolStudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var findStud = await _context.Students.FindAsync(id);
            if (findStud != null)
            {
                _context.Students.Remove(findStud);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest();

            }
        }
    }
}
