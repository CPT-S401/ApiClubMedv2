using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class CookieManager : IDataRepository<Cookie>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public CookieManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Cookie>> GetAll()
        {
            return clubMedDbContext.Cookies.ToList();
        }

        public ActionResult<Cookie> GetById(int id)
        {
            var cookie = clubMedDbContext.Cookies.Find(id);

            if (cookie == null)
            {
                return new NotFoundResult();
            }

            return cookie;
        }

        public ActionResult<Cookie> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var cookie = clubMedDbContext.Cookies.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (cookie == null)
            {
                return new NotFoundResult();
            }

            return cookie;
        }

        public void Add(Cookie entity)
        {
            clubMedDbContext.Cookies.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Cookie entityToUpdate, Cookie entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Cookie entity)
        {
            clubMedDbContext.Cookies.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
