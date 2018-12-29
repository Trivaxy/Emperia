using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace Emperia.Items.Sets.PreHardmode.Marble
{
	public class MarbleTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.magic = true;
			item.width = 22;
			item.height = 24;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 5000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;

			item.shoot = mod.ProjectileType("MarbleEnergy");
			item.shootSpeed = 6f;
			item.mana = 5;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Marble Spellbook");
	  Tooltip.SetDefault("Releases slow-moving bursts of white energy");
    }
	public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MarbleBar", 9);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
	}
}
