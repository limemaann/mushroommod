using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.Projectiles
{
    public class Fireball_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Ball");
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = ProjAIStyleID.NebulaArcanum;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
        }

        // Additional hooks/methods here.
    }
}