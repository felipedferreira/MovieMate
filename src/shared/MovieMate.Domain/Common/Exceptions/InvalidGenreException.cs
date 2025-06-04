namespace MovieMate.Application.Abstractions.Exceptions
{
    [Serializable]
    public class InvalidGenreException : Exception
    {
        public IEnumerable<Guid> InvalidGenreIds { get; private set; }
        public InvalidGenreException(IEnumerable<Guid> invalidGenreIds) : base("The genre is invalid or does not exist.")
        {
            InvalidGenreIds = invalidGenreIds;
        }
    }
}
