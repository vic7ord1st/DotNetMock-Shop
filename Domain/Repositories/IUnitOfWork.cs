using System.Threading.Tasks;

namespace supermarket.API.Domain.Repositories {
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}