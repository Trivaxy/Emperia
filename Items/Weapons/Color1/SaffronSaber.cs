using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items.Weapons.Color1  //where is located
{
    public class SaffronSaber : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Saffron Sabre");
			Tooltip.SetDefault("Striking an enemy will increase movement speed for a short time\nStriking a boss increases the duration");
		}
        public override void SetDefaults()
        {     //Sword name
            item.damage = 34;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 36;              //Sword width
            item.height = 40;             //Sword height
            item.useTime = 18;          //how fast 
            item.useAnimation = 18;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 2f;  
			item.crit = 2;			//Sword knockback
            item.value = 48000;        
            item.rare = 3;
			item.scale = 1f;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
			}
		}
        public override void AddRecipes()  //How to craft this sword
        {
            ModRecipe recipe = new ModRecipe(mod);      
            recipe.AddIngredient(null, "Prism", 1); 
			recipe.AddIngredient(ItemID.Topaz, 8); 
			recipe.AddIngredient(ItemID.YellowMarigold, 1); 
            recipe.AddTile(TileID.Anvils); 			//you need 1 DirtBlock  //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
		 public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            if (target.boss)
			    player.AddBuff(mod.BuffType("SaffronSadism"), Main.rand.Next(360, 600) + 300);
            else
                player.AddBuff(mod.BuffType("SaffronSadism"), Main.rand.Next(360, 600));
        }
    }
}
