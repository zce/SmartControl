
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

namespace SmartControl.Hubs
{
    public class ControlHub : Hub
    {
        public static IList<ClientInfo> Connections = new List<ClientInfo>();

        public void Login(string token)
        {
            Connections.Add(new ClientInfo { Token = token, ConnectionId = Context.ConnectionId });
        }

        public void ChangeView(string token, string hash)
        {
            var tempConnections = Connections.Where(c => c.Token == token);
            var clients = Clients.Clients(tempConnections.Select(c => c.ConnectionId).ToList());
            clients.ChangeView(hash);
        }
    }
    public class ClientInfo
    {
        public string Token { get; set; }
        public string ConnectionId { get; set; }
    }
}
