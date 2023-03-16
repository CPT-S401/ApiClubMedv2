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
    public class TypeActivitesController : ControllerBase
    {
        private readonly IDataRepository<TypeActivite> _dataRepository;

        public TypeActivitesController(IDataRepository<TypeActivite> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeActivite>>> GetTypeActivites()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeActivite>> GetTypeActiviteById(int id)
        {
            var typeActivite = _dataRepository.GetById(id);

            if (typeActivite == null)
            {
                return NotFound();
            }
            return typeActivite;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeActivite>> GetTypeActiviteByName(string name)
        {
            var typeActivite = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (typeActivite == null)
            {
                return NotFound();
            }
            return typeActivite;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeActivite(int id, TypeActivite typeActivite)
        {
            if (id != typeActivite.Id)
            {
                return BadRequest();
            }
            var typeActiviteToUpdate = _dataRepository.GetById(id);
            if (typeActiviteToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(typeActiviteToUpdate.Value, typeActivite);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeActivite>> PostTypeActivite(TypeActivite typeActivite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(typeActivite);
            return CreatedAtAction("GetById", new { id = typeActivite.Id }, typeActivite);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeActivite(int id)
        {
            var typeActivite = _dataRepository.GetById(id);
            if (typeActivite == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(typeActivite.Value);
            return NoContent();
        }
    }
}
