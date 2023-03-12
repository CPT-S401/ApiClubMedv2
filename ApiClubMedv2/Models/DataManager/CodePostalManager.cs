using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class CodePostalManager : IDataRepository<CodePostal>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public CodePostalManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<CodePostal>> GetAll()
        {
            return clubMedDbContext.CodesPostaux.ToList();
        }

        public ActionResult<CodePostal> GetById(int id)
        {
            var codePostal = clubMedDbContext.CodesPostaux.Find(id);

            if (codePostal == null)
            {
                return new NotFoundResult();
            }

            return codePostal;
        }

        public ActionResult<CodePostal> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var codePostal = clubMedDbContext.CodesPostaux.FirstOrDefault(c => c.Code.ToLower() == str.ToLower());

            if (codePostal == null)
            {
                return new NotFoundResult();
            }

            return codePostal;
        }

        public void Add(CodePostal entity)
        {
            clubMedDbContext.CodesPostaux.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(CodePostal entityToUpdate, CodePostal entity)
        {
            entityToUpdate.Code = entity.Code;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(CodePostal entity)
        {
            clubMedDbContext.CodesPostaux.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
