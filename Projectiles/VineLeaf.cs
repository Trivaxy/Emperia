using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class VineLeaf : ModProjectile
    {
		private bool init = false;
		Color rgb;
		private int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vine Leaf");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 24;       //projectile width
            projectile.height = 14;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
			projectile.aiStyle = 0;
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 3;      //how many npc will penetrate
            projectile.timeLeft = 2000;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //this make that the projectile will face the corect way
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);// |
            if (projectile.velocity.X > 0)
			{
				projectile.spriteDirection = 1;	
			}
			else if (projectile.velocity.X < 0)
			{
				projectile.spriteDirection = -1;
			}
			
			if (!init)
			{
				rgb = new Color(50,205,50);

                for (int index1 = 0; index1 < 4; ++index1)
                {
                    int index3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 76, (float)projectile.velocity.X, (float)projectile.velocity.Y, 0, rgb, 1.1f);
                    Main.dust[index3].noGravity = true;
                    Main.dust[index3].velocity = projectile.Center - Main.dust[index3].position;
                    ((Vector2)@Main.dust[index3].velocity).Normalize();
                    Dust dust1 = Main.dust[index3];
                    Vector2 vector2_1 = dust1.velocity * -3f;
                    dust1.velocity = vector2_1;
                    Dust dust2 = Main.dust[index3];
                    Vector2 vector2_2 = dust2.velocity + (projectile.velocity / 2f);
                    dust2.velocity = vector2_2;
                }
                init = true;
			}

            int index2 = Dust.NewDust(new Vector2((float)(projectile.position.X + 4.0), (float)(projectile.position.Y + 4.0)), projectile.width - 8, projectile.height - 8, 76, (float)(projectile.velocity.X * 0.200000002980232), (float)(projectile.velocity.Y * 0.200000002980232), 0, rgb, 0.7f);
            Main.dust[index2].position = projectile.Center;
            Main.dust[index2].noGravity = true;
            Main.dust[index2].velocity = projectile.velocity * 0.5f;
        }
		
		public override void Kill(int timeLeft)
        {

        	 for (int i = 0; i < 360; i += 36)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-1, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 46, 0f, 0f, 158, new Color(53f, 67f, 253f), 1f);
				Main.dust[num622].velocity += (vec *2f);
				Main.dust[num622].noGravity = true;
				}

		}
		
    }
}