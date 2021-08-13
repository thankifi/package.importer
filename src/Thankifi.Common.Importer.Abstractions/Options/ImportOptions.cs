using System;

namespace Thankifi.Common.Importer.Abstractions.Options
{
    public class ImportOptions
    {
        public static readonly string Section = "Import"; 
        public ImportOptions(string source)
        {
            Source = new Uri(source) ?? throw new ArgumentException("Dataset source is not a valid url");
        }

        public Uri Source { get; }
    }
    
}