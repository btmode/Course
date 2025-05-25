using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using PullCourse.Hubs;
using PullCourse.Service;

var builder = WebApplication.CreateBuilder(args);

var connString = "Host=localhost;Username=postgres;Database=Course;Password=postgres";


builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton(new CourseService(connString));

var app = builder.Build();


var scope = app.Services.CreateScope();
var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<CurrencyHub>>();

Task.Run(async () =>
{
    using var conn = new Npgsql.NpgsqlConnection(connString);
    conn.Open();

    Console.WriteLine("<<<<<< Connected to PostgreSQL >>>>>>");

    using var listen = new Npgsql.NpgsqlCommand("LISTEN currency_update;", conn);
    listen.ExecuteNonQuery();

    conn.Notification += async (o, e) => 
    {
        Console.WriteLine($"ЛОГИРОВАНИЕ: {e.Payload}"); 
        try {
            await hubContext.Clients.Group("tlt").SendAsync("ReceiveUpdate", e.Payload);
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    };

    while (true)
    {
        conn.Wait(); 
    }
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CurrencyHub>("/currencyHub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboard}/{action=Index}/{id?}");
});

app.Run();