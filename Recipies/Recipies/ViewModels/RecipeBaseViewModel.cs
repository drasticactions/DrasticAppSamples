// <copyright file="RecipeBaseViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Recipies.ViewModels
{
    public class RecipeBaseViewModel : BaseViewModel
    {
        public RecipeBaseViewModel(IServiceProvider services)
            : base(services)
        {
            this.Client = services.GetService(typeof(IRecipiesClient)) as IRecipiesClient ?? throw new NullReferenceException(nameof(IRecipiesClient));
        }

        internal IRecipiesClient Client { get; }
    }
}
