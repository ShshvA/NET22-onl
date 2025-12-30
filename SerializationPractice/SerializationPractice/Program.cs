using System;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string storagePath = "../../../fileStorage";
            string fullStoragePath = Path.GetFullPath(storagePath);
            string extension = "json";
            string filePath = "";

            try
            {
                filePath = GetFilePath(fullStoragePath, extension);
                SquadClass squad = LoadSquadFromJson(filePath);

                Console.WriteLine("Squad после парсинга json файла.\n");
                squad.GetInfo();

                Console.WriteLine("\n\n Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();

                string xmlPath = Path.Combine(fullStoragePath, squad.SquadName + ".xml");

                if( SaveSquadToXml(xmlPath, squad))
                {
                    SquadClass squadXml = LoadSquadFromXml(xmlPath);

                    Console.WriteLine("Squad после парсинга xml файла.\n");
                    squadXml.GetInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:\n\t{ex.Message}");
            }

            Console.WriteLine();
        }

        public static string GetFilePath(string directoryPath, string extension)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Директория не найдена: {directoryPath}");
            }

            if (!Directory.EnumerateFiles(directoryPath).Any())
            {
                throw new Exception($"Директория пустая: {directoryPath}");
            }

            string searchPattern = "*" + (extension.StartsWith(".") ? extension : "." + extension);
            var files = Directory.EnumerateFiles(directoryPath, searchPattern);
            if (!files.Any())
            {
                throw new Exception($"В директории нет файлов '{(extension.StartsWith(".") ? extension : "." + extension)}' формата.");
            }
            else if (files.Count() > 1)
            {
                throw new Exception($"В директории более одного файла '{(extension.StartsWith(".") ? extension : "." + extension)}' формата.");
            }
            else
            {
                return files.First();
            }
        }

        public static SquadClass LoadSquadFromJson(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл не найден: {filePath}");
                }

                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    SquadClass squad = JsonSerializer.Deserialize<SquadClass>(stream, options);

                    if (squad == null)
                    {
                        throw new JsonException("Не удалось десериализовать JSON");
                    }

                    return squad;
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка JSON: {ex.Message}");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                throw;
            }
        }

        public static bool SaveSquadToXml(string filePath, SquadClass squad)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SquadClass));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    serializer.Serialize(stream, squad, ns);

                    return true;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                throw;
            }
        }

        public static SquadClass LoadSquadFromXml(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл не найден: {filePath}");
                }

                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SquadClass));

                    SquadClass squad = (SquadClass)serializer.Deserialize(stream);

                    return squad;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                throw;
            }
        }
    }
}
