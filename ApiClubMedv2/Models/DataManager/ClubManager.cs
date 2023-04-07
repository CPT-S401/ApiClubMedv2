using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiClubMedv2.Models.DataManager
{
    public class ClubManager : IDataRepositoryJoin<Club>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ClubManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Club>> GetAll()
        {
            return new JsonResult(
                clubMedDbContext.Clubs
                .Include(am => am.ClubMultimedias)
                        .ThenInclude(m => m.Multimedia)
                .Include(c => c.ClubPaysLocalisations)
                    .ThenInclude(pl => pl.Pays)
                .Select(c => new
                    {
                        c.Id,
                        NomClub = c.Nom,
                        c.LienPDF,
                        DescriptionClub = c.Description,
                        c.Longitude,
                        c.Latitude,
                        c.Email,
                        Pays = c.ClubPaysLocalisations.Select(pl => new
                        {
                            pl.Pays.Id,
                            pl.Pays.Nom,
                        }).FirstOrDefault(),
                        DomaineSkiable = c.Domaine ?? c.Domaine,
                        Avis = c.Avis ?? c.Avis,
                        Multimedia = c.ClubMultimedias.Select(m => new
                        {
                            m.Multimedia.Id,
                            m.Multimedia.Nom,
                            m.Multimedia.Lien,
                        }).ToList()
                    }
            )
        );
        }

        public ActionResult<IEnumerable<Club>> GetStringByTable(string nameCountry)
        {
            return new JsonResult(clubMedDbContext.Clubs
                    .Include(c => c.ClubPaysLocalisations)
                        .ThenInclude(pl => pl.Pays)
                    .Where(c => c.ClubPaysLocalisations
                        .Any(pl => pl.Pays.Nom.ToUpper() == nameCountry.ToUpper())
                    )
                    .Select(c => new
                        {
                            c.Id,
                            c.Nom,
                            c.Description,
                            c.LienPDF,
                            c.Longitude,
                            c.Latitude,
                            c.Email,
                        }
                    )
                );

            /* AUTRE FACON DE FAIRE 
            
            return (from pays in clubMedDbContext.Set<Pays>()
                         join clubPaysLocalisation in clubMedDbContext.Set<ClubPaysLocalisation>()
                               on pays.Id equals clubPaysLocalisation.IdPays
                         join club in clubMedDbContext.Set<Club>()
                               on clubPaysLocalisation.IdClub equals club.Id
                         where pays.Nom == nameCountry
                         select club).Distinct().ToList();*/
        }

        public ActionResult<Club> GetById(int id)
        {
            var club = new JsonResult(clubMedDbContext.Clubs
                .Where(ca => ca.Id == id)
                 .Include(am => am.ClubMultimedias)
                        .ThenInclude(m => m.Multimedia)
                .Include(c => c.ClubPaysLocalisations)
                    .ThenInclude(pl => pl.Pays)
                .Select(c => new
                    {
                        c.Id,
                        NomClub = c.Nom,
                        c.LienPDF,
                        DescriptionClub = c.Description,
                        c.Longitude,
                        c.Latitude,
                        c.Email,
                        Pays = c.ClubPaysLocalisations.Select(pl => new
                        {
                            pl.Pays.Id,
                            pl.Pays.Nom,
                        }).FirstOrDefault(),
                        DomaineSkiable = c.Domaine  ?? c.Domaine,
                        Avis = c.Avis ?? c.Avis,
                        Multimedia = c.ClubMultimedias.Select(m => new
                        {
                            m.Multimedia.Id,
                            m.Multimedia.Nom,
                            m.Multimedia.Lien,
                        }).ToList()
                    }
                )
            );

            if (club == null)
            {
                return new NotFoundResult();
            }

            return club;
        }

        public ActionResult<Club> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var club = clubMedDbContext.Clubs.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (club == null)
            {
                return new NotFoundResult();
            }

            return club;
        }

        public void Add(Club entity)
        {
            clubMedDbContext.Clubs.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Club entityToUpdate, Club entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.IdDomaineSkiable = entity.IdDomaineSkiable;
            entityToUpdate.Longitude = entity.Longitude;
            entityToUpdate.Latitude = entity.Latitude;
            entityToUpdate.LienPDF = entity.LienPDF;
            entityToUpdate.Email = entity.Email;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Club entity)
        {
            clubMedDbContext.Clubs.Remove(entity);
            clubMedDbContext.SaveChanges();
        }

        public ActionResult<IEnumerable<Club>> GetIdByTable(int idTable)
        {
            throw new NotImplementedException();
        }
    }
}
