using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace steampunk.Items.TheMind
{
	public class BioworkMind : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases mining speed by 80%" +
				"\nmove speed by 6%" +
				"\nand max run speed by 6%" +
				"\nAlso auto comsumes healing and mana potions" +
				"\nbut due to your fragile brain you lose 10 defense");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<steamPlayer>().bioworkMind = true;
		}
	}
}
