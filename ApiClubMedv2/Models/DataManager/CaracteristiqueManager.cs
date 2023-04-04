using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class CaracteristiqueManager : IDataRepository<Caracteristique>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public CaracteristiqueManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Caracteristique>> GetAll()
        {
            return clubMedDbContext.Caracteristiques.ToList();
        }

        public ActionResult<Caracteristique> GetById(int id)
        {
            var caracteristique = clubMedDbContext.Caracteristiques.Find(id);

            if (caracteristique == null)
            {
                return new NotFoundResult();
            }

            return caracteristique;
        }

        public ActionResult<Caracteristique> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var caracteristique = clubMedDbContext.Caracteristiques.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (caracteristique == null)
            {
                return new NotFoundResult();
            }

            return caracteristique;
        }

        public void Add(Caracteristique entity)
        {
            clubMedDbContext.Caracteristiques.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Caracteristique entityToUpdate, Caracteristique entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Caracteristique entity)
        {
            clubMedDbContext.Caracteristiques.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}