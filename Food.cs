using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Feeding
    {
        public string Food { get; set; }
        public Feeding(string food) => Food = food;
    }
    public class Feeding_Lunch : Feeding
    {
        public Feeding_Lunch(string food) : base(food) { }
    }
    public interface IFeeding<in T> where T : class
    {
        void Feed(T food);
    }

    public class Food<identifier> : IFeeding<Feeding>
        where identifier : notnull
    {
        public identifier ID { get; set; } // Идентификатор - номер ИД, либо название корма
        public String Kind { get; set; } // Вид - Мясо, овощ, фрукт
        public String Title { get; set; } // Название - Рулька, Картофель, Банан
        public double Callories { get; set; } // Каллории - 200, 150, 80

        public Food(identifier id, string kind, string title, short callories)
        {
            ID = id;
            Kind = kind;
            Title = title;
            Callories = callories;
        }

        // Демонстрация контрвариативности
        public void Feed(Feeding food)
        {
            Console.WriteLine($"Животное поело {food.Food}");
        }

        public void Print()
        {
            Console.WriteLine($"ИД: {ID}, Тип: {Kind}, Название: {Title}, Каллории: {Callories}");
        }
    }
}
