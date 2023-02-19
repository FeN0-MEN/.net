using System;
using System.Collections;
using System.Collections.Generic;

namespace Zoo
{
    public class  Animals // Информация о животном (Имя, род, возраст, количество)
    {
        public string AnimalName { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }

        public Animals(string animalName, string type, int age, int price)
        {
            AnimalName = animalName;
            Type = type;
            Age = age;
            Price = price;
        }
        
        public override string ToString()
        {
            return $"Имя животного: {AnimalName}, Род животного: {Type}, Возраст: {Age}, Цена просмотра животного: {Price}";
        }

        
    }
}