using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace Emperia.Items.Sets.Hardmode.Stratos
{
    public class StratosBroadsword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stratos Broadsword");
			Tooltip.SetDefault("Hitting enemies sends rock shards flying");
		}


        public override void SetDefaults()
        {
            item.damage = 54;
            item.useTime = 30;
            item.useAnimation = 30;
            item.melee = true;            
            item.width = 60;              
            item.height = 66;             
            item.useStyle = 1;        
            item.knockBack = 5f;
            item.value = 258000;
            item.crit = 6;
            item.rare = 4;
            item.UseSound = SoundID.Item1;   
            item.autoReuse = true;
            item.useTurn = false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 180);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;

            }
        }



        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddIngredient(ItemID.BladeofGrass, 1);
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(ItemID.BloodButcherer, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
