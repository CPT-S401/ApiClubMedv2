using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class AvisManager : IDataRepository<Avis>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public AvisManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Avis>> GetAll()
        {
            return clubMedDbContext.Avis.ToList();
        }

        public ActionResult<Avis> GetById(int id)
        {
            var avis = clubMedDbContext.Avis.Find(id);

            if (avis == null)
            {
                return new NotFoundResult();
            }

            return avis;
        }

        public ActionResult<Avis> GetByString(string str)
        {
            var avis = new Avis();

            return avis;
        }

        public void Add(Avis entity)
        {
            clubMedDbContext.Avis.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Avis entityToUpdate, Avis entity)
        {
            entityToUpdate.Note = entity.Note;
            entityToUpdate.Commentaire = entity.Commentaire;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Avis entity)
        {
            clubMedDbContext.Avis.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
