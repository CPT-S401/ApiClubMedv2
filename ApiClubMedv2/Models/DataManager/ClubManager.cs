using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class ClubManager : IDataRepository<Club>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ClubManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Club>> GetAll()
        {
            return clubMedDbContext.Clubs.ToList();
        }

        public ActionResult<Club> GetById(int id)
        {
            var club = clubMedDbContext.Clubs.Find(id);

            if (club == null)
            {
                return new NotFoundResult();
            }

            return club;
        }

        public ActionResult<Club> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var club = clubMedDbContext.Clubs.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (club == null)
            {
                return new NotFoundResult();
            }

            return club;
        }

        public void Add(Club entity)
        {
            clubMedDbContext.Clubs.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Club entityToUpdate, Club entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.IdDomaineSkiable = entity.IdDomaineSkiable;
            entityToUpdate.Longitude = entity.Longitude;
            entityToUpdate.Latitude = entity.Latitude;
            entityToUpdate.LienPDF = entity.LienPDF;
            entityToUpdate.Email = entity.Email;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Club entity)
        {
            clubMedDbContext.Clubs.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }

}
