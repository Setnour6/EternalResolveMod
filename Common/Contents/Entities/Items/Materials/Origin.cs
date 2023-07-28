using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials
{
    public class Origin_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.WallofFlesh )
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<Origin>( ) , 1 , 6 , 6 ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    /// <summary>
    /// 纯洁蓝宝石.
    /// </summary>
    public class Origin : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "纯洁蓝宝石" );
            Tooltip.AddTranslation( Chinese , "" +
                "传说中珍贵的起源之石" );

            DisplayName.AddTranslation( English , "Flawless Sapphire" );
            Tooltip.AddTranslation( English , "" +
                "The legendary precious stone of origin" );
        }
        public override void SetDefaults( )
        {
            ToItem( 7 );
            Item.value = Item.sellPrice( 0 , 15 );
            Item.scale = 0.7f;
        }
    }
}