using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Others
{
    public class UnknownCreatureSkull_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.MeteorHead )
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<UnknownCreatureSkull>( ) , 20 , 1 , 1 ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }

    /// <summary>
    /// 未知生物头骨, 击杀陨石怪有5%几率掉落.
    /// </summary>
    [AutoloadEquip( new EquipType[ ] { EquipType.Head } )]
    public class UnknownCreatureSkull : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "未知生物头骨" );

            DisplayName.AddTranslation( English , "Unknown creature‘s Skull" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToItem( 1 );
            Item.maxStack = 1;
            Item.defense = 2;
            Item.value = Item.sellPrice( 0 , 0 , 99 , 99 );
        }
    }
}
