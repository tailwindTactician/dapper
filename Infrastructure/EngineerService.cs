using Dapper;
using Domain;

namespace Infrastructure;

public class EngineerService
{
    private readonly DbContext _context;
    public EngineerService()
    {
        _context = new DbContext();
    }

    public void AddEngineer(Engineer engineer)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"insert into engineers(full_name, specialty) values('{engineer.FullName}', '{engineer.Specialty}')";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Ошибка при добавлении инженера!");
            return;
        }
        Console.WriteLine(" Инженер успешно добавлен!");
    }

    public void DeleteEngineer(int id)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"delete from engineers where id={id}";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Инженер не найден!");
            return;
        }
        Console.WriteLine(" Инженер удалён!");
    }

    public List<Engineer> ShowEngineers()
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = "select * from engineers";
        var engineers = conn.Query<Engineer>(query).ToList();
        return engineers;
    }

    public void UpdateEngineer(Engineer engineer)
    {
        using var conn = _context.GetConnection();
        conn.Open();

        string query = $"update engineers set full_name='{engineer.FullName}', specialty='{engineer.Specialty}' where id={engineer.Id}";
        int n = conn.Execute(query);
        if (n == 0)
        {
            Console.WriteLine(" Инженер не найден!");
            return;
        }
        Console.WriteLine("Инженер обновлён!");
    }
}
