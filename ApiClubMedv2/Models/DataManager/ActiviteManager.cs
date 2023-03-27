using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.DataManager
{
    public class ActiviteManager : IDataRepositoryJoin<Activite>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ActiviteManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Activite>> GetAll()
        {
            return new JsonResult(
                clubMedDbContext.Activites.Select(c => new
                    {
                        c.Id,
                        NomActivite = c.Nom,
                        NomTypeActivite = c.TypeActivite.Nom,
                        c.Description,
                        c.AgeMin,
                        c.Duree,
                        c.Prix,
                        AgeMax = c.ActiviteEnfant.AgeMax != null ? c.ActiviteEnfant.AgeMax : default(double?),
                        c.EstIncluse,
                    }
                )
            );
        }

        public ActionResult<IEnumerable<Activite>> GetIdByTable(int idClub)
        {
            return new JsonResult(clubMedDbContext.Activites
                    .Include(cA => cA.ClubActivites)
                        .ThenInclude(c => c.Club)
                        .ThenInclude(cAE => cAE.ClubActivitesEnfant)
                    .Where(cA => cA.ClubActivites
                        .Any(pl => pl.Club.Id == idClub) || cA.ActiviteEnfant != null)
                    .Select(c => new
                        {
                            c.Id,
                            NomActivite = c.Nom,
                            NomTypeActivite = c.TypeActivite.Nom,
                            c.Description,
                            c.AgeMin,
                            c.Duree,
                            c.Prix,
                            AgeMax = c.ActiviteEnfant.AgeMax  != null ? c.ActiviteEnfant.AgeMax : default(double?),
                            c.EstIncluse,
                        }
                    )
                );
        }

        public ActionResult<Activite> GetById(int id)
        {
            var activite = new JsonResult(clubMedDbContext.Activites
                .Include(cA => cA.ClubActivites)
                .Where(ca => ca.Id == id)
                .Select(c => new
                    {
                        c.Id,
                        NomActivite = c.Nom,
                        NomTypeActivite = c.TypeActivite.Nom,
                        c.Description,
                        c.AgeMin,
                        c.Duree,
                        c.Prix,
                        AgeMax = c.ActiviteEnfant.AgeMax != null ? c.ActiviteEnfant.AgeMax : default(double?),
                        c.EstIncluse,
                    }
                )
            );

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

        public ActionResult<IEnumerable<Activite>> GetStringByTable(string stringTable)
        {
            throw new NotImplementedException();
        }
    }
}
