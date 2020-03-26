using System.Collections.Generic;
using System.Threading.Tasks;

namespace supermarket.API.Domain.Services
{
 public interface IListService <T> {
     Task<IEnumerable<T>> ListAsync();
 }
}