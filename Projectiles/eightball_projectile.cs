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
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
        }

        // Additional hooks/methods here.
    }
}