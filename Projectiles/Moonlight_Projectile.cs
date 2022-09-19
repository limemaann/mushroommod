using Microsoft.Xna.Framework;
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

            Projectile.CloneDefaults(ProjectileID.TerraBeam);

            // properties
            Projectile.alpha = 255;
            Projectile.width = 44;
            Projectile.height= 44;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 3;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 600;

            AIType = ProjectileID.TerraBeam;

        }

        // Additional hooks/methods here.
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
    }
}