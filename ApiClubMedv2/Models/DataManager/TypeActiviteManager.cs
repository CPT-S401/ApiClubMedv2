using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class TypeActiviteManager : IDataRepository<TypeActivite>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public TypeActiviteManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<TypeActivite>> GetAll()
        {
            return clubMedDbContext.TypesActivite.ToList();
        }

        public ActionResult<TypeActivite> GetById(int id)
        {
            var typeActivite = clubMedDbContext.TypesActivite.Find(id);

            if (typeActivite == null)
            {
                return new NotFoundResult();
            }

            return typeActivite;
        }

        public ActionResult<TypeActivite> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var typeActivite = clubMedDbContext.TypesActivite.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (typeActivite == null)
            {
                return new NotFoundResult();
            }

            return typeActivite;
        }

        public void Add(TypeActivite entity)
        {
            clubMedDbContext.TypesActivite.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(TypeActivite entityToUpdate, TypeActivite entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(TypeActivite entity)
        {
            clubMedDbContext.TypesActivite.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
