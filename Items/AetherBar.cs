using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items
{
	public class AetherBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aetherium Bar");
			Tooltip.SetDefault("’Surprisingly light");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 2;
		}

	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Aetherium", 3);
			recipe.AddTile(TileID.SkyMill);  
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AetherBar", 5);
			recipe.AddIngredient(ItemID.Feather, 3);
			recipe.AddIngredient(ItemID.Cloud, 15);
			recipe.AddTile(TileID.SkyMill);  
			recipe.SetResult(ItemID.LuckyHorseshoe);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench, 1);
			recipe.AddIngredient(null, "Prism", 2);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.WorkBenches);  
			recipe.SetResult(ItemID.AlchemyTable);
			recipe.AddRecipe();
		}
	}
}