using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Projectiles
{
    public class eightball_projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eight Ball");
        }

        public override void SetDefaults()
        {
            Projectile.arrow = true;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = ProjAIStyleID.Arrow; // or 1
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        // Additional hooks/methods here.
    }
}