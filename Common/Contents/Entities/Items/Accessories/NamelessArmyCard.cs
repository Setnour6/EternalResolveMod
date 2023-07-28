using EternalResolve.Common.Codes.Utils;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories
{
    public class NamelessArmyCard_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.IsZombie( ) )
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<NamelessArmyCard>( ) , 100 , 1 , 1 ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    /// <summary>
    /// 无名军牌, 击杀僵尸有1%几率掉落.
    /// </summary>
    public class NamelessArmyCard : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "无名军牌" );

            DisplayName.AddTranslation( English , "Nameless Army Card" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            base.SetDefaults( );
        }
    }
}
