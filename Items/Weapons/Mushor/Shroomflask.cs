﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items.Weapons.Mushor 
{
public class Shroomflask : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomy Flask");
			Tooltip.SetDefault("Creates a potent field of mushroom gas on enemy hits\n Summons a pack of floating mushrooms from the ground on tile hits");
		}
	public override void SetDefaults()
	{
		item.width = 28;  
		item.damage = 22;  
		item.mana = 20;//Keep this reasonable please.
		item.magic = true;  
		item.noMelee = true;
		item.noUseGraphic = true;
		item.useAnimation = 32;
		item.useStyle = 1;
		item.useTime = 32;
		item.knockBack = 0f;  //Ranges from 1 to 9.
		item.UseSound = SoundID.Item106;
		item.autoReuse = false;  //Dictates whether the weapon can be "auto-fired".
		item.height = 30;  //The height of the .png file in pixels divided by 2.
		item.maxStack = 1;
		item.value = 60000;  //Value is calculated in copper coins.
		item.rare = 3;  //Ranges from 1 to 11.
		item.shoot = mod.ProjectileType("ShroomFlask");
		item.shootSpeed = 9f;
	}
}}
