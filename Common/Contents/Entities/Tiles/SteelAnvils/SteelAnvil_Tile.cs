using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils
{
    public class SteelAnvil_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            Main.tileTable[ Type ] = true;
            Main.tileSolidTop[ Type ] = true;
            Main.tileNoAttach[ Type ] = true;
            Main.tileLavaDeath[ Type ] = true;
            Main.tileFrameImportant[ Type ] = true;
            TileID.Sets.DisableSmartCursor[ Type ] = true;
            DustType = 21;
            SoundType = SoundID.Tink;
            SoundStyle = 1;
            AdjTiles = new int[ ] { TileID.Anvils };
            TileObjectData.newTile.CopyFrom( TileObjectData.Style2x1 );
            TileObjectData.newTile.CoordinateHeights = new[ ] { 18 };
            TileObjectData.addTile( Type );
            AddToArray( ref TileID.Sets.RoomNeeds.CountsAsTable );
            ModTranslation name = CreateMapEntryName( );
            name.AddTranslation( EternalResolve.Chinese , "锻钢砧" );
            name.AddTranslation( EternalResolve.English , "Steel Anvil" );
            AddMapEntry( new Color( 200 , 200 , 200 ) , name );
            base.SetStaticDefaults( );
        }
        public override void NumDust( int i , int j , bool fail , ref int num )
        {
            num = ( fail ? 1 : 3 );
        }
        public override void KillMultiTile( int i , int j , int frameX , int frameY )
        {
            Item.NewItem( i * 16 , j * 16 , 32 , 16 , ModContent.ItemType<SteelAnvil>( ) , 1 , false , 0 , false , false );
        }
    }
}