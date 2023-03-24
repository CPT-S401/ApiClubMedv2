using ApiClubMedv2.Controllers;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections.Immutable;
using Newtonsoft.Json;

namespace ApiClubMedv2.Models.DataManager
{
    public class ClubManager : IDataRepositoryClub<Club>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ClubManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Club>> GetAll()
        {
            return clubMedDbContext.Clubs.ToList();
        }

        public ActionResult<IEnumerable<Club>> GetClubsByCountry(string nameCountry)
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
            var club = clubMedDbContext.Clubs.Find(id);

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
    }

}
