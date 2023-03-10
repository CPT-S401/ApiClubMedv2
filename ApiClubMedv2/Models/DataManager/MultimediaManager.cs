using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class MultimediaManager : IDataRepository<Multimedia>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public MultimediaManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Multimedia>> GetAll()
        {
            return clubMedDbContext.Multimedias.ToList();
        }

        public ActionResult<Multimedia> GetById(int id)
        {
            var multimedia = clubMedDbContext.Multimedias.Find(id);

            if (multimedia == null)
            {
                return new NotFoundResult();
            }

            return multimedia;
        }

        public ActionResult<Multimedia> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var multimedia = clubMedDbContext.Multimedias.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (multimedia == null)
            {
                return new NotFoundResult();
            }

            return multimedia;
        }

        public void Add(Multimedia entity)
        {
            clubMedDbContext.Multimedias.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Multimedia entityToUpdate, Multimedia entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Lien = entity.Lien;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Multimedia entity)
        {
            clubMedDbContext.Multimedias.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
