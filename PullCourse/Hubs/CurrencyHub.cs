using Microsoft.AspNetCore.SignalR;

namespace PullCourse.Hubs;

public class CurrencyHub : Hub
{
    public async Task JoinCityGroup(string city)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, city);
        Console.WriteLine($"Client joined city group: {city}");
    }
}