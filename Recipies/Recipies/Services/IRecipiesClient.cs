// <copyright file="IRecipiesClient.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Recipies.Services
{
    /// <summary>
    /// Access the recipies API.
    /// </summary>
    public interface IRecipiesClient
    {
        /// <summary>
        /// Query the recipe endpoint for recipe data, based on the given search query.
        /// </summary>
        /// <param name="query">Query parameter.</param>
        /// <returns><see cref="RecipeQuery"/>.</returns>
        RecipeQuery QueryRecipeDataAsync(SearchQuery query);
    }
}
