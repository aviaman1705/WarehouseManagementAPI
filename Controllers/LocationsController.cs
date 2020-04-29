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
    [Route("api/locations")]
    public class LocationsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public LocationsController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            List<LocationDTO> LocationsDTO = _mapper.Map<List<LocationDTO>>(_db.Locations.ToList());
            return Ok(LocationsDTO);
        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get(int id)
        {
            LocationDTO LocationDTO = _mapper.Map<LocationDTO>(_db.Locations.Where(temp => temp.Id == id).FirstOrDefault());

            if (LocationDTO != null)
            {
                return Ok(LocationDTO);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] Location Location)
        {
            Location LocationAllreadyExsist = _db.Locations.FirstOrDefault(p => p.Place == Location.Place);
            if (LocationAllreadyExsist != null)
            {
                return BadRequest(new { error = "אייטם כבר קיים" });
            }
            else
            {
                _db.Locations.Add(Location);
                _db.SaveChanges();
                LocationDTO LocationDTO = _mapper.Map<LocationDTO>(_db.Locations.Where(temp => temp.Id == Location.Id).FirstOrDefault());
                return Ok(LocationDTO);
            }
        }


        [HttpPut()]
        [Route("UpdateLocationDetails")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] Location Location)
        {
            Location existingLocation = _db.Locations.Where(temp => temp.Id == Location.Id).FirstOrDefault();
            if (existingLocation != null)
            {
                existingLocation.Place = Location.Place;
                _db.SaveChanges();

                LocationDTO existingLocationDTO = _mapper.Map<LocationDTO>(existingLocation);
                return Ok(existingLocationDTO);
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
            Location existingLocation = _db.Locations.Where(temp => temp.Id == id).FirstOrDefault();
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
        // GET api/Location/location
        [HttpGet("search/{place}")]
        public int Search(string place)
        {
            bool locationExsist = _db.Locations.Any(x => x.Place.StartsWith(place));
            if (locationExsist)
            {
                return -1;
            }
            return 1;
        }
    }
}