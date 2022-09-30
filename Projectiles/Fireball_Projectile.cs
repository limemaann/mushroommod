using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using IL.Terraria.DataStructures;

namespace mushroommod.Projectiles
{

    public class Fireball_Projectile : ModProjectile
    {
        Texture2D[] animation = new Texture2D[4];

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Ball");
            Main.projFrames[Projectile.type] = 4;
            

            for (int i = 0; i < 4; i++)
            {
                animation[i] = ModContent.Request<Texture2D>($"mushroommod/Projectiles/Fireball Animation/glow{i}", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            }
        }

        public override void SetDefaults()
        {
            // basic properties
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.extraUpdates = 2;


            // weapon properties
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {

            int frameSpeed = 4; //How fast you want it to animate
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            /*
            //This will cycle through all of the frames in the sprite sheet
            int frameSpeed = 4; //How fast you want it to animate
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
            */
        }

        public override void PostDraw(Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = animation[Projectile.frame];
            //Texture2D texture = ModContent.Request<Texture2D>("mushroommod/Projectiles/Fireball_Projectile _Glowmask", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            spriteBatch.Draw
                (
                    texture,
                    new Vector2(Projectile.position.X - Main.screenPosition.X + Projectile.width * 0.5f, Projectile.position.Y - Main.screenPosition.Y + Projectile.height - texture.Height * 0.5f + 2f),
                    new Rectangle(0, 0, texture.Width, texture.Height),
                    Color.White,
                    0f,
                    texture.Size() * 0.5f,
                    1f,
                    SpriteEffects.None,
                    0f
                );

            //base.PostDraw(lightColor);
        }
    }
}