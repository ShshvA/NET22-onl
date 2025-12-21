namespace ExceptionsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RegistrationClass> users = new List<RegistrationClass>();

            Register(users);
            Register(users);

            Console.WriteLine("Данные пользователей:");
            foreach (var user in users)
            {
                Console.WriteLine($"Пользователь {user.Id}:\n" +
                    $"{user.GetData()}\n");
            }
        }

        static void Register(List<RegistrationClass> users)
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
                    (RegistrationClass user, bool result) = RegistrationClass.RegisterUser(login, password, confirmPasword);
                    if (result)
                    {
                        Console.WriteLine($"\nПользователь успешно введен: \n{user.GetData()}");
                        users.Add(user);
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
