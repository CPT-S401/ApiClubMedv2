using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class DomaineSkiableManager : IDataRepository<DomaineSkiable>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public DomaineSkiableManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<DomaineSkiable>> GetAll()
        {
            return clubMedDbContext.Domaines.ToList();
        }

        public ActionResult<DomaineSkiable> GetById(int id)
        {
            var domaineSkiable = clubMedDbContext.Domaines.Find(id);

            if (domaineSkiable == null)
            {
                return new NotFoundResult();
            }

            return domaineSkiable;
        }

        public ActionResult<DomaineSkiable> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var domaineSkiable = clubMedDbContext.Domaines.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (domaineSkiable == null)
            {
                return new NotFoundResult();
            }

            return domaineSkiable;
        }

        public void Add(DomaineSkiable entity)
        {
            clubMedDbContext.Domaines.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(DomaineSkiable entityToUpdate, DomaineSkiable entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.NomStation = entity.NomStation;
            entityToUpdate.AltitudeBasse = entity.AltitudeBasse;
            entityToUpdate.AltitudeHaute = entity.AltitudeHaute;
            entityToUpdate.InfoSki = entity.InfoSki;
            entityToUpdate.LongeurPistes = entity.LongeurPistes;
            entityToUpdate.NbPistes = entity.LongeurPistes;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(DomaineSkiable entity)
        {
            clubMedDbContext.Domaines.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
