using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses
{
    public class DeadBone_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.SkeletronHead )
                npcLoot.Add( ItemDropRule.BossBag( ModContent.ItemType<DeadBone>( ) ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class DeadBone : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "骨玉佩" );
            Tooltip.AddTranslation( Chinese ,
                "增加4点的护甲穿透\n" +
                "增加4点的生命回复\n" +
                "放置于背包内时，增加5%移动速度。\n" +
                "\"已亡者的爱情\"" );

            DisplayName.AddTranslation( English , "Dead Bone" );
            Tooltip.AddTranslation( English ,
                "Add 4 armorPenetration\n" +
                "Add 4 lifeRegen\n" +
                "When it in your inventory , you will add 5% moveSpeed\n" +
                "\"Love of the dead\"" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            Item.defense = 1;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.armorPenetration += 4;
            player.lifeRegen += 4;
        }
        public override void UpdateInventory( Player player )
        {
            player.moveSpeed += 0.05f;
        }
    }
}
