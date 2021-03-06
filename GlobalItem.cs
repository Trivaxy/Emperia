﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Emperia;

namespace Emperia
{
	public class ExampleInstancedGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity {get{return true;}}
		public override bool CloneNewInstances {get{return true;}}		
		public int forestSetShots = 2;
		public override bool UseItem(Item item, Player player)
        {
			if (item.type == 28 || item.type == 188 || item.type == 499 || item.type == 3544 || item.type == 226 || item.type == 227 || item.type == 3001 || item.type == mod.ItemType("AshenBandage"))
			{
				MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
				if (modPlayer.vitalityCrystal)
				{
					player.statLife += 25;
					player.HealEffect(25);
				}
			}
			if (item.type == 5 || item.type == mod.ItemType("MushroomPlatter") || item.type == mod.ItemType("MushroomPlatterCrim"))
			{
				MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
				if (modPlayer.frostleafSet)
				{
					player.AddBuff(mod.BuffType("FrostleafBuff"), 1200);
				}
			}
			return false;
		}
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
			{
				int x = Main.rand.Next(3);
				if (x == 0)
				{
					Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("Skelebow")); 
				}
				else if (x == 1)
				{
					Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("NecromanticFlame")); 
				}
				else if (x == 2)
				{
					Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("BoneWhip")); 
				}
			}
		}
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockback)
		{
			if (item.ranged && player.GetModPlayer<MyPlayer>().forestSetRanged)
			{
				forestSetShots--;
				if (forestSetShots == 0)
				{
					forestSetShots = 3;
					Projectile.NewProjectile(position.X, position.Y, speedX * .75f, speedY * .75f, mod.ProjectileType("VineLeaf"), damage, knockback, player.whoAmI);
					
				}
				return true;
			}
			return true;
			
		}
        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.thrown && player.GetModPlayer<MyPlayer>().forestSetThrown)
            {
                return (Main.rand.Next(3) != 0);
            }
            return true;
        }
	}
}
