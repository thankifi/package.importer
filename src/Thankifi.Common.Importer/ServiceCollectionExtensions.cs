using System;
using Microsoft.Extensions.DependencyInjection;
using Thankifi.Common.Importer.Abstractions;
using Thankifi.Common.Importer.Abstractions.Options;

namespace Thankifi.Common.Importer
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds filters and related services to the container.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="options"></param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddImporter(this IServiceCollection services, Action<ImportOptions>? options)
        {
            var importerConfig = services.AddOptions<ImportOptions>().BindConfiguration(ImportOptions.Section);
            
            if (options is not null)
            {
                importerConfig.Configure(options);
            }
            
            services.AddHttpClient<IImporter, Importer>();


            return services;
        }
    }
}