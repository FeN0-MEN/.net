#nullable enable
using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        delegate void Time();
        static void Main(string[] args)
        {
            Food<int> Steak = new Food<int>(50, "Мясо", "Стейк", 230);

            // Делегаты 

            Time Now = Time;
            void Time() => Console.WriteLine($"Сейчас {DateTime.Now}");
            Now();

            Action Print_Steack = () => Steak.Print();
            Print_Steack();

            // Дженерики

            IFeeding<Feeding> Fish = new Food<int>(2, "Мясо", "Рыба", 220);
            Fish.Feed(new Feeding_Lunch("на ужин Рыбу"));

            IFeeding<Feeding> Chicken = new Food<int>(3, "Мясо", "Курица", 190);
            IFeeding<Feeding_Lunch> Feed = Chicken;
            Feed.Feed(new Feeding_Lunch("на ужин Курицу"));

            // Объект класса для сериализации и десериализации в JSON
            Json<Dictionary<string, Animals>> animalDictionaryJson = new Json<Dictionary<string, Animals>>();
            
            // Словарь со списком животных в зоопарке
            Dictionary<string, Animals> animalsList = animalDictionaryJson.DeserializeDictionary(Config.JSON_PATH);
            
            Console.WriteLine("Животные в зоопарке: ");
            foreach (var item in animalsList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Введите 1, чтобы добавить животное в зоопарк");
            string? addAnimal = Console.ReadLine();
            if (addAnimal == "1")
            {
                Console.WriteLine("Введите имя животного");
                string? animalName = Console.ReadLine();
                
                Console.WriteLine("Введите род животного");
                string? animalType = Console.ReadLine();
                    
                Console.WriteLine("Введите возраст животного");
                int animalAge = Convert.ToInt32(Console.ReadLine());
                if (animalAge < 0)
                {
                    throw new AnimalException(Config.ERROR_TXT);
                }
                    
                Console.WriteLine("Введите цену просмотра животного");
                int animalPrice = Convert.ToInt32(Console.ReadLine());
                if (animalPrice < 0)
                {
                    throw new AnimalException(Config.ERROR_TXT);
                }

                try
                {
                    animalsList.Add(animalName ?? throw new InvalidOperationException(), 
                        new Animals(animalName, animalType, animalAge, animalPrice));
                    // Сохранение меню в JSON
                    animalDictionaryJson.SerializeDictionary(animalsList, Config.JSON_PATH);
                    Console.WriteLine("Обновленный список животных");
                    foreach (var item in animalsList)
                    {
                        Console.WriteLine(item);
                    }
                }
                catch 
                {
                    Console.WriteLine("Такие животные уже есть в списке");
                }
            }
            
            Cashier cashier = new Cashier("Петрова", "Лариса", "Ивановна", 12500); 
            cashier.Greetings(); 
            
            List<string> orderListNow = new List<string>(); // Список текущих просмотров
            List<int> pricesNow = new List<int>(); // Цены текущих просмотров
            
            // Задание 2 + Задание 4 - показ логирования
            CustomList<Animals> myCustomList = new CustomList<Animals>(); // Создание списка просмотра
            myCustomList.Add(animalsList["Як"]);
            myCustomList.Add(animalsList["Тигровая акула"]);
            myCustomList.Add(animalsList["Сурикат"]);
            myCustomList.Add(animalsList["Петух"]);
            
            foreach (var product in myCustomList)
            {
                orderListNow.Add(product.AnimalName); ;
                pricesNow.Add(product.Price);
            }
            
            cashier.NotifyOrder(orderListNow); // Сообщение о новом просмотре
            
            // Создание чека с заказом (Задание 4 - показ логирования)
            Check check = new Check(orderListNow, cashier.Surname, cashier.Name, cashier.Patronymic, pricesNow); 
            Console.WriteLine(check);
            
            myCustomList.Clear();
            
        }
        public static void Display(CageCollection cgList)
        {
            Console.WriteLine("\nШирина\tДлина\tВысота\tТип\t\tХэш-код");
            foreach (Cage cg in cgList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}",
                    cg.Height.ToString(), cg.Length.ToString(),
                    cg.Width.ToString(), cg.Type.ToString(), cg.GetHashCode().ToString());
            }
        }
    }
}