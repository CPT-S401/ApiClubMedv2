using ApiClubMedv2.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubMedv2.Models.Repository
{
    public interface IDataRepositoryJoin<TEntity> : IDataRepository<TEntity>
    {
        ActionResult<IEnumerable<TEntity>> GetIdByTable(int idTable);
        ActionResult<IEnumerable<TEntity>> GetStringByTable(string stringTable);
    }
}
