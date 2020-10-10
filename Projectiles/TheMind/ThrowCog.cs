using steampunk.NPCs.TheMind;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace steampunk.Projectiles.TheMind
{
	public class ThrowCog : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thrown Cog");
		}

		public override void SetDefaults() {
			projectile.width = 4;
			projectile.height = 4;
			projectile.timeLeft = 60;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				PlaySound();
				if (projectile.ai[0] < 0f)
				{
					projectile.alpha = 0;
				}
				if (projectile.ai[0] == 44f)
				{
					projectile.coldDamage = true;
				}
				if (projectile.ai[0] < 0f && Main.expertMode)
				{
					cooldownSlot = 1;
				}
				projectile.Name = "Trown Cog";
				projectile.localAI[0] = 1f;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if ((Main.expertMode || Main.rand.NextBool()) && projectile.ai[0] >= 0f)
			{
				target.AddBuff(BuffID.Electrified, 120, true);
			}
		}
		public virtual void PlaySound()
		{
			var Metal = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/MetalClank2");
			Main.PlaySound(Metal);
		}
	}
}