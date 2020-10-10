using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace steampunk.Items.Placeable
{
	public class AlloyMixer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A alloy melter for making different alloys");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.AlloyMixerTile>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Furnace);
			recipe.AddIngredient(ItemID.IronBar, 25);
			recipe.AddIngredient(ItemID.WaterBucket, 2);
			recipe.AddIngredient(mod, "Charcoal", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}