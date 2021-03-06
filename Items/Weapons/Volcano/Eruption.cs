using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Chat;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Emperia.Items.Weapons.Volcano  
{
    public class Eruption : ModItem
    {
		public override void SetDefaults()
		{

			item.damage = 17;
			item.noMelee = true;
			item.noUseGraphic = false;
			item.magic = true;
			item.scale = 1f;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 3f;

			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.rare = 2;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shootSpeed = 3f;
			item.mana = 15;
			item.shoot = mod.ProjectileType("MagmaBlob");
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eruption");
            Tooltip.SetDefault("Shoots a volley of explosive magma blobs");
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			int numberProjectiles = 4; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * Main.rand.Next(1, 3), perturbedSpeed.Y * Main.rand.Next(1, 3), type, damage, knockBack, player.whoAmI);
			}
			return false; 
		}
    }
}
