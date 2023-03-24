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
    public class RestaurantsController : ControllerBase
    {
        private readonly IDataRepositoryJoin<Restaurant> _dataRepository;

        public RestaurantsController(IDataRepositoryJoin<Restaurant> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET : api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return _dataRepository.GetAll();
        }

        // GET : api/Restaurants/GetRestaurantsByClub
        [HttpGet]
        [Route("[action]/{idClub}")]
        [ActionName("GetRestaurantsByClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsByClub(int idClub)
        {
            var restaurants = _dataRepository.GetIdByTable(idClub);

            if (restaurants == null)
            {
                return NotFound();
            }
            return restaurants;
        }

        // GET : api/Restaurant/1
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            var restaurant = _dataRepository.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return restaurant;
        }

        // GET : api/Restaurant/la_plagne
        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restaurant>> GetRestaurantByName(string name)
        {
            var restaurant = _dataRepository.GetByString(name);
            //var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            if (restaurant == null)
            {
                return NotFound();
            }
            return restaurant;
        }

        // PUT: api/Restaurant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }
            var restaurantToUpdate = _dataRepository.GetById(id);
            if (restaurantToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.Update(restaurantToUpdate.Value, restaurant);
                return NoContent();
            }
        }

        // POST: api/Restaurant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataRepository.Add(restaurant);
            return CreatedAtAction("GetById", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurant/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = _dataRepository.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _dataRepository.Delete(restaurant.Value);
            return NoContent();
        }
    }
}
