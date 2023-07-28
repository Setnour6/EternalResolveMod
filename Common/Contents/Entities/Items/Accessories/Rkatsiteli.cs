using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories
{
    public class Rkatsiteli_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.Bird )
            {
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<Rkatsiteli>( ) , 5 , 1 , 1 ) );
            }
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class Rkatsiteli : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "白羽" );
            Tooltip.AddTranslation( Chinese , "提供羽落效果" );

            DisplayName.AddTranslation( English , "Rkatsiteli" );
            Tooltip.AddTranslation( English , "Provide Featherfall effect" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.AddBuff( BuffID.Featherfall , 1 );
            base.UpdateAccessory( player , hideVisual );
        }
    }
}
