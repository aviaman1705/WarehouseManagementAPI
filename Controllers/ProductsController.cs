using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Identity;
using MvcTaskManager.Models;
using MvcTaskManager.Models.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;

namespace MvcTaskManager.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(
            ApplicationDbContext db,
            IMapper mapper,
            ILogger<ProductsController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            try
            {
                List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(_db.Products.ToList());
                _logger.LogInformation($"{Environment.NewLine} Get");
                return Ok(productsDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get(int id)
        {
            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(_db.Products.Where(temp => temp.Id == id).FirstOrDefault());
                _logger.LogInformation($"{Environment.NewLine} Get {id}");

                if (productDTO != null)
                {
                    return Ok(productDTO);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }


        [HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                Product productAllreadyExsist = _db.Products.FirstOrDefault(p => p.Title == product.Title && p.Code == product.Code);
                _logger.LogInformation($"{Environment.NewLine} Post {product}");

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
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }


        [HttpPut()]
        [Route("UpdateProductDetails")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                Product existingProduct = _db.Products.Where(temp => temp.Id == product.Id).FirstOrDefault();
                _logger.LogInformation($"{Environment.NewLine} Put {product}");

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
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }


        [HttpDelete]
        [Route("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int Delete(int id)
        {
            try
            {
                Product existingProduct = _db.Products.Where(temp => temp.Id == id).FirstOrDefault();
                _logger.LogInformation($"{Environment.NewLine} Delete {id}");

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
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }
        // GET api/product/title/value
        [HttpGet("{type}/{value}")]
        public int Search(string type, string value)
        {
            try
            {
                _logger.LogInformation($"{Environment.NewLine} Search {type}/{value}");

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
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }
    }
}
