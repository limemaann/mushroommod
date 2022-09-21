using IL.Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using mushroommod.Dusts;
using mushroommod.Projectiles;
using On.Terraria.GameContent;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Items
{
    public class MoonlightGreatsword : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Oceiros, the Consumed King, was infatuated with the search for moonlight, but in the end, it never revealed itself to him.");
        }

        public override void SetDefaults()
        {

            // common properties
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 30);
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 1;

            // use properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 16;
            Item.useTime = 32;
            Item.autoReuse = true;
            Item.useTurn = false;


            // weapon properties
            Item.damage = 90;
            Item.knockBack = 4.75f;
            Item.DamageType = DamageClass.Melee;

            // projectile properties
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Moonlight_Projectile>();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2(hitbox.Width, hitbox.Height), (0f), (1.86f), (2.42f));

            if (Main.rand.Next(2) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width / 2, hitbox.Height / 2 , DustID.Clentaminator_Cyan);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}