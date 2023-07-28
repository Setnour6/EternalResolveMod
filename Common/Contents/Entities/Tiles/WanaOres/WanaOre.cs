using EternalResolve.Common.Contents.Entities.Items;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.WanaOres
{
    public class WanaOre : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "瓦能矿" );
            DisplayName.AddTranslation( English , "Wana Ore" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 4 , ModContent.TileType<WanaOre_Tile>( ) );
            Item.value = Item.sellPrice( 0 , 0 , 75 , 0 );
            base.SetDefaults( );
        }
    }
}
