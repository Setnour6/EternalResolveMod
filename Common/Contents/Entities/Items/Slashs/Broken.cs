using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs
{
    public class Broken_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( !npc.SpawnedFromStatue && npc.type == NPCID.Zombie )
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<Broken>( ) , 10 , 1 , 1 ) );
            else
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<Broken>( ) , 1000 , 1 , 1 ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
        public override void ModifyGlobalLoot( GlobalLoot globalLoot )
        {
            base.ModifyGlobalLoot( globalLoot );
        }
    }
    public class Broken : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "锈刀" );
            DisplayName.AddTranslation( English , "Borken" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 2 );
            Item.damage = 1;
            Item.value = Item.sellPrice( 0 , 1 , 75 );
            base.SetDefaults( );
        }
    }
}
