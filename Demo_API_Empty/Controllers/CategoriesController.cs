using Demo_API_Empty.DTO;
using Demo_API_Empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_API_Empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        MySaleDBContext _saleDBContext = new MySaleDBContext();
        //get all
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            return Ok (_saleDBContext.Categories.Include(p=>p.Products).Select(p=> new CategoryResponse
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                Products = p.Products.Select(x=> new ProductResponse
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    Image = x.Image
                }).ToList()
            }).ToList());
        }

        //get by ID
        [HttpGet]
        [Route("id")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _saleDBContext.Categories.Find(id);
            return Ok(category);
        }
        // Insert
        [HttpPost]
        public IActionResult InsertCategory(Category category)
        {
            
            _saleDBContext.Categories.Add(category);
            _saleDBContext.SaveChanges();
            return Ok(category);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var categoryOld = _saleDBContext.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (categoryOld == null)
            {
                return BadRequest();
            }
            categoryOld.CategoryName = category.CategoryName;
            _saleDBContext.SaveChanges();
            return Ok(categoryOld);
        }

        // Delete
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _saleDBContext.Categories.SingleOrDefault(x => x.CategoryId == id);
            _saleDBContext.Remove(category);
            _saleDBContext.SaveChanges();
            return Ok();
        }


    }
}
