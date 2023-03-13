using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class TypeChambreManager : IDataRepository<TypeChambre>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public TypeChambreManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<TypeChambre>> GetAll()
        {
            return clubMedDbContext.TypesChambre.ToList();
        }

        public ActionResult<TypeChambre> GetById(int id)
        {
            var typeChambre = clubMedDbContext.TypesChambre.Find(id);

            if (typeChambre == null)
            {
                return new NotFoundResult();
            }

            return typeChambre;
        }

        public ActionResult<TypeChambre> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var typeChambre = clubMedDbContext.TypesChambre.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (typeChambre == null)
            {
                return new NotFoundResult();
            }

            return typeChambre;
        }

        public void Add(TypeChambre entity)
        {
            clubMedDbContext.TypesChambre.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(TypeChambre entityToUpdate, TypeChambre entity)
        {
            entityToUpdate.Nom = entity.Nom;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(TypeChambre entity)
        {
            clubMedDbContext.TypesChambre.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
