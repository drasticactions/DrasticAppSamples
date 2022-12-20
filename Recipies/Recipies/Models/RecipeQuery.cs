// <copyright file="RecipeQuery.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Recipies.Models
{
    public class RecipeQuery
    {
        [JsonPropertyName("q")]
        public string? QueryText { get; set; }

        [JsonPropertyName("from")]
        public int StartIndex { get; set; }

        [JsonPropertyName("to")]
        public int EndIndex { get; set; }

        [JsonPropertyName("hits")]
        public Hit[]? Hits { get; set; }
    }
}
