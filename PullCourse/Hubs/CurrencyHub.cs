using Microsoft.AspNetCore.SignalR;

namespace PullCourse.Hubs;

public class CurrencyHub : Hub
{
<<<<<<< HEAD
    public async Task JoinCityGroup(string city)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, city);
        Console.WriteLine($"Client joined city group: {city}");
=======
    public async Task SendUpdate(string message)
    {
        await Clients.All.SendAsync("ReceiveUpdate", message);
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
    }
}