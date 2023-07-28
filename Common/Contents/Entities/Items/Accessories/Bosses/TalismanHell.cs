using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses
{
    public class TalismanHell_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.WallofFlesh )
                npcLoot.Add( ItemDropRule.BossBag( ModContent.ItemType<DeadBone>( ) ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class TalismanHell : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "地狱护符" );
            Tooltip.AddTranslation( Chinese ,
                "免疫烧伤、免疫咒火、免疫霜火\n" +
                "\"恶魔的爱.\"" );
            DisplayName.AddTranslation( English , "Talisman Hell" );
            Tooltip.AddTranslation( English ,
                "Immune burn, immune spell Fire, immune frost fire\n" +
                "\"Devil's love.\"" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.defense = 4;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.buffImmune[ 24 ] = true;
            player.buffImmune[ 39 ] = true;
            player.buffImmune[ 44 ] = true;
        }
    }
}
