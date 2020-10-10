using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace steampunk.Items.Pets
{
	public class WolfPetItem : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return false;
		}
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Wolf Item");
			Tooltip.SetDefault("Summons a Wolf to follow you - LuckieWolfPaws Dev Pet");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.BabyGrinchMischiefWhistle);
			item.shoot = ProjectileType<Projectiles.Pets.WolfPet>();
			item.buffType = BuffType<Buffs.Pets.WolfPetBuff>();
		}
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}