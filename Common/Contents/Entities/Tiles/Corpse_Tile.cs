using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EternalResolve.Common.Contents.Entities.Tiles
{
    internal class Corpse_Tile : ModTile
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
            name.AddTranslation( EternalResolve.Chinese , "尸体" );
            name.AddTranslation( EternalResolve.English , "Corpse" );
            DustType = 21;
            AddMapEntry( new Color( 200 , 200 , 200 ) , name );
        }
        public override bool RightClick( int i , int j )
        {
            Item.NewItem(null, new Vector2( i , j ) * 16 , ModContent.ItemType<Rust>( ) );
            WorldGen.KillTile( i , j );
            return true;
        }
    }
}