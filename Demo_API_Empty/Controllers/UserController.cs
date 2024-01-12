using Demo_API_Empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_Empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MySaleDBContext _saleDBContext = new MySaleDBContext();

        //get all
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_saleDBContext.Users.ToList());
        }
        [HttpPost]
        public IActionResult InsertUser(User user)
        {
            _saleDBContext.Users.Add(user);
            _saleDBContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var userOld = _saleDBContext.Users.FirstOrDefault(x => x.Account == user.Account);
            if (userOld == null)
            {
                return BadRequest();
            }
            userOld.Password = user.Password;
            userOld.Name = user.Name;
            userOld.Address = user.Address;
            userOld.Gender = user.Gender;
            _saleDBContext.SaveChanges();
            return Ok(userOld);
        }

        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            var user = _saleDBContext.Users.SingleOrDefault(x => x.Account == id);
            if(user == null)
            {
                return BadRequest();
            }
            _saleDBContext.Remove(user);
            _saleDBContext.SaveChanges();
            return Ok();
        }
    }
}
