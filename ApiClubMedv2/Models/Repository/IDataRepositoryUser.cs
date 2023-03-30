using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.Repository
{
    public interface IDataRepositoryUser<TEntity> : IDataRepository<TEntity>
    {
        ActionResult<TEntity> GetAutenticateUser(string criteria, string criteria2);
    }
}
