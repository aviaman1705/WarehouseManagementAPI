using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Identity;
using MvcTaskManager.Models;
using MvcTaskManager.Models.ViewModels;
using AutoMapper;

namespace MvcTaskManager.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductsController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(_db.Products.ToList());
            return Ok(productsDTO);
        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get(int id)
        {
            ProductDTO productDTO = _mapper.Map<ProductDTO>(_db.Products.Where(temp => temp.Id == id).FirstOrDefault());

            if (productDTO != null)
            {
                return Ok(productDTO);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] Product product)
        {

            Product productAllreadyExsist = _db.Products.FirstOrDefault(p => p.Title == product.Title && p.Code == product.Code);

            if (productAllreadyExsist != null)
            {
                productAllreadyExsist.Count += product.Count;
                _db.SaveChanges();
                return Ok(productAllreadyExsist);
            }
            else
            {
                _db.Products.Add(product);
                _db.SaveChanges();

                ProductDTO productDTO = _mapper.Map<ProductDTO>(_db.Products.Where(temp => temp.Id == product.Id).FirstOrDefault());
                return Ok(productDTO);
            }
        }


        [HttpPut()]
        [Route("UpdateProductDetails")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] Product product)
        {
            Product existingProduct = _db.Products.Where(temp => temp.Id == product.Id).FirstOrDefault();
            if (existingProduct != null)
            {
                existingProduct.Code = product.Code;
                existingProduct.Count = product.Count;
                existingProduct.Title = product.Title;

                _db.SaveChanges();

                ProductDTO existingProjectDTO = _mapper.Map<ProductDTO>(existingProduct);
                return Ok(existingProjectDTO);
            }
            else
            {
                return null;
            }
        }


        [HttpDelete]
        [Route("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int Delete(int id)
        {
            Product existingProduct = _db.Products.Where(temp => temp.Id == id).FirstOrDefault();
            if (existingProduct != null)
            {
                _db.Products.Remove(existingProduct);
                _db.SaveChanges();
                return id;
            }
            else
            {
                return -1;
            }
        }
        // GET api/product/title/value
        [HttpGet("{type}/{value}")]
        public int Search(string type, string value)
        {

            if (type == "title")
            {
                bool titleExsist = _db.Products.Any(x => x.Title.StartsWith(value));
                if (titleExsist)
                {
                    return -1;
                }
                return 1;
            }
            else if (type == "code")
            {
                bool titleExsist = _db.Products.Any(x => x.Code.StartsWith(value));
                if (titleExsist)
                {
                    return -1;
                }
                return 1;
            }
            else
                return 1;
        }
    }
}