using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Npcs.GoblinArmy
{
    public class GoblinSorceress : ModNPC
    {
        private enum Move
        {
           Walk, 
		   Shoot
        }

        private int counter;

        private Move move;
        private Move prevMove;
        private Vector2 targetPosition;
		
		private bool init = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Sorceress");
			Main.npcFrameCount[npc.type] = 9;
		}
        public override void SetDefaults()
        {
            npc.lifeMax = 275;
            npc.damage = 30;
            npc.defense = 5;
            npc.knockBackResist = 0f;
            npc.width = 42;
            npc.height = 64;
            npc.value = Item.buyPrice(0, 0, 50, 0);
            npc.npcSlots = 1f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
			npc.scale = 1f;
        }
		public override void FindFrame(int frameHeight)
		{
			if (move == Move.Walk)
			{
				npc.frameCounter += 0.2f;
				npc.frameCounter %= 5; 
				int frame = (int)npc.frameCounter; 
				npc.frame.Y = frame * frameHeight; 
			}
			else if (move == Move.Shoot)
			{
				npc.frameCounter += 0.1f;
				npc.frameCounter %= 3; 
				int frame = (int)npc.frameCounter + 5; 
				npc.frame.Y = frame * frameHeight; 
			}
			
		}

        public override void AI()
		{
			if (npc.velocity.X < 0)
				npc.spriteDirection = -1;
			else if (npc.velocity.X > 0)
				npc.spriteDirection = 1;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (!init)
			{
				move = Move.Walk;
				counter = 250;
				init = true;
			}
			if (move == Move.Walk)
            { 
				counter--;
				npc.aiStyle = 3;
				aiType = 508;
				if (npc.velocity.X > 2f)
					npc.velocity.X = 2f;
				if (npc.velocity.X < -2f)
					npc.velocity.X = -2f;
				if (counter <= 0)
				{
					SetMove(Move.Shoot, 30);
				}
			}
			if (move == Move.Shoot)
			{
				counter--;
				if (player.Center.X > npc.Center.X)
					npc.spriteDirection = 1;
				else
					npc.spriteDirection = -1;
				npc.velocity.X = 0;
				int xOff = 0;
				if (npc.spriteDirection == 1) xOff = -5;
				else xOff = 5;
				Vector2 placePosition = npc.Center + new Vector2(-xOff, -npc.height / 2);
				for (int index1 = 0; index1 < 3; ++index1)
				{
					Vector2 vel = new Vector2(2, 0).RotatedByRandom(MathHelper.ToRadians(360));
					int index2 = Dust.NewDust(placePosition + vel, npc.width, npc.height, DustID.Shadowflame, 0.0f, 0.0f, 100, new Color(), 0.8f);
					
				}
				if (counter <= 0)
				{	
					SetMove(Move.Walk, 250);
					if (Main.rand.Next(5) == 0)
					{
						for (int i = -1; i <= 1; i++)
						{
							Vector2 placePosition1 = new Vector2(player.Center.X + 100 * i, player.Center.Y - 600);
							Vector2 direction1 = player.Center - placePosition1;
							direction1.Normalize();
							Projectile.NewProjectile(placePosition1.X, placePosition1.Y, direction1.X * 10f, direction1.Y * 10f, mod.ProjectileType("ShadowBoltHostile"), 10, 1, Main.myPlayer, 0, 0);
						}
					}
					else
					{
						Vector2 direction = Main.player[npc.target].Center - placePosition;
						direction.Normalize();
						int p = Projectile.NewProjectile(placePosition.X, placePosition.Y, direction.X * 8f, direction.Y * 8f, mod.ProjectileType("ShadowBoltHostile"), 22, 1, Main.myPlayer, 0, 0);
					}
					
				}
			}
		}
		

       

       /* private void SmoothMoveToPosition(Vector2 toPosition, float addSpeed, float maxSpeed, float slowRange = 64, float slowBy = .95f)
        {
            if (Math.Abs((toPosition - npc.Center).Length()) >= slowRange)
            {
                npc.velocity += Vector2.Normalize((toPosition - npc.Center) * addSpeed);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxSpeed, maxSpeed);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -maxSpeed, maxSpeed);
            }
            else
            {
                npc.velocity *= slowBy;
            }
        }*/

        private bool IsBelowPhaseTwoThreshhold()
        {
            return npc.life <= npc.lifeMax / 2;     
        }

        private void SetMove(Move toMove, int counter)
        {
            prevMove = move;
            move = toMove;
            this.counter = counter;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return Main.invasionType == 1 ? 0.05f : 0;
		}
		/*public override void NPCLoot()
		{
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Yeti/gore1"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Yeti/gore2"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Yeti/gore3"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Yeti/gore4"), 1f);
			Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Yeti/gore5"), 1f);
			/*if (!EmperialWorld.downedMushor)
			{
            	Main.NewText("The guardian of the mushroom biome has fallen...", 0, 75, 161, false);
				EmperialWorld.downedMushor = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("YetiTrophy"));
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MammothineClub"));
				}
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HuntersSpear"));
				}
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BigGameHunter"));
				}
				
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("YetiMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChilledFootprint"));
				}
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArcticIncantation"));
				}
			}
		}*/

	}
}
