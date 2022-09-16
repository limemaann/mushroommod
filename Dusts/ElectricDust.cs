using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace mushroommod.Dusts
{
    class ElectricDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            //dust.noLight = false;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity; // Moves the dust particle
            dust.rotation += dust.velocity.X * 0.15f; // Rotates the dust particle so it doesn't move in the same direction every time
            dust.scale *= 0.95f; // Makes the dust particle smaller by scaling it down to 95%
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, (0f * 0.5f * light), (1.86f * 0.5f * light), (2.42f * 0.5f * light));
            if (dust.scale < 0.5f) // checks to see if the size of the dust particle is smaller than specified scale limit (0.5f) in this case
            {
                dust.active = false; // if size of dust particle IS smaller than specified scale limit, the dust will disappear
            }
            return false;

            /*
            dust.position += dust.velocity;
            dust.scale -= 0.01f;
            if (dust.scale < 0.75f)
            {
                dust.active = false;
            }
            return false;
            */
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            lightColor = new Color(0, 186, 242, 25);
            return lightColor;
        }
    }
}