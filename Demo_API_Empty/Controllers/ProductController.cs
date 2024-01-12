using Demo_API_Empty.DTO;
using Demo_API_Empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API_Empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MySaleDBContext _saleDBContext = new MySaleDBContext();
        //get all
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(_saleDBContext.Products.ToList());
        }

        //get by ID
        [HttpGet]
        [Route("id")]
        public IActionResult GetProductByID(int id)
        {
            var product = _saleDBContext.Products.Find(id);
            return Ok(product);
        }
        // Insert
        [HttpPost]
        public IActionResult InsertProduct(ProductRequest req)
        {
            var product = new Product
            {
                ProductName = req.ProductName,
                UnitPrice = req.UnitPrice,
                UnitsInStock = req.UnitsInStock,
                Image = req.Image,
                CategoryId = req.CategoryId
            };
            
            _saleDBContext.Products.Add(product);
            _saleDBContext.SaveChanges();
            return Ok(product);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var productOld = _saleDBContext.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productOld == null)
            {
                return BadRequest();
            }
            productOld.ProductName = product.ProductName;
            productOld.UnitPrice = product.UnitPrice;
            productOld.CategoryId = product.CategoryId;
            _saleDBContext.SaveChanges();
            return Ok(productOld);
        }

        // Delete
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _saleDBContext.Products.SingleOrDefault(x => x.ProductId == id);
            _saleDBContext.Remove(product);
            _saleDBContext.SaveChanges();
            return Ok();
        }
    }
}
