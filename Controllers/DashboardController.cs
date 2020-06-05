using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTaskManager.Identity;
using MvcTaskManager.Models;
using MvcTaskManager.Models.ViewModels;

namespace MvcTaskManager.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;
        public DashboardController(
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
                DashboardDTO dto = _mapper.Map<DashboardDTO>(new Dashboard(_db));
                _logger.LogInformation($"{Environment.NewLine} Get");
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }

    }
}