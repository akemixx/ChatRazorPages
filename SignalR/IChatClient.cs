using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRazorPages.SignalR
{
    public interface IChatClient
    {
        Task ReceiveMessage(string text, string sender, string time);
    }
}
