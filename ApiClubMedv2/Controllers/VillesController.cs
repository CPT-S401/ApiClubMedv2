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
    public class VillesController : ControllerBase
    {
        private readonly IDataRepository<Ville> _dataRepository;

        public VillesController(IDataRepository<Ville> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ville>>> GetVilles()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ville>> GetVilleById(int id)
        {
            var ville = _dataRepository.GetById(id);

            if (ville == null)
            {
                return NotFound();
            }
            return ville;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ville>> GetVilleByName(string name)
        {
            var ville = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (ville == null)
            {
                return NotFound();
            }
            return ville;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVille(int id, Ville ville)
        {
            if (id != ville.Id)
            {
                return BadRequest();
            }
            var villeToUpdate = _dataRepository.GetById(id);
            if (villeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(villeToUpdate.Value, ville);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ville>> PostVille(Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(ville);
            return CreatedAtAction("GetById", new { id = ville.Id }, ville);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVille(int id)
        {
            var ville = _dataRepository.GetById(id);
            if (ville == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(ville.Value);
            return NoContent();
        }
    }
}
