using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;

namespace ApiClubMedv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeClubsController : ControllerBase
    {
        private readonly IDataRepository<TypeClub> _dataRepository;

        public TypeClubsController(IDataRepository<TypeClub> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeClub>>> GetTypeClubs()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClub>> GetTypeClubById(int id)
        {
            var typeClub = _dataRepository.GetById(id);

            if (typeClub == null)
            {
                return NotFound();
            }
            return typeClub;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeClub>> GetTypeClubByName(string name)
        {
            var typeClub = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (typeClub == null)
            {
                return NotFound();
            }
            return typeClub;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeClub(int id, TypeClub typeClub)
        {
            if (id != typeClub.Id)
            {
                return BadRequest();
            }
            var typeClubToUpdate = _dataRepository.GetById(id);
            if (typeClubToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(typeClubToUpdate.Value, typeClub);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeClub>> PostTypeClub(TypeClub typeClub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(typeClub);
            return CreatedAtAction("GetById", new { id = typeClub.Id }, typeClub);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeClub(int id)
        {
            var typeClub = _dataRepository.GetById(id);
            if (typeClub == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(typeClub.Value);
            return NoContent();
        }
    }
}
