using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace SCP_035_Rework.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Spawn035 : ICommand
    {
        public string Command { get; } = "Spawn035";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Spawns the command sender as 035";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("035.spawn"))
            {
                response = "You do not have permission";
                return false;
            }

            
            EventHandlers.SetAs035(Player.Get(sender));
            response = "Success!";
            return true;
        }
    }
}