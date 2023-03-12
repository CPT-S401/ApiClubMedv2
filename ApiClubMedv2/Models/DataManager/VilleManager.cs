using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class VilleManager : IDataRepository<Ville>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public VilleManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Ville>> GetAll()
        {
            return clubMedDbContext.Villes.ToList();
        }

        public ActionResult<Ville> GetById(int id)
        {
            var ville = clubMedDbContext.Villes.Find(id);

            if (ville == null)
            {
                return new NotFoundResult();
            }

            return ville;
        }

        public ActionResult<Ville> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var ville = clubMedDbContext.Villes.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (ville == null)
            {
                return new NotFoundResult();
            }

            return ville;
        }

        public void Add(Ville entity)
        {
            clubMedDbContext.Villes.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Ville entityToUpdate, Ville entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Ville entity)
        {
            clubMedDbContext.Villes.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
