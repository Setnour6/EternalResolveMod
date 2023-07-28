using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Npcs
{
    public class Modify_PriceBalance : GlobalNPC
    {
        public override void SetDefaults( NPC npc )
        {
            npc.value = npc.lifeMax / 1000 + 1;
            base.SetDefaults( npc );
        }
    }
}
