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
    public class CodesPostauxController : ControllerBase
    {
        private readonly IDataRepository<CodePostal> _dataRepository;

        public CodesPostauxController(IDataRepository<CodePostal> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodePostal>>> GetCodesPostaux()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CodePostal>> GetCodePostalById(int id)
        {
            var codePostal = _dataRepository.GetById(id);

            if (codePostal == null)
            {
                return NotFound();
            }
            return codePostal;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CodePostal>> GetCodePostalByName(string name)
        {
            var codePostal = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (codePostal == null)
            {
                return NotFound();
            }
            return codePostal;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCodePostal(int id, CodePostal codePostal)
        {
            if (id != codePostal.Id)
            {
                return BadRequest();
            }
            var codePostalToUpdate = _dataRepository.GetById(id);
            if (codePostalToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(codePostalToUpdate.Value, codePostal);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CodePostal>> PostCodePostal(CodePostal codePostal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(codePostal);
            return CreatedAtAction("GetById", new { id = codePostal.Id }, codePostal);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCodePostal(int id)
        {
            var codePostal = _dataRepository.GetById(id);
            if (codePostal == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(codePostal.Value);
            return NoContent();
        }
    }
}
