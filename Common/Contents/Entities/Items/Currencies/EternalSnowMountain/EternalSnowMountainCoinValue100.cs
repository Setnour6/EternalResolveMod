﻿using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Currencies.EternalSnowMountain
{
    public class EternalSnowMountainCoinValue100 : ERItem
    {
        public override string Texture => ModContent.GetModItem( ModContent.ItemType<EternalSnowMountainCoin>( ) ).Texture;
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "100 元硬币" );

            DisplayName.AddTranslation( English , "Value 100 Coin" );

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