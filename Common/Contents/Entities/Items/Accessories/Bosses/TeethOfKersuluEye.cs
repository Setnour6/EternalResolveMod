using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses
{
    public class TeethOfKersuluEye_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.EyeofCthulhu )
                npcLoot.Add( ItemDropRule.BossBag( ModContent.ItemType<TeethOfKersuluEye>( ) ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class TeethOfKersuluEye : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "克苏鲁眼之牙" );
            Tooltip.AddTranslation( Chinese ,
                 "增加15点护甲穿透\n" +
                "\"还保持着活性...\"" );
            DisplayName.AddTranslation( English , "Teeth Of Kersulu Eye" );
            Tooltip.AddTranslation( English ,
                 "Add 15 armorPenetration\n" +
                "\"Still active...\"" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.defense = 1;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.armorPenetration += 15;
            player.dash = 1;
        }
    }
}
