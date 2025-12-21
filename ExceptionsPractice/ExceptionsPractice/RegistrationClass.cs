namespace ExceptionsPractice;

public class RegistrationClass
{
    public string Login { get; private set; }
    public string Password { get; private set; }
    public int Id { get; private set; }

    private static int _userCount = 0;

    public RegistrationClass(string login, string password)
    {
        Login = login;
        Password = password;
        Id = ++_userCount;
    }

    public static (RegistrationClass, bool) RegisterUser(string login, string password, string confirmPassword)
    {
        if (login.Length >= 20)
        {
            throw new WrongLoginException("WrongLoginException: " +
                                        "Длина логина должна быть меньше 20 символов.");
        }

        if (IsSpaceDetected(login))
        {
            throw new WrongLoginException("WrongLoginException: " +
                                        "Логин не должен содержать пробелы.");
        }

        if (password.Length >= 20)
        {
            throw new WrongPasswordException("WrongPasswordException: " +
                                        "Длина пароля должна быть меньше 20 символов.");
        }

        if (IsSpaceDetected(password))
        {
            throw new WrongPasswordException("WrongPasswordException: " +
                                        "Пароль не должен содержать пробелы.");
        }

        if (!IsDigitDetected(password))
        {
            throw new WrongPasswordException("WrongPasswordException: " +
                                        "Пароль должен содержать хотябы 1 цифру.");
        }

        if (password != confirmPassword)
        {
            throw new WrongPasswordException("WrongPasswordException: " +
                                        "Пароли должны совпадать.");
        }

        return (new RegistrationClass(login, password), true);
    }

    public string GetData()
    {
        return $"\tID: {Id}\n" +
            $"\tЛогин: {Login}\n" +
            $"\tПароль: {Password}";
    }

    private static bool IsSpaceDetected(string str)
    {
        return str.Any(char.IsWhiteSpace);
    }

    private static bool IsDigitDetected(string str)
    {
        return str.Any(char.IsDigit);
    }
}
