using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace steampunk.Projectiles.Pets
{
	public class WolfPet : ModProjectile
	{
		public override bool Autoload(ref string name)
		{
			return false;
		}
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wolf"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.BabyGrinch);
			aiType = ProjectileID.BabyGrinch;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.grinch = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			steamPlayer modPlayer = player.GetModPlayer<steamPlayer>();
			if (player.dead) {
				modPlayer.WolfPetItem = false;
			}
			if (modPlayer.WolfPetItem) {
				projectile.timeLeft = 2;
			}
		}
	}
}