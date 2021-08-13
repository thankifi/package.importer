using System.Threading;
using System.Threading.Tasks;

namespace Thankifi.Common.Importer.Abstractions
{
    public interface IImporter
    {
        Task<Dataset?> GetDataset(CancellationToken cancellationToken = default);
        Task<int?> GetVersion(CancellationToken cancellationToken = default);
    }
}