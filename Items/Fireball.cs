using mushroommod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Items
{
    public class Fireball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Flame catalyst used by pyromancers. Creates a powerful flame in the wielder's hand.");
        }

        public override void SetDefaults()
        {
            // common properties
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(gold: 20);
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 16;

            // use properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.autoReuse = true;
            Item.useTurn = true;

            // weapon properties
            Item.damage = 75;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 18;
            Item.noMelee = true;

            // projectile properties
            Item.shootSpeed = 6f;
            Item.shoot = ModContent.ProjectileType<Fireball_Projectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddIngredient(ItemID.CursedFlame, 15);
            recipe.Register();
        }
    }
}