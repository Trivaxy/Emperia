﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items.Accessories
 {
public class RetinalBane : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Retinal Bane");
			Tooltip.SetDefault("Allows the player to dash into enemies, inflicting cursed damage\nDouble Tap a direction to dash");
		}
	public override void SetDefaults()
	{
		item.damage = 60;
		item.melee = true;
		item.defense = 4;
		item.width = 30;
		item.height = 38;
		item.value = 180000;
		item.expert = true;
		item.accessory = true;
	}
	
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
	
		MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		modPlayer.cursedDash = true;
		
	}
	 public override void AddRecipes()  //How to craft this sword
     {
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.EoCShield, 1);
		recipe.AddIngredient(ItemID.HallowedBar, 10);
		recipe.AddIngredient(ItemID.CursedFlame, 10);
		recipe.AddIngredient(ItemID.SoulofSight, 15);
        recipe.AddTile(TileID.MythrilAnvil); 			
        recipe.SetResult(this);
        recipe.AddRecipe(); 

     }

}}
