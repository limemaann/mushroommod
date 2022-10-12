using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mushroommod.NPCs
{
    public class Lizard_Wizard : ModNPC
    {

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            // general
            NPC.height = 40;
            NPC.width = 18;
            NPC.aiStyle = 7;
            NPC.friendly = true;
            NPC.townNPC = true;

            // combat
            NPC.lifeMax = 250;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.knockBackResist = 0.5f;

        }
    
    }
}