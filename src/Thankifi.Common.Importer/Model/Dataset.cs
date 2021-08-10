using System;
using System.Collections.Generic;

namespace Thankifi.Common.Importer.Model
{
    public record Dataset
    {
        public List<Category> Categories { get; set; }
        public List<Gratitude> Gratitudes { get; set; }
        
        public record Gratitude
        {
            public Guid Id { get; set; }
            public string Language { get; set; }
            public string Text { get; set; }
            public List<string> Categories { get; set; }
        }

        public record Category
        {
            public Guid Id { get; set; }
            public string Slug { get; set; }
        }
    }
}