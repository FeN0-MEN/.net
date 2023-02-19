using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Check : ISnPtoString<string> // Чек просмотра
    {
        private readonly Logger _logger = new Logger();
        public List<string> AnimalNames { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Price { get; set; }
        public DateTime DateAndTimeNow { get; set; }
        
        public Check(List<string> animalName, string surname, string name, string patronymic, List<int> price)
        {
            AnimalNames = animalName;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Price = price.Sum();
            DateAndTimeNow = DateTime.Now;
            _logger.Notify += LoggerMethods.LogInFile;
            _logger.Notify += LoggerMethods.LogInConsole;
            StringBuilder newCheck = new StringBuilder();
            newCheck.AppendLine("\n----------------------------");
            newCheck.Append("Животные к просмотру: ");
            foreach (var str in AnimalNames)
            {
                newCheck.Append(str + " ");
            }
            newCheck.AppendLine();
            newCheck.AppendLine($"Итоговая стоимость просмотра: {Price}");
            newCheck.AppendLine($"ФИО работника зоопарка: {SnPtoString()}");
            newCheck.AppendLine($"Дата и время посещения: {DateAndTimeNow}");
            newCheck.AppendLine("----------------------------");
            
            _logger.OnNotify("Создан новый чек с данными:" +
                                    $"{newCheck}"
                                    );
            _logger.Notify -= LoggerMethods.LogInFile;
            _logger.Notify -= LoggerMethods.LogInConsole;
        }
        
        public override string ToString()
        {
            StringBuilder newCheck = new StringBuilder();
            newCheck.AppendLine("\n----------------------------");
            newCheck.Append("Животные к просмотру: ");
            foreach (var str in AnimalNames)
            {
                newCheck.Append(str + " ");
            }
            newCheck.AppendLine();
            newCheck.AppendLine($"Итоговая стоимость просмотра: {Price}");
            newCheck.AppendLine($"ФИО работника зоопарка: {SnPtoString()}");
            newCheck.AppendLine($"Дата и время посещения: {DateAndTimeNow}");
            newCheck.AppendLine("----------------------------");
            return newCheck.ToString();
        }

        public string SnPtoString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}