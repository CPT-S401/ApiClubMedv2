using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClubMedv2.Models.DataManager
{
    public class TypeChambreManager : IDataRepositoryJoin<TypeChambre>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public TypeChambreManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<TypeChambre>> GetAll()
        {
            return new JsonResult(
               clubMedDbContext.TypesChambre
               .Include(am => am.TypeChambreMultimedias)
                        .ThenInclude(m => m.Multimedia)
               .Select(c => new
                   {
                       c.Id,
                       c.IdClub,
                       NomTypeChambre = c.Nom,
                       c.Description,
                       c.Prix,
                       c.Surface,
                       Multimedia = c.TypeChambreMultimedias.Select(m => new
                       {
                           m.Multimedia.Id,
                           m.Multimedia.Nom,
                           m.Multimedia.Lien,
                       }).ToList()
                   }
               )
           );
        }

        public ActionResult<IEnumerable<TypeChambre>> GetIdByTable(int idClub)
        {
            return new JsonResult(clubMedDbContext.TypesChambre
                    .Include(am => am.TypeChambreMultimedias)
                        .ThenInclude(m => m.Multimedia)
                    .Where(cTC => cTC.IdClub == idClub)
                    .Select(c => new
                        {
                            c.Id,
                            NomTypeChambre = c.Nom,
                            c.Description,
                            c.Prix,
                            c.Surface,
                            Multimedia = c.TypeChambreMultimedias.Select(m => new
                            {
                                m.Multimedia.Id,
                                m.Multimedia.Nom,
                                m.Multimedia.Lien,
                            }).ToList()
                        }
                    )
                );
        }

        public ActionResult<IEnumerable<TypeChambre>> GetStringByTable(string stringTable)
        {
            throw new NotImplementedException();
        }

        public ActionResult<TypeChambre> GetById(int id)
        {
            var typeChambre = new JsonResult(clubMedDbContext.TypesChambre
                .Where(ca => ca.Id == id)
                .Include(am => am.TypeChambreMultimedias)
                        .ThenInclude(m => m.Multimedia)
                .Select(c => new
                    {
                        c.Id,
                        c.IdClub,
                        NomTypeChambre = c.Nom,
                        c.Description,
                        c.Prix,
                        c.Surface,
                        Multimedia = c.TypeChambreMultimedias.Select(m => new
                        {
                            m.Multimedia.Id,
                            m.Multimedia.Nom,
                            m.Multimedia.Lien,
                        }).ToList()
                    }
                ));

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
