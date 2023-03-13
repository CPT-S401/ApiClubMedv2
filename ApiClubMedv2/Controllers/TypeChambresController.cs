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
    public class TypeChambresController : ControllerBase
    {
        private readonly IDataRepository<TypeChambre> _dataRepository;

        public TypeChambresController(IDataRepository<TypeChambre> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeChambre>>> GetTypeChambres()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeChambre>> GetTypeChambreById(int id)
        {
            var typeChambre = _dataRepository.GetById(id);

            if (typeChambre == null)
            {
                return NotFound();
            }
            return typeChambre;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeChambre>> GetTypeChambreByName(string name)
        {
            var typeChambre = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (typeChambre == null)
            {
                return NotFound();
            }
            return typeChambre;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeChambre(int id, TypeChambre typeChambre)
        {
            if (id != typeChambre.Id)
            {
                return BadRequest();
            }
            var typeChambreToUpdate = _dataRepository.GetById(id);
            if (typeChambreToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(typeChambreToUpdate.Value, typeChambre);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeChambre>> PostTypeChambre(TypeChambre typeChambre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(typeChambre);
            return CreatedAtAction("GetById", new { id = typeChambre.Id }, typeChambre);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeChambre(int id)
        {
            var typeChambre = _dataRepository.GetById(id);
            if (typeChambre == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(typeChambre.Value);
            return NoContent();
        }
    }
}
