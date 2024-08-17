using Microsoft.AspNetCore.Mvc;
using ProductPortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public ProductController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetProductDetails")]
        public List<Product> GetProductDetails()
        {
            List<Product> lstProduct = new List<Product>();
            try
            {
                lstProduct = trainingDBContext.Product.ToList();
                return lstProduct;
            }
            catch (Exception ex)
            {
                lstProduct = new List<Product>();
                return lstProduct;
            }
        }
        [HttpPost("AddProduct")]
        public string AddProduct(Product product)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(product.ProductName))
                {
                    trainingDBContext.Add(product);
                    trainingDBContext.SaveChanges();
                    message = "Product added successfully";
                }
                else
                    message = "Product Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
