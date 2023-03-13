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
    public class LocalisationsController : ControllerBase
    {
        private readonly IDataRepository<Localisation> _dataRepository;

        public LocalisationsController(IDataRepository<Localisation> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localisation>>> GetLocalisations()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Localisation>> GetLocalisationById(int id)
        {
            var localisation = _dataRepository.GetById(id);

            if (localisation == null)
            {
                return NotFound();
            }
            return localisation;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Localisation>> GetLocalisationByName(string name)
        {
            var localisation = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (localisation == null)
            {
                return NotFound();
            }
            return localisation;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLocalisation(int id, Localisation localisation)
        {
            if (id != localisation.Id)
            {
                return BadRequest();
            }
            var localisationToUpdate = _dataRepository.GetById(id);
            if (localisationToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(localisationToUpdate.Value, localisation);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Localisation>> PostLocalisation(Localisation localisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(localisation);
            return CreatedAtAction("GetById", new { id = localisation.Id }, localisation);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLocalisation(int id)
        {
            var localisation = _dataRepository.GetById(id);
            if (localisation == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(localisation.Value);
            return NoContent();
        }
    }
}
