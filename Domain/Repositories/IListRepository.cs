using System.Collections.Generic;
using System.Threading.Tasks;

namespace supermarket.API.Domain.Repositories
{
 public interface IListRepository<T> {
     Task<IEnumerable<T>> ListAsync();
 }
}