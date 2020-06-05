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
    [Route("api/locations")]
    public class LocationsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;
        public LocationsController(
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
                List<LocationDTO> LocationsDTO = _mapper.Map<List<LocationDTO>>(_db.Locations.ToList());
                _logger.LogInformation($"{Environment.NewLine} Get");
                return Ok(LocationsDTO);
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
                LocationDTO LocationDTO = _mapper.Map<LocationDTO>(_db.Locations.Where(temp => temp.Id == id).FirstOrDefault());
                _logger.LogInformation($"{Environment.NewLine} Get {id}");

                if (LocationDTO != null)
                {
                    return Ok(LocationDTO);
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
        public IActionResult Post([FromBody] Location location)
        {
            try
            {
                Location LocationAllreadyExsist = _db.Locations.FirstOrDefault(p => p.Place == location.Place);
                _logger.LogInformation($"{Environment.NewLine} Post {location}");

                if (LocationAllreadyExsist != null)
                {
                    return BadRequest(new { error = "אייטם כבר קיים" });
                }
                else
                {
                    _db.Locations.Add(location);
                    _db.SaveChanges();
                    LocationDTO LocationDTO = _mapper.Map<LocationDTO>(_db.Locations.Where(temp => temp.Id == location.Id).FirstOrDefault());
                    return Ok(LocationDTO);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Environment.NewLine} {ex.Message}");
                throw;
            }
        }


        [HttpPut()]
        [Route("UpdateLocationDetails")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] Location location)
        {
            try
            {
                Location existingLocation = _db.Locations.Where(temp => temp.Id == location.Id).FirstOrDefault();
                _logger.LogInformation($"{Environment.NewLine} Put {location}");

                if (existingLocation != null)
                {
                    existingLocation.Place = location.Place;
                    _db.SaveChanges();

                    LocationDTO existingLocationDTO = _mapper.Map<LocationDTO>(existingLocation);
                    return Ok(existingLocationDTO);
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
                Location existingLocation = _db.Locations.Where(temp => temp.Id == id).FirstOrDefault();
                _logger.LogInformation($"{Environment.NewLine} Delete {id}");

                if (existingLocation != null)
                {
                    _db.Locations.Remove(existingLocation);
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
        // GET api/Location/location
        [HttpGet("search/{place}")]
        public int Search(string place)
        {
            try
            {
                bool locationExsist = _db.Locations.Any(x => x.Place.StartsWith(place));
                _logger.LogInformation($"{Environment.NewLine} Search {place}");

                if (locationExsist)
                {
                    return -1;
                }
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