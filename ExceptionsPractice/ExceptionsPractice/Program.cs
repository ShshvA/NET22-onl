namespace ExceptionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Ведите логин: ");
                string login = Console.ReadLine();
                Console.Write("Ведите пароль: ");
                string password = Console.ReadLine();
                Console.Write("Повторите пароль: ");
                string confirmPasword = Console.ReadLine();

                try
                {
                    if (RegistrationClass.RegisterUser(login, password, confirmPasword))
                    {
                        Console.WriteLine($"\nПользователь успешно введен: \n{RegistrationClass.GetData()}");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.Write("\nНажмите любую клавишу чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
