// <copyright file="MockRecipiesClient.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Bogus;

namespace Recipies.Services
{
    /// <summary>
    /// Mock Recipies client. Returns fake data.
    /// </summary>
    public class MockRecipiesClient : IRecipiesClient
    {
        private Faker<RecipeQuery> fakeRecipeQuery;
        private Faker<Hit> fakeHit;
        private Faker<Recipe> fakeRecipe;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockRecipiesClient"/> class.
        /// </summary>
        public MockRecipiesClient()
        {
            this.fakeRecipe = new Faker<Recipe>()
                .RuleFor(r => r.RecipeName, f => f.Lorem.Word())
                .RuleFor(r => r.Ingredients, f => f.Make<string>(10, h => f.Lorem.Sentence()))
                .RuleFor(r => r.ImageUrl, f => f.Image.LoremFlickrUrl(keywords: "food"))
                .RuleFor(r => r.RecipeUrl, f => f.Lorem.Word());

            this.fakeHit = new Faker<Hit>()
                .RuleFor(h => h.Recipe, f => this.fakeRecipe.Generate())
                .RuleFor(h => h.Id, f => f.Random.Int());

            this.fakeRecipeQuery = new Faker<RecipeQuery>()
                .RuleFor(r => r.QueryText, f => f.Lorem.Word())
                .RuleFor(r => r.StartIndex, f => f.Random.Int())
                .RuleFor(r => r.EndIndex, f => f.Random.Int())
                .RuleFor(r => r.Hits, f => this.fakeHit.GenerateBetween(50, 100).ToArray());
        }

        /// <inheritdoc/>
        public RecipeQuery QueryRecipeDataAsync(SearchQuery query)
        {
            return this.fakeRecipeQuery.Generate();
        }
    }
}
