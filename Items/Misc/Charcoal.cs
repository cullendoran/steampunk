using Terraria.ID;
using Terraria.ModLoader;

namespace steampunk.Items.Misc
{
	public class Charcoal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A peice of charcoal made by burning wood in a furnace");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
