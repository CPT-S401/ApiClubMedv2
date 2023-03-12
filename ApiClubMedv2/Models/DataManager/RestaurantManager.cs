using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class RestaurantManager : IDataRepository<Restaurant>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public RestaurantManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            return clubMedDbContext.Restaurants.ToList();
        }

        public ActionResult<Restaurant> GetById(int id)
        {
            var restaurant = clubMedDbContext.Restaurants.Find(id);

            if (restaurant == null)
            {
                return new NotFoundResult();
            }

            return restaurant;
        }

        public ActionResult<Restaurant> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var restaurant = clubMedDbContext.Restaurants.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (restaurant == null)
            {
                return new NotFoundResult();
            }

            return restaurant;
        }

        public void Add(Restaurant entity)
        {
            clubMedDbContext.Restaurants.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Restaurant entityToUpdate, Restaurant entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Restaurant entity)
        {
            clubMedDbContext.Restaurants.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
