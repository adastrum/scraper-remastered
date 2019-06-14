namespace Scraper.Api.Models
{
    public class Result<T>
        where T : class
    {
        public bool IsSuccess { get; }

        public T Value { get; }

        protected Result(bool success, T value)
        {
            IsSuccess = success;
            Value = value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value);
        }

        public static Result<T> Failure()
        {
            return new Result<T>(false, null);
        }
    }
}
