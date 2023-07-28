using EternalResolve.Common.Contents.Entities.Items;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Entities.Tiles.Bricks.GuJi
{
    public class GuJiBrick2_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            TileID.Sets.Ore[ Type ] = true;
            Main.tileSpelunker[ Type ] = true;
            Main.tileMergeDirt[ Type ] = true;
            Main.tileSolid[ Type ] = true;
            Main.tileBlockLight[ Type ] = true;
            Main.tileMergeDirt[ Type ] = true;
            for ( int count = 0; count < TextureAssets.Tile.Length; count++ )
            {
                Main.tileMerge[ count ][ Type ] = true;
            }
            ModTranslation name = CreateMapEntryName( );
            name.AddTranslation( EternalResolve.Chinese , "古纪平台砖" );
            name.AddTranslation( EternalResolve.English , "Gu Ji Platform brick" );
            AddMapEntry( new Color( 152 , 191 , 198 ) , name );
            DustType = 84;
            SoundType = SoundID.Tink;
            SoundStyle = 1;
            MineResist = 1.4f;
            MinPick = 180;
        }
        public override bool CanExplode( int i , int j )
        {
            return false;
        }
        public override bool Drop( int i , int j )
        {
            Item.NewItem( new Vector2( i * 16 , j * 16 ) , ModContent.ItemType<GuJiBrick2>( ) , 1 );
            return true;
        }
    }
}