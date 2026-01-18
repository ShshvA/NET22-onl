using GoodsWarehouse.Interfaces;
using GoodsWarehouse.Models;
using System.Text.Json;

namespace GoodsWarehouse.Services
{
    public class UserService: IUserService
    {
        private readonly string _filePath;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private List<User> _users;

        public UserService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _filePath = "users.json";
            _httpContextAccessor = httpContextAccessor;
            _users = ReadUsersFromFile();
        }

        private List<User> ReadUsersFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
                }
                else
                {
                    return new List<User>();
                }
            }
            catch (Exception)
            {
               return new List<User>();
            }
        }

        private void SaveUsersToFile(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_filePath, json);
        }

        public bool Register(User user)
        {
            if (_users.Any(u => u.Username == user.Username))
            {
                return false;
            }

            _users.Add(user);
            SaveUsersToFile(_users);

            Login(user.Username, user.Password);
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Username", user.Username);
                _httpContextAccessor.HttpContext.Session.SetString("IsAuthenticated", "true");
                return true;
            }

            return false;
        }

        public bool UserExists(string username)
        {
            return _users.Any(u => u.Username == username);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("IsAuthenticated") == "true";
        }

        public string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("Username");
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Username");
            _httpContextAccessor.HttpContext.Session.Remove("IsAuthenticated");
        }
    }
}
