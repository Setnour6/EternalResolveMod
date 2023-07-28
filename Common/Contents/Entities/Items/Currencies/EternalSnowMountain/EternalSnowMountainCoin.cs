using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;

namespace EternalResolve.Common.Contents.Entities.Items.Currencies.EternalSnowMountain
{
    public class EternalSnowMountainCoin : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "1 元硬币" );

            DisplayName.AddTranslation( English , "Value 1 Coin" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 99999;
            Item.GetGlobalItem<ItemToolTipHack>( ).TextLine = new TextLine( "◆ 来自 [永恒雪山] 派系发行的货币 " , Color.CadetBlue );
            base.SetDefaults( );
        }
    }
}