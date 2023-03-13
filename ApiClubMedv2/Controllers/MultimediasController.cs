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
    public class MultimediasController : ControllerBase
    {
        private readonly IDataRepository<Multimedia> _dataRepository;

        public MultimediasController(IDataRepository<Multimedia> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multimedia>>> GetMultimedias()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Multimedia>> GetMultimediaById(int id)
        {
            var multimedia = _dataRepository.GetById(id);

            if (multimedia == null)
            {
                return NotFound();
            }
            return multimedia;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Multimedia>> GetMultimediaByName(string name)
        {
            var multimedia = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (multimedia == null)
            {
                return NotFound();
            }
            return multimedia;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutMultimedia(int id, Multimedia multimedia)
        {
            if (id != multimedia.Id)
            {
                return BadRequest();
            }
            var multimediaToUpdate = _dataRepository.GetById(id);
            if (multimediaToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(multimediaToUpdate.Value, multimedia);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Multimedia>> PostMultimedia(Multimedia multimedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(multimedia);
            return CreatedAtAction("GetById", new { id = multimedia.Id }, multimedia);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMultimedia(int id)
        {
            var multimedia = _dataRepository.GetById(id);
            if (multimedia == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(multimedia.Value);
            return NoContent();
        }
    }
}
