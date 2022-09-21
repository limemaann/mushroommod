using Microsoft.Xna.Framework;
using mushroommod.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Projectiles
{
    public class Moonlight_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonlight Projectile");
        }

        public override void SetDefaults()
        {

            Projectile.CloneDefaults(ProjectileID.LightBeam);

            // properties
            Projectile.alpha = 0;
            Projectile.width = 44;
            Projectile.height= 44;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.maxPenetrate = 10;
            Projectile.penetrate = 4;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            //Projectile.timeLeft = 600;
            Projectile.light = 0.75f;
            Projectile.velocity *= 10f;

            //AIType = ProjectileID.TerraBeam;
        }

        public override void AI()
        {
            int num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 0f - Projectile.velocity.Y * 4f), 40, 40, ModContent.DustType<ElectricDust>(), Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Main.dust[num309].velocity *= -0.25f;
            num309 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 0f - Projectile.velocity.Y * 4f), 40, 40, ModContent.DustType<ElectricDust>(), Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Main.dust[num309].velocity *= -0.25f;
            Main.dust[num309].position -= Projectile.velocity * 0.5f;

            base.AI();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            return base.OnTileCollide(oldVelocity);
        }

        // Additional hooks/methods here.

        /*
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
        */

        /*
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
        }
        */
    }
}