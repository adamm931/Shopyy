using Shopyy.Domain.Entities;
using System.Threading.Tasks;

namespace Shopyy.Application.Abstractions.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }

        Task SaveChangesAsync();
    }
}
