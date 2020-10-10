using Terraria.ID;
using Terraria.ModLoader;

namespace steampunk.Items.Misc
{
	public class BrassCog : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A basic brass cog");
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
			recipe.AddIngredient(mod, "BrassBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}
