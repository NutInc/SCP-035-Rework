using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace SCP_035_Rework
{
    public class Config : IConfig
    {
        [Description("The maximum amount of SCP-035s there can be in a given round.")]
        public int Max035Count = 2;

        [Description("The % chance of an item being picked up being SCP-035.")]
        public float Scp035PickupChance = 5f;

        [Description("The health that SCP-035 will have")]
        public float Scp035Health { get; set; } = 500f;

        public int RotateInterval { get; set; } = 120;

        [Description("The visual effect that will be applied to the player who picks up SCP-035.")]
        public EffectType CorrosionEffectType { get; set; } = EffectType.Corroding;

        [Description("How much health should be deducted every second.")]
        public float DecayRate { get; set; } = 0.5f;

        [Description("How much the decay rate will be multiplied by.")]
        public float DecayMultiplier { get; set; } = 1f;

        [Description("How often should the DecayRate be multiplied by the DecayMultiplier?")]
        public float DecayMultiplicationInterval { get; set; } = 10f;

        [Description("The message that is sent to players when picking up SCP-035.")]
        public string PickupMessage { get; set; } = "You have picked up SCP-035 and have become an SCP!";

        [Description("The list of items that can be turned in to an SCP-035;")]
        public List<ItemType> Items { get; set; } = new List<ItemType>
        {
            ItemType.Coin,
            ItemType.Flashlight,
            ItemType.Radio,
            ItemType.MicroHID,
            ItemType.ArmorCombat,
            ItemType.ArmorHeavy,
            ItemType.ArmorLight,
            ItemType.GrenadeFlash,
            ItemType.GrenadeHE
        };

        [Description("Should the plugin be loaded on server start?")]
        public bool IsEnabled { get; set; } = true;
    }
}