using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public abstract class Employees // Информация о работнике (фамилия, имя, отчество, заработная плата)
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Salary { get; set; }
        //public abstract string Post { get; set; }
        public Employees(string surname, string name, string patronymic, int salary)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Salary = salary;
        }
        public abstract void Greetings();
    }
    
    class Cashier : Employees
    {
        public Cashier(string surname, string name, string patronymic, int salary) 
            : base(surname, name, patronymic, salary) { }
        public string Post { get; set; } = "Продавец билетов";
        public override void Greetings()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic} ({Post}):\nКаких животных хотите посмотреть?");
        }
        public void NotifyOrder<T>(T order) where T : List<string> // Ограничение при обобщении
        {
            StringBuilder newOrder = new StringBuilder();
            foreach (var str in order)
            {
                newOrder.Append(str + " ");
            }
            
            Console.WriteLine($"Пользователь хочет посмотреть на {newOrder}");
        }
    }

    class Guide : Employees
    {
        public Guide(string surname, string name, string patronymic, int salary) 
            : base(surname, name, patronymic, salary) { }
        public string Post { get; set; } = "Проводник по зоопарку";
        public override void Greetings()
        {
            Console.WriteLine($"{Surname} {Name} {Patronymic} ({Post}):\nЗдесь можно посмотреть на животное");
        }
    }
}