// <copyright file="RecipeQueryGridView.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Tools;
using Recipies.ViewModels;

namespace Recipies.WinUI
{
    public sealed partial class RecipeQueryGridView : BaseViewModelControl
    {
        public RecipeQueryGridView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = Ioc.Default.ResolveWith<RecipeQueryViewModel>();
        }

        internal Recipies.ViewModels.RecipeQueryViewModel viewModel { get; }
    }
}
