using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Interfaces
{
    public interface IDatabaseCreator
    {
        public Task<bool> CreateAsync(bool recreate = false);
    }
}
