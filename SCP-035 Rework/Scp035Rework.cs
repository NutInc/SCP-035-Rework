using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP_035_Rework
{
    public class Scp035Plugin : Plugin<Config>
    {
        public static Scp035Plugin Singleton;

        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "SCP-035";
        public override string Prefix { get; } = "scp_035";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0, 0);
        public override PluginPriority Priority => PluginPriority.Low;

        public override void OnEnabled()
        {
            Singleton = this;

            Server.RoundStarted += EventHandlers.OnRoundStart;
            Server.RoundEnded += EventHandlers.OnRoundEnd;
            Player.ChangingRole += EventHandlers.OnChangingRole;
            Player.PickingUpItem += EventHandlers.OnPickingUpItem;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;

            Server.RoundStarted -= EventHandlers.OnRoundStart;
            Server.RoundEnded -= EventHandlers.OnRoundEnd;
            Player.ChangingRole -= EventHandlers.OnChangingRole;
            Player.PickingUpItem -= EventHandlers.OnPickingUpItem;

            base.OnDisabled();
        }
    }
}