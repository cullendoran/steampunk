using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using steampunk.Items.Misc;

namespace steampunk.Items.TheMind
{
	public class TheMindBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			player.QuickSpawnItem(ItemType<BioworkMind>());
			player.QuickSpawnItem(ItemType<BrassCog>(), 5);
			player.QuickSpawnItem(ItemType<ScrapMetal>(), 6);
		}

		public override int BossBagNPC => NPCType<NPCs.TheMind.TheMind>();
	}
}