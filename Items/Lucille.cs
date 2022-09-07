using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Items
{
    public class Lucille : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Jeffery, break out Lucille");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            // Set other Item.X values here
        }

        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}