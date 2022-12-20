// <copyright file="Recipe.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Recipies.Models
{
    public class Recipe
    {
        [JsonPropertyName("label")]
        public string? RecipeName { get; set; }

        [JsonPropertyName("ingredientLines")]
        public string[]? Ingredients { get; set; }

        [JsonPropertyName("image")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("url")]
        public string? RecipeUrl { get; set; }
    }
}
