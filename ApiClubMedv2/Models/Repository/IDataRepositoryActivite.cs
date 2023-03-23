using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.Repository
{
    public interface IDataRepositoryActivite<TEntity> : IDataRepository<TEntity>
    {
        ActionResult<IEnumerable<TEntity>> GetActivitiesByClub(int idClub);
    }
}
