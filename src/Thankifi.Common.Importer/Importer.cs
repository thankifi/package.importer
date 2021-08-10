using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thankifi.Common.Importer.Model;
using Thankifi.Common.Importer.Options;

namespace Thankifi.Common.Importer
{
    public class Importer : IImporter
    {
        private readonly ILogger<Importer> _logger;
        private readonly HttpClient _httpClient;

        public Importer(ILogger<Importer> logger, HttpClient httpClient, ImportOptions options)
        {
            _logger = logger;
            _httpClient = httpClient;

            _httpClient.BaseAddress = options.Source;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        public async Task<Dataset?> GetDataset(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("dataset.json", cancellationToken);

            try
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<Dataset>(cancellationToken: cancellationToken);

                return content;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception retrieving version information. Received {@Response}", response);
            }

            return default;
        }

        public async Task<int?> GetVersion(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("version.json", cancellationToken);

            try
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<VersionResponse>(cancellationToken: cancellationToken);

                return content?.Version;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception retrieving version information. Received {@Response}", response);
            }
            
            return default;
        }
    }
}