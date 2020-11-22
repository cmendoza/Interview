using System;

namespace Interview.Api.Utils
{
    public class Envelope<T>
    {
        public T        Result        { get; }
        public string   ErrorMessage  { get; }
        public DateTime TimeGenerated { get; }
        public bool     HasError => ErrorMessage != null;

        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public class Envelope : Envelope<string>
    {
        protected Envelope(string errorMessage) : base(null, errorMessage) { }

        public static Envelope<T> Ok<T>(T result) => new Envelope<T>(result, null);

        public static Envelope Ok() => new Envelope(null);

        public static Envelope Error(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage)) throw new ArgumentNullException(nameof(errorMessage));

            return new Envelope(errorMessage);
        }
    }
}
