using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	public class VulcanMeteor: ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulcan Meteor");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 240;
			projectile.alpha = 255;
			projectile.width = 26;
			projectile.height = 24;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = true;
			projectile.melee = true;
		}

		public override void AI()
		{
			projectile.velocity.X *= .98f;
			projectile.velocity.Y += .15f;
			for (int i = 0; i < 10; i++)
			{
				int num = Dust.NewDust(projectile.Center, 26, 26, 258, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = 0;
				Main.dust[num].position.X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
				Main.dust[num].position.Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 258);
				Vector2 vel = new Vector2(0, -1).RotatedBy(Main.rand.NextFloat() * 6.283f) * 3.5f;
			}
		}

	}
}