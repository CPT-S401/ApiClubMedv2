using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class ActiviteEnfantManager : IDataRepository<ActiviteEnfant>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ActiviteEnfantManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<ActiviteEnfant>> GetAll()
        {
            return clubMedDbContext.ActivitesEnfant.ToList();
        }

        public ActionResult<ActiviteEnfant> GetById(int id)
        {
            var activiteEnfant = clubMedDbContext.ActivitesEnfant.Find(id);

            if (activiteEnfant == null)
            {
                return new NotFoundResult();
            }

            return activiteEnfant;
        }

        public ActionResult<ActiviteEnfant> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var activiteEnfant = clubMedDbContext.ActivitesEnfant.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (activiteEnfant == null)
            {
                return new NotFoundResult();
            }

            return activiteEnfant;
        }

        public void Add(ActiviteEnfant entity)
        {
            clubMedDbContext.ActivitesEnfant.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(ActiviteEnfant entityToUpdate, ActiviteEnfant entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.AgeMin = entity.AgeMin;
            entityToUpdate.Duree = entity.Duree;
            entityToUpdate.EstIncluse = entity.EstIncluse;
            entityToUpdate.AgeMax = entity.AgeMax;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(ActiviteEnfant entity)
        {
            clubMedDbContext.ActivitesEnfant.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
