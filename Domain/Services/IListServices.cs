using System.Collections.Generic;
using System.Threading.Tasks;

namespace mockshop.API.Domain.Services
{
 public interface IListService <T> {
     Task<IEnumerable<T>> ListAsync();
 }
}