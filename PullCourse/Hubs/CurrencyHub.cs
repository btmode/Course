using Microsoft.AspNetCore.SignalR;

namespace PullCourse.Hubs;

public class CurrencyHub : Hub
{
    public async Task SendUpdate(string message)
    {
        await Clients.All.SendAsync("ReceiveUpdate", message);
    }
}