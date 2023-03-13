using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class PaysManager : IDataRepository<Pays>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public PaysManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Pays>> GetAll()
        {
            return clubMedDbContext.Pays.ToList();
        }

        public ActionResult<Pays> GetById(int id)
        {
            var pays = clubMedDbContext.Pays.Find(id);

            if (pays == null)
            {
                return new NotFoundResult();
            }

            return pays;
        }

        public ActionResult<Pays> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var pays = clubMedDbContext.Pays.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (pays == null)
            {
                return new NotFoundResult();
            }

            return pays;
        }

        public void Add(Pays entity)
        {
            clubMedDbContext.Pays.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Pays entityToUpdate, Pays entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Pays entity)
        {
            clubMedDbContext.Pays.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
