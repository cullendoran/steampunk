using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace steampunk.Items.Accessories
{
	public class ClockworkShield : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A shield used long ago by the steampunkers to defend themselves" +
				"\nThis one is covered with leather" +
				"\nIncreases damage by 10%" +
				"\nEndurance by 25%" +
				"\nAnd Defense by 20" +
				"\nBut due to the fragile design, if you get hit you are inflicted with broken armor for 2 seconds");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<steamPlayer>().clockworkShield = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BrassBar", 40);
			recipe.AddIngredient(mod, "BrassCog", 10);
			recipe.AddIngredient(ItemID.Leather, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}