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
    public class ActivitesController : ControllerBase
    {
        private readonly IDataRepositoryJoin<Activite> _dataRepository;

        public ActivitesController(IDataRepositoryJoin<Activite> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Activites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Activites/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            var activite = _dataRepository.GetById(id);

            if (activite == null)
            {
                return NotFound();
            }
            return activite;
        }

        // GET : api/Activites/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteByName(string name)
        {
            var activite = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (activite == null)
            {
                return NotFound();
            }
            return activite;
        }

        // PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.Id)
            {
                return BadRequest();
            }
            var activiteToUpdate = _dataRepository.GetById(id);
            if (activiteToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(activiteToUpdate.Value, activite);
                return NoContent();
            }
        }

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(activite);
            return CreatedAtAction("GetById", new { id = activite.Id }, activite);
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = _dataRepository.GetById(id);
            if (activite == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(activite.Value);
            return NoContent();
        }

        // GET : api/Activites/GetActivitiesByClub
        [HttpGet]
        [Route("[action]/{idClub}")]
        [ActionName("GetActivitesByClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivitesByClub(int idClub)
        {
            var activites = _dataRepository.GetIdByTable(idClub);

            if (activites == null)
            {
                return NotFound();
            }
            return activites;
        }
    }
}
