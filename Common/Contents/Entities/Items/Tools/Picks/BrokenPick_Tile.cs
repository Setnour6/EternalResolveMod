using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EternalResolve.Common.Contents.Entities.Items.Tools.Picks
{
    public class BrokenPick_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            Main.tileSolid[ Type ] = false;
            Main.tileNoAttach[ Type ] = true;
            Main.tileLavaDeath[ Type ] = false;
            Main.tileFrameImportant[ Type ] = true;
            TileObjectData.newTile.CopyFrom( TileObjectData.Style3x2 );
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile( Type );
            ModTranslation name = CreateMapEntryName( );
            name.AddTranslation( EternalResolve.Chinese , "插在地上的稿子" );
            name.AddTranslation( EternalResolve.English , "A pick" );
            DustType = 21;
            AddMapEntry( new Color( 200 , 200 , 200 ) , name );
        }
        public override bool RightClick( int i , int j )
        {
            Item.NewItem(null, i * 16 , j * 16 , 32 , 16 , ModContent.ItemType<BrokenPick>( ) , 1 , false , 0 , false , false );
            WorldGen.KillTile( i , j );
            return true;
        }
    }
}
