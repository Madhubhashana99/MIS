using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MIS.Data;
using MIS.Domains;
using MIS.DTO;
using MIS.Models;

namespace MIS.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public StudentController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

     

        [HttpGet]
        [Route("get-students")]
        public async Task<IActionResult> GetStudents([FromQuery]int pageNumber = 1, int pageSize = 10)
        {
            if(pageNumber <= 0 || pageSize <= 0){
                return BadRequest();
            }

            var totalCount = await _db.Students.CountAsync();
            var items = await _db.Students.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();

            var response = new PagedResult<StudentModel>
            {
                Items = _mapper.Map<List<StudentModel>>(items),
                TotalCount = totalCount,
                Page = pageNumber,
                PageSize = pageSize
            };

            return Ok(response);


            
        }


        [HttpPost]
        [Route("add-students")]
        public async Task<IActionResult> AddStudents([FromBody] StudentDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var student = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Phone_no = request.Phone_no,

            };

            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return Ok();

        }




        [HttpPut]
        [Route("update-student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto request)
        {
            if (request == null || id <= 0)
            {
                return BadRequest(new { error = "Invalid request data" });
            }

            var find_student = await _db.Students.FindAsync(id);

            if (find_student == null)
            {
                return NotFound(new { error = "Student not found" });
            }

            // Update the student details
            find_student.FirstName = request.FirstName;
            find_student.LastName = request.LastName;
            find_student.Email = request.Email;
            find_student.DateOfBirth = request.DateOfBirth;
            find_student.Address = request.Address;
            find_student.Phone_no = request.Phone_no;

            // Save changes to the database
            _db.Students.Update(find_student);
            await _db.SaveChangesAsync();

            return Ok(new { success = true, message = "Student updated successfully" });
        }



        [HttpDelete]
        [Route("delete-student/{id}")]
        public IActionResult DeleteStudentById(int id) {
            var student = _db.Students.Find(id);

            if (student is null) 
            {
                return NotFound();
            }
            else
            {
                _db.Students.Remove(student);
                _db.SaveChanges();

                return Ok(student);    

            }
        }




    }
}
