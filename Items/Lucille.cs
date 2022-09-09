using mushroommod.Projectiles;
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

            // common properties
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 30);


            // use properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.autoReuse = true;

            // weapon properties
            Item.damage = 50;
            Item.knockBack = 6.4f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = true;

            // projectile properties
            Item.shootSpeed = 5.6f;
            Item.shoot = ModContent.ProjectileType<Lucille_projectile>();

            /*
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            */
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}