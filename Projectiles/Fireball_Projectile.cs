using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using IL.Terraria.DataStructures;
using mushroommod.Dusts;
using CsvHelper.TypeConversion;

namespace mushroommod.Projectiles
{

    public class Fireball_Projectile : ModProjectile
    {
        Texture2D[] animation = new Texture2D[4];

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
            //Projectile.light = 0.75f; this just adds white light, see AI method for colored light

            // weapon properties
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;

            for (int i = 0; i < 4; i++)
            {
                animation[i] = ModContent.Request<Texture2D>($"mushroommod/Projectiles/Fireball Animation/glow{i}", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            }
        }
        public override void AI()
        {
            // Animation
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

            // Lighting 
            Lighting.AddLight(Projectile.Center, 0.87f, 0.44f, 0.15f);

            // Dusts
            int num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 0f - Projectile.velocity.Y * 4f), 40, 40, DustID.SolarFlare, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Main.dust[num309].velocity *= -0.25f;
            num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 0f - Projectile.velocity.Y * 4f), 40, 40, DustID.SolarFlare, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Main.dust[num309].velocity *= -0.25f;
            Main.dust[num309].position -= Projectile.velocity * 0.5f;

            base.AI();

            #region homing AI
            // homing AI
            float num132 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
            float num133 = Projectile.localAI[0];
            if (num133 == 0f)
            {
                Projectile.localAI[0] = num132;
                num133 = num132;
            }
            float num134 = Projectile.position.X;
            float num135 = Projectile.position.Y;
            float num136 = 300f;
            bool flag3 = false;
            int num137 = 0;
            if (Projectile.ai[1] == 0f)
            {
                for (int num138 = 0; num138 < 200; num138++)
                {
                    if (Main.npc[num138].CanBeChasedBy(this, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num138 + 1)))
                    {
                        float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
                        float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
                        float num141 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num139) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num140);
                        if (num141 < num136 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                        {
                            num136 = num141;
                            num134 = num139;
                            num135 = num140;
                            flag3 = true;
                            num137 = num138;
                        }
                    }
                }
                if (flag3)
                {
                    Projectile.ai[1] = (float)(num137 + 1);
                }
                flag3 = false;
            }
            if (Projectile.ai[1] > 0f)
            {
                int num142 = (int)(Projectile.ai[1] - 1f);
                if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                {
                    float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                    float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                    if (Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num143) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num144) < 1000f)
                    {
                        flag3 = true;
                        num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                        num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                    }
                }
                else
                {
                    Projectile.ai[1] = 0f;
                }
            }
            if (!Projectile.friendly)
            {
                flag3 = false;
            }
            if (flag3)
            {
                float num145 = num133;
                Vector2 vector10 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num146 = num134 - vector10.X;
                float num147 = num135 - vector10.Y;
                float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
                num148 = num145 / num148;
                num146 *= num148;
                num147 *= num148;
                int num149 = 8;
                Projectile.velocity.X = (Projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
                Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
            }
            #endregion
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

        /*
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 40, 40, DustID.SolarFlare, -Projectile.velocity.X + rnd.Next(100) / 30, -Projectile.velocity.Y + rnd.Next(100) / 30);
                Projectile.light = 1.5f;
            }

            Projectile.light = 0.75f;
            return true;
        }
        */

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 40, 40, DustID.SolarFlare, -Projectile.velocity.X + rnd.Next(-30, 100) / 30, -Projectile.velocity.Y + rnd.Next(-30, 100) / 30);
                Projectile.light = 1.5f;
            }

            Projectile.light = 0.75f;
        }
    }
}