using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Importer.Model;

namespace Thankifi.Common.Importer
{
    public interface IImporter
    {
        Task<Dataset?> GetDataset(CancellationToken cancellationToken = default);
        Task<int?> GetVersion(CancellationToken cancellationToken = default);
    }
}