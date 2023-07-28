using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.EkandaBricks
{
    public class EkandaBrick_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            TileID.Sets.Ore[ Type ] = true;
            Main.tileSpelunker[ Type ] = true;
            //	Main.tileOreFinderPriority[ Type ] = 810;物块价值
            Main.tileMergeDirt[ Type ] = true;
            Main.tileSolid[ Type ] = true;
            Main.tileBlockLight[ Type ] = true;
            Main.tileMergeDirt[ Type ] = true;
            for ( int count = 0; count < TextureAssets.Tile.Length; count++ )
            {
                Main.tileMerge[ count ][ Type ] = true;
            }
            ModTranslation name = CreateMapEntryName( );
            name.AddTranslation( EternalResolve.Chinese , "埃坎达神殿砖" );
            name.AddTranslation( EternalResolve.English , "Ekanda Brick" );
            AddMapEntry( new Color( 152 , 171 , 198 ) , name );
            DustType = 84;
            //	ItemDrop = ModContent.ItemType<>( );
            HitSound = SoundID.Tink;
            //SoundStyle = 1;
            MineResist = 999f;
            MinPick = 999;
        }
        public override bool CanExplode( int i , int j )
        {
            return false;
        }
    }
}
