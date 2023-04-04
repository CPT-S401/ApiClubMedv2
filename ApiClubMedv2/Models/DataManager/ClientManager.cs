using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.DataManager
{
    public class ClientManager : IDataRepositoryUser<Client>
    {
        private readonly ClubMedDbContext clubMedDbContext;

        public ClientManager(ClubMedDbContext context)
        {
            clubMedDbContext = context;
        }

        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return clubMedDbContext.Clients.ToList();
        }

        public ActionResult<Client> GetById(int id)
        {
            var Client = clubMedDbContext.Clients.Find(id);

            if (Client == null)
            {
                return new NotFoundResult();
            }

            return Client;
        }

        public ActionResult<Client> GetByString(string str)
        {
            var Client = clubMedDbContext.Clients.FirstOrDefault(c => c.Email.ToUpper() == str.ToUpper());

            if (Client == null)
            {
                return new NotFoundResult();
            }

            return Client;
        }

        public ActionResult<Client> GetAutenticateUser(string email, string password)
        {
            var Client = clubMedDbContext.Clients.FirstOrDefault(c => c.Email.ToUpper() == email.ToUpper()
                && c.Password == password);

            if (Client == null)
            {
                return new NotFoundResult();
            }

            return Client;
        }

        public void Add(Client entity)
        {
            clubMedDbContext.Clients.Add(entity);
            clubMedDbContext.SaveChanges();
        }

        public void Update(Client entityToUpdate, Client entity)
        {
            entityToUpdate.GenreClient = entity.GenreClient;
            entityToUpdate.NomClient = entity.NomClient;
            entityToUpdate.PrenomClient = entity.PrenomClient;
            entityToUpdate.DateNaissance = entity.DateNaissance;
            entityToUpdate.Mobile = entity.Mobile;
            entityToUpdate.NumeroRue = entity.NumeroRue;
            entityToUpdate.NomRue = entity.NomRue;
            entityToUpdate.CodePostalClient = entity.CodePostalClient;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Password = entity.Password;
            clubMedDbContext.SaveChanges();
        }

        public void Delete(Client entity)
        {
            clubMedDbContext.Clients.Remove(entity);
            clubMedDbContext.SaveChanges();
        }
    }
}
