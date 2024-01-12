using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Template.Controllers
{
    public class StudentRequest{
       public string name {  get; set; }
       public int age { get; set; }
    }
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Tạo danh sách Student
        List<Student> data = new List<Student>()
        {
            new Student("SV01", "Nguyen Van A", 20),
            new Student("SV02", "Nguyen Van B", 19)
        };

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(data);
        }
        [HttpGet("{code}")]
        public IActionResult GetStudentByID(string code)
        {
            return Ok(data.SingleOrDefault(c => c.code == code));
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody]Student student) { 
            data.Add(student);
            return Ok(data);
        }
        [HttpPut]
        public IActionResult EditStudent(string code, [FromBody]StudentRequest req)
        {
            Student s1 = data.SingleOrDefault(c=> c.code.Equals(code));
            s1.name = req.name;
            s1.age = req.age;
            return Ok(data);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(string code)
        {
            
            var student = data.SingleOrDefault(s => s.code == code);
            data.Remove(student);
            return Ok(data);
        }

    }
}
