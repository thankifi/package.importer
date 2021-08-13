using System;
using System.Collections.Generic;

namespace Thankifi.Common.Importer.Abstractions
{
    /// <summary>
    /// Import dataset.
    /// </summary>
    public record Dataset
    {
        public List<Category>? Categories { get; set; }
        public List<Language>? Languages { get; set; }
        public List<Gratitude>? Gratitudes { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public record Category
        {
            public Guid Id { get; set; }
            public string Slug { get; set; }
        }

        /// <summary>
        /// Language
        /// </summary>
        public record Language
        {
            public Guid Id { get; set; }
            public string Code { get; set; }
        }

        /// <summary>
        /// Gratitude
        /// </summary>
        public record Gratitude
        {
            public Guid Id { get; set; }
            public string Language { get; set; }
            public string Text { get; set; }
            public List<string> Categories { get; set; }
        }
    }
}