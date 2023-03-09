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
    public class DomaineSkiablesController : ControllerBase
    {
        private readonly IDataRepository<DomaineSkiable> _dataRepository;

        public DomaineSkiablesController(IDataRepository<DomaineSkiable> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomaineSkiable>>> GetDomainesSkiables()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DomaineSkiable>> GetDomaineSkiableById(int id)
        {
            var domaineSkiable = _dataRepository.GetById(id);

            if (domaineSkiable == null)
            {
                return NotFound();
            }
            return domaineSkiable;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DomaineSkiable>> GetDomaineSkiableByName(string name)
        {
            var club = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDomaineSkiable(int id, DomaineSkiable domaineSkiable)
        {
            if (id != domaineSkiable.Id)
            {
                return BadRequest();
            }
            var domaineSkiableToUpdate = _dataRepository.GetById(id);
            if (domaineSkiableToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(domaineSkiableToUpdate.Value, domaineSkiable);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Club>> PostDomaineSkiable(DomaineSkiable domaineSkiable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(domaineSkiable);
            return CreatedAtAction("GetById", new { id = domaineSkiable.Id }, domaineSkiable);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDomaineSkiable(int id)
        {
            var domaineSkiable = _dataRepository.GetById(id);
            if (domaineSkiable == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(domaineSkiable.Value);
            return NoContent();
        }
    }
}
