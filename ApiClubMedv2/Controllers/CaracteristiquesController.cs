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
    public class CaracteristiquesController : ControllerBase
    {
        private readonly IDataRepository<Caracteristique> _dataRepository;

        public CaracteristiquesController(IDataRepository<Caracteristique> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetCaracteristiques()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Caracteristique>> GetCaracteristiqueById(int id)
        {
            var caracteristique = _dataRepository.GetById(id);

            if (caracteristique == null)
            {
                return NotFound();
            }
            return caracteristique;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Caracteristique>> GetCaracteristiqueByName(string name)
        {
            var caracteristique = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (caracteristique == null)
            {
                return NotFound();
            }
            return caracteristique;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCaracteristique(int id, Caracteristique caracteristique)
        {
            if (id != caracteristique.Id)
            {
                return BadRequest();
            }
            var caracteristiqueToUpdate = _dataRepository.GetById(id);
            if (caracteristiqueToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(caracteristiqueToUpdate.Value, caracteristique);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Caracteristique>> PostCaracteristique(Caracteristique caracteristique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(caracteristique);
            return CreatedAtAction("GetById", new { id = caracteristique.Id }, caracteristique);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletecaracteristique(int id)
        {
            var caracteristique = _dataRepository.GetById(id);
            if (caracteristique == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(caracteristique.Value);
            return NoContent();
        }
    }
}
