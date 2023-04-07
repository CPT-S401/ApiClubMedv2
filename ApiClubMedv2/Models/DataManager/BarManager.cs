using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.DataManager
{
    public class BarManager : IDataRepositoryJoin<Bar>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public BarManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Bar>> GetAll()
        {
            return clubMedDbContext.Bars.ToList();
        }

        public ActionResult<IEnumerable<Bar>> GetIdByTable(int idClub)
        {
            return new JsonResult(clubMedDbContext.Bars
                    .Where(b => b.IdClub == idClub)
                    .Include(bm => bm.BarMultimedias)
                        .ThenInclude(m => m.Multimedia)
                    .Select(b => new
                        {
                            b.Id,
                            b.Nom,
                            b.Description,
                            Multimedia = b.BarMultimedias.Select(m => new
                                {
                                    m.Multimedia.Id,
                                    m.Multimedia.Nom,
                                    m.Multimedia.Lien,
                                }
                            ).ToList()
                        }
                   )
            );
        }
        
        public ActionResult<Bar> GetById(int id)
        {
            var bar = clubMedDbContext.Bars.Find(id);

            if (bar == null)
            {
                return new NotFoundResult();
            }

            return bar;
        }

        public ActionResult<Bar> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var bar = clubMedDbContext.Bars.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (bar == null)
            {
                return new NotFoundResult();
            }

            return bar;
        }

        public void Add(Bar entity)
        {
            clubMedDbContext.Bars.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Bar entityToUpdate, Bar entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Bar entity)
        {
            clubMedDbContext.Bars.Remove(entity);
            clubMedDbContext.SaveChanges();
        }

        public ActionResult<IEnumerable<Bar>> GetStringByTable(string stringTable)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Club>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
