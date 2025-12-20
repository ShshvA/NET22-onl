namespace ExceptionsPractice;

public class RegistrationClass
{
    public static string Login { get; private set; }
    public static string Password { get; private set; }

    public RegistrationClass(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public static bool RegisterUser(string login, string password, string confirmPassword)
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

        new RegistrationClass(login, password);
        return true;
    }

    public static string GetData()
    {
        return $"\tЛогин: {Login}\n" +
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
