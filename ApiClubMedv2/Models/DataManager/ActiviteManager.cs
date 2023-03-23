using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.DataManager
{
    public class ActiviteManager : IDataRepositoryActivite<Activite>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ActiviteManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Activite>> GetAll()
        {
            return clubMedDbContext.Activites.ToList();
        }

        public ActionResult<IEnumerable<Activite>> GetActivitiesByClub(int idClub)
        {
            return new JsonResult(clubMedDbContext.Activites
                    .Include(cA => cA.ClubActivites)
                        .ThenInclude(c => c.Club)
                    .Where(cA => cA.ClubActivites
                        .Any(pl => pl.Club.Id == idClub))
                    .Select(c => new
                        {
                            c.Id,
                            NomActivite = c.Nom,
                            NomTypeActivite = c.TypeActivite.Nom,
                            c.Description,
                            c.AgeMin,
                            c.Duree,
                            c.Prix,
                            c.EstIncluse,
                        }
                    )
                );

            /* A TESTER 

                                .Include(cA => cA.ClubActivites)
                        .ThenInclude(c => c.Club)
                    .Include(cA => cA.ActivitesEnfant)
                        .ThenInclude(c => c.ClubEnfant)
                    .Where(cA => cA.ClubActivites
                        .Any(pl => pl.Club.Id == idClub)
                        || cA.ActivitesEnfant
                            .Any(ae => ae.ClubEnfant.Id == idClub))
            */
        }

        public ActionResult<Activite> GetById(int id)
        {
            var activite = clubMedDbContext.Activites.Find(id);

            if (activite == null)
            {
                return new NotFoundResult();
            }

            return activite;
        }

        public ActionResult<Activite> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var activite = clubMedDbContext.Activites.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (activite == null)
            {
                return new NotFoundResult();
            }

            return activite;
        }

        public void Add(Activite entity)
        {
            clubMedDbContext.Activites.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Activite entityToUpdate, Activite entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.AgeMin = entity.AgeMin;
            entityToUpdate.Duree = entity.Duree;
            entityToUpdate.EstIncluse = entity.EstIncluse;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Activite entity)
        {
            clubMedDbContext.Activites.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
