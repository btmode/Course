using Dapper;
using Npgsql;
using PullCourse.Models;

namespace PullCourse.Service;

public class CourseService
{
<<<<<<< HEAD
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

   
=======
    private readonly string _connStr;

    public CourseService(string connStr)
    {
        _connStr = connStr;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = @"
            SELECT DISTINCT ON (currency_code)
                currency_code AS CurrencyCode, 
                ROUND (buy_rate,2)  AS Buy, 
                ROUND (sell_rate,2) AS Sell 
            FROM currency_rates
            ORDER BY currency_code, updated_at DESC;
        ";
        return await conn.QueryAsync<Course>(sql);
    }
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
}