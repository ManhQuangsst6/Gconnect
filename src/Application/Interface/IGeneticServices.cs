using Gconnect.Application.Common.Models;

namespace Gconnect.Application.Interface;
public interface IGeneticServices<TSource, TDestination>
{
    public Task<PaginatedList<TDestination>> Filter(string keySearch, int pageSize, int pageNumber);
    public Task<List<TDestination>> GetAll();
    public TDestination? Get(string id);
    public string Save(TDestination role);
    public void Delete(string id);
    public void Update(TDestination role);
    
}
