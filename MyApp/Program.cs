﻿using Domain;
using Infrastructure;

var engineerService = new EngineerService();
var carService = new CarService();

while (true)
{
    Console.WriteLine("\n=== МЕНЮ ===");
    Console.WriteLine("1. Добавить инженера");
    Console.WriteLine("2. Добавить машину");
    Console.WriteLine("3. Показать инженеров");
    Console.WriteLine("4. Показать машины");
    Console.WriteLine("5. Обновить инженера");
    Console.WriteLine("6. Обновить машину");
    Console.WriteLine("7. Удалить инженера");
    Console.WriteLine("8. Удалить машину");
    Console.WriteLine("0. Выход");
    Console.Write("Выбери: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            var e = new Engineer();
            Console.Write("Имя инженера: ");
            e.FullName = Console.ReadLine();
            Console.Write("Специальность: ");
            e.Specialty = Console.ReadLine();
            engineerService.AddEngineer(e);
            break;

        case "2":
            var c = new Car();
            Console.Write("Марка: ");
            c.Brand = Console.ReadLine();
            Console.Write("Модель: ");
            c.Model = Console.ReadLine();
            Console.Write("Год: ");
            c.Year = int.Parse(Console.ReadLine());
            Console.Write("Цена: ");
            c.Price = decimal.Parse(Console.ReadLine());
            Console.Write("ID инженера: ");
            c.EngineerId = int.Parse(Console.ReadLine());
            carService.AddCar(c);
            break;

        case "3":
            var engineers = engineerService.ShowEngineers();
            foreach (var eng in engineers)
                Console.WriteLine($"{eng.Id}. {eng.FullName} — {eng.Specialty}");
            break;

        case "4":
            var cars = carService.ShowCars();
            foreach (var car in cars)
                Console.WriteLine($"{car.Id}. {car.Brand} {car.Model} ({car.Year}) - {car.Price}$ / Инженер ID: {car.EngineerId}");
            break;

        case "5":
            var engToUpdate = new Engineer();
            Console.Write("ID инженера: ");
            engToUpdate.Id = int.Parse(Console.ReadLine());
            Console.Write("Новое имя: ");
            engToUpdate.FullName = Console.ReadLine();
            Console.Write("Новая специальность: ");
            engToUpdate.Specialty = Console.ReadLine();
            engineerService.UpdateEngineer(engToUpdate);
            break;

        case "6":
            var carToUpdate = new Car();
            Console.Write("ID машины: ");
            carToUpdate.Id = int.Parse(Console.ReadLine());
            Console.Write("Новая марка: ");
            carToUpdate.Brand = Console.ReadLine();
            Console.Write("Новая модель: ");
            carToUpdate.Model = Console.ReadLine();
            Console.Write("Новый год: ");
            carToUpdate.Year = int.Parse(Console.ReadLine());
            Console.Write("Новая цена: ");
            carToUpdate.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Новый ID инженера: ");
            carToUpdate.EngineerId = int.Parse(Console.ReadLine());
            carService.UpdateCar(carToUpdate);
            break;

        case "7":
            Console.Write("ID инженера для удаления: ");
            engineerService.DeleteEngineer(int.Parse(Console.ReadLine()));
            break;

        case "8":
            Console.Write("ID машины для удаления: ");
            carService.DeleteCar(int.Parse(Console.ReadLine()));
            break;

        case "0": return;
    }
}
