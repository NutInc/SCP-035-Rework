using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace SCP_035_Rework
{
    public static class EventHandlers
    {
        private static Config _config = Scp035Plugin.Singleton.Config;
        private static Dictionary<Player, int> PlayerDecayRates = new Dictionary<Player, int>();

        public static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            
        }

        public IEnumerator<float> EffectCoroutine(Player player)
        {
            
        }
    }
}