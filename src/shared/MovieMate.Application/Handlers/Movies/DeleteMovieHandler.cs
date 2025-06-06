using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Domain.MovieAggregate;

namespace MovieMate.Application.Handlers.Movies
{
    internal class DeleteMovieHandler : IDeleteMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _ = await _movieRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {id}");

            await _movieRepository.DeleteByIdAsync(id, cancellationToken);

            // delete relationships for movie generes - DeleteByMovieIdAsync
        }
    }
}
