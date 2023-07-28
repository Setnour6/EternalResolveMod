using EternalResolve.Common.Contents.Entities.Items;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Entities.Tiles.Bricks.GuJi
{
    public class GuJiBrick2 : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "古纪平台砖" );
            DisplayName.AddTranslation( English , "Gu Ji Platform brick" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 8 , ModContent.TileType<GuJiBrick2_Tile>( ) );
            Item.value = Item.sellPrice( 0 , 75 , 0 , 0 );
            base.SetDefaults( );
        }
    }
}