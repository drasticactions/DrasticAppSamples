// <copyright file="Hit.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Recipies.Models
{
    public class Hit
    {
        [JsonPropertyName("recipe")]
        public Recipe? Recipe { get; set; }

        public int Id { get; set; }
    }
}
