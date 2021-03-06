using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.Corrupt
{
    public class RotDaggerProj : ModProjectile
    {
		bool init = false;
		Color rgb;
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RotDaggerProj");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 30;       //projectile width
            projectile.height = 30;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.thrown = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = -1;      //how many npc will penetrate
            projectile.timeLeft = 2000;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //this make that the projectile will face the corect way
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;// |
            int index2 = Dust.NewDust(new Vector2((float)(projectile.position.X + 4.0), (float)(projectile.position.Y + 4.0)), projectile.width - 8, projectile.height - 8, 75, (float)(projectile.velocity.X * 0.200000002980232), (float)(projectile.velocity.Y * 0.200000002980232), 0, rgb, 0.7f);
            Main.dust[index2].position = projectile.Center;
            Main.dust[index2].noGravity = true;
            Main.dust[index2].velocity = projectile.velocity * 0.5f;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.Next(3) == 0)
			 target.AddBuff(BuffID.CursedInferno, 240);
		}
		public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, projectile.Center);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("FireBallCursed"), projectile.damage, 1, Main.myPlayer, 0, 0);
        }
		
    }
}