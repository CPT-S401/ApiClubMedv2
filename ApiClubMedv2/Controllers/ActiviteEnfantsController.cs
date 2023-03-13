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
    public class ActiviteEnfantsController : ControllerBase
    {
        private readonly IDataRepository<ActiviteEnfant> _dataRepository;

        public ActiviteEnfantsController(IDataRepository<ActiviteEnfant> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiviteEnfant>>> GetActivites()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActiviteEnfant>> GetActiviteEnfantById(int id)
        {
            var activiteEnfant = _dataRepository.GetById(id);

            if (activiteEnfant == null)
            {
                return NotFound();
            }
            return activiteEnfant;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActiviteEnfant>> GetActiviteEnfantByName(string name)
        {
            var activiteEnfant = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (activiteEnfant == null)
            {
                return NotFound();
            }
            return activiteEnfant;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActiviteEnfant(int id, ActiviteEnfant activiteEnfant)
        {
            if (id != activiteEnfant.Id)
            {
                return BadRequest();
            }
            var activiteEnfantToUpdate = _dataRepository.GetById(id);
            if (activiteEnfantToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(activiteEnfantToUpdate.Value, activiteEnfant);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActiviteEnfant>> PostActiviteEnfant(ActiviteEnfant activiteEnfant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(activiteEnfant);
            return CreatedAtAction("GetById", new { id = activiteEnfant.Id }, activiteEnfant);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActiviteEnfant(int id)
        {
            var activiteEnfant = _dataRepository.GetById(id);
            if (activiteEnfant == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(activiteEnfant.Value);
            return NoContent();
        }
    }
}
