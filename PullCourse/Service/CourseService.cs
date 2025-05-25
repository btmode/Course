using Dapper;
using Npgsql;
using PullCourse.Models;

namespace PullCourse.Service;

public class CourseService
{
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
}