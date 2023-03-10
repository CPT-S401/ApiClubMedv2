using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class TransportManager : IDataRepository<Transport>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public TransportManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Transport>> GetAll()
        {
            return clubMedDbContext.Transports.ToList();
        }

        public ActionResult<Transport> GetById(int id)
        {
            var transport = clubMedDbContext.Transports.Find(id);

            if (transport == null)
            {
                return new NotFoundResult();
            }

            return transport;
        }

        public ActionResult<Transport> GetByString(string str)
        {
            str = str.Replace('_', ' ');
            var transport = clubMedDbContext.Transports.FirstOrDefault(c => c.Nom.ToLower() == str.ToLower());

            if (transport == null)
            {
                return new NotFoundResult();
            }

            return transport;
        }

        public void Add(Transport entity)
        {
            clubMedDbContext.Transports.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Transport entityToUpdate, Transport entity)
        {
            entityToUpdate.Nom = entity.Nom;
            entityToUpdate.Prix = entity.Prix;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Transport entity)
        {
            clubMedDbContext.Transports.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
