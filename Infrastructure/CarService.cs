using Dapper;
using Domain;

namespace Infrastructure;

public class CarService
{
    private readonly DbContext _context;
    public CarService()
    {
        _context = new DbContext();
    }

    public void AddCar(Car car)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"insert into cars(brand, model, year, price, engineer_id) values('{car.Brand}', '{car.Model}', {car.Year}, {car.Price}, {car.EngineerId})";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Ошибка при добавлении машины!");
            return;
        }
        Console.WriteLine(" Машина успешно добавлена!");
    }

    public void DeleteCar(int id)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"delete from cars where id={id}";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Машина не найдена!");
            return;
        }
        Console.WriteLine(" Машина удалена!");
    }

    public List<Car> ShowCars()
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = "select * from cars";
        var cars = conn.Query<Car>(query).ToList();
        return cars;
    }

    public void UpdateCar(Car car)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"update cars set brand='{car.Brand}', model='{car.Model}', year={car.Year}, price={car.Price}, engineer_id={car.EngineerId} where id={car.Id}";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Машина не найдена!");
            return;
        }
        Console.WriteLine(" Машина обновлена!");
    }
}
