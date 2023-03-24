using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using ApiClubMedv2.Models.DataManager;

namespace ApiClubMedv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IDataRepositoryJoin<Club> _dataRepository;

        public ClubsController(IDataRepositoryJoin<Club> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clubs/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Club>> GetClubById(int id)
        {
            var club = _dataRepository.GetById(id);

            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        // GET : api/Clubs/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Club>> GetClubByName(string name)
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
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.Id)
            {
                return BadRequest();
            }
            var clubToUpdate = _dataRepository.GetById(id);
            if (clubToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(clubToUpdate.Value, club);
                return NoContent();
            }
        }

        // POST: api/Clubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(club);
            return CreatedAtAction("GetById", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = _dataRepository.GetById(id);
            if (club == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(club.Value);
            return NoContent();
        }

        // GET : api/Clubs/GetClubsByCountry
        [HttpGet]
        [Route("[action]/{nameCountry}")]
        [ActionName("GetClubsByCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubsByCountry(string nameCountry)
        {
            var clubs = _dataRepository.GetStringByTable(nameCountry);

            if (clubs == null)
            {
                return NotFound();
            }
            return clubs;
        }
    }
}
