using Terraria.ID;
using Terraria.ModLoader;

namespace steampunk.Items.Misc
{
	public class ScrapMetal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A peice of salvaged metal from The Mind");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
		}
	}
}
