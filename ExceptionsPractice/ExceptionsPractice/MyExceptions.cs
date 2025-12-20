namespace ExceptionsPractice;

public class WrongLoginException : Exception
{
    public WrongLoginException()
    : base() { }
    public WrongLoginException(string message)
        : base(message) { }
}

public class WrongPasswordException : Exception
{
    public WrongPasswordException() { }
    public WrongPasswordException(string message)
        : base(message) { }
}