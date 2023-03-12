using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class TypeClubManager : IDataRepository<TypeClub>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public TypeClubManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<TypeClub>> GetAll()
        {
            return clubMedDbContext.TypesClub.ToList();
        }

        public ActionResult<TypeClub> GetById(int id)
        {
            var typeClub = clubMedDbContext.TypesClub.Find(id);

            if (typeClub == null)
            {
                return new NotFoundResult();
            }

            return typeClub;
        }

        public ActionResult<TypeClub> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var typeClub = clubMedDbContext.TypesClub.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (typeClub == null)
            {
                return new NotFoundResult();
            }

            return typeClub;
        }

        public void Add(TypeClub entity)
        {
            clubMedDbContext.TypesClub.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(TypeClub entityToUpdate, TypeClub entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(TypeClub entity)
        {
            clubMedDbContext.TypesClub.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
