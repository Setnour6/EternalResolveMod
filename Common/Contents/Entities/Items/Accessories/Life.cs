using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories
{
    public class Life_Loot : GlobalNPC
    {
        public override void ModifyGlobalLoot( GlobalLoot globalLoot )
        {
            globalLoot.Add( ItemDropRule.Common( ModContent.ItemType<Life>( ) , 2000 , 1 , 1 ) );
            base.ModifyGlobalLoot( globalLoot );
        }
    }
    public class Life : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "生机" );
            Tooltip.AddTranslation( Chinese , "" +
                "获得 10 点生命回复." );

            DisplayName.AddTranslation( English , "Life" );
            Tooltip.AddTranslation( English , "" +
                "Add 10 lifeRegen" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            Item.value = Item.sellPrice( 0 , 1 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.lifeRegen += 10;
        }
    }
}
