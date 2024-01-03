namespace SistemaPrayaga.Domain
{
    public class SistemaPrayagaException : Exception
    {
        public SistemaPrayagaException()
        { }

        public SistemaPrayagaException(string message)
            : base(message)
        { }

        public SistemaPrayagaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}