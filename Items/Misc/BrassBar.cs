using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace steampunk.Items.Misc
{
	public class BrassBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A bar of impure brass made from brass mixture");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 750;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WaterBucket);
			recipe.AddIngredient(mod, "BrassMixture", 4);
			recipe.AddTile(mod, "BrassRefineryTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnCraft(Recipe recipe)
		{
			Item waterbucket = recipe.requiredItem.FirstOrDefault(i => i.type == ItemID.WaterBucket);
			if (waterbucket != null)
			{
				Main.LocalPlayer.QuickSpawnItem(ItemID.EmptyBucket, waterbucket.stack);
			}
		}
	}
}
