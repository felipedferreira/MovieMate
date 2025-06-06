﻿namespace MovieMate.API
{
    public static class ApiEndpoints
    {
        public const string ApiBase = "api";
        public static class MovieApiEndpoints
        {
            public const string Base = $"{ApiBase}/movies";

            public const string Create = Base;
            public const string GetAll = Base;
            public const string GetById = $"{Base}/{{id:guid}}";
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class GenreApiEndpoints
        {
            public const string Base = $"{ApiBase}/genres";
            public const string Create = Base;
            public const string GetAll = Base;
        }
    }
}
