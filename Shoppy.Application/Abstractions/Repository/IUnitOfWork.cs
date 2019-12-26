using System.Threading.Tasks;

namespace Shopyy.Application.Abstractions.Repository
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
