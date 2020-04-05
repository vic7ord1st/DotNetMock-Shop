using System.Threading.Tasks;

namespace mockshop.API.Domain.Repositories {
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}