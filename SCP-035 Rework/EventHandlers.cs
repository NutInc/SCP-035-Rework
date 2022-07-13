using System;
using System.Collections.Generic;
using Assets._Scripts.Dissonance;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using MEC;

namespace SCP_035_Rework
{
    public static class EventHandlers
    {
        private static readonly Config _config = Scp035Plugin.Singleton.Config;
        private static Dictionary<Player, int> PlayerDecayRates = new Dictionary<Player, int>();
        private static Pickup _scpItem;
        private static Player _scp035;
        private static readonly Random _random = new Random();
        private static readonly List<CoroutineHandle> _coroutineHandles = new List<CoroutineHandle>();

        public static void OnRoundStart()
        {
            _coroutineHandles.Add(Timing.RunCoroutine(RotateScpItem()));
        }

        public static void OnRoundEnd(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines(_coroutineHandles.ToArray());
        }

        public static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            // If 035 is alive dont manage pickups
            if (_scp035 != null)
                return;

            // If item for some reason does not exist set a new item
            if (!Map.Pickups.Contains(_scpItem))
                ChangeScpItem();

            if (ev.Pickup == _scpItem) SetAs035(ev.Player);
        }

        public static void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player == _scp035) RemoveAs035(ev.Player);
        }

        private static IEnumerator<float> RotateScpItem()
        {
            while (true)
            {
                if (_scp035 == null)
                    ChangeScpItem();

                yield return Timing.WaitForSeconds(_config.RotateInterval);
            }
        }

        public static void SetAs035(Player ply)
        {
            ply.Broadcast(10, _config.PickupMessage);
            ply.Health = _config.Scp035Health;

            var dissonanceUserSetup = ply.GameObject.GetComponent<DissonanceUserSetup>();
            dissonanceUserSetup.EnableListening(TriggerType.Role, Assets._Scripts.Dissonance.RoleType.SCP);
            dissonanceUserSetup.EnableSpeaking(TriggerType.Role, Assets._Scripts.Dissonance.RoleType.SCP);
            dissonanceUserSetup.SCPChat = true;

            ply.CustomInfo = $"<color=red>{ply.Nickname}\nSCP-035</color>";
            ply.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Nickname;
            ply.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Role;
            ply.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.PowerStatus;
            ply.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.UnitName;
            _scp035 = ply;
            _scpItem = null;
        }

        private static void RemoveAs035(Player ply)
        {
            _scp035 = null;

            var dissonanceUserSetup = ply.GameObject.GetComponent<DissonanceUserSetup>();
            dissonanceUserSetup.DisableListening(TriggerType.Role, Assets._Scripts.Dissonance.RoleType.SCP);
            dissonanceUserSetup.DisableSpeaking(TriggerType.Role, Assets._Scripts.Dissonance.RoleType.SCP);
            dissonanceUserSetup.SCPChat = false;
        }

        private static void ChangeScpItem()
        {
            _scpItem = Map.Pickups[_random.Next(Map.Pickups.Count)];
            Log.Debug($"035 item has moved: {_scpItem.Type} {_scpItem.Position}");
        }
    }
}