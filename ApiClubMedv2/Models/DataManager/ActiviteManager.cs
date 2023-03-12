using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class ActiviteManager : IDataRepository<Activite>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ActiviteManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Activite>> GetAll()
        {
            return clubMedDbContext.Activites.ToList();
        }

        public ActionResult<Activite> GetById(int id)
        {
            var activite = clubMedDbContext.Activites.Find(id);

            if (activite == null)
            {
                return new NotFoundResult();
            }

            return activite;
        }

        public ActionResult<Activite> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var activite = clubMedDbContext.Activites.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (activite == null)
            {
                return new NotFoundResult();
            }

            return activite;
        }

        public void Add(Activite entity)
        {
            clubMedDbContext.Activites.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Activite entityToUpdate, Activite entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.AgeMin = entity.AgeMin;
            entityToUpdate.Duree = entity.Duree;
            entityToUpdate.EstIncluse = entity.EstIncluse;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Activite entity)
        {
            clubMedDbContext.Activites.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
