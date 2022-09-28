using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace mushroommod.Projectiles
{
    public class Fireball_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Ball");
            Main.projFrames[Projectile.type] = 4;
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
        }

        
        public override void PostDraw(Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = (Texture2D) ModContent.Request<object>("mushroommod/Projectiles/Fireball_Projectile_Glowmask");
            spriteBatch.Draw()
            {

            }

            

            //base.PostDraw(lightColor);
        }
        

    }
}