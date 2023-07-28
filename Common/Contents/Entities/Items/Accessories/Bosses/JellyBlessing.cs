using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses
{
    public class JellyBlessing_Loot : GlobalNPC
    {
        public override void ModifyGlobalLoot( GlobalLoot globalLoot )
        {
            globalLoot.Add( ItemDropRule.Common( ModContent.ItemType<JellyBlessing>( ) , 10000 , 1 , 1 ) );
            base.ModifyGlobalLoot( globalLoot );
        }
    }
    public class JellyBlessing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "果冻 · 祝福" );
            Tooltip.AddTranslation( Chinese ,
                "增加你6点生命回复\n" +
                "愿您游玩本模组时幸福愉快." );

            DisplayName.AddTranslation( English , "Jelly · Blessing" );
            Tooltip.AddTranslation( English ,
                "Add 6 lifeRegen\n" +
                "\"Have a good time.\"" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            Item.defense = 4;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.lifeRegen += 6;
        }
    }
}
