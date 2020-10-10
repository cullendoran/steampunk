using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace steampunk.Items.Misc
{
	public class BrassMixture : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A primitive brass mixture made from alloying some copper, tin, and charcoal");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 12;
			item.height = 12;
			item.value = 750;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperOre, 8);
			recipe.AddIngredient(ItemID.TinOre, 8);
			recipe.AddIngredient(mod, "Charcoal", 16);
			recipe.AddTile(mod, "AlloyMixerTile");
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}
