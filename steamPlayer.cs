using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
namespace steampunk
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class steamPlayer : ModPlayer
	{
		public bool clockworkShield;
		public bool bioworkMind;
		public int lifeCounter;
		public bool WolfPetItem;

		public override void ResetEffects() {
			clockworkShield = false;
			WolfPetItem = false;
			if (!bioworkMind) {
				lifeCounter = player.statLife;

			}
			bioworkMind = false;
		}

		// In MP, other clients need accurate information about your player or else bugs happen.
		// clientClone, SyncPlayer, and SendClientChanges, ensure that information is correct.
		// We only need to do this for data that is changed by code not executed by all clients, 
		// or data that needs to be shared while joining a world.
		// For example, examplePet doesn't need to be synced because all clients know that the player is wearing the ExamplePet item in an equipment slot. 
		// The examplePet bool is set for that player on every clients computer independently (via the Buff.Update), keeping that data in sync.
		// ExampleLifeFruits, however might be out of sync. For example, when joining a server, we need to share the exampleLifeFruits variable with all other clients.
		// In addition, in ExampleUI we have a button that toggles "Non-Stop Party". We need to sync this whenever it changes.

		public override void UpdateDead() {
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			if (bioworkMind)
			{
				player.controlQuickHeal = true;
				if (player.potionDelayTime <= 0)
                {
					if (lifeCounter <= 25)
					{
						player.QuickHeal();
					}

				}
			}
			if (clockworkShield)
			{
				player.AddBuff(BuffID.BrokenArmor, 180);
			}
		}
		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		{
			if (bioworkMind)
			{
				player.statDefense -= 10;
				player.pickSpeed += 0.80f;
				player.moveSpeed += 0.6f;
				player.maxRunSpeed += 0.6f;
				player.manaFlower = true;
			}
			if (clockworkShield)
			{
				player.allDamage += 0.10f;
				player.endurance += 0.25f;
				player.statDefense += 20;
			}
		}
	}
}
