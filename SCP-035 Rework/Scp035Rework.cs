using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace SCP_035_Rework
{
    public class Scp035Plugin : Plugin<Config>
    {
        public static Scp035Plugin Singleton;
        
        public override string Author { get; } = "imskyyc @ Nut Inc";
        public override string Name { get; } = "035-Rework";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0, 0);
        public override PluginPriority Priority => PluginPriority.Low;

        public override void OnEnabled()
        {
            Singleton = this;

            Player.PickingUpItem += EventHandlers.OnPickingUpItem;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            
            Player.PickingUpItem -= EventHandlers.OnPickingUpItem;

            base.OnDisabled();
        }
    }
}