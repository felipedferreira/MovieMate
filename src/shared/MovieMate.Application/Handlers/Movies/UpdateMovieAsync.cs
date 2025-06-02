using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Extensions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Models;
using MovieMate.Application.Abstractions.Services;

namespace MovieMate.Application.Handlers.Movies
{
    public class UpdateMovieAsync : IUpdateMovieAsync
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieAsync(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            var foundMovie = await _movieRepository.GetByIdAsync(movie.Id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {movie.Id}");
            await _movieRepository.UpdateAsync(movie.ToDomainModel(), cancellationToken);
        }
    }
}
