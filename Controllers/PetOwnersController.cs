using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwners;

        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetPetOwnerById(int id)
        {
            var PetOwner = _context.PetOwners.Find(id);
            if (PetOwner == null)
            {
                return NotFound();
            }
            return PetOwner;
        }

        [HttpPost]
        public IActionResult CreatePetOwner(PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CreatePetOwner), new {id = petOwner.Id}, petOwner);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteOwner(int id)
        {
            PetOwner petOwner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner petOwner)
        {
            petOwner.Id = id;

            _context.Update(petOwner);
            _context.SaveChanges();

            return petOwner;
        }

    }
}
