using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Items
{
    public class MoonlightGreatsword : ModItem
    {
        public static short glowMask;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Oceiros, the Consumed King, was infatuated with the search for moonlight, but in the end, it never revealed itself to him.");
            glowMask = GlowMaskAPI.Tools.instance.AddGlowMask();
            // fix the missing assemblies error
        }

        public override void SetDefaults()
        {

            // common properties
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 30);
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 1;
            Item.glowMask = glowMask;

            // use properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 16;
            Item.useAnimation = 16;
            Item.autoReuse = true;


            // weapon properties
            Item.damage = 90;
            Item.knockBack = 4.75f;
            Item.DamageType = DamageClass.Melee;
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