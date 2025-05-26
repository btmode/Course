<<<<<<< HEAD
using System.Text.Json;
=======
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
using Microsoft.AspNetCore.SignalR;
using PullCourse.Hubs;
using PullCourse.Service;

var builder = WebApplication.CreateBuilder(args);

var connString = "Host=localhost;Username=postgres;Database=Course;Password=postgres";

<<<<<<< HEAD

=======
// Регистрация сервисов
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton(new CourseService(connString));

var app = builder.Build();

<<<<<<< HEAD

=======
// Слушаем pg_notify и шлём в SignalR
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
var scope = app.Services.CreateScope();
var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<CurrencyHub>>();

Task.Run(async () =>
{
    using var conn = new Npgsql.NpgsqlConnection(connString);
    conn.Open();

<<<<<<< HEAD
    Console.WriteLine("<<<<<< Connected to PostgreSQL >>>>>>");
=======
    Console.WriteLine("<<<<< Connected to PostgreSQL >>>>>>");
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa

    using var listen = new Npgsql.NpgsqlCommand("LISTEN currency_update;", conn);
    listen.ExecuteNonQuery();

<<<<<<< HEAD
    conn.Notification += async (o, e) => 
    {
        Console.WriteLine($"ЛОГИРОВАНИЕ: {e.Payload}"); 
        try {
            await hubContext.Clients.Group("tlt").SendAsync("ReceiveUpdate", e.Payload);
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
=======
    conn.Notification += async (o, e) =>
    {
        Console.WriteLine($"----- NOTIFY received: {e.Payload} -----");
        await hubContext.Clients.All.SendAsync("ReceiveUpdate", e.Payload);
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
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