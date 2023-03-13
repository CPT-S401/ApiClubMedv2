using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class LocalisationManager : IDataRepository<Localisation>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public LocalisationManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Localisation>> GetAll()
        {
            return clubMedDbContext.Localisations.ToList();
        }

        public ActionResult<Localisation> GetById(int id)
        {
            var localisation = clubMedDbContext.Localisations.Find(id);

            if (localisation == null)
            {
                return new NotFoundResult();
            }

            return localisation;
        }

        public ActionResult<Localisation> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var localisation = clubMedDbContext.Localisations.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (localisation == null)
            {
                return new NotFoundResult();
            }

            return localisation;
        }

        public void Add(Localisation entity)
        {
            clubMedDbContext.Localisations.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Localisation entityToUpdate, Localisation entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Localisation entity)
        {
            clubMedDbContext.Localisations.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
