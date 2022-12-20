// <copyright file="DebugPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Tools;
using Microsoft.UI.Xaml.Controls;
using Recipies.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Recipies.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DebugPage : BasePage
    {

        public DebugPage()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = Ioc.Default.ResolveWith<RecipeQueryViewModel>();
        }

        internal Recipies.ViewModels.RecipeQueryViewModel viewModel { get; }
    }
}
