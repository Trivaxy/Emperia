using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Emperia.Projectiles
{
	public class FireBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.PainterPaintball);

			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 225;

		}
		
	

		public override void AI()
		{
			projectile.ai[1] ++;
			int x1 = Main.rand.Next(7);
			/*Color rgb = new Color(0, 0, 0);
			if (x1 == 0)
			{
				rgb = new Color(230, 0, 0);
			}
			else if (x1 == 1)
			{
				rgb = new Color(255, 255, 0);
			}
			else if (x1 == 2)
			{
				rgb = new Color(0, 0, 240);
			}
			else if(x1 == 3)
			{
				rgb = new Color(0, 255, 0);
			}
			else if(x1 == 4)
			{
				rgb = new Color(255, 105, 180);
			}
			else if (x1 == 5)
			{
				rgb = new Color(132, 112, 255);
			}
			else if (x1 == 6)
			{
				rgb = new Color(255, 165, 0);
			}*/
			if (Main.rand.Next(2) == 0)
            {
            	int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width / 8, projectile.height / 8, 6, 0f, 0f, 0, new Color(39, 90, 219), 1f);
            }
		}
			public override bool OnTileCollide(Vector2 oldVelocity)
			{
				projectile.velocity = Vector2.Zero;
				return false;
			}
		
		
		
	}
}