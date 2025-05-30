﻿using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services;
using MovieMate.Application.Abstractions.Extensions;
using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Handlers.Movies;

namespace MovieMate.Application.Handlers.Movies
{
    internal class GetMovieByIdAsync : IGetMovieByIdAsync
    {
        private readonly IMovieRepository _movieRepository;
        public GetMovieByIdAsync(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await _movieRepository.GetByIdAsync(id, cancellationToken) ?? throw new NotFoundException($"Movie with ID {id} not found.");
            return movie.ToApplicationModel();
        }
    }
}
