using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.Repository
{
    public interface IDataRepositoryClub<TEntity> : IDataRepository<TEntity>
    {
        ActionResult<IEnumerable<TEntity>> GetClubsByCountry(string nameCountry);
    }
}
