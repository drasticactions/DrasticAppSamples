// <copyright file="SearchQuery.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>


namespace Recipies.Models
{
    public class SearchQuery
    {

        public SearchQuery(string word)
        {
            this.Type = SearchQueryType.Word;
            this.SearchWord = word;
        }

        public SearchQuery(MealType type)
        {
            if (type == MealType.Unknown)
            {
                throw new ArgumentException(nameof(type));
            }

            this.Type = SearchQueryType.Meal;
            this.Meal = type;
        }

        public enum SearchQueryType
        {
            Meal,
            Word
        }

        public enum MealType
        {
            Unknown,
            Breakfast,
            Lunch,
            Dinner,
            Snack,
        }

        public SearchQueryType Type { get; }

        public MealType Meal { get; }

        public string? SearchWord { get; }
    }
}
