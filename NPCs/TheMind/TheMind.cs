using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using steampunk.Items.Misc;
using steampunk.Projectiles.TheMind;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Audio;
using static Terraria.ModLoader.ModContent;

namespace steampunk.NPCs.TheMind
{
	[AutoloadBossHead]
	public class TheMind : ModNPC
	{
		private const int sphereRadius = 300;
		private float attackCool
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}

		private float moveCool
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}

		private float rotationSpeed
		{
			get => npc.ai[2];
			set => npc.ai[2] = value;
		}

		private int moveTime = 300;
		private int moveTimer = 60;
		internal int cogTimer;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Mind");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 40;
			npc.defense = 30;
			npc.knockBackResist = 0f;
			npc.width = 100;
			npc.height = 100;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			music = MusicID.Boss1;
			bossBag = ItemType<Items.TheMind.TheMindBag>();
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Misc.ScrapMetal>(), 6);
				Item.NewItem(npc.getRect(), ItemType<Items.Misc.BrassCog>(), 5);
			}
		}
		public override void AI()
        {

			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (!player.active || player.dead)
				{
					npc.velocity = new Vector2(0f, 10f);
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
					return;
				}
			}
			moveCool -= 1f;
			if (Main.netMode != NetmodeID.MultiplayerClient && moveCool <= 0f)
			{
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				double angle = Main.rand.NextDouble() * 2.0 * Math.PI;
				int distance = sphereRadius + Main.rand.Next(200);
				Vector2 moveTo = player.Center + (float)distance * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				moveCool = (float)moveTime + (float)Main.rand.Next(100);
				npc.velocity = (moveTo - npc.Center) / moveCool;
				rotationSpeed = (float)(Main.rand.NextDouble() + Main.rand.NextDouble());
				if (rotationSpeed > 1f)
				{
					rotationSpeed = 1f + (rotationSpeed - 1f) / 2f;
				}
				if (Main.rand.NextBool())
				{
					rotationSpeed *= -1;
				}
				rotationSpeed *= 0.01f;
				npc.netUpdate = true;
			}
			if (Vector2.Distance(Main.player[npc.target].position, npc.position) > sphereRadius)
			{
				moveTimer--;
			}
			else
			{
				moveTimer += 3;
				if (moveTime >= 300 && moveTimer > 60)
				{
					moveTimer = 60;
				}
			}
			if (moveTimer <= 0)
			{
				moveTimer += 60;
				moveTime -= 3;
				if (moveTime < 99)
				{
					moveTime = 99;
					moveTimer = 0;
				}
				npc.netUpdate = true;
			}
			else if (moveTimer > 60)
			{
				moveTimer -= 60;
				moveTime += 3;
				npc.netUpdate = true;
			}
			attackCool -= 1f;
			if (Main.netMode != NetmodeID.MultiplayerClient && attackCool <= 0f)
			{
				attackCool = 200f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
				Vector2 delta = player.Center - npc.Center;
				float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
				if (magnitude > 0)
				{
					delta *= 5f / magnitude;
				}
				else
				{
					delta = new Vector2(0f, 5f);
				}
				int damage = (npc.damage - 30) / 2;
				if (Main.expertMode)
				{
					damage = (int)(damage / Main.expertDamage);
				}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, ProjectileType<ThrowCog>(), damage, 3f, Main.myPlayer, 600f);
				npc.netUpdate = true;
			}
			if (Main.rand.NextBool())
			{
				float radius = (float)Math.Sqrt(Main.rand.Next(sphereRadius * sphereRadius));
				double angle = Main.rand.NextDouble() * 2.0 * Math.PI;
			}
		}
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f;
			return null;
		}
	}
}
