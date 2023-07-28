using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs
{
    /// <summary>
    /// 高级工作台.
    /// </summary>
    public class AdvancedWorkbench_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            Main.tileSolid[ Type ] = false;
            Main.tileNoAttach[ Type ] = true;
            Main.tileLavaDeath[ Type ] = false;
            Main.tileFrameImportant[ Type ] = true;
            TileObjectData.newTile.CopyFrom( TileObjectData.Style4x2 );
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[ ]
            {
                18
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile( Type );
            ModTranslation name = CreateMapEntryName( );
            name.AddTranslation( EternalResolve.Chinese , "高级工作台" );
            name.AddTranslation( EternalResolve.English , "AdvancedWorkbench" );
            DustType = 21;
            AdjTiles = new int[ ]
            {
                TileID.WorkBenches,
                TileID.Furnaces,
                TileID.Anvils,
                ModContent.TileType<SteelAnvil_Tile>()
            };
            AddMapEntry( new Color( 200 , 200 , 200 ) , name );
        }
        public override void KillMultiTile( int i , int j , int frameX , int frameY )
        {
            Item.NewItem( i * 16 , j * 16 , 32 , 16 , ModContent.ItemType<AdvancedWorkbench>( ) , 1 , false , 0 , false , false );
        }
    }
}