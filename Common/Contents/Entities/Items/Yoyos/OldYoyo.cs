using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class OldYoyo_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if( npc.type == NPCID.Plantera )
            {
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<OldYoyo>( ) , 1 , 1 , 1 ));
            }
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class OldYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "旧悠悠球" );
            DisplayName.AddTranslation( English , "OldYoyo" );
        }
        public override void SetDefaults( )
        {
            ToItem( 6 );
            Item.value = Item.sellPrice( 0 , 0 , 75 , 0 );
        }
    }
}
