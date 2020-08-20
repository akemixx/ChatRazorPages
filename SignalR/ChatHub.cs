using ChatRazorPages.Data;
using ChatRazorPages.ModelsDB;
using ChatRazorPages.SignalR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatRazorPages
{
    public class ChatHub : Hub<IChatClient>
    {
        readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessageToAll(string text)
        {
            var message = new Message()
            {
                Text = text,
                Sender = this.Context.User.Identity.Name,
                SendingDateTime = DateTime.Now
            };
            _context.Message.Add(message);
            _context.SaveChanges();

            await Clients.All.ReceiveMessage(message.Text, message.Sender, message.SendingDateTime.ToString("HH:mm:ss"));
        }
    }
}