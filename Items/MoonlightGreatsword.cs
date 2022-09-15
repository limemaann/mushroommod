using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Text;
using System.Drawing;
using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;

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
            Item.useAnimation = 16;
            Item.autoReuse = true;


            // weapon properties
            Item.damage = 90;
            Item.knockBack = 4.75f;
            Item.DamageType = DamageClass.Melee;
        }

        // add PostDraw so it does it in swing mode too

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Microsoft.Xna.Framework.Color lightColor, Microsoft.Xna.Framework.Color alphaColor, float rotation, float scale, int whoAmI)
        {
            // says this item is missing, what the fuck
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Items/MoonlightGreatsword_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
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