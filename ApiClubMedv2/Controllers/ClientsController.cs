using Microsoft.AspNetCore.Mvc;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;

namespace ApiClubMedv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDataRepositoryUser<Client> _dataRepository;

        public ClientsController(IDataRepositoryUser<Client> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Clients/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = _dataRepository.GetById(id);

            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // GET : api/Clients/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientByName(string name)
        {
            var client = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest();
            }
            var clientToUpdate = _dataRepository.GetById(id);
            if (clientToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(clientToUpdate.Value, client);
                return NoContent();
            }
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(client);
            return CreatedAtAction("GetById", new { id = client.IdClient }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = _dataRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(client.Value);
            return NoContent();
        }
    }
}
