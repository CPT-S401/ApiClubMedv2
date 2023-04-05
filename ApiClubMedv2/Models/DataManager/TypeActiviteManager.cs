using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return new JsonResult(
               clubMedDbContext.TypesActivite
               .Include(am => am.TypeActiviteMultimedias)
                        .ThenInclude(m => m.Multimedia)
               .Select(c => new
                   {
                       c.Id,
                       NomTypeActivite = c.Nom,
                       c.Description,
                       Multimedia = c.TypeActiviteMultimedias.Select(m => new
                       {
                           m.Multimedia.Id,
                           m.Multimedia.Nom,
                           m.Multimedia.Lien,
                       }).ToList(),

                       Activites = c.Activites.Select(c => new
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
                           Multimedia = c.ActiviteMultimedias.Select(m => new
                           {
                               m.Multimedia.Id,
                               m.Multimedia.Nom,
                               m.Multimedia.Lien,
                           }).ToList()
                       }).ToList(),
                    }
               )
           );
        }

        public ActionResult<TypeActivite> GetById(int id)
        {
            var typeActivite = new JsonResult(clubMedDbContext.TypesActivite
                .Where(ca => ca.Id == id)
                .Include(am => am.TypeActiviteMultimedias)
                        .ThenInclude(m => m.Multimedia)
                .Select(c => new
                    {
                        c.Id,
                        NomTypeActivite = c.Nom,
                        c.Description,
                        c.Activites,
                        Multimedia = c.TypeActiviteMultimedias.Select(m => new
                        {
                            m.Multimedia.Id,
                            m.Multimedia.Nom,
                            m.Multimedia.Lien,
                        }).ToList()
                    }
                ));

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
