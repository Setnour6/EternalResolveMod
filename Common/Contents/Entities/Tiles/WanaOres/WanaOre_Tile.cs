using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Entities.Tiles.WanaOres
{
    public class WanaOre_SpawnSystem : ModSystem
    {
        public static bool DownedWallofFlesh = false;

        public override void SaveWorldData( TagCompound tag )
        {
            tag.Add( "DownedWallofFlesh" , DownedWallofFlesh );
            base.SaveWorldData( tag );
        }
        public override void LoadWorldData( TagCompound tag )
        {
            DownedWallofFlesh = tag.GetBool( "DownedWallofFlesh" );
            base.LoadWorldData( tag );
        }
    }
    public class WanaOre_Spawn : GlobalNPC
    {
        public override void OnKill( NPC npc )
        {
            if ( npc.type == NPCID.WallofFlesh && !WanaOre_SpawnSystem.DownedWallofFlesh )
            {
                WanaOre_SpawnSystem.DownedWallofFlesh = true;
                Main.NewText( "大地的一部分力量获得了解放" );
                for ( int k = 0; k < (int) ( Main.maxTilesX * Main.maxTilesY * 0.00005 ); k++ )
                {
                    int x = WorldGen.genRand.Next( 0 , Main.maxTilesX );
                    int y = WorldGen.genRand.Next( (int) WorldGen.worldSurfaceLow , Main.maxTilesY );
                    Tile tile = Framing.GetTileSafely( x , y );
                    if ( tile.IsActive && tile.type == TileID.Stone )
                    {
                        WorldGen.TileRunner( x , y , WorldGen.genRand.Next( 3 , 5 ) , WorldGen.genRand.Next( 2 , 4 ) , ModContent.TileType<WanaOre_Tile>( ) );
                    }
                }
            }
            base.OnKill( npc );
        }
    }
    public class WanaOre_Tile : ModTile
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
            name.AddTranslation( EternalResolve.Chinese , "瓦能矿" );
            name.AddTranslation( EternalResolve.English , "Wana Ore" );
            AddMapEntry( new Color( 152 , 191 , 198 ) , name );
            DustType = 84;
            //	ItemDrop = ModContent.ItemType<>( );
            SoundType = SoundID.Tink;
            SoundStyle = 1;
            MineResist = 1.2f;
            MinPick = 100;
        }
        public override bool CanExplode( int i , int j )
        {
            return false;
        }
        public override bool Drop( int i , int j )
        {
            Item.NewItem( new Vector2( i * 16 , j * 16 ) , ModContent.ItemType<WanaOre>( ) , 1 );
            return true;
        }
    }
}