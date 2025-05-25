using Dapper;
using Npgsql;
using PullCourse.Models;

namespace PullCourse.Service;

public class CourseService
{
    private readonly string? _connection;

    public CourseService(string connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync(string city)
    {
        var allowedCities = new[] { "tlt", "msk", "prm" };
        var actualCity = allowedCities.Contains(city?.ToLower()) ? city : "tlt";
    
        Console.WriteLine($"Запрашиваем данные для города: {actualCity}"); 
    
        using var conn = new NpgsqlConnection(_connection);
        var sql = @"
            SELECT DISTINCT ON (currency_code)
                currency_code as CurrencyCode, 
                ROUND(buy_rate,2) as Buy, 
                ROUND(sell_rate,2) as Sell, 
                city as City
            FROM currency_rates
            WHERE city = @city
            ORDER BY currency_code, updated_at DESC;";

        Console.WriteLine($"Выполняем SQL: {sql}"); 
    
        var result = await conn.QueryAsync<Course>(sql, new { city = actualCity });
    
        Console.WriteLine($"Получено {result.Count()} записей"); 
    
        return result;
    }

   
}