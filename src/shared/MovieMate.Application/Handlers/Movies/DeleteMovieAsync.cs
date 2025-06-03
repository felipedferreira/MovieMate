using MovieMate.Application.Abstractions.Exceptions;
using MovieMate.Application.Abstractions.Handlers.Movies;
using MovieMate.Application.Abstractions.Services.DataAccess;

namespace MovieMate.Application.Handlers.Movies
{
    internal class DeleteMovieAsync : IDeleteMovieAsync
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteMovieAsync(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await _movieRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Unable to find movie by id: {id}");

            await _movieRepository.DeleteByIdAsync(id, cancellationToken);
        }
    }
}
