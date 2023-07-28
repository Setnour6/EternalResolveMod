using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Electrics
{
    public class Battery : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "电池" );
            Tooltip.AddTranslation( Chinese , "最普通的电池" );

            DisplayName.AddTranslation( English , "Battery" );
            Tooltip.AddTranslation( English , "A Battery" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 999;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
            Item.GetGlobalItem<ItemElectric>( ).IsBattery = true;
            Item.GetGlobalItem<ItemElectric>( ).CanCharge = true;
            base.SetDefaults( );
        }
    }
}