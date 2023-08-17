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
        public IActionResult CreatePetOwner(PetOwner petowner)
        {
            _context.Add(petowner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CreatePetOwner), new {id = petowner.Id}, petowner);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteOwner(int id)
        {
            PetOwner petowner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petowner);
            _context.SaveChanges();

            return Ok();
        }




    }
}
