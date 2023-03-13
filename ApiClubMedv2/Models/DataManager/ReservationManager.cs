using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ReservationManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Reservation>> GetAll()
        {
            return clubMedDbContext.Reservations.ToList();
        }

        public ActionResult<Reservation> GetById(int id)
        {
            var reservation = clubMedDbContext.Reservations.Find(id);

            if (reservation == null)
            {
                return new NotFoundResult();
            }

            return reservation;
        }

        public ActionResult<Reservation> GetByString(string str)
        {
            Reservation reservation = new Reservation();

            return reservation;
        }

        public void Add(Reservation entity)
        {
            clubMedDbContext.Reservations.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Reservation entityToUpdate, Reservation entity)
        {
            entityToUpdate.DateDebut = entity.DateDebut;
            entityToUpdate.DateFin = entity.DateFin;
            entityToUpdate.Date = entity.Date;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Reservation entity)
        {
            clubMedDbContext.Reservations.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
