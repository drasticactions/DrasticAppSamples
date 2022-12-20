// <copyright file="RecipeQueryViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using static Recipies.Models.SearchQuery;

namespace Recipies.ViewModels
{
    public class RecipeQueryViewModel : RecipeBaseViewModel
    {
        private SearchQuery? query;
        private RecipeQuery? recipeQuery;

        public RecipeQueryViewModel(IServiceProvider services, SearchQuery? query = null)
            : base(services)
        {
            this.query = query;
            this.SearchViaMealType = new AsyncCommand<MealType>(async (type) => { }, null, this.ErrorHandler);
            this.SearchViaString = new AsyncCommand<string>(async (query) => { }, null, this.ErrorHandler);
        }

        public AsyncCommand<MealType> SearchViaMealType { get; }

        public AsyncCommand<string> SearchViaString { get; }

        public ObservableCollection<Recipe> Recipes { get; } = new ObservableCollection<Recipe>();

        public override async Task OnLoad()
        {
            await base.OnLoad();
            await this.PerformBusyAsyncTask(this.LoadTempData, "Loading Temp Data");
        }

        private async Task LoadTempData()
        {
            this.Recipes.Clear();
            this.recipeQuery = this.Client.QueryRecipeDataAsync(new SearchQuery(MealType.Breakfast))!;
            foreach (var item in this.recipeQuery.Hits!)
            {
                this.Recipes.Add(item.Recipe!);
            }
        }
    }
}
